using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ES
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (args[0] == "-success")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form10());
                }
                if (args[0] == "-error")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form11());
                }
            }
        }
    }
}
