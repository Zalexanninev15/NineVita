using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NineVita_Tool
{

    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
                if (args[0] == "-help")
                {
                    Console.WriteLine("Я знал, что вы введёте эту команду. Интересно, сколько времени это заняло...");
                    Console.WriteLine("И да, вам не нужно было это вводить :)");
                    Console.ReadKey();
                }
                if (args[0] == "-ok")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form10());
                }
            if (args[0] == "-normal")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
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
