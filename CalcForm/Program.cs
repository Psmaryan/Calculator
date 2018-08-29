using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Analaizer;

namespace CalcForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                //Application.Run(new Form1() { expr = args[0] });
                AnalaizerClass.expression = args[0];
                
                Console.WriteLine(AnalaizerClass.Estimate());
            }
            else
                Application.Run(new Form1());
        }
    }
}
