using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace FIR
{
    class CodeSearchProvider
    {
        private RichTextBox txtText;
        string searchExpression;
        //bool isCaseSensitive;
        MatchCollection contextCodeMatched = null;
        int currentSelected = -1;

        public CodeSearchProvider(
            RichTextBox txtText,
            string searchExpression,
            bool isCaseSensitive,
            bool isRegex)
        {
            this.txtText = txtText;
            if (isRegex)
                //this.searchExpression = "(?s:" + searchExpression + ")";
                this.searchExpression = searchExpression;
            else
                this.searchExpression = Regex.Replace(searchExpression, @"([\(\)\.\*\?\[\}\\\$\^\|\+])", @"\$1");// screening chars ().*?[}\$^|+
            //this.isCaseSensitive = isCaseSensitive;
            RecalculateContextCodeMatched(isCaseSensitive/*, isRegex*/);
        }

        private void RecalculateContextCodeMatched(bool IsCaseSensitive/*, bool IsRegex*/)
        {
            //Regex re = new Regex(searchExpression);
            string text = txtText.Text;
            RegexOptions optionsNonSingleString = new RegexOptions();
            RegexOptions optionsSingleString;
            if (!IsCaseSensitive)
                optionsNonSingleString = RegexOptions.IgnoreCase;
            optionsSingleString = optionsNonSingleString | RegexOptions.Singleline;

            //re.Options = optionsSingleString;
            if (Regex.IsMatch(text,searchExpression,optionsNonSingleString))
                contextCodeMatched = Regex.Matches(text, searchExpression, optionsNonSingleString);
            else
                contextCodeMatched = Regex.Matches(text, searchExpression, optionsSingleString);

/*            if (isCaseSensitive)
                contextCodeMatched = Regex.Matches(txtText.Text, searchExpression);
            else
                contextCodeMatched = Regex.Matches(txtText.Text, searchExpression, RegexOptions.IgnoreCase);*/
        }
        public void SelectNext()
        {
            currentSelected++;
            if (currentSelected >= contextCodeMatched.Count) currentSelected = 0;
            txtText.Select(contextCodeMatched[currentSelected].Index, contextCodeMatched[currentSelected].Value.Length);
            txtText.Focus();
        }
        public void SelectPrevious()
        {
            currentSelected--;
            if (currentSelected < 0) currentSelected = contextCodeMatched.Count - 1;
            txtText.Select(contextCodeMatched[currentSelected].Index, contextCodeMatched[currentSelected].Value.Length);
            txtText.Focus();
        }
        public Founded[] Matches
        {
            get
            {
                Founded[] founds = new Founded[contextCodeMatched.Count];
                for (int i = 0; i < contextCodeMatched.Count; i++)
                    founds[i] = new Founded(contextCodeMatched[i].Index, contextCodeMatched[i].Value.Length);
                return founds;
            }
        }

        public int Matched
        {
            get { return contextCodeMatched == null ? 0 : contextCodeMatched.Count; }
        }
        public int CurrentFounded
        {
            get { return currentSelected; }
        }


    }
    public struct Founded
    {
        public Founded(int Index, int Length)
        {
            index = Index;
            lenght = Length;
        }
        private int index;
        public int Index
        {
            get { return index; }
            //set { index = value; }
        }
        private int lenght;
        public int Length
        {
            get { return lenght; }
            //set { len = value; }
        }


    }
}
