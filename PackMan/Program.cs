using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackMan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Controller_MainForm cm;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (args.Length)
            {
                case 0: cm = new Controller_MainForm(); break;
                case 1: cm = new Controller_MainForm(int.Parse(args[0])); break;
                case 2: cm = new Controller_MainForm(int.Parse(args[0]), int.Parse(args[1])); break;
                case 3: cm = new Controller_MainForm(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2])); break;
                default: goto case 0;
            }
            Application.Run(cm);
        }
    }
}
