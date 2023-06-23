using MetroFramework.Forms;
using SharpConfig;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace NineVita_Tool
{
    public partial class MainForm : MetroForm
    {
        Form f;
        string[] exe;
        string[] scripts;
        string[] portal;
        string[] apps;
        string[] frimwares;
        string dfu1, works, other, flasher, app, def1, mbnfile, backups, port;
        public MainForm()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(3500);
            InitializeComponent();
            t.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "reboot edl";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            myProcess.WaitForExit();
            Thread.Sleep(9000);
            StreamReader srIncoming = myProcess.StandardOutput; 
            textBox15.Text = srIncoming.ReadToEnd(); 
            if ((textBox15.Text == "") || (textBox15.Text == " ")) { textBox15.Text = "Операция завершена"; }
            if ((textBox15.Text == "") || (textBox15.Text == " ")) { textBox15.Text = "Ошибка"; }
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "devices";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; 
            textBox10.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            if (((app != "") || (app != " ")) && (!metroCheckBox13.Checked == true))
            {
                app = textBox11.Text;
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "shell pm uninstall -k --user 0 " + app;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.Start();
                StreamReader srIncomings = myProcess.StandardOutput; 
                textBox12.Text = srIncomings.ReadToEnd(); 
                string name = "adb";
                System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process anti in etc)
                    if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
            }
            if (metroCheckBox13.Checked == true)
            {
                int i = 0;
                for (; i < 14;)
                {
                    Process myssProcess = new Process();
                    myssProcess.StartInfo.FileName = "cmd.exe";
                    myssProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "shell pm uninstall -k --user 0 " + apps[i];
                    myssProcess.StartInfo.CreateNoWindow = true;
                    myssProcess.StartInfo.UseShellExecute = false;
                    myssProcess.StartInfo.RedirectStandardOutput = true;
                    myssProcess.Start();
                    StreamReader srIncoming = myssProcess.StandardOutput; 
                    textBox12.Text = srIncoming.ReadToEnd(); 
                    i = i + 1;
                }
                string name = "adb";
                System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process anti in etc)
                    if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Text == "Введите имя пакета (узнайте через приложение App Inspector)")
            {
                textBox11.Clear();
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if ((textBox8.Text == "") || (textBox8.Text == " "))
            {
                textBox7.Text = "РАЗДЕЛ НЕ ВВЕДЁН";
                textBox7.ForeColor = Color.Red;
                metroToggle7.Checked = false;
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Text == "Введите имя файла для установки (с расширением) (через кнопку 'Папка')")
            {
                textBox14.Clear();
                textBox14.ForeColor = Color.Black;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            if (metroCheckBox9.Checked)
            {
                def1 = "-s";
            }
            else
            {
                def1 = "-d";
            }
            app = textBox14.Text;
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "install" + " " + def1 + " " + Application.StartupPath + "\\adb\\installapk\\" + app;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; 
            textBox13.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\adb\\installapk");
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle2.Checked)
            {
                if (!metroCheckBox2.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел userdata!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle2.Checked = false;
                }
            }
        }

        private void metroCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox13.Checked == true)
            {
                frimwares = new string[11];
                apps = new string[14];
                apps[0] = "com.facebook.katana";
                apps[1] = "com.facebook.system";
                apps[2] = "com.facebook.appmanager";
                apps[3] = "com.facebook.service";
                apps[4] = "com.google.android.onetimeinitializer";
                apps[5] = "com.google.android.music";
                apps[6] = "com.google.android.videos";
                apps[7] = "com.google.android.apps.photos";
                apps[8] = "com.google.android.keep";
                apps[9] = "com.google.android.marvin.talkback";
                apps[10] = "com.google.android.youtube";
                apps[11] = "com.google.android.apps.docs";
                apps[12] = "com.google.android.apps.maps";
                apps[13] = "com.google.android.tts";
                textBox11.Enabled = false;
            }
            if (!metroCheckBox13.Checked == true)
            {
                textBox11.Enabled = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "reboot recovery";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; 
            textBox10.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "get-state";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; 
            textBox10.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "reboot bootloader";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput; 
            textBox10.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            f = new AppsForm();
            f.Show();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                metroToggle1.Checked = true;
            }
            if (!metroCheckBox1.Checked)
            {
                textBox1.ReadOnly = true;
                textBox1.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle1.Checked = false;
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                textBox2.ReadOnly = false;
                textBox2.Text = "";
                metroToggle2.Checked = true;
            }
            if (!metroCheckBox2.Checked)
            {
                textBox2.ReadOnly = true;
                textBox2.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle2.Checked = false;
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
            {
                textBox3.ReadOnly = false;
                textBox3.Text = "";
                metroToggle3.Checked = true;
            }
            if (!metroCheckBox3.Checked)
            {
                textBox3.ReadOnly = true;
                textBox3.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle3.Checked = false;
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)
            {
                textBox4.ReadOnly = false;
                textBox4.Text = "";
                metroToggle4.Checked = true;
            }
            if (!metroCheckBox4.Checked)
            {
                textBox4.ReadOnly = true;
                textBox4.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle4.Checked = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            f = new PartitionsForm();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", backups);
        }

        private void metroToggle6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle6.Checked)
            {
                if (!metroCheckBox6.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел vendor!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle6.Checked = false;
                }
            }
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked)
            {
                textBox6.ReadOnly = false;
                textBox6.Text = "";
                metroToggle6.Checked = true;
            }
            if (!metroCheckBox6.Checked)
            {
                textBox6.ReadOnly = true;
                textBox6.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle6.Checked = false;
            }
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked)
            {
                textBox9.ReadOnly = false;
                textBox9.Text = "";
                metroToggle8.Checked = true;
            }
            if (!metroCheckBox8.Checked)
            {
                textBox9.ReadOnly = true;
                textBox9.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle8.Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((!metroCheckBox1.Checked == true) && (!metroCheckBox3.Checked == true) && (!metroCheckBox4.Checked == true) && (!metroCheckBox5.Checked == true) && (!metroCheckBox6.Checked == true) && (!metroCheckBox8.Checked == true) && (!metroCheckBox2.Checked == true) && ((textBox8.Text == "") || (textBox8.Text == " ")) && (!metroCheckBox7.Checked == true))
            {
                MessageBox.Show(
               "Выберете хотя бы одно действие!",
                "Ошибка!",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.RightAlign);
            }
            else
            {
                works = textBox19.Text;
                if (works.Length == 0)
                {
                    MessageBox.Show(
                    "Номер COM порта не найден!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
                else
                {
                    //=============================Бекап разделов=============================

                    //system
                    if ((metroCheckBox1.Checked) && (metroToggle1.Checked == true))
                    {
                        Process myProcess_sys_backup = new Process();
                        myProcess_sys_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_sys_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "system" + " " + backups + "\\" + "system";
                        myProcess_sys_backup.Start();
                        myProcess_sys_backup.WaitForExit();
                    }

                    //recovery
                    if ((metroCheckBox3.Checked) && (metroToggle3.Checked == true))
                    {
                        Process myProcess_recovery_backup = new Process();
                        myProcess_recovery_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_recovery_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "recovery" + " " + backups + "\\" + "recovery";
                        myProcess_recovery_backup.Start();
                        myProcess_recovery_backup.WaitForExit();
                    }

                    //boot
                    if ((metroCheckBox4.Checked) && (metroToggle4.Checked == true))
                    {
                        Process myProcess_boot_backup = new Process();
                        myProcess_boot_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_boot_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "boot" + " " + backups + "\\" + "boot";
                        myProcess_boot_backup.Start();
                        myProcess_boot_backup.WaitForExit();
                    }

                    //aboot
                    if ((metroCheckBox5.Checked) && (metroToggle5.Checked == true))
                    {
                        Process myProcess_aboot_backup = new Process();
                        myProcess_aboot_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_aboot_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "aboot" + " " + backups + "\\" + "aboot";
                        myProcess_aboot_backup.Start();
                        myProcess_aboot_backup.WaitForExit();
                    }

                    //vendor
                    if ((metroCheckBox6.Checked) && (metroToggle6.Checked == true))
                    {
                        Process myProcess_vendor_backup = new Process();
                        myProcess_vendor_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_vendor_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "vendor" + " " + backups + "\\" + "vendor";
                        myProcess_vendor_backup.Start();
                        myProcess_vendor_backup.WaitForExit();
                    }

                    //modem
                    if ((metroCheckBox8.Checked) && (metroToggle8.Checked == true))
                    {
                        Process myProcess_modem_backup = new Process();
                        myProcess_modem_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_modem_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "modem" + " " + backups + "\\" + "modem";
                        myProcess_modem_backup.Start();
                        myProcess_modem_backup.WaitForExit();
                    }

                    //other
                    if ((metroToggle7.Checked == true) && (textBox8.Text != "") || (textBox8.Text != " "))
                    {
                        other = textBox8.Text;
                        Process myProcess_other_backup = new Process();
                        myProcess_other_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_other_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + other + " " + backups + "\\" + other;
                        myProcess_other_backup.Start();
                        myProcess_other_backup.WaitForExit();
                    }

                    //ALL
                    if (metroCheckBox7.Checked)
                    {
                        Process myProcess_All_backup = new Process();
                        myProcess_All_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_All_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & allbackup.bat " + works + " " + mbnfile + " " + backups + "\\";
                        myProcess_All_backup.Start();
                        myProcess_All_backup.WaitForExit();
                    }

                    //userdata
                    if ((metroCheckBox2.Checked) && (metroToggle2.Checked == true))
                    {
                        Process myProcess_userdata_backup = new Process();
                        myProcess_userdata_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_userdata_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "userdata" + " " + backups + "\\" + "userdata";
                        myProcess_userdata_backup.Start();
                        myProcess_userdata_backup.WaitForExit();
                    }
                    //=============================Прошивка разделов=============================
                    if ((metroCheckBox2.Checked) && (metroCheckBox12.Checked) && ((textBox2.Text == " ") || (textBox2.Text == "")))
                    {
                        Process myProcess_cleaner_flash = new Process();
                        myProcess_cleaner_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_cleaner_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flashoffline.bat " + works + " " + mbnfile + " " + "userdata" + " " + "cleaner";
                        myProcess_cleaner_flash.Start();
                        myProcess_cleaner_flash.WaitForExit();
                    }
                    //system
                    flasher = textBox1.Text;
                    if ((metroCheckBox1.Checked) && ((textBox1.Text != " ") || (textBox1.Text != "")))
                    {
                        Process myProcess_sys_flash = new Process();
                        myProcess_sys_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_sys_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "system" + " " + flasher;
                        myProcess_sys_flash.Start();
                        myProcess_sys_flash.WaitForExit();
                    }

                    //recovery
                    flasher = textBox3.Text;
                    if ((metroCheckBox3.Checked) && ((textBox3.Text != " ") || (textBox3.Text != "")))
                    {
                        Process myProcess_recovery_flash = new Process();
                        myProcess_recovery_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_recovery_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "recovery" + " " + flasher;
                        myProcess_recovery_flash.Start();
                        myProcess_recovery_flash.WaitForExit();
                    }
                    if ((metroCheckBox3.Checked) && (metroCheckBox10.Checked) && ((textBox3.Text == " ") || (textBox3.Text == "")))
                    {
                        Process myProcess_recoverytwrp_flash = new Process();
                        myProcess_recoverytwrp_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_recoverytwrp_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flashoffline.bat " + works + " " + mbnfile + " " + "recovery" + " " + "twrp";
                        myProcess_recoverytwrp_flash.Start();
                        myProcess_recoverytwrp_flash.WaitForExit();
                    }

                    //boot
                    flasher = textBox4.Text;
                    if ((metroCheckBox4.Checked) && ((textBox4.Text != " ") || (textBox4.Text != "")))
                    {
                        Process myProcess_boot_flash = new Process();
                        myProcess_boot_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_boot_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "boot" + " " + flasher;
                        myProcess_boot_flash.Start();
                        myProcess_boot_flash.WaitForExit();
                    }
                    if ((metroCheckBox4.Checked) && (metroCheckBox11.Checked) && ((textBox4.Text == " ") || (textBox4.Text == "")))
                    {
                        Process myProcess_root_flash = new Process();
                        myProcess_root_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_root_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flashoffline.bat " + works + " " + mbnfile + " " + "boot" + " " + "root";
                        myProcess_root_flash.Start();
                        myProcess_root_flash.WaitForExit();
                    }

                    //aboot
                    flasher = textBox5.Text;
                    if ((metroCheckBox5.Checked) && ((textBox5.Text != " ") || (textBox5.Text != "")))
                    {
                        Process myProcess_aboot_flash = new Process();
                        myProcess_aboot_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_aboot_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "aboot" + " " + flasher;
                        myProcess_aboot_flash.Start();
                        myProcess_aboot_flash.WaitForExit();
                    }

                    //vendor
                    flasher = textBox6.Text;
                    if ((metroCheckBox6.Checked) && ((textBox6.Text != " ") || (textBox6.Text != "")))
                    {
                        Process myProcess_vendor_flash = new Process();
                        myProcess_vendor_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_vendor_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "vendor" + " " + flasher;
                        myProcess_vendor_flash.Start();
                        myProcess_vendor_flash.WaitForExit();
                    }

                    //modem
                    flasher = textBox9.Text;
                    if ((metroCheckBox8.Checked) && ((textBox9.Text != " ") || (textBox9.Text != "")))
                    {
                        Process myProcess_modem_flash = new Process();
                        myProcess_modem_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_modem_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "modem" + " " + flasher;
                        myProcess_modem_flash.Start();
                        myProcess_modem_flash.WaitForExit();
                    }

                    //other
                    flasher = textBox7.Text;
                    if (((textBox8.Text != " ") || (textBox8.Text != "")) && ((flasher != " ") || (flasher != "")))
                    {
                        Process myProcess_other_flash = new Process();
                        myProcess_other_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_other_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + textBox8.Text + " " + flasher;
                        myProcess_other_flash.Start();
                        myProcess_other_flash.WaitForExit();
                    }

                    //userdata
                    flasher = textBox2.Text;
                    if ((metroCheckBox2.Checked) && ((textBox2.Text != " ") || (textBox2.Text != "")))
                    {
                        Process myProcess_userdata_flash = new Process();
                        myProcess_userdata_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_userdata_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + mbnfile + " " + "userdata" + " " + flasher;
                        myProcess_userdata_flash.Start();
                        myProcess_userdata_flash.WaitForExit();
                    }
                }
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked)
            {
                if (!metroCheckBox1.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел system!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle1.Checked = false;
                }
            }
        }

        private void metroToggle2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (metroToggle2.Checked)
            {
                if (!metroCheckBox2.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел userdata!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle2.Checked = false;
                }
            }
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle3.Checked)
            {
                if (!metroCheckBox3.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел recovery!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle3.Checked = false;
                }
            }
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle4.Checked)
            {
                if (!metroCheckBox4.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел boot!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle4.Checked = false;
                }
            }
        }

        private void metroToggle5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle5.Checked)
            {
                if (!metroCheckBox5.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел aboot!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle5.Checked = false;
                }
            }
        }

        private void metroToggle8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle8.Checked)
            {
                if (!metroCheckBox8.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел modem!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroToggle1.Checked = false;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("devmgmt.msc");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.png"); // Путь к логотипу (max)
            label6.Text = "Стоковая (v11)"; // Название прошивки
            label9.Text = "Android 8.1"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Green;
            label13.Text = "НЕТ"; //Наличие багов
            textBox17.Text = "Заводская прошивка."; // Краткое описание
            button4.Text = "2/16";
            button32.Text = "3/32";
            frimwares[0] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92021946"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "V11"; // Папка прошивки
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (frimwares[0] != "blablabla")
            {
                System.Diagnostics.Process.Start(frimwares[0]);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (frimwares[1] != "blablabla")
            {
                System.Diagnostics.Process.Start(frimwares[1]);
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (frimwares[2] != "blablabla")
            {
                System.Diagnostics.Process.Start(frimwares[2]);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (frimwares[3] != "blablabla")
            {
                System.Diagnostics.Process.Start(@Application.StartupPath + "\\CACHE\\SCREENSHOT\\" + frimwares[3] + "\\1.png");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (frimwares[3] != "blablabla")
            {
                System.Diagnostics.Process.Start(@Application.StartupPath + "\\CACHE\\SCREENSHOT\\" + frimwares[3] + "\\2.png");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (frimwares[3] != "blablabla")
            {
                System.Diagnostics.Process.Start(@Application.StartupPath + "\\CACHE\\SCREENSHOT\\" + frimwares[3] + "\\3.png");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.png"); // Путь к логотипу (max)
            label6.Text = "Стоковая (v9)"; // Название прошивки
            label9.Text = "Android 8.1"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Green;
            label13.Text = "НЕТ"; //Наличие багов
            textBox17.Text = "Заводская прошивка."; // Краткое описание
            button4.Text = "2/16";
            button32.Text = "3/32";
            frimwares[0] = "https://mega.nz/#F!w4UlCSbB!a3WHXuVCY97Mhx7tYEVORw"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://mega.nz/#F!w4UlCSbB!a3WHXuVCY97Mhx7tYEVORw"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "V11"; // Папка прошивки
        }

        private void button25_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\lo151.png"); // Путь к логотипу (max)
            label6.Text = "LineageOS 15.1"; // Название прошивки
            label9.Text = "Android 8.1"; // Версия зелёного робота
            label10.ForeColor = Color.Red;
            label10.Text = "НЕТ"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ОЧЕНЬ МНОГО"; //Наличие багов
            textBox17.Text = "Прошивка, основанная на AOSP (Android 8.1), но без приложений Google (даже сервисов нет!) и с очень большим количеством настроек и багов."; // Краткое описание
            button4.Text = "MEGA";
            button32.Text = "Я.Диск";
            frimwares[0] = "https://mega.nz/#!otMXyIYb!Z4egSUmo1jc3XOSHqLx1MjQw32L-C3ubb74T-jI5RfM"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://yadi.sk/d/ICPSLStOLi11kg"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86029984"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "LO151"; // Папка прошивки
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\oo.png"); // Путь к логотипу (max)
            label6.Text = "OctopusOS"; // Название прошивки
            label9.Text = "Android 9"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ВОЗМОЖНО"; //Наличие багов
            textBox17.Text = "Прошивка основанная на AOSP'e."; // Краткое описание
            button4.Text = "Скакчать";
            button32.Text = "Ещё раз";
            frimwares[0] = "https://yadi.sk/d/cklsb4NNhUFINQ"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://yadi.sk/d/cklsb4NNhUFINQ"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86241947"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "OO"; // Папка прошивки
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.png"); // Путь к логотипу (max)
            label6.Text = "Стоковая (v12)"; // Название прошивки
            label9.Text = "Android 8.1"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ОЧЕНЬ МНОГО"; //Наличие багов
            textBox17.Text = "Заводская прошивка."; // Краткое описание
            button4.Text = "2/16";
            button32.Text = "3/32";
            frimwares[0] = "https://mega.nz/#F!15cXWSRa!4xej5rd1yk9gDVSZbae_EA"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "V12"; // Папка прошивки
        }

        private void button28_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ho.png"); // Путь к логотипу (max)
            label6.Text = "HavocOS 2.6"; // Название прошивки
            label9.Text = "Android 9"; // Версия зелёного робота
            label10.ForeColor = Color.Red;
            label10.Text = "НЕТ"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ВОЗМОЖНО"; //Наличие багов
            textBox17.Text = "Havoc-OS 2.x is based on AOSP, inspired by Google Pixel." +
                "Has a refined Material Design 2 UI by @SKULSHADY." +
                "So many features that you probably won't find in any ROM." +
                "All you can dream of and all you'll ever need." +
                "Just flash and enjoy...";
            button4.Text = "MEGA";
            button32.Text = "Я.Диск";
            frimwares[0] = "https://mega.nz/#!J5M3gQxY!7kHlt6lNVhkK1bM4yulyANeiB0f-4zGELI60RdHWnXU"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://yadi.sk/d/tBSHhWzlJp6-5w"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86124087"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "HO"; // Папка прошивки
        }

        private void button33_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.ru/forum/index.php?s=&showtopic=892755&view=findpost&p=71222655");
        }

        private void metroToggle7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle7.Checked)
            {
                if ((textBox8.Text == "") || (textBox8.Text == " "))
                {
                    MessageBox.Show(
                    "Введите необходимый раздел!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                    metroToggle7.Checked = false;
                }
            }
        }

        private void metroCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox11.Checked)
            {
                if (!metroCheckBox4.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел boot!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroCheckBox11.Checked = false;
                }
                else
                {
                    MessageBox.Show(
                    "После прошивки ROOT возможны проблемы с личными данными (раздел userdata). Рекомендуется после прошивки стереть их! Для использования ROOT прав необходимо установить Magisk Manager из вкладки 'ADB'!",
                    "Важно!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void metroCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox10.Checked)
            {
                if (!metroCheckBox3.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел recovery!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroCheckBox10.Checked = false;
                }
                else
                {
                    MessageBox.Show(
                    "После прошивки TWRP Recovery возможны проблемы с личными данными (раздел userdata). Рекомендуется после прошивки стереть их!",
                    "Важно!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://play.google.com/store/apps/details?id=bg.projectoria.appinspector");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            f = new InfoForm();
            f.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.ru/forum/index.php?act=findpost&pid=91409816&anchor=Spoil-91409816-5");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox8.Text == " ")
            {
                textBox7.ReadOnly = true;
                textBox7.Text = "РАЗДЕЛ НЕ ВВЕДЁН";
                metroToggle7.Checked = false;
            }
            else
            {
                textBox7.ReadOnly = false;
                textBox7.Text = "";
                metroToggle7.Checked = true;
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)
            {
                textBox5.ReadOnly = false;
                textBox5.Text = "";
                metroToggle5.Checked = true;
            }
            if (!metroCheckBox5.Checked)
            {
                textBox5.ReadOnly = true;
                textBox5.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle5.Checked = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            f = new DelForm();
            f.Show();
        }

        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            textBox16.Text = "";
            openFileDialog1.Filter = "Прошивальщик|*.mbn";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            textBox16.Text = filename;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\plugins");
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\scripts");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            f = new ChangelogForm();
            f.Show();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=91409816");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cloud.mail.ru/public/2mYP/2AYva2UMu");
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.MBN = textBox16.Text;
            Properties.Settings.Default.Backups = textBox18.Text;
            Properties.Settings.Default.Save();
            mbnfile = textBox16.Text;
            backups = textBox18.Text;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.ReadOnly == false)
            {
                textBox1.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox1.Text = filename;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.ReadOnly == false)
            {
                textBox2.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox2.Text = filename;
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.ReadOnly == false)
            {
                textBox3.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox3.Text = filename;
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.ReadOnly == false)
            {
                textBox4.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox4.Text = filename;
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.ReadOnly == false)
            {
                textBox5.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox5.Text = filename;
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.ReadOnly == false)
            {
                textBox6.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox6.Text = filename;
            }
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox9.ReadOnly == false)
            {
                textBox9.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox9.Text = filename;
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.ReadOnly == false)
            {
                textBox7.Text = "";
                openFileDialog1.Filter = "Файл прошивки|*.img";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                textBox7.Text = filename;
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Loader32("plugin", "1", exe[0]);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Loader32("plugin", "2", exe[1]);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            Loader32("plugin", "3", exe[2]);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            Loader32("plugin", "4", exe[3]);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[0]);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[1]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[4]);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[5]);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[6]);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[7]);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ho3.png"); // Путь к логотипу (max)
            label6.Text = "HavocOS 3.0"; // Название прошивки
            label9.Text = "Android 10"; // Версия зелёного робота
            label10.ForeColor = Color.Red;
            label10.Text = "НЕТ"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ВОЗМОЖНО"; //Наличие багов
            textBox17.Text = "Havoc-OS 3.x is based on AOSP, inspired by Google Pixel." +
                "Has a refined Material Design 2 UI by @SKULSHADY." +
                "So many features that you probably won't find in any ROM." +
                "All you can dream of and all you'll ever need." +
                "Just flash and enjoy...";
            button4.Text = "Скачать";
            button32.Text = "Ещё раз";
            frimwares[0] = "https://sourceforge.net/projects/expressluke-gsis/files/HavocOS/Ten/ARM64/A/Havoc-OS-v3.0-20191225-ARM64A-Unofficial.img.xz/download"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://sourceforge.net/projects/expressluke-gsis/files/HavocOS/Ten/ARM64/A/Havoc-OS-v3.0-20191225-ARM64A-Unofficial.img.xz/download"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92530905"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "HO3"; // Папка прошивки
        }

        private void button29_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\BootleggersROM.png"); // Путь к логотипу (max)
            label6.Text = "BootleggersROM"; // Название прошивки
            label9.Text = "Android 9"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Green;
            label13.Text = "НЕТ"; //Наличие багов
            textBox17.Text = "Довольно красивая прошивка версии 4.1 на Android 9, правленная nFound.";
            button4.Text = "Mail.ru";
            button32.Text = "A.Host";
            frimwares[0] = "https://cloud.mail.ru/public/2XXK/3LCBhc8eq"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://androidfilehost.com/?w=files&flid=291038&sort_by=date&sort_dir=DESC"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=87734060"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "BootleggersROM"; // Папка прошивки
        }

        private void button38_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ao.png"); // Путь к логотипу (max)
            label6.Text = "ArrowOS"; // Название прошивки
            label9.Text = "Android 10"; // Версия зелёного робота
            label10.ForeColor = Color.Red;
            label10.Text = "НЕТ"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "НЕИЗВЕСТНО"; //Наличие багов
            textBox17.Text = "ArrowOS is an AOSP based project started with the aim of keeping things simple, " +
                "clean and neat. We added just the right and mostly used stuff that will be actually USEFUL " +
                "at the end of the day, aiming to deliver smooth performance with better battery life.";
            button4.Text = "Скачать";
            button32.Text = "Ещё раз";
            frimwares[0] = "https://sourceforge.net/projects/gsi-albus/files/arm64-aonly/android10/arrow/system.img/download"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://sourceforge.net/projects/gsi-albus/files/arm64-aonly/android10/arrow/system.img/download"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92619499"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "AO"; // Папка прошивки
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Плагины и Скрипты.ini");
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[2]);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.ru/forum/index.php?act=findpost&pid=91409816&anchor=Spoil-91409816-13");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            portal = SerialPort.GetPortNames();
            if (portal.Length != 0)
            {
                for (int i = 0; i < portal.Length; i++)
                {
                    dfu1 = portal[i].ToString();
                }
                textBox19.Text = dfu1.Remove(0, 3);
            }
            else
            {
                MessageBox.Show(
            "COM порты не обнаружены!",
            "Ошибка!",
             MessageBoxButtons.OK,
             MessageBoxIcon.Error,
             MessageBoxDefaultButton.Button1,
             MessageBoxOptions.RightAlign);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MBN = "";
            Properties.Settings.Default.Backups = "";
            Properties.Settings.Default.Save();
            textBox16.Text = @Application.StartupPath + "\\EWT\\emmcdl\\ZTE_BV9_Vita.mbn";
            textBox18.Text = @Application.StartupPath + "\\EWT\\backups";
        }

        private void metroCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox12.Checked)
            {
                if (!metroCheckBox2.Checked)
                {
                    MessageBox.Show(
                "Активируйте раздел userdata!",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
                    metroCheckBox12.Checked = false;
                }
                else
                {
                    MessageBox.Show(
                    "После прошивки 'чистильщика' ваши данные будут стёрты! Рекомендуется сделать бекап!",
                    "Важно!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void metroCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
 
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Loader32("script", "0", scripts[3]);
        }

        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            textBox18.Text = "";
            string path = null;
            using (var folderBrowserDialog1 = new FolderBrowserDialog())
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    path = folderBrowserDialog1.SelectedPath;
            textBox18.Text = path;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "install -d  " + Application.StartupPath + "\\adb\\installapk\\root\\" + "mm.apk";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start();
            StreamReader srIncoming = myProcess.StandardOutput;
            textBox13.Text = srIncoming.ReadToEnd(); 
            string name = "adb";
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process anti in etc)
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox19.Text.Length != 0)
            { 
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & dfu.bat " + textBox19.Text;
            myProcess.Start();
            myProcess.WaitForExit();
            Thread.Sleep(2000);
            MessageBox.Show(
            "Обязательно обновите номер COM порта!",
            "Внимание!",
             MessageBoxButtons.OK,
             MessageBoxIcon.Warning,
             MessageBoxDefaultButton.Button1,
             MessageBoxOptions.RightAlign);
            }
            if (textBox19.Text.Length == 0)
             {
                    MessageBox.Show(
                    "Номер COM порта не найден!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frimwares = new string[4];
            textBox11.Text = "Введите имя пакета (узнайте через приложение App Inspector)";
            textBox11.ForeColor = Color.Gray;
            textBox14.Text = "Введите имя файла для установки (с расширением) (через кнопку 'Папка')";
            textBox14.ForeColor = Color.Gray;
            pictureBox6.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.png"); // Путь к логотипу (v12)
            pictureBox3.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.png"); // Путь к логотипу (v11)
            pictureBox10.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.png"); // Путь к логотипу (v9)
            pictureBox4.Load(@Application.StartupPath + "\\CACHE\\LOGO\\lo151.png");
            pictureBox5.Load(@Application.StartupPath + "\\CACHE\\LOGO\\oo.png");
            pictureBox7.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ho.png");
            pictureBox8.Load(@Application.StartupPath + "\\CACHE\\LOGO\\BootleggersROM.png");
            pictureBox9.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ho3.png");
            pictureBox12.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ao.png");
            frimwares[0] = "blablabla";
            frimwares[1] = "blablabla";
            frimwares[2] = "blablabla";
            frimwares[3] = "blablabla";
            textBox16.Text = Properties.Settings.Default.MBN;
            if ((textBox16.Text == "") || (textBox16.Text == " "))
            {
                textBox16.Text = @Application.StartupPath + "\\EWT\\emmcdl\\ZTE_BV9_Vita.mbn";
            }
            textBox18.Text = Properties.Settings.Default.Backups;
            if ((textBox18.Text == "") || (textBox18.Text == " "))
            {
                textBox18.Text = @Application.StartupPath + "\\EWT\\backups";
            }
            mbnfile = textBox16.Text;
            backups = textBox18.Text;
            exe = new string[4];
            scripts = new string[8];
            var config = Configuration.LoadFromFile("Плагины и Скрипты.ini");
            var section = config["Plugins"];
            button39.Text = section["name1"].StringValue;
            exe[0] = section["exe1"].StringValue;
            button45.Text = section["name2"].StringValue;
            exe[1] = section["exe2"].StringValue;
            button46.Text = section["name3"].StringValue;
            exe[2] = section["exe3"].StringValue;
            button47.Text = section["name4"].StringValue;
            exe[3] = section["exe4"].StringValue;
            var sectio1 = config["Scripts"];
            scripts[0] = sectio1["file1"].StringValue;
            button51.Text = scripts[0];
            scripts[1] = sectio1["file2"].StringValue;
            button50.Text = scripts[1];
            scripts[2] = sectio1["file3"].StringValue;
            button49.Text = scripts[2];
            scripts[3] = sectio1["file4"].StringValue;
            button48.Text = scripts[3];
            scripts[4] = sectio1["file5"].StringValue;
            button9.Text = scripts[4];
            scripts[5] = sectio1["file6"].StringValue;
            button13.Text = scripts[5];
            scripts[6] = sectio1["file7"].StringValue;
            button16.Text = scripts[6];
            scripts[7] = sectio1["file8"].StringValue;
            button54.Text = scripts[7];
        }
        private void Loader32(string type, string number, string run)
        {
            if ((type == "plugin") && (run != "0"))
            {
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = "cmd.exe";
                    myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/plugins/" + number + " & " + run + ".exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.Start();
            }
            if ((type == "script") && (run != "0"))
            {
                if ((metroCheckBox14.Checked) || (metroCheckBox15.Checked) || (metroCheckBox16.Checked))
                {
                    string argum = " ";
                    string argum1 = " ";
                    string argum2 = " ";
                    // port mbnfile backups
                    port = textBox19.Text;
                    if (metroCheckBox14.Checked) { argum = argum + port; }
                    if (metroCheckBox15.Checked) { argum1 = argum1 + mbnfile; }
                    if (metroCheckBox16.Checked) { argum2 = argum2 + backups; }
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = "cmd.exe";
                    myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/scripts & " + run + ".bat" + argum + argum1 + argum2;
                    myProcess.Start();
                }
                else
                {
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = "cmd.exe";
                    myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/scripts & " + run + ".bat";
                    myProcess.Start();
                }
            }
            if (run == "0")
            {
                MessageBox.Show(
                "Кажется вы забыли что-то подключить :)",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            }
        }
        public void StartForm()
        {
            Application.Run(new SplashLoadForm());
        }
    }
}