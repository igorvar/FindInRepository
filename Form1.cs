using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;
using FIR.Properties;
using System.Configuration;
//using System.Configuration;
namespace FIR
{
    public partial class Form1 : Form
    {
        //MatchCollection _ContextCodeMatched = null;
        //int _ContextCodeMatchedNuber = 0; 
        CodeSearchProvider _csp = null;
        private readonly string SQL_STRING = string.Empty;
        private readonly SqlConnection SQL_CONNECTION = null;
        private RtfCreator _CurrentCode = null;
        //private string _rtfWithoutMatches = string.Empty;
        private void Form1_Load(object sender, EventArgs e)
        {
            RtfCreator.AddColor("Comment", Color.Green);
            RtfCreator.AddColor("Matched", Color.Khaki);

            RtfCreator.AddColor("parentheses1", Color.Brown);
            RtfCreator.AddColor("parentheses2", Color.Blue);
            RtfCreator.AddColor("parentheses3", Color.Violet);
            RtfCreator.AddColor("parentheses4", Color.Orange);
            RtfCreator.AddColor("parentheses5", Color.Red);
            //            ConvertOtherToRtf();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            string[] tmpArr = null;
            Application.DoEvents();
            cmbTypeGroup.Items.Add(new TypeGroup("(All)", null));
            
            for (int i = 0; i < Settings.Default.GroupsOfTypes.Count/*/.Setting.// .Groups.Count*/; i++)
            {
                tmpArr = Regex.Split(Settings.Default.GroupsOfTypes[i].ToString(), @"\s*:\s*");
                if (tmpArr.Length == 2)
                    cmbTypeGroup.Items.Add(new TypeGroup(tmpArr[0], Regex.Split(tmpArr[1], @"\s*,\s*")));
            }
            LoadListType();
            return;
        }
        private void LoadListType()
        {
            string listOfTypes = null;
            int columnWidth = 0;
            string[] tmpArr = null;
            Configuration conf = null;
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = "Settings.Xml";
            conf = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            
            if (int.Parse(conf.AppSettings.Settings["SqlHash"].Value) == SQL_STRING.GetHashCode())
                listOfTypes = conf.AppSettings.Settings["ObjectTypes"].Value;
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = // for non MS SQL DB possible need change 
                    "select distinct SiebelObject from (" + SQL_STRING + ") as t1 order by SiebelObject";
                cmd.Connection = SQL_CONNECTION;
                //if error Connectio timeout (15 sec by default, change timeout of connection: cmd.CommandTimeout = 0;//(0 - infinity timout )
                DataSet ds = new DataSet();
                StringBuilder sb = null;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    da.Fill(ds);
                }
                catch(SqlException ex)
                {
                    int defaultTimeout = cmd.CommandTimeout;
                    cmd.CommandTimeout *= 10;
                    try
                    {
                        da.Fill(ds);
                    }
                    catch(SqlException ex1)
                    {
                        if (DialogResult.Yes ==
                            MessageBox.Show("Error on filling list of types.\n\"" + ex1.Message + "\"\n" +
                                "For ConnectionString " + cmd.Connection.ConnectionString + " default timeout " + defaultTimeout + " seconds.\n" +
                                "Current timeout " + cmd.CommandTimeout + " seconds.\n\nDo you want to try with infinite timeout?", "Error or creation types", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                            )
                        {
                            cmd.CommandTimeout = 0;
                            da.Fill(ds);
                        }
                        else
                        {
                            Application.DoEvents();
                            this.Close();
                            Application.Exit();
                            return;
                        }
                    }
                    cmd.CommandTimeout = defaultTimeout;
                }
                sb = new StringBuilder(ds.Tables[0].Rows.Count);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    sb.AppendFormat((i == 0 ? "" : ",") + "{0}", ds.Tables[0].Rows[i][0].ToString());

                listOfTypes = sb.ToString();
                conf.AppSettings.Settings["SqlHash"].Value = SQL_STRING.GetHashCode().ToString();
                conf.AppSettings.Settings["ObjectTypes"].Value = listOfTypes;
                conf.Save();
            }

            tmpArr = Regex.Split(listOfTypes, ",");
            lstTypes.Items.Clear();
            using (Graphics g = lstTypes.CreateGraphics())
            {
                for (int i = 0; i < tmpArr.Length; i++)
                {
                    lstTypes.Items.Add(tmpArr[i]);
                    columnWidth = Math.Max(columnWidth, (int)(g.MeasureString(tmpArr[i], lstTypes.Font).Width));
                }
            }

            lstTypes.ColumnWidth = columnWidth;
        }
        public Form1()
        {
            
            InitializeComponent();
            SQL_STRING = File.ReadAllText("Select.sql");
            SqlConnectionStringBuilder sqlBuilder = null;//new SqlConnectionStringBuilder();
            //Settings s = new Settings();
            
            //s1=(new Settings());
            //////////////////////////////////
            sqlBuilder = new SqlConnectionStringBuilder(Settings.Default.SiebelDbConnectionString);
            //sqlBuilder = new SqlConnectionStringBuilder(s.SiebelDbConnectionString);
            
            //Settings
            if (!sqlBuilder.IntegratedSecurity && string.IsNullOrEmpty(sqlBuilder.Password))
            {
                frmCredentials frmCred = new frmCredentials(sqlBuilder.UserID, "");
                if (frmCred.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    //this.Close();
                    this.DialogResult = DialogResult.Abort;

                    Application.Exit();
                    return;
                }
                else
                {
                    sqlBuilder.UserID = frmCred.UserName;
                    sqlBuilder.Password = frmCred.Password;
                }
            }
            SQL_CONNECTION = new SqlConnection(sqlBuilder.ToString());

            return;
        }


        private void btnSearchInDB_Click(object sender, EventArgs e)
        {
            try
            {
                rtbCode.Clear();
                _CurrentCode = null;
                DataSet ds = new DataSet();

                //SqlCommand cmd = new SqlCommand(GetSqlExpr(), SQL_CONNECTION);
                SqlCommand cmd = new SqlCommand(GetSqlExpr(), SQL_CONNECTION);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                /*SQL_CONNECTION.Open();
                MessageBox.Show(SQL_CONNECTION.ServerVersion);
                SQL_CONNECTION.Close();*/

                dataGridView.DataSource = ds.Tables[0];
                //txtBxSearch.Text = Regex.Replace(rtbTextSearcSpec.Text, "%", "");
                //
                CalcRegexForSearchInCode();
                //
                //SQL_CONNECTION.ServerVersion
                this.Text = (string)(this.Tag) + " Found " + ds.Tables[0].Rows.Count;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CalcRegexForSearchInCode()
        {
            string codeSearchExpr = string.Empty;
            bool isRegex;
            codeSearchExpr = Regex.Replace(rtbTextSearcSpec.Text, @"^\*|\*$", "");
            codeSearchExpr = Regex.Replace(codeSearchExpr, "''", "'");

            if (isRegex = Regex.IsMatch(codeSearchExpr, "[?*]"))
            {
                codeSearchExpr = Regex.Replace(
                       codeSearchExpr,
                       @"([\(\)\.\[\]\}\\\$\^\|\+])",
                       @"\$1");
                codeSearchExpr = Regex.Replace(codeSearchExpr, @"\?", ".");
                codeSearchExpr = Regex.Replace(codeSearchExpr, @"\*", ".*?");
            }
            chkBoxIsRegex.Checked = false;
            txtBxSearch.Text = codeSearchExpr;
            chkBoxIsRegex.Checked = isRegex;

        }
        void CalcRegexForSearchInCode_bak()
        {
            string codeSearchExpr = string.Empty;
            codeSearchExpr = Regex.Replace(rtbTextSearcSpec.Text, "^%|%$", "");
            if (Regex.IsMatch(codeSearchExpr, "''|[_%]"))
            {
                //codeSearchExpr = Regex.Replace(codeSearchExpr, @"\[_\]", "_");
                //codeSearchExpr = Regex.Replace(codeSearchExpr, @"\[%\]", "%");
                codeSearchExpr = Regex.Replace(
                    codeSearchExpr,
                    @"([\(\)\.\*\?\[\]\}\\\$\^\|\+])",
                    @"\$1");
                codeSearchExpr = Regex.Replace(codeSearchExpr, "''", "'");
                codeSearchExpr = Regex.Replace(codeSearchExpr, "_", ".");
                codeSearchExpr = Regex.Replace(codeSearchExpr, "%", ".*?");
                chkBoxIsRegex.Checked = true;
            }
            else
                chkBoxIsRegex.Checked = false;
            txtBxSearch.Text = codeSearchExpr;
        }
        private string GetSqlExpr2()
        {
            string OneChar = "_"; string OneCharSymb = "[_]";
            string AnyChars = "%"; string AnyCharSymb = "[%]";
            string like = rtbTextSearcSpec.Text;

            string whereExp = "\nwhere ";
            List<string> wheres = new List<string>();
            string sqlString = SQL_STRING;
            StringBuilder sb = new StringBuilder();
            if (lstTypes.CheckedItems.Count == 0) throw new Exception("No types selected");
            if (string.IsNullOrEmpty(rtbTextSearcSpec.Text)) throw new Exception("No search expression for text");
            if (lstTypes.CheckedItems.Count != lstTypes.Items.Count)
            {
                for (int i = 0; i < lstTypes.CheckedItems.Count; i++)
                    sb.AppendFormat((i == 0 ? " " : ", ") + "'{0}'", lstTypes.CheckedItems[i].ToString());
                wheres.Add("\tSiebelObject in (" + sb.ToString() + ")");
            }
            if (string.IsNullOrEmpty(like)) throw new Exception("No search expression for text");
            like = like.Replace(AnyChars, AnyCharSymb).Replace(OneChar, OneCharSymb);
            like = like.Replace("?", OneChar).Replace("*", AnyChars);

            if (chkBoxCaseSensitive.Checked)
                wheres.Add("Text like '" + like + "'");
            else
                wheres.Add("lower(Text) like lower('" + like + "')");
            if (wheres.Count != 0)
            {
                for (int i = 0; i < wheres.Count; i++)
                    whereExp += "\n\t" + (i == 0 ? "" : "and ") + wheres[i];
                sqlString = "select * from (\n" + sqlString + ") tTable" + whereExp;
            }

            return sqlString;


        }
        /// <summary>
        /// function designed for creation SQL expression for MS SQL. for other Db possible need other function
        /// </summary>
        /// <returns></returns>
        private string GetSqlExpr()
        {
            string whereExp = "\nwhere";
            string sqlString = string.Empty;
            string likeExp = rtbTextSearcSpec.Text;
            List<string> wheresItems = new List<string>();
            StringBuilder sb = new StringBuilder(lstTypes.CheckedItems.Count);
            if (lstTypes.CheckedItems.Count == 0) throw new Exception("No types selected");
            if (string.IsNullOrEmpty(likeExp)) throw new Exception("No search expression for text");
            if (lstTypes.CheckedItems.Count != lstTypes.Items.Count)
            {
                for (int i = 0; i < lstTypes.CheckedItems.Count; i++)
                    sb.AppendFormat((i == 0 ? " " : ", ") + "'{0}'", lstTypes.CheckedItems[i].ToString());
                wheresItems.Add("\tSiebelObject in (" + sb.ToString() + ")");
            }


            likeExp = Regex.Replace(likeExp, "'", "''"); // instead ' using '' - search symbol ' in DB
            likeExp = Regex.Replace(likeExp, @"\[", @"[[]");// instead [ using [[] -  search symbol [ in DB
            likeExp = Regex.Replace(likeExp, "_", "[_]"); // instead _ using [_] - search symbol _ in DB
            likeExp = Regex.Replace(likeExp, @"\?", "_"); // instead ? using _ - any symbol in DB
            likeExp = Regex.Replace(likeExp, "%", "[%]"); // instead % using [%] - search symbol % in DB
            likeExp = Regex.Replace(likeExp, @"\*", "%"); // instead * using % - any rows in DB
            if (chkBoxCaseSensitive.Checked)
                wheresItems.Add("Text like '" + likeExp + "'");
            else
                wheresItems.Add("lower(Text) like lower('" + likeExp + "')");

            for (int i = 0; i < wheresItems.Count; i++)
                whereExp += "\n\t" + (i == 0 ? "" : "and ") + wheresItems[i];
            sqlString = "select * from (\n" + SQL_STRING + ") tTable" + whereExp;
            return sqlString;
        }
        private string GetSqlExpr_bak()
        {
            string sqlString = SQL_STRING;//File.ReadAllText("Select.sql");
            string whereExp = "\nwhere ";
            List<string> wheres = new List<string>();
            StringBuilder sb = new StringBuilder();

            if (lstTypes.CheckedItems.Count == 0) throw new Exception("No types selected");
            if (lstTypes.CheckedItems.Count != lstTypes.Items.Count)
            {
                for (int i = 0; i < lstTypes.CheckedItems.Count; i++)
                    sb.AppendFormat((i == 0 ? " " : ", ") + "'{0}'", lstTypes.CheckedItems[i].ToString());
                wheres.Add("\tSiebelObject in (" + sb.ToString() + ")");
            }

            if (string.IsNullOrEmpty(rtbTextSearcSpec.Text)) throw new Exception("No search expression for text");
            if (chkBoxCaseSensitive.Checked)
                wheres.Add("Text like '" + rtbTextSearcSpec.Text + "'");
            else
                wheres.Add("lower(Text) like lower('" + rtbTextSearcSpec.Text + "')");


            if (wheres.Count != 0)
            {
                for (int i = 0; i < wheres.Count; i++)
                    whereExp += "\n\t" + (i == 0 ? "" : "and ") + wheres[i];
                sqlString = "select * from (\n" + sqlString + ") tTable" + whereExp;
            }

            return sqlString;
        }
        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView.CurrentRow == null)
            //{
            //    rtbCode.Clear();
            //    return;
            //}
            _CurrentCode = new RtfCreator(dataGridView.Rows[e.RowIndex].Cells["Text"].Value.ToString());
            rtbCode.Clear();

            switch (dataGridView.Rows[e.RowIndex].Cells["Language"].Value.ToString())
            {
                case "JS":
                    ConvertJsToRtf();
                    break;
                case "SBL":
                    ConvertBasicToRtf();
                    break;
                default:
                    //rtbCode.Text = dataGridView.CurrentRow.Cells["Text"].Value.ToString();
                    //rtbCode.Rtf = _CurrentCode.Rtf;
                    ConvertOtherToRtf();
                    break;

            }

            //_rtfWithoutMatches = _CurrentCode.Rtf;
            //rtbCode.Rtf = _rtfWithoutMatches;
            rtbCode.Rtf = _CurrentCode.Rtf;
            ConditionsSearchChanged();
        }

        void ConvertJsToRtf()
        {
            MatchCollection mcComments = null;
            MatchCollection mcStrings = null;
            bool isRealComment = true;
            mcComments = Regex.Matches(_CurrentCode.Text, @"//.*?\n|(?s:/\*.*?\*/)");
            mcStrings = Regex.Matches(_CurrentCode.Text, @"'(?>\\'|.)*?'|\u0022(?>\\\u0022|.)*?\u0022"); // \u0022  symbol "

            for (int c = 0; c < mcComments.Count; c++)
            {
                isRealComment = true;
                for (int s = 0; s < mcStrings.Count && isRealComment == true; s++)
                {
                    if (mcComments[c].Index > mcStrings[s].Index && mcComments[c].Index < mcStrings[s].Index + mcStrings[s].Length)
                        isRealComment = false;
                }
                if (isRealComment)
                    _CurrentCode.MarkText(RtfCreator.MarkType.ForeColor, "Comment", mcComments[c].Index, mcComments[c].Value.Length);
            }
        }
        void ConvertBasicToRtf()
        {
            MatchCollection comments = Regex.Matches(_CurrentCode.Text, @"'.*");
            MatchCollection strings = Regex.Matches(_CurrentCode.Text, "\"(.*?)\"");
            bool isRealComment = true;
            for (int i = 0; i < comments.Count; i++)
            {
                isRealComment = true;
                for (int j = 0; j < strings.Count && isRealComment == true; j++)
                {
                    if (comments[i].Index > strings[j].Index && comments[i].Index < strings[j].Index + strings[j].Value.Length)
                        isRealComment = false;
                }
                if (isRealComment)
                    _CurrentCode.MarkText(RtfCreator.MarkType.ForeColor, "Comment", comments[i].Index, comments[i].Value.Length);
            }
        }

        void ConvertOtherToRtf()
        {

            //_CurrentCode = new RtfCreator("((s)((((d))))+(ddddd))");
            StringBuilder str = new StringBuilder(_CurrentCode.Text);
            //Regex re = new Regex(@"\([^\(\)]*?\)");
            Regex re = new Regex(@"(?<OPEN>\()[^()]*?(?<CLOSE>\))");
            MatchCollection mc = null;
            int level = 0;
            int opnPos;
            int clsPos;
            do
            {
                level++;
                if (level > 5) level = 1;

                //mc = Regex.Matches(str.ToString(), @"\([^\(\)]*?\)");
                mc = re.Matches(str.ToString());
                for (int i = 0; i < mc.Count; i++)
                {
                    opnPos = mc[i].Groups["OPEN"].Index;
                    clsPos = mc[i].Groups["CLOSE"].Index;
                    _CurrentCode.MarkText(RtfCreator.MarkType.ForeColor, string.Format("parentheses{0}", level), opnPos, 1);
                    _CurrentCode.MarkText(RtfCreator.MarkType.ForeColor, string.Format("parentheses{0}", level), clsPos, 1);

                    str.Remove(opnPos, 1); str.Insert(opnPos, '~');
                    str.Remove(clsPos, 1); str.Insert(clsPos, '~');
                }

            } while (mc.Count > 0);
            //MatchCollection mc = Regex.Matches(str, @"\([^\(\)]+?\)");

        }


        private void btnInvertTypesSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTypes.Items.Count; i++)
                lstTypes.SetItemChecked(i, !lstTypes.GetItemChecked(i));
        }


        private void txtBxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ConditionsSearchChanged();
                errorProvider1.SetError(chkBoxIsRegex, "");
            }
            catch (ArgumentException ex)
            {
                if (chkBoxIsRegex.Checked)
                    //MessageBox.Show("Error in regular expression.\nIf no finished typing it, try uncheck flag Regex.","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    errorProvider1.SetError(chkBoxIsRegex, "Error in regular expression.\nIf no finished typing it, try uncheck flag Regex.");
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                throw;
            }

        }
        private void chkBoxCaseSensitiveCode_CheckedChanged(object sender, EventArgs e)
        {
            ConditionsSearchChanged();
        }
        private void chkBoxIsRegex_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(txtBxSearch, "");
                ConditionsSearchChanged();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void ConditionsSearchChanged()
        {
            _csp = new CodeSearchProvider(rtbCode, txtBxSearch.Text, chkBoxCaseSensitiveCode.Checked, chkBoxIsRegex.Checked);
            if (_CurrentCode != null)
                _CurrentCode.UnMarkAll(RtfCreator.MarkType.BackGround);

            btnSearchPrev.Enabled = btnSearchNext.Enabled = _csp.Matched != 0;
            txtMatchesCode.Text = string.Format("Match: {0}", _csp.Matched.ToString());
            if (_CurrentCode != null)
            {
                for (int i = 0; i < _csp.Matched; i++)
                    _CurrentCode.MarkText(RtfCreator.MarkType.BackGround, "Matched", _csp.Matches[i].Index, _csp.Matches[i].Length);

                rtbCode.Clear();
                rtbCode.Rtf = _CurrentCode.Rtf;
            }
        }



        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            _csp.SelectNext();
        }

        private void btnSearchPrev_Click(object sender, EventArgs e)
        {
            _csp.SelectPrevious();
        }

        private void chkBoxCodeWrap_CheckedChanged(object sender, EventArgs e)
        {
            rtbCode.WordWrap = chkBoxCodeWrap.Checked;
        }


        private void cmbTypeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeGroup.SelectedItem.ToString() == "(All)")
            {
                for (int i = 0; i < lstTypes.Items.Count; i++) lstTypes.SetItemChecked(i, true);
                return;
            }
            for (int i = 0; i < lstTypes.Items.Count; i++) lstTypes.SetItemChecked(i, false);
            string[] types = ((TypeGroup)(cmbTypeGroup.SelectedItem)).Types;
            for (int i = 0; i < types.Length; i++)
                for (int j = 0; j < lstTypes.Items.Count; j++)
                    if (lstTypes.Items[j].ToString() == types[i])
                    {
                        lstTypes.SetItemChecked(j, true);
                        break;
                    }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (dataGridView.Rows.Count == 0) 
            //        rtbCode.Clear();
        }

    }
    /// <summary>
    /// Elements of cmbTypeGroup
    /// </summary>
    struct TypeGroup
    {
        private string name;
        private string[] types;

        public string[] Types { get { return types; } }
        public TypeGroup(string name, string[] types)
        {
            this.types = types;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}