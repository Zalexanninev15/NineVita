using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
namespace NineVita
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process pr = RI(); if (pr != null) { MessageBox.Show("Можно запустить только 1 копию программы!", "Инфомация", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { Application.Run(new MainForm()); }
        }
        public static Process RI() 
        { 
            Process current = Process.GetCurrentProcess(); 
            Process[] pr = Process.GetProcessesByName(current.ProcessName); 
            foreach (Process i in pr) 
            { if (i.Id != current.Id) { if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName) { return i; } } } 
            return null; 
        }
    }
}