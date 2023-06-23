using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace NineVita
{
    public partial class AppsForm : Form
    {
        public AppsForm() { InitializeComponent(); this.Size = new System.Drawing.Size(474, 613); }
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
            StreamReader srIncoming = myProcess.StandardOutput; 
            richTextBox1.Text = srIncoming.ReadToEnd();
            string name = "adb";
            Process[] etc = Process.GetProcesses();
            foreach (Process anti in etc) { if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill(); }
            MessageBox.Show("Выполнено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            StreamReader srIncoming = myProcess.StandardOutput;
            richTextBox1.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            Process[] etc = Process.GetProcesses();
            foreach (Process anti in etc) { if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill(); }
            MessageBox.Show("Выполнено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            StreamReader srIncoming = myProcess.StandardOutput;
            richTextBox1.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            Process[] etc = Process.GetProcesses();
            foreach (Process anti in etc) { if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill(); }
            MessageBox.Show("Выполнено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}