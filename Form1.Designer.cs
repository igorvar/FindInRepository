namespace FIR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSearchInDB = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cmbTypeGroup = new System.Windows.Forms.ComboBox();
            this.lstTypes = new System.Windows.Forms.CheckedListBox();
            this.btnInvertTypesSelection = new System.Windows.Forms.Button();
            this.chkBoxCaseSensitive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbTextSearcSpec = new System.Windows.Forms.RichTextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.chkBoxIsRegex = new System.Windows.Forms.CheckBox();
            this.chkBoxCodeWrap = new System.Windows.Forms.CheckBox();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.btnSearchPrev = new System.Windows.Forms.Button();
            this.chkBoxCaseSensitiveCode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatchesCode = new System.Windows.Forms.TextBox();
            this.txtBxSearch = new System.Windows.Forms.TextBox();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchInDB
            // 
            this.btnSearchInDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchInDB.BackgroundImage")));
            this.btnSearchInDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchInDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearchInDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearchInDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchInDB.Location = new System.Drawing.Point(198, 1);
            this.btnSearchInDB.Name = "btnSearchInDB";
            this.btnSearchInDB.Size = new System.Drawing.Size(52, 23);
            this.btnSearchInDB.TabIndex = 0;
            this.btnSearchInDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchInDB.UseVisualStyleBackColor = true;
            this.btnSearchInDB.Click += new System.EventHandler(this.btnSearchInDB_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkBoxIsRegex);
            this.splitContainer1.Panel2.Controls.Add(this.chkBoxCodeWrap);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearchNext);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearchPrev);
            this.splitContainer1.Panel2.Controls.Add(this.chkBoxCaseSensitiveCode);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtMatchesCode);
            this.splitContainer1.Panel2.Controls.Add(this.txtBxSearch);
            this.splitContainer1.Panel2.Controls.Add(this.rtbCode);
            this.splitContainer1.Size = new System.Drawing.Size(874, 531);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(874, 264);
            this.splitContainer2.SplitterDistance = 264;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cmbTypeGroup);
            this.splitContainer3.Panel1.Controls.Add(this.lstTypes);
            this.splitContainer3.Panel1.Controls.Add(this.btnInvertTypesSelection);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chkBoxCaseSensitive);
            this.splitContainer3.Panel2.Controls.Add(this.btnSearchInDB);
            this.splitContainer3.Panel2.Controls.Add(this.label1);
            this.splitContainer3.Panel2.Controls.Add(this.rtbTextSearcSpec);
            this.splitContainer3.Size = new System.Drawing.Size(264, 264);
            this.splitContainer3.SplitterDistance = 197;
            this.splitContainer3.TabIndex = 4;
            // 
            // cmbTypeGroup
            // 
            this.cmbTypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeGroup.FormattingEnabled = true;
            this.cmbTypeGroup.Location = new System.Drawing.Point(6, 3);
            this.cmbTypeGroup.Name = "cmbTypeGroup";
            this.cmbTypeGroup.Size = new System.Drawing.Size(222, 21);
            this.cmbTypeGroup.TabIndex = 4;
            this.cmbTypeGroup.SelectedIndexChanged += new System.EventHandler(this.cmbTypeGroup_SelectedIndexChanged);
            // 
            // lstTypes
            // 
            this.lstTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTypes.CheckOnClick = true;
            this.lstTypes.FormattingEnabled = true;
            this.lstTypes.Items.AddRange(new object[] {
            "Reading types..."});
            this.lstTypes.Location = new System.Drawing.Point(0, 27);
            this.lstTypes.MultiColumn = true;
            this.lstTypes.Name = "lstTypes";
            this.lstTypes.Size = new System.Drawing.Size(264, 169);
            this.lstTypes.TabIndex = 1;
            // 
            // btnInvertTypesSelection
            // 
            this.btnInvertTypesSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvertTypesSelection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInvertTypesSelection.BackgroundImage")));
            this.btnInvertTypesSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInvertTypesSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 3F);
            this.btnInvertTypesSelection.Location = new System.Drawing.Point(234, 3);
            this.btnInvertTypesSelection.Name = "btnInvertTypesSelection";
            this.btnInvertTypesSelection.Size = new System.Drawing.Size(27, 23);
            this.btnInvertTypesSelection.TabIndex = 3;
            this.btnInvertTypesSelection.Text = "vif";
            this.btnInvertTypesSelection.UseVisualStyleBackColor = true;
            this.btnInvertTypesSelection.Click += new System.EventHandler(this.btnInvertTypesSelection_Click);
            // 
            // chkBoxCaseSensitive
            // 
            this.chkBoxCaseSensitive.AutoSize = true;
            this.chkBoxCaseSensitive.Location = new System.Drawing.Point(96, 7);
            this.chkBoxCaseSensitive.Name = "chkBoxCaseSensitive";
            this.chkBoxCaseSensitive.Size = new System.Drawing.Size(96, 17);
            this.chkBoxCaseSensitive.TabIndex = 2;
            this.chkBoxCaseSensitive.Text = "Case Sensitive";
            this.chkBoxCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text search expr:";
            // 
            // rtbTextSearcSpec
            // 
            this.rtbTextSearcSpec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbTextSearcSpec.DetectUrls = false;
            this.rtbTextSearcSpec.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rtbTextSearcSpec.Location = new System.Drawing.Point(0, 27);
            this.rtbTextSearcSpec.Name = "rtbTextSearcSpec";
            this.rtbTextSearcSpec.Size = new System.Drawing.Size(265, 33);
            this.rtbTextSearcSpec.TabIndex = 0;
            this.rtbTextSearcSpec.Text = "**";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 19;
            this.dataGridView.Size = new System.Drawing.Size(606, 264);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowEnter);
            // 
            // chkBoxIsRegex
            // 
            this.chkBoxIsRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxIsRegex.AutoSize = true;
            this.chkBoxIsRegex.Location = new System.Drawing.Point(734, 4);
            this.chkBoxIsRegex.Name = "chkBoxIsRegex";
            this.chkBoxIsRegex.Size = new System.Drawing.Size(57, 17);
            this.chkBoxIsRegex.TabIndex = 7;
            this.chkBoxIsRegex.Text = "Regex";
            this.chkBoxIsRegex.UseVisualStyleBackColor = true;
            this.chkBoxIsRegex.CheckedChanged += new System.EventHandler(this.chkBoxIsRegex_CheckedChanged);
            // 
            // chkBoxCodeWrap
            // 
            this.chkBoxCodeWrap.Location = new System.Drawing.Point(8, 3);
            this.chkBoxCodeWrap.Name = "chkBoxCodeWrap";
            this.chkBoxCodeWrap.Size = new System.Drawing.Size(52, 20);
            this.chkBoxCodeWrap.TabIndex = 6;
            this.chkBoxCodeWrap.Text = "Wrap";
            this.chkBoxCodeWrap.UseVisualStyleBackColor = true;
            this.chkBoxCodeWrap.CheckedChanged += new System.EventHandler(this.chkBoxCodeWrap_CheckedChanged);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchNext.Font = new System.Drawing.Font("Arial", 7F);
            this.btnSearchNext.Location = new System.Drawing.Point(610, 2);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(20, 20);
            this.btnSearchNext.TabIndex = 5;
            this.btnSearchNext.Text = "►";
            this.btnSearchNext.UseVisualStyleBackColor = true;
            this.btnSearchNext.Click += new System.EventHandler(this.btnSearchNext_Click);
            // 
            // btnSearchPrev
            // 
            this.btnSearchPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchPrev.Font = new System.Drawing.Font("Arial", 7F);
            this.btnSearchPrev.Location = new System.Drawing.Point(590, 2);
            this.btnSearchPrev.Name = "btnSearchPrev";
            this.btnSearchPrev.Size = new System.Drawing.Size(20, 20);
            this.btnSearchPrev.TabIndex = 5;
            this.btnSearchPrev.Text = "◄";
            this.btnSearchPrev.UseVisualStyleBackColor = true;
            this.btnSearchPrev.Click += new System.EventHandler(this.btnSearchPrev_Click);
            // 
            // chkBoxCaseSensitiveCode
            // 
            this.chkBoxCaseSensitiveCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxCaseSensitiveCode.Location = new System.Drawing.Point(635, 2);
            this.chkBoxCaseSensitiveCode.Name = "chkBoxCaseSensitiveCode";
            this.chkBoxCaseSensitiveCode.Size = new System.Drawing.Size(96, 20);
            this.chkBoxCaseSensitiveCode.TabIndex = 3;
            this.chkBoxCaseSensitiveCode.Text = "Case Sensitive";
            this.chkBoxCaseSensitiveCode.UseVisualStyleBackColor = true;
            this.chkBoxCaseSensitiveCode.CheckedChanged += new System.EventHandler(this.chkBoxCaseSensitiveCode_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(198, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Find:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMatchesCode
            // 
            this.txtMatchesCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatchesCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatchesCode.Location = new System.Drawing.Point(797, 5);
            this.txtMatchesCode.Multiline = true;
            this.txtMatchesCode.Name = "txtMatchesCode";
            this.txtMatchesCode.ReadOnly = true;
            this.txtMatchesCode.Size = new System.Drawing.Size(74, 20);
            this.txtMatchesCode.TabIndex = 1;
            this.txtMatchesCode.TabStop = false;
            this.txtMatchesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMatchesCode.TextChanged += new System.EventHandler(this.txtBxSearch_TextChanged);
            // 
            // txtBxSearch
            // 
            this.txtBxSearch.AllowDrop = true;
            this.txtBxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxSearch.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtBxSearch.Location = new System.Drawing.Point(234, 2);
            this.txtBxSearch.Name = "txtBxSearch";
            this.txtBxSearch.Size = new System.Drawing.Size(353, 20);
            this.txtBxSearch.TabIndex = 1;
            this.txtBxSearch.TextChanged += new System.EventHandler(this.txtBxSearch_TextChanged);
            // 
            // rtbCode
            // 
            this.rtbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCode.BackColor = System.Drawing.SystemColors.Window;
            this.rtbCode.DetectUrls = false;
            this.rtbCode.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCode.HideSelection = false;
            this.rtbCode.Location = new System.Drawing.Point(0, 26);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.ReadOnly = true;
            this.rtbCode.Size = new System.Drawing.Size(871, 234);
            this.rtbCode.TabIndex = 0;
            this.rtbCode.Text = "";
            this.rtbCode.WordWrap = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 531);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Tag = "FIR.";
            this.Text = "FIR";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchInDB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckedListBox lstTypes;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnInvertTypesSelection;
        private System.Windows.Forms.CheckBox chkBoxCaseSensitive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbTextSearcSpec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxSearch;
        private System.Windows.Forms.CheckBox chkBoxCaseSensitiveCode;
        private System.Windows.Forms.Button btnSearchNext;
        private System.Windows.Forms.Button btnSearchPrev;
        private System.Windows.Forms.CheckBox chkBoxCodeWrap;
        private System.Windows.Forms.ComboBox cmbTypeGroup;
        private System.Windows.Forms.TextBox txtMatchesCode;
        private System.Windows.Forms.CheckBox chkBoxIsRegex;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

