using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NineVita_Tool
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "shell pm list packages";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            richTextBox1.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "shell pm list packages --user 0 -d";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            richTextBox1.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "shell pm list packages --user 0 -e";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            richTextBox1.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
        }
    }
}
