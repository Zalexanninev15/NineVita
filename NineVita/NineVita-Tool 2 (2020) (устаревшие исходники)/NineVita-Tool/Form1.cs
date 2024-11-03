using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Net;
using System.Reflection;
using SharpConfig;
using System.Runtime.ConstrainedExecution;
using NineVita_Tool.Properties;

namespace NineVita_Tool
{
    public partial class Form1 : MetroForm
    {
        Form f;
        string[] portal;
        string[] apps;
        string[] frimwares;
        string dfu1, adbedl1, works, other, flasher, app, def1, nametool, donet, debugmode;
        int openw, xx;
        public Form1()
        {
            InitializeComponent();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?showuser=5330563");
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?showuser=5901662");
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mega.nz/#!1lV2iagS!frhZSoSZgOil__azejpnz9qHdEJpYu5MbQPhVtwjBPM");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
            //Process myProcess = new Process();
            //myProcess.StartInfo.FileName = "cmd.exe";
            //myProcess.StartInfo.CreateNoWindow = true;
            //myProcess.StartInfo.UseShellExecute = false;
            //myProcess.StartInfo.RedirectStandardOutput = true;
            //myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "reboot edl";
            //myProcess.Start();
            //myProcess.WaitForExit();
            Cmd("start " + @Application.StartupPath + "/adb & adb.exe " + "reboot edl");
            StreamReader srIncoming = Cmd.StandardOutput;
            textBox15.Text = srIncoming.ReadToEnd();
            Thread.Sleep(9000);
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
            portal = SerialPort.GetPortNames();
            for (int i = 0; i < portal.Length; i++)
            {
                adbedl1 = portal[i].ToString();
            }
            metroLabel14.Text = adbedl1.Remove(0, 3);
            if ((textBox15.Text == "") || (textBox15.Text == " "))
            {
                textBox15.Text = "Завершено"; 
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            portal = SerialPort.GetPortNames();
            for (int i = 0; i < portal.Length; i++)
            {
                dfu1 = portal[i].ToString();
            }
            metroLabel14.Text = dfu1.Remove(0, 3);
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
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            textBox10.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
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
                StreamReader srIncomings = myProcess.StandardOutput; //присваивание результата
                textBox12.Text = srIncomings.ReadToEnd(); //вывод результата
                string name = "adb";//процесс, который нужно убить
                System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
                foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                    if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
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
                    StreamReader srIncoming = myssProcess.StandardOutput; //присваивание результата
                    textBox12.Text = srIncoming.ReadToEnd(); //вывод результата
                    i = i + 1;
                }
                string name = "adb";//процесс, который нужно убить
                System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
                foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                    if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
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

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?s=&showtopic=952274&view=findpost&p=91409816");
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

        private void button10_Click(object sender, EventArgs e) //Установка приложений
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
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            textBox13.Text = srIncoming.ReadToEnd(); //вывод результата
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
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
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            textBox10.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
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
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            textBox10.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
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
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            textBox10.Text = srIncoming.ReadToEnd(); //вывод результат
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
        }

        private void button22_Click(object sender, EventArgs e)
        {
            f = new Form5();
            f.Show();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                textBox1.ReadOnly = false;
                textBox1.Text = "system.img";
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
                textBox2.Text = "userdata.img";
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
                textBox3.Text = "recovery.img";
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
                textBox4.Text = "boot.img";
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
            f = new Form2();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\ewt\\backups");
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
                textBox6.Text = "vendor.img";
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
                textBox9.Text = "modem.img";
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
            if ((!metroCheckBox1.Checked == true) && (!metroCheckBox3.Checked == true) && (!metroCheckBox4.Checked == true) && (!metroCheckBox5.Checked == true) && (!metroCheckBox6.Checked == true) && (!metroCheckBox8.Checked == true) && (!metroCheckBox2.Checked == true) && ((textBox8.Text == "") || (textBox8.Text == " ")) && (!metroCheckBox12.Checked == true) && (!metroCheckBox7.Checked == true))
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
                portal = SerialPort.GetPortNames();
                for (int i = 0; i < portal.Length; i++)
                {
                    dfu1 = portal[i].ToString();
                }
                works = dfu1.Remove(0, 3);
                //=============================Бекап разделов=============================

                //system
                if ((metroCheckBox1.Checked) && (metroToggle1.Checked == true))
                {
                    Process myProcess_sys_backup = new Process();
                    myProcess_sys_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_sys_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "system" + " " + "system";
                    myProcess_sys_backup.Start();
                    myProcess_sys_backup.WaitForExit();
                }

                //recovery
                if ((metroCheckBox3.Checked) && (metroToggle3.Checked == true))
                {
                    Process myProcess_recovery_backup = new Process();
                    myProcess_recovery_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_recovery_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "recovery" + " " + "recovery";
                    myProcess_recovery_backup.Start();
                    myProcess_recovery_backup.WaitForExit();
                }

                //boot
                if ((metroCheckBox4.Checked) && (metroToggle4.Checked == true))
                {
                    Process myProcess_boot_backup = new Process();
                    myProcess_boot_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_boot_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "boot" + " " + "boot";
                    myProcess_boot_backup.Start();
                    myProcess_boot_backup.WaitForExit();
                }

                //aboot
                if ((metroCheckBox5.Checked) && (metroToggle5.Checked == true))
                {
                    Process myProcess_aboot_backup = new Process();
                    myProcess_aboot_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_aboot_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "aboot" + " " + "aboot";
                    myProcess_aboot_backup.Start();
                    myProcess_aboot_backup.WaitForExit();
                }

                //vendor
                if ((metroCheckBox6.Checked) && (metroToggle6.Checked == true))
                {
                    Process myProcess_vendor_backup = new Process();
                    myProcess_vendor_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_vendor_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "vendor" + " " + "vendor";
                    myProcess_vendor_backup.Start();
                    myProcess_vendor_backup.WaitForExit();
                }

                //modem
                if ((metroCheckBox8.Checked) && (metroToggle8.Checked == true))
                {
                    Process myProcess_modem_backup = new Process();
                    myProcess_modem_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_modem_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "modem" + " " + "modem";
                    myProcess_modem_backup.Start();
                    myProcess_modem_backup.WaitForExit();
                }

                //other
                if ((metroToggle7.Checked == true) && (textBox8.Text != "") || (textBox8.Text != " "))
                {
                    other = textBox8.Text;
                    Process myProcess_other_backup = new Process();
                    myProcess_other_backup.StartInfo.FileName = "cmd.exe";
                    if (debugmode == "0")
                    myProcess_other_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + other + " " + other;
                    myProcess_other_backup.Start();
                    myProcess_other_backup.WaitForExit();
                }

                //ALL
                if (metroCheckBox7.Checked)
                {
                    Process myProcess_All_backup = new Process();
                    myProcess_All_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_All_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & allbackup.bat " + works;
                    myProcess_All_backup.Start();
                    myProcess_All_backup.WaitForExit();
                }

                //userdata
                if ((metroCheckBox2.Checked) && (metroToggle2.Checked == true))
                {
                    Process myProcess_userdata_backup = new Process();
                    myProcess_userdata_backup.StartInfo.FileName = "cmd.exe";
                    myProcess_userdata_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + "userdata" + " " + "userdata";
                    myProcess_userdata_backup.Start();
                    myProcess_userdata_backup.WaitForExit();
                }
                //=============================Прошивка разделов=============================
                //system
                flasher = textBox1.Text;
                if ((metroCheckBox1.Checked) && ((textBox1.Text != " ") || (textBox1.Text != "")))
                {
                    Process myProcess_sys_flash = new Process();
                    myProcess_sys_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_sys_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "system" + " " + flasher;
                    myProcess_sys_flash.Start();
                    myProcess_sys_flash.WaitForExit();
                }

                //recovery
                flasher = textBox3.Text;
                if ((metroCheckBox3.Checked) && ((textBox3.Text != " ") || (textBox3.Text != "")))
                {
                    Process myProcess_recovery_flash = new Process();
                    myProcess_recovery_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_recovery_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "recovery" + " " + flasher;
                    myProcess_recovery_flash.Start();
                    myProcess_recovery_flash.WaitForExit();
                }
                if ((metroCheckBox3.Checked) && (metroCheckBox10.Checked) && ((textBox3.Text == " ") || (textBox3.Text == "")))
                {
                    Process myProcess_recoverytwrp_flash = new Process();
                    myProcess_recoverytwrp_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_recoverytwrp_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flashoffline.bat " + works + " " + "recovery" + " " + "twrp";
                    myProcess_recoverytwrp_flash.Start();
                    myProcess_recoverytwrp_flash.WaitForExit();
                }

                //boot
                flasher = textBox4.Text;
                if ((metroCheckBox4.Checked) && ((textBox4.Text != " ") || (textBox4.Text != "")))
                {
                    Process myProcess_boot_flash = new Process();
                    myProcess_boot_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_boot_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "boot" + " " + flasher;
                    myProcess_boot_flash.Start();
                    myProcess_boot_flash.WaitForExit();
                }
                if ((metroCheckBox4.Checked) && (metroCheckBox11.Checked) && ((textBox4.Text == " ") || (textBox4.Text == "")))
                {
                    Process myProcess_root_flash = new Process();
                    myProcess_root_flash.StartInfo.FileName = "cmd.exe";
                    if (debugmode == "0")
                    myProcess_root_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flashoffline.bat " + works + " " + "boot" + " " + "root";
                    myProcess_root_flash.Start();
                    myProcess_root_flash.WaitForExit();
                }

                //aboot
                flasher = textBox5.Text;
                if ((metroCheckBox5.Checked) && ((textBox5.Text != " ") || (textBox5.Text != "")))
                {
                    Process myProcess_aboot_flash = new Process();
                    myProcess_aboot_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_aboot_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "aboot" + " " + flasher;
                    myProcess_aboot_flash.Start();
                    myProcess_aboot_flash.WaitForExit();
                }

                //vendor
                flasher = textBox6.Text;
                if ((metroCheckBox6.Checked) && ((textBox6.Text != " ") || (textBox6.Text != "")))
                {
                    Process myProcess_vendor_flash = new Process();
                    myProcess_vendor_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_vendor_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "vendor" + " " + flasher;
                    myProcess_vendor_flash.Start();
                    myProcess_vendor_flash.WaitForExit();
                }

                //modem
                flasher = textBox9.Text;
                if ((metroCheckBox8.Checked) && ((textBox9.Text != " ") || (textBox9.Text != "")))
                {
                    Process myProcess_modem_flash = new Process();
                    myProcess_modem_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_modem_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "modem" + " " + flasher;
                    myProcess_modem_flash.Start();
                    myProcess_modem_flash.WaitForExit();
                }

                //other
                flasher = textBox8.Text;
                if ((textBox7.Text != " ") || (textBox7.Text != "") && (flasher != " ") || (flasher != ""))
                {
                    Process myProcess_other_flash = new Process();
                    myProcess_other_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_other_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "modem" + " " + flasher;
                    myProcess_other_flash.Start();
                    myProcess_other_flash.WaitForExit();
                }

                //userdata
                flasher = textBox2.Text;
                if ((metroCheckBox2.Checked) && ((textBox2.Text != " ") || (textBox2.Text != "")))
                {
                    Process myProcess_userdata_flash = new Process();
                    myProcess_userdata_flash.StartInfo.FileName = "cmd.exe";
                    myProcess_userdata_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash.bat " + works + " " + "userdata" + " " + flasher;
                    myProcess_userdata_flash.Start();
                    myProcess_userdata_flash.WaitForExit();
                }
                if (metroCheckBox12.Checked) //Отключение защиты Google FRP
                {
                    Process myProcess = new Process();
                    myProcess.StartInfo.FileName = "cmd.exe";
                    myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & dfrp.bat " + metroLabel14.Text;
                    myProcess.Start();
                    myProcess.WaitForExit();
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
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.jpg"); // Путь к логотипу (max)
            label6.Text = "Стоковая (v11)"; // Название прошивки
            label9.Text = "Android 8.1"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Green;
            label13.Text = "НЕТ"; //Наличие багов
            textBox17.Text = "Заводская прошивка."; // Краткое описание
            button4.Text = "2/16";
            button32.Text = "3/32";
            frimwares[0] = "https://4pda.to/forum/index.php?s=&showtopic=952274&view=findpost&p=92021946"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://mega.nz/#!ZgN32QZR!2S6JrSc6hjRrJtgW1GMUTcSn746oKX0TrrAUFNwx_iQ"; // Ссылка на скачивание файла "system.img" (зеркало)
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
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.jpg"); // Путь к логотипу (max)
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
            frimwares[2] = "https://4pda.to/forum/index.php?s=&showtopic=952274&view=findpost&p=86029984"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "LO151"; // Папка прошивки
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\oo.png"); // Путь к логотипу (max)
            label6.Text = "OctopusOS"; // Название прошивки
            label9.Text = "Android 9.0"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ВОЗМОЖНО"; //Наличие багов
            textBox17.Text = "Прошивка основанная на AOSP'e."; // Краткое описание
            button4.Text = "MEGA";
            button32.Text = "Я.Диск";
            frimwares[0] = "https://mega.nz/#!d9FTlaIJ!IQsmOCEauPj-cACQyfiuNFPKvsugt71OwnNseK8PwcU"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://yadi.sk/d/cklsb4NNhUFINQ"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://4pda.to/forum/index.php?s=&showtopic=952274&view=findpost&p=86241947"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "OO"; // Папка прошивки
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.jpg"); // Путь к логотипу (max)
            label6.Text = "Стоковая (v12)"; // Название прошивки
            label9.Text = "Android 8.1"; // Версия зелёного робота
            label10.ForeColor = Color.Green;
            label10.Text = "ДА"; // Наличие Google Apps (GAPPS)
            label13.ForeColor = Color.Red;
            label13.Text = "ДА"; //Наличие багов
            textBox17.Text = "Заводская прошивка."; // Краткое описание
            button4.Text = "2/16";
            button32.Text = "3/32";
            frimwares[0] = "https://mega.nz/#F!15cXWSRa!4xej5rd1yk9gDVSZbae_EA"; // Ссылка на скачивание файла "system.img" (рекомендуется из облака MEGA)
            frimwares[1] = "https://mega.nz/#!RlMBmSwC!XzbRON6Qu62V8wVn41yk6Npl0CMLEf6mficrfNF1xao"; // Ссылка на скачивание файла "system.img" (зеркало)
            frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "V12"; // Папка прошивки
        }

        private void button28_Click(object sender, EventArgs e)
        {
            pictureBox11.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ho.png"); // Путь к логотипу (max)
            label6.Text = "HavocOS"; // Название прошивки
            label9.Text = "Android 9.0"; // Версия зелёного робота
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
            frimwares[2] = "https://4pda.to/forum/index.php?s=&showtopic=952274&view=findpost&p=86124087"; // Ссылка на источник или "подробнее об прошивке"
            frimwares[3] = "HO"; // Папка прошивки
        }

        private void button39_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://yasobe.ru/na/podarok_z15");
            xx = 2;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\stc\\img");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\stc\\files");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Process myProcess_sys_unpack = new Process();
            myProcess_sys_unpack.StartInfo.FileName = "cmd.exe";
            myProcess_sys_unpack.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/stc & extract.bat";
            myProcess_sys_unpack.Start();
            myProcess_sys_unpack.WaitForExit();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Process myProcess_sys_convert = new Process();
            myProcess_sys_convert.StartInfo.FileName = "cmd.exe";
            myProcess_sys_convert.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/stc & convert.bat";
            myProcess_sys_convert.Start();
            myProcess_sys_convert.WaitForExit();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Process myProcess_sys_convert = new Process();
            myProcess_sys_convert.StartInfo.FileName = "cmd.exe";
            myProcess_sys_convert.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/stc & create.bat";
            myProcess_sys_convert.Start();
            myProcess_sys_convert.WaitForExit();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?s=&showtopic=892755&view=findpost&p=71222655");
        }

        private void metroLink7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?showuser=5330563");
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
            xx = 3;
            f = new Form8();
            f.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?act=findpost&pid=91409816&anchor=Spoil-91409816-5");
        }

        private void metroLink4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://4pda.to/forum/index.php?showuser=8633511");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (xx == 3)
            {
                f = new Form9();
                f.Show();
            }
            else
            { 
                xx = 1; 
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Cmd("help & pause");
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
                textBox7.Text = textBox8.Text + ".img";
                metroToggle7.Checked = true;
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)
            {
                textBox5.ReadOnly = false;
                textBox5.Text = "aboot.img";
                metroToggle5.Checked = true;
            }
            if (!metroCheckBox5.Checked)
            {
                textBox5.ReadOnly = true;
                textBox5.Text = "РАЗДЕЛ НЕ ВЫБРАН";
                metroToggle5.Checked = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", @Application.StartupPath + "\\ewt\\files");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            f = new Form6();
            f.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (((app != "") || (app != " ")) && (!metroCheckBox13.Checked == true))
            {
                app = textBox11.Text;
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.exe " + "uninstall -k " + app;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.Start();
                StreamReader srIncomings = myProcess.StandardOutput; //присваивание результата
                textBox12.Text = srIncomings.ReadToEnd(); //вывод результата
                string name = "adb";//процесс, который нужно убить
                System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
                foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                    if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
            }

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
            StreamReader srIncoming = myProcess.StandardOutput; //присваивание результата
            textBox13.Text = srIncoming.ReadToEnd(); //вывод результата
            string name = "adb";//процесс, который нужно убить
            System.Diagnostics.Process[] etc = System.Diagnostics.Process.GetProcesses();//получим процессы
            foreach (System.Diagnostics.Process anti in etc)//обойдем каждый процесс
                if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill();//найдем нужный и убьем
        }

        private void button3_Click(object sender, EventArgs e)
        {
            portal = SerialPort.GetPortNames();
            for (int i = 0; i < portal.Length; i++)
            {
                dfu1 = portal[i].ToString();
            }
            metroLabel14.Text = dfu1.Remove(0, 3);
            Thread.Sleep(7000);
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & dfu.bat " + metroLabel14.Text;
            myProcess.Start();
            myProcess.WaitForExit();
            Thread.Sleep(2000);
            portal = SerialPort.GetPortNames();
            for (int i = 0; i < portal.Length; i++)
            {
                dfu1 = portal[i].ToString();
            }
            metroLabel14.Text = dfu1.Remove(0, 3);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            f = new Form3();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xx = 0;
                Form4 form = new Form4();
                form.ShowDialog();
                frimwares = new string[4];
                textBox11.Text = "Введите имя пакета (узнайте через приложение App Inspector)";
                textBox11.ForeColor = Color.Gray;
                textBox14.Text = "Введите имя файла для установки (с расширением) (через кнопку 'Папка')";
                textBox14.ForeColor = Color.Gray;
                pictureBox6.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.jpg"); // Путь к логотипу (v12)
                pictureBox3.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.jpg"); // Путь к логотипу (v11)
                pictureBox10.Load(@Application.StartupPath + "\\CACHE\\LOGO\\v.jpg"); // Путь к логотипу (v9)
                pictureBox4.Load(@Application.StartupPath + "\\CACHE\\LOGO\\lo151.png");
                pictureBox5.Load(@Application.StartupPath + "\\CACHE\\LOGO\\oo.png");
                pictureBox7.Load(@Application.StartupPath + "\\CACHE\\LOGO\\ho.png");
                frimwares[0] = "blablabla";
                frimwares[1] = "blablabla";
                frimwares[2] = "blablabla";
                frimwares[3] = "blablabla";
        }

        private void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo { FileName = "cmd", Arguments = $"/c {line}"}).WaitForExit();
        }
    }
}