using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FIR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form f = new Form1();
            if (f.DialogResult == DialogResult.Abort)
                return;
            Application.Run(f);
        }
    }
}