using HtmlAgilityPack;
using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NineVita
{
    public partial class MainForm : MetroForm
    {
        Form f;
        string[] portal; string[] apps; string[] frimwares;
        int fs;
        string avp, dfu1, adba, works, other, flasher, id, app, mbnfile = @Application.StartupPath + @"\flasher.mbn", backups = @Application.StartupPath + @"\EWT\backups", bakex = "img";
        public MainForm() { InitializeComponent(); }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            ADBCommander("reboot edl");
        }

        void button8_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            ADBCommander("devices");
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
                Process[] etc = Process.GetProcesses();
                foreach (Process anti in etc) { if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill(); }
            }
            if (metroCheckBox13.Checked == true)
            {
                int i = 0;
                for (; i < 37;)
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
                Process[] etc = Process.GetProcesses();
                foreach (Process anti in etc) { if (anti.ProcessName.ToLower().Contains(name.ToLower())) anti.Kill(); }
            }
            MessageBox.Show("Выполнено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Text == "Введите имя пакета приложения")
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
                textBox7.ReadOnly = true;
                metroToggle711.Checked = false;
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Text == "Введите имя файла для установки (с расширением)")
            {
                textBox14.Clear();
                textBox14.ForeColor = Color.Black;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            if (metroCheckBox9.Checked) { ADBCommander("install -r -s " + @Application.StartupPath + @"\ADB\InstallAPK\" + textBox14.Text); }
            else { ADBCommander("install -r " + @Application.StartupPath + @"\ADB\InstallAPK\" + textBox14.Text); }
            textBox13.Text = adba;
        }

        private void button17_Click(object sender, EventArgs e) { Process.Start("explorer", @Application.StartupPath + @"\ADB\InstallAPK"); }

        private void metroCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox13.Checked == true)
            {
                apps = new string[37];
                apps[0] = "com.facebook.katana";
                apps[1] = "com.facebook.system";
                apps[2] = "com.facebook.appmanager";
                apps[3] = "com.facebook.services";
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
                apps[14] = "com.google.android.apps.messaging";
                apps[15] = "com.google.android.calculator";
                apps[16] = "com.google.android.feedback";
                apps[17] = "com.google.android.gm";
                apps[18] = "com.google.android.apps.tachyon";
                apps[19] = "com.google.android.googlequicksearchbox";
                apps[20] = "com.google.android.inputmethod.latin";
                apps[21] = "com.google.android.calendar";
                apps[22] = "com.android.chrome";
                apps[23] = "com.google.android.inputmethod.latin";
                apps[24] = "com.google.android.apps.walletnfcrel";
                apps[25] = "com.android.stk";
                apps[26] = "ru.yandex.searchplugin";
                apps[27] = "com.yandex.zen";
                apps[28] = "com.hermes.superb.oem";
                apps[29] = "ru.sberbankmobile";
                apps[30] = "com.yandex.zenkitpartnerconfig";
                apps[31] = "com.UCMobile.intl";
                apps[32] = "com.ume.browser.cust";
                apps[33] = "com.google.android.contacts";
                apps[34] = "com.google.android.dialer";
                apps[35] = "com.android.stk";
                apps[36] = "com.quicinc.fmradio";
                textBox11.Enabled = false;
            }
            if (!metroCheckBox13.Checked == true) { textBox11.Enabled = true; }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            ADBCommander("reboot recovery");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            ADBCommander("get-state");
        }

        private void button23_Click(object sender, EventArgs e)
        { 
            textBox10.Clear();
            ADBCommander("reboot");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            foreach (Form F in Application.OpenForms) { if (F.Name == "AppsForm") { fs = 1; } else { fs = 0; } }
            if (fs == 0) { f = new AppsForm(); f.Show(); }
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
            foreach (Form F in Application.OpenForms) { if (F.Name == "PartitionsForm") { fs = 1; } else { fs = 0; } }
            if (fs == 0) { f = new PartitionsForm(); f.Show(); }
        }

        private void button12_Click(object sender, EventArgs e) { Process.Start("explorer.exe", @backups); }
        private void metroToggle6_CheckedChanged(object sender, EventArgs e) { if (metroToggle6.Checked) { if (!metroCheckBox6.Checked) { MessageBox.Show("Активируйте раздел vendor!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle6.Checked = false; } } }

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
            if ((!metroCheckBox1.Checked == true) && (!metroCheckBox3.Checked == true) && (!metroCheckBox4.Checked == true) && (!metroCheckBox5.Checked == true) && (!metroCheckBox6.Checked == true) && (!metroCheckBox8.Checked == true) && (!metroCheckBox2.Checked == true) && ((textBox8.Text == "") || (textBox8.Text == " ")) && (!metroCheckBox7.Checked == true)) { MessageBox.Show("Выберете хотя бы одно действие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                works = textBox19.Text;
                if (works.Length == 0) { MessageBox.Show("Номер COM порта не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    //
                    //=============================Бэкап разделов=============================
                    //
                    //system
                    if ((metroCheckBox1.Checked == true) && (metroToggle1.Checked == true))
                    {
                        Process myProcess_sys_backup = new Process();
                        myProcess_sys_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_sys_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "system" + " " + backups + "\\" + "system" + " " + bakex;
                        myProcess_sys_backup.Start();
                        myProcess_sys_backup.WaitForExit();
                        //metroCheckBox1.Checked = false;
                        //metroToggle1.Checked = false;
                    }

                    //recovery
                    if ((metroCheckBox3.Checked == true) && (metroToggle3.Checked == true))
                    {
                        Process myProcess_recovery_backup = new Process();
                        myProcess_recovery_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_recovery_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "recovery" + " " + backups + "\\" + "recovery" + " " + bakex;
                        myProcess_recovery_backup.Start();
                        myProcess_recovery_backup.WaitForExit();
                        //metroCheckBox3.Checked = false;
                        //metroToggle3.Checked = false;
                    }

                    //boot
                    if ((metroCheckBox4.Checked == true) && (metroToggle4.Checked == true))
                    {
                        Process myProcess_boot_backup = new Process();
                        myProcess_boot_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_boot_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "boot" + " " + backups + "\\" + "boot" + " " + bakex;
                        myProcess_boot_backup.Start();
                        myProcess_boot_backup.WaitForExit();
                        //metroCheckBox4.Checked = false;
                        //metroToggle4.Checked = false;
                    }

                    //aboot
                    if ((metroCheckBox5.Checked == true) && (metroToggle5.Checked == true))
                    {
                        Process myProcess_aboot_backup = new Process();
                        myProcess_aboot_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_aboot_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "aboot" + " " + backups + "\\" + "aboot" + " " + bakex;
                        myProcess_aboot_backup.Start();
                        myProcess_aboot_backup.WaitForExit();
                        //metroCheckBox5.Checked = false;
                        //metroToggle5.Checked = false;
                    }

                    //vendor
                    if ((metroCheckBox6.Checked == true) && (metroToggle6.Checked == true))
                    {
                        Process myProcess_vendor_backup = new Process();
                        myProcess_vendor_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_vendor_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "vendor" + " " + backups + "\\" + "vendor" + " " + bakex;
                        myProcess_vendor_backup.Start();
                        myProcess_vendor_backup.WaitForExit();
                        //metroCheckBox6.Checked = false;
                        //metroToggle6.Checked = false;
                    }

                    //modem
                    if ((metroCheckBox8.Checked == true) && (metroToggle8.Checked == true))
                    {
                        Process myProcess_modem_backup = new Process();
                        myProcess_modem_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_modem_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "modem" + " " + backups + "\\" + "modem" + " " + bakex;
                        myProcess_modem_backup.Start();
                        myProcess_modem_backup.WaitForExit();
                        //metroCheckBox8.Checked = false;
                        //metroToggle8.Checked = false;
                    }

                    //other
                    if ((metroToggle711.Checked == true) && ((textBox7.Text != "РАЗДЕЛ НЕ ВВЕДЁН") || (textBox7.Text != "")))
                    {
                        other = textBox8.Text;
                        Process myProcess_other_backup = new Process();
                        myProcess_other_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_other_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + other + " " + backups + "\\" + other + " " + bakex;
                        myProcess_other_backup.Start();
                        myProcess_other_backup.WaitForExit();
                        //metroToggle711.Checked = false;
                        //textBox8.Text = "РАЗДЕЛ НЕ ВВЕДЁН";
                        //textBox7.Clear();
                    }

                    //ALL
                    if (metroCheckBox7.Checked == true)
                    {
                        Process myProcess_All_backup = new Process();
                        myProcess_All_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_All_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & allbackup.bat " + works + " " + mbnfile + " " + backups + "\\" + " " + bakex;
                        myProcess_All_backup.Start();
                        myProcess_All_backup.WaitForExit();
                        //metroCheckBox7.Checked = false;
                    }

                    //userdata
                    if ((metroCheckBox2.Checked == true) && (metroToggle2.Checked == true))
                    {
                        Process myProcess_userdata_backup = new Process();
                        myProcess_userdata_backup.StartInfo.FileName = "cmd.exe";
                        myProcess_userdata_backup.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & backup.bat " + works + " " + mbnfile + " " + "userdata" + " " + backups + "\\" + "userdata" + " " + bakex;
                        myProcess_userdata_backup.Start();
                        myProcess_userdata_backup.WaitForExit();
                        //metroCheckBox2.Checked = false;
                        //metroToggle2.Checked = false;
                    }
                    //
                    //=============================Прошивка разделов=============================
                    //
                    //system
                    if ((metroCheckBox1.Checked == true) && (textBox1.Text != ""))
                    {
                        flasher = textBox1.Text;
                        Process myProcess_sys_flash = new Process();
                        myProcess_sys_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_sys_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "system" + " " + flasher;
                        myProcess_sys_flash.Start();
                        myProcess_sys_flash.WaitForExit();
                        //metroCheckBox1.Checked = false;
                    }

                    //recovery
                    if ((metroCheckBox3.Checked == true) && (textBox3.Text != ""))
                    {
                        flasher = textBox3.Text;
                        Process myProcess_recovery_flash = new Process();
                        myProcess_recovery_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_recovery_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "recovery" + " " + flasher;
                        myProcess_recovery_flash.Start();
                        myProcess_recovery_flash.WaitForExit();
                        //metroCheckBox3.Checked = false;
                    }

                    //boot
                    if ((metroCheckBox4.Checked == true) && (textBox4.Text != ""))
                    {
                        flasher = textBox4.Text;
                        Process myProcess_boot_flash = new Process();
                        myProcess_boot_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_boot_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "boot" + " " + flasher;
                        myProcess_boot_flash.Start();
                        myProcess_boot_flash.WaitForExit();
                        //metroCheckBox4.Checked = false;
                    }

                    //aboot
                    if ((metroCheckBox5.Checked == true) && (textBox5.Text != ""))
                    {
                        flasher = textBox5.Text;
                        Process myProcess_aboot_flash = new Process();
                        myProcess_aboot_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_aboot_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "aboot" + " " + flasher;
                        myProcess_aboot_flash.Start();
                        myProcess_aboot_flash.WaitForExit();
                        //metroCheckBox5.Checked = false;
                    }

                    //vendor
                    if ((metroCheckBox6.Checked == true) && (textBox6.Text != ""))
                    {
                        flasher = textBox6.Text;
                        Process myProcess_vendor_flash = new Process();
                        myProcess_vendor_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_vendor_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "vendor" + " " + flasher;
                        myProcess_vendor_flash.Start();
                        myProcess_vendor_flash.WaitForExit();
                        //metroCheckBox6.Checked = false;
                    }

                    //modem
                    if ((metroCheckBox8.Checked == true) && (textBox9.Text != ""))
                    {
                        flasher = textBox9.Text;
                        Process myProcess_modem_flash = new Process();
                        myProcess_modem_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_modem_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "modem" + " " + flasher;
                        myProcess_modem_flash.Start();
                        myProcess_modem_flash.WaitForExit();
                        //metroCheckBox8.Checked = false;
                    }

                    //other
                    if ((textBox8.Text != "") && ((textBox7.Text != "РАЗДЕЛ НЕ ВВЕДЁН") || (textBox7.Text != "")))
                    {
                        flasher = textBox7.Text;
                        Process myProcess_other_flash = new Process();
                        myProcess_other_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_other_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + textBox8.Text + " " + flasher;
                        myProcess_other_flash.Start();
                        myProcess_other_flash.WaitForExit();
                        //textBox8.Text = "РАЗДЕЛ НЕ ВВЕДЁН";
                        //textBox7.Clear();
                    }

                    //userdata
                    if ((metroCheckBox2.Checked == true) && (textBox2.Text != ""))
                    {
                        flasher = textBox2.Text;
                        Process myProcess_userdata_flash = new Process();
                        myProcess_userdata_flash.StartInfo.FileName = "cmd.exe";
                        myProcess_userdata_flash.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/ewt & flash" + ".bat " + works + " " + mbnfile + " " + "userdata" + " " + flasher;
                        myProcess_userdata_flash.Start();
                        myProcess_userdata_flash.WaitForExit();
                        //metroCheckBox2.Checked = false;
                    }
                }
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e) { if (metroToggle1.Checked) { if (!metroCheckBox1.Checked) { MessageBox.Show( "Активируйте раздел system!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle1.Checked = false; } } }
        private void metroToggle2_CheckedChanged_1(object sender, EventArgs e) { if (metroToggle2.Checked) { if (!metroCheckBox2.Checked) { MessageBox.Show("Активируйте раздел userdata!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle2.Checked = false; } } }
        private void metroToggle3_CheckedChanged(object sender, EventArgs e) { if (metroToggle3.Checked) { if (!metroCheckBox3.Checked) { MessageBox.Show( "Активируйте раздел recovery!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle3.Checked = false; } } }
        private void metroToggle4_CheckedChanged(object sender, EventArgs e) { if (metroToggle4.Checked) { if (!metroCheckBox4.Checked) { MessageBox.Show( "Активируйте раздел boot!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle4.Checked = false; } } }
        private void metroToggle5_CheckedChanged(object sender, EventArgs e) { if (metroToggle5.Checked) { if (!metroCheckBox5.Checked) { MessageBox.Show( "Активируйте раздел aboot!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle5.Checked = false; } } }
        private void metroToggle8_CheckedChanged(object sender, EventArgs e) { if (metroToggle8.Checked) { if (!metroCheckBox8.Checked) { MessageBox.Show("Активируйте раздел modem!","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); metroToggle8.Checked = false; } } }
        private void pictureBox2_Click(object sender, EventArgs e) { try { Process.Start("devmgmt.msc"); } catch { } }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\v.png");
                label6.Text = "Стоковая (v11)";
                label9.Text = "Android 8.1"; 
                label10.ForeColor = Color.Green;
                label10.Text = "ДА";
                label13.ForeColor = Color.Green;
                label13.Text = "НЕТ";
                textBox17.Text = "Заводская прошивка.";
                button4.Text = "2/16";
                button32.Text = "3/32";
                frimwares[0] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92021946";
                frimwares[1] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481";
                frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA";
                frimwares[3] = "V11";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button4_Click(object sender, EventArgs e){ if (frimwares[0] != "blablabla") { try { Process.Start(frimwares[0]); } catch{ MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);} } }
        private void button32_Click(object sender, EventArgs e) { if (frimwares[1] != "blablabla") { try { Process.Start(frimwares[1]); } catch { MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } } }
        private void button37_Click(object sender, EventArgs e) { if (frimwares[2] != "blablabla") { try { Process.Start(frimwares[2]); } catch { MessageBox.Show( "Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } } }
        private void button34_Click(object sender, EventArgs e) { if (frimwares[3] != "blablabla") { try { Process.Start(@Application.StartupPath + @"\DATA\SCREENSHOT\" + frimwares[3] + @"\1.png"); } catch { } } }
        private void button36_Click(object sender, EventArgs e) { if (frimwares[3] != "blablabla") { try { Process.Start(@Application.StartupPath + @"\DATA\SCREENSHOT\" + frimwares[3] + @"\2.png"); } catch { } }  }
        private void button35_Click(object sender, EventArgs e) { if (frimwares[3] != "blablabla") { try { Process.Start(@Application.StartupPath + @"\DATA\SCREENSHOT\" + frimwares[3] + @"\3.png"); } catch { } } }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\v.png");
                label6.Text = "Стоковая (v9)";
                label9.Text = "Android 8.1";
                label10.ForeColor = Color.Green;
                label10.Text = "ДА";
                label13.ForeColor = Color.Green;
                label13.Text = "НЕТ";
                textBox17.Text = "Заводская прошивка.";
                button4.Text = "2/16";
                button32.Text = "3/32";
                frimwares[0] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92021946";
                frimwares[1] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481";
                frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA";
                frimwares[3] = "V9";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\lo151.png");
                label6.Text = "LineageOS 15.1";
                label9.Text = "Android 8.1";
                label10.ForeColor = Color.Blue;
                label10.Text = "ОПЦИОНАЛЬНО";
                label13.ForeColor = Color.Red;
                label13.Text = "ОЧЕНЬ МНОГО";
                textBox17.Text = "Прошивка, основанная на AOSP (Android 8.1) с очень большим количеством настроек.";
                button4.Text = "GAPPS";
                button32.Text = "No GAPPS";
                frimwares[0] = "https://4pda.ru/forum/index.php?act=findpost&pid=86029984&anchor=Spoil-86029984-6";
                frimwares[1] = "https://4pda.ru/forum/index.php?act=findpost&pid=86029984&anchor=Spoil-86029984-6";
                frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86029984";
                frimwares[3] = "LO151";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\oo.png");
                label6.Text = "OctopusOS";
                label9.Text = "Android 9";
                label10.ForeColor = Color.Green;
                label10.Text = "ДА";
                label13.ForeColor = Color.Red;
                label13.Text = "ВОЗМОЖНО";
                textBox17.Text = "Прошивка основанная на AOSP'e.";
                button4.Text = "Скачать";
                button32.Text = "Ещё раз";
                frimwares[0] = "https://yadi.sk/d/cklsb4NNhUFINQ";
                frimwares[1] = "https://yadi.sk/d/cklsb4NNhUFINQ";
                frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86241947";
                frimwares[3] = "OO";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\v.png");
                label6.Text = "Стоковая (v12)";
                label9.Text = "Android 8.1";
                label10.ForeColor = Color.Green;
                label10.Text = "ДА";
                label13.ForeColor = Color.Red;
                label13.Text = "ВОЗМОЖНО";
                textBox17.Text = "Заводская прошивка.";
                button4.Text = "2/16";
                button32.Text = "3/32";
                frimwares[0] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92021946";
                frimwares[1] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92437481";
                frimwares[2] = "https://www.ztedevices.com/en/support/detail?id=B4F82174264A4271990B5943CA6819AA";
                frimwares[3] = "V12";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private string ParseTitle(string htmlCode)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlCode);
            HtmlNode titleNode = null;
            SearchNode(htmlDoc.DocumentNode, ref titleNode);
            return titleNode == null ? string.Empty : titleNode.InnerText;
        }

        private void SearchNode(HtmlNode node, ref HtmlNode result)
        {
            foreach (var curNode in node.ChildNodes)
            {
                if (curNode.Name.Equals("title", StringComparison.CurrentCultureIgnoreCase)) { result = curNode; }
                else { SearchNode(curNode, ref result); }
            }
        }

        private string GetResponse(string uri)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0) { sb.Append(Encoding.Default.GetString(buf, 0, count)); }
            }
            while (count > 0);
            return sb.ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\ho.png");
                label6.Text = "HavocOS 2.6";
                label9.Text = "Android 9";
                label10.ForeColor = Color.Red;
                label10.Text = "НЕТ";
                label13.ForeColor = Color.Red;
                label13.Text = "ВОЗМОЖНО";
                textBox17.Text = "Havoc-OS 2.x is based on AOSP, inspired by Google Pixel." +
                    "Has a refined Material Design 2 UI by @SKULSHADY." +
                    "So many features that you probably won't find in any ROM." +
                    "All you can dream of and all you'll ever need." +
                    "Just flash and enjoy...";
                button4.Text = "Скачать";
                button32.Text = "Ещё раз";
                frimwares[0] = "https://yadi.sk/d/tBSHhWzlJp6-5w";
                frimwares[1] = "https://yadi.sk/d/tBSHhWzlJp6-5w";
                frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=86124087";
                frimwares[3] = "HO";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button33_Click(object sender, EventArgs e) { try { Process.Start("https://4pda.ru/forum/index.php?s=&showtopic=892755&view=findpost&p=71222655"); } catch { MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void metroToggle7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle711.Checked)
            {
                if ((textBox8.Text == "") || (textBox8.Text == " "))
                {
                    MessageBox.Show("Введите необходимый раздел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroToggle711.Checked = false;
                }
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e) { try { Process.Start("https://4pda.ru/forum/index.php?showtopic=950607"); } catch { MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            foreach (Form F in Application.OpenForms) { if (F.Name == "InfoForm") { fs = 1; } else { fs = 0; } }
            if (fs == 0) { f = new InfoForm(); f.Show(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox8.Text == " ")
            {
                textBox7.ReadOnly = true;
                textBox7.Text = "РАЗДЕЛ НЕ ВВЕДЁН";
                metroToggle711.Checked = false;
            }
            else
            {
                textBox7.ReadOnly = false;
                textBox7.Text = "";
                metroToggle711.Checked = true;
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
            foreach (Form F in Application.OpenForms) { if (F.Name == "DelForm") { fs = 1; } else { fs = 0; } }
            if (fs == 0) { f = new DelForm(); f.Show(); }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            foreach (Form F in Application.OpenForms) { if (F.Name == "ChangelogForm") { fs = 1; } else { fs = 0; } }
            if (fs == 0) { f = new ChangelogForm(); f.Show(); }
        }

        private void pictureBox17_Click(object sender, EventArgs e) { try { Process.Start("https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=91409816"); } catch { MessageBox.Show( "Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.ReadOnly == false)
            {
                textBox1.Text = "";
                openFileDialog1.Title = "Открытие файла прошивки";
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox1.Text = openFileDialog1.FileName; }
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.ReadOnly == false)
            {
                textBox2.Text = "";
                openFileDialog1.Title = "Открытие файла прошивки";
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox2.Text = openFileDialog1.FileName; }
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.ReadOnly == false)
            {
                textBox3.Text = "";
                openFileDialog1.Title = "Открытие файла прошивки";
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox3.Text = openFileDialog1.FileName; }
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.ReadOnly == false)
            {
                textBox4.Text = "";
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox4.Text = openFileDialog1.FileName; }
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.ReadOnly == false)
            {
                textBox5.Text = "";
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "Открытие файла прошивки";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox5.Text = openFileDialog1.FileName; }
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.ReadOnly == false)
            {
                textBox6.Text = "";
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox6.Text = openFileDialog1.FileName; }
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.ReadOnly == false)
            {
                textBox7.Text = "";
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "Открытие файла прошивки";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox7.Text = openFileDialog1.FileName; }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\ho.png");
                label6.Text = "HavocOS 3.0";
                label9.Text = "Android 10";
                label10.ForeColor = Color.Red;
                label10.Text = "НЕТ";
                label13.ForeColor = Color.Red;
                label13.Text = "ВОЗМОЖНО";
                textBox17.Text = "Havoc-OS 3.x is based on AOSP, inspired by Google Pixel." +
                    "Has a refined Material Design 2 UI by @SKULSHADY." +
                    "So many features that you probably won't find in any ROM." +
                    "All you can dream of and all you'll ever need." +
                    "Just flash and enjoy...";
                button4.Text = "Скачать";
                button32.Text = "Ещё раз";
                frimwares[0] = "https://sourceforge.net/projects/expressluke-gsis/files/HavocOS/Ten/ARM64/A/Havoc-OS-v3.0-20191225-ARM64A-Unofficial.img.xz/download";
                frimwares[1] = "https://sourceforge.net/projects/expressluke-gsis/files/HavocOS/Ten/ARM64/A/Havoc-OS-v3.0-20191225-ARM64A-Unofficial.img.xz/download";
                frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92530905";
                frimwares[3] = "HO3"; // Папка прошивки
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\BootleggersROM.png");
                label6.Text = "BootleggersROM";
                label9.Text = "Android 9";
                label10.ForeColor = Color.Red;
                label10.Text = "НЕТ";
                label13.ForeColor = Color.Green;
                label13.Text = "НЕТ";
                textBox17.Text = "Довольно красивая прошивка версии 4.1 на Android 9, правленная nFound.";
                button4.Text = "Mail.ru";
                button32.Text = "A.Host";
                frimwares[0] = "https://cloud.mail.ru/public/2XXK/3LCBhc8eq";
                frimwares[1] = "https://androidfilehost.com/?w=files&flid=291038&sort_by=date&sort_dir=DESC";
                frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=87734060";
                frimwares[3] = "BootleggersROM";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\ao.png");
                label6.Text = "ArrowOS";
                label9.Text = "Android 10";
                label10.ForeColor = Color.Red;
                label10.Text = "НЕТ";
                label13.ForeColor = Color.Red;
                label13.Text = "НЕИЗВЕСТНО";
                textBox17.Text = "ArrowOS is an AOSP based project started with the aim of keeping things simple, " +
                    "clean and neat. We added just the right and mostly used stuff that will be actually USEFUL " +
                    "at the end of the day, aiming to deliver smooth performance with better battery life.";
                button4.Text = "Скачать";
                button32.Text = "Ещё раз";
                frimwares[0] = "https://sourceforge.net/projects/gsi-albus/files/arm64-aonly/android10/arrow/arrow-11-02-2020.7z/download";
                frimwares[1] = "https://sourceforge.net/projects/gsi-albus/files/arm64-aonly/android10/arrow/arrow-11-02-2020.7z/download";
                frimwares[2] = "https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=92619499";
                frimwares[3] = "AO";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void pictureBox21_Click(object sender, EventArgs e)
        {
            portal = SerialPort.GetPortNames();
            if (portal.Length != 0)
            {
                for (int i = 0; i < portal.Length; i++) { dfu1 = portal[i].ToString(); }
                textBox19.Text = dfu1.Remove(0, 3);
            }
            else { MessageBox.Show("COM порт не обнаружен!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                textBox14.Text = "Введите имя файла для установки (с расширением)";
                textBox14.ForeColor = Color.Gray;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox11.Text = "Введите имя пакета приложения";
                textBox11.ForeColor = Color.Gray;
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e) { try { Process.Start("https://t.me/ZTEBV9VitaNews"); } catch { MessageBox.Show("Браузер по умолчанию не настроен!","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error); } }

        private void bakdir_TextChanged(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita"))
            {
                reg.SetValue("BackupPath", bakdir.Text);
                backups = bakdir.Text;
                if (backups == "") { bakdir.Text = @Application.StartupPath + @"\EWT\backups"; }
            }
        }

        private void flasherdir_TextChanged(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita"))
            {
                reg.SetValue("Flasher", flasherdir.Text);
                mbnfile = flasherdir.Text;
                if (mbnfile == "") { flasherdir.Text = @Application.StartupPath + @"\flasher.mbn"; ; }
            }
        }

        private void fileEx_TextChanged(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita"))
            {
                reg.SetValue("FileExtension", fileEx.Text);
                bakex = fileEx.Text;
                if (bakex == "") { fileEx.Text = "img"; ; }
            }
        }

        private void flasherdir_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Открытие MBN файла";
            openFileDialog1.Filter = "Прошивальщик|*.mbn";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { flasherdir.Text = openFileDialog1.FileName; }
            else { flasherdir.Clear(); }
        }

        private void bakdir_Click(object sender, EventArgs e)
        {
            var dialog = new FolderDialog { InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), Title = "Укажите нужную папку" };
            if (dialog.Show()) { bakdir.Text = dialog.FileName; }
            else { bakdir.Clear(); }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { try { Process.Start("https://4pda.ru/forum/index.php?showtopic=993643"); } catch { MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void button5_Click(object sender, EventArgs e) { panel2.Hide(); Properties.Settings.Default.HideAC = true; Properties.Settings.Default.Save(); }

        private void button9_Click(object sender, EventArgs e)
        {
			bool IsPhoto = false;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    Uri user = new Uri("https://4pda.ru/forum/index.php?showuser=" + UserID1.Text);
                    string htmlCode = GetResponse(user.ToString());
                    string username = ParseTitle(htmlCode).Replace(" - 4PDA", "");
                    wc.DownloadFile(user, @Application.StartupPath + @"\DATA\profile.dat");
                    string[] profile = File.ReadAllLines(@Application.StartupPath + @"\DATA\profile.dat", Encoding.Default);
                    File.Delete(@Application.StartupPath + @"\DATA\profile.dat");
                    for (int i = 0; i < profile.Length; i++)
                    {
                        if (profile[i].Contains("photo") && (IsPhoto == false))
                        {
                            try
                            {
                                avp = Convert.ToString("http:" + profile[i + 1].Replace("			<img src=\"", "").Replace("\" border=\"0\" alt=\"Аватар\" title=\"" + username + "\"/>", ""));
                                wc.DownloadFile(avp, @Application.StartupPath + @"\DATA\avatar.dat"); 
                                avatarAuth1.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat";
								IsPhoto = true;
                            }
                            catch
                            {
                                char[] charArray = username.ToCharArray();
                                username = Convert.ToString(charArray[0]).ToLower() + username.Remove(0, 1);
                                avp = Convert.ToString("http:" + profile[i + 1].Replace("			<img src=\"", "").Replace("\" border=\"0\" alt=\"Аватар\" title=\"" + username + "\"/>", ""));
                                wc.DownloadFile(avp, @Application.StartupPath + @"\DATA\avatar.dat");
                                avatarAuth1.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat";
								IsPhoto = true;
                            }
							if (File.Exists(@Application.StartupPath + @"\DATA\avatar.dat") == false) { avatarAuth1.Image = Properties.Resources.StandardAvatar; }
                        }
                    }
                    helloUser1.Text += username + "!";
                    button16.Visible = true;
                    button13.Visible = true;
                    metroLabel14.Visible = true;
                    helloUser1.Visible = true;
                    avatarAuth1.Visible = true;
                    UserID1.Enabled = false;
                }
            }
            catch { MessageBox.Show("Данного ID не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pictureBox20_Click(object sender, EventArgs e) { try { Process.Start("https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=93481168"); } catch { MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }
        private void avatar_Click(object sender, EventArgs e) { try { Process.Start("https://4pda.ru/forum/index.php?showuser=" + id); } catch { MessageBox.Show("Браузер по умолчанию не настроен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); } }

        private void button42_Click(object sender, EventArgs e)
        {
			bool IsPhoto = false;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    Uri user = new Uri("https://4pda.ru/forum/index.php?showuser=" + UserID2.Text);
                    string htmlCode = GetResponse(user.ToString());
                    string username = ParseTitle(htmlCode).Replace(" - 4PDA", "");
                    wc.DownloadFile(user, @Application.StartupPath + @"\DATA\profile.dat");
                    string[] profile = File.ReadAllLines(@Application.StartupPath + @"\DATA\profile.dat", Encoding.Default);
                    File.Delete(@Application.StartupPath + @"\DATA\profile.dat");
                    for (int i = 0; i < profile.Length; i++)
                    {
                        if (profile[i].Contains("photo") && (IsPhoto == false))
                        {
                            try
                            {
                                string avp = Convert.ToString("http:" + profile[i + 1].Replace("			<img src=\"", "").Replace("\" border=\"0\" alt=\"Аватар\" title=\"" + username + "\"/>", ""));
                                wc.DownloadFile(avp, @Application.StartupPath + @"\DATA\avatar.dat");
                                avatarAuth2.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat";
								IsPhoto = true;
                            }
                            catch
                            {
                                char[] charArray = username.ToCharArray();
                                username = Convert.ToString(charArray[0]).ToLower() + username.Remove(0, 1);
                                avp = Convert.ToString("http:" + profile[i + 1].Replace("			<img src=\"", "").Replace("\" border=\"0\" alt=\"Аватар\" title=\"" + username + "\"/>", ""));
                                wc.DownloadFile(avp, @Application.StartupPath + @"\DATA\avatar.dat");
                                avatarAuth2.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat";
								IsPhoto = true;
                            }
							if (File.Exists(@Application.StartupPath + @"\DATA\avatar.dat") == false) { avatarAuth2.Image = Properties.Resources.StandardAvatar; }
                        }
                    }
                    helloUser2.Text += username + "!";
                    button39.Visible = true;
                    button19.Visible = true;
                    metroLabel15.Visible = true;
                    helloUser2.Visible = true;
                    avatarAuth2.Visible = true;
                    UserID2.Enabled = false;
                }
            }
            catch { MessageBox.Show("Данный ID не является подлинным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita")) { reg.SetValue("ID", UserID2.Text); }
            id = UserID2.Text;
            panel3.Visible = false;
            panel4.Visible = false;
            avatar.Visible = true;
            try { avatar.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat"; } catch { avatar.Image = Properties.Resources.StandardAvatar; }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            metroTabControl1.Visible = false;
            avatar.Visible = false;
            avatar.Enabled = false;
            Properties.Settings.Default.HideAC = false;
            Properties.Settings.Default.Save();
            try { File.Delete(@Application.StartupPath + @"\DATA\avatar.dat"); } catch { }
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita"))
                {
                    try { reg.DeleteValue("ID"); } catch { }
                    try { reg.DeleteValue("BackupPath"); } catch { }
                    try { reg.DeleteValue("Flasher"); } catch { }
                    try { reg.DeleteValue("FileExtension"); } catch { }
                }
            } catch { }
            MessageBox.Show("Операция завершена!\nСейчас приложение закроется.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                avatar.Enabled = false;
                try { File.Delete(@Application.StartupPath + @"\DATA\avatar_old.dat"); } catch { }
                File.Move(@Application.StartupPath + @"\DATA\avatar.dat", @Application.StartupPath + @"\DATA\avatar_old.dat");
            } catch { }
            string str = "adb";
            foreach (Process process2 in Process.GetProcesses()) { if (process2.ProcessName.ToLower().Contains(str.ToLower())) { process2.Kill(); } }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { MessageBox.Show("1. Откройте свой профиль на 4PDA\n2. Скопируйте цифры из адресной строки (ссылка), которые идут после 'showuser='\n3. Вставьте цифры в текстовое поле и авторизуйтесь", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void textBox9_Click(object sender, EventArgs e)
        {
            if (textBox9.ReadOnly == false)
            {
                textBox9.Text = "";
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "Открытие файла прошивки";
                openFileDialog1.Filter = "Файл прошивки|*.img|Классический файл прошивки| *.bin";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) { textBox9.Text = openFileDialog1.FileName; }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { pictureBox1.Image = Properties.Resources.Logo4; }
        private void UserID1_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = (!(Char.IsDigit(e.KeyChar)) && !(Char.IsControl(e.KeyChar))); }
        private void UserID2_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = (!(Char.IsDigit(e.KeyChar)) && !(Char.IsControl(e.KeyChar))); }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = (!(Char.IsDigit(e.KeyChar)) && !(Char.IsControl(e.KeyChar))); }

        private void button19_Click(object sender, EventArgs e)
        {
            helloUser1.Text = "Приветсвую тебя, ";
            helloUser2.Text = "Приветсвую тебя, ";
            button16.Visible = false;
            button13.Visible = false;
            button19.Visible = false;
            button39.Visible = false;
            metroLabel14.Visible = false;
            metroLabel15.Visible = false;
            helloUser1.Visible = false;
            avatarAuth1.Visible = false;
            UserID1.Clear();
            UserID1.Enabled = true;
            helloUser2.Visible = false;
            avatarAuth2.Visible = false;
            UserID2.Clear();
            UserID2.Enabled = true;
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita")) { reg.SetValue("ID", ""); }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita")) { reg.SetValue("ID", UserID1.Text); }
            id = UserID1.Text;
            panel3.Visible = false;
            panel4.Visible = false;
            avatar.Visible = true;
            try { avatar.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat"; } catch { avatar.Image = Properties.Resources.StandardAvatar; }
        }

        private void button41_Click(object sender, EventArgs e) { try { Process.Start(@Application.StartupPath + @"\DATA\dev.png"); } catch { } }

        private void button40_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\aex_v.png");
                label6.Text = "AEX 5.8 (AospExtended)";
                label9.Text = "Android 8.1";
                label10.ForeColor = Color.Blue;
                label10.Text = "ОПЦИОНАЛЬНО";
                label13.ForeColor = Color.Red;
                label13.Text = "ДА";
                textBox17.Text = "Кастомный Android, основанный на AOSP и имеющий множество настроек для кастомизации системы.";
                button4.Text = "GAPPS";
                button32.Text = "No GAPPS";
                frimwares[0] = "http://4pda.ru/forum/index.php?act=findpost&pid=93874587&anchor=Spoil-93874587-8";
                frimwares[1] = "http://4pda.ru/forum/index.php?act=findpost&pid=93874587&anchor=Spoil-93874587-7";
                frimwares[2] = "http://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=93874587";
                frimwares[3] = "AEX_V";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.Load(@Application.StartupPath + @"\DATA\LOGO\aex.png");
                label6.Text = "AEX 6.5 (AospExtended)";
                label9.Text = "Android 9";
                label10.ForeColor = Color.Red;
                label10.Text = "НЕТ";
                label13.ForeColor = Color.Red;
                label13.Text = "ДА";
                textBox17.Text = "Кастомный Android, основанный на AOSP и имеющий множество настроек для кастомизации системы.";
                button4.Text = "Скачать";
                button32.Text = "Ещё раз";
                frimwares[0] = "https://androidfilehost.com/?fid=1395089523397949479";
                frimwares[1] = "https://androidfilehost.com/?fid=1395089523397949479";
                frimwares[2] = "http://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=85452591";
                frimwares[3] = "AEX";
            } catch { MessageBox.Show("Данные для показа не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/adb & adb.bat";
            myProcess.Start();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            Task.Run(() => ADBCommander("install -d " + @Application.StartupPath + @"\ADB\InstallAPK\root\mm.apk"));
            textBox13.Text = adba;
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
                MessageBox.Show("Обязательно обновите номер COM порта!","Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            if (textBox19.Text.Length == 0) { MessageBox.Show( "Номер COM порта не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frimwares = new string[4];
            textBox11.Text = "Введите имя пакета приложения";
            textBox11.ForeColor = Color.Gray;
            textBox14.Text = "Введите имя файла для установки (с расширением)";
            textBox14.ForeColor = Color.Gray;
            try
            {
                pictureBox6.Load(@Application.StartupPath + @"\DATA\LOGO\v.png");
                pictureBox3.Load(@Application.StartupPath + @"\DATA\LOGO\v.png");
                pictureBox10.Load(@Application.StartupPath + @"\DATA\LOGO\v.png");
                pictureBox4.Load(@Application.StartupPath + @"\DATA\LOGO\lo151.png");
                pictureBox5.Load(@Application.StartupPath + @"\DATA\LOGO\oo.png");
                pictureBox7.Load(@Application.StartupPath + @"\DATA\LOGO\ho.png");
                pictureBox8.Load(@Application.StartupPath + @"\DATA\LOGO\BootleggersROM.png");
                pictureBox9.Load(@Application.StartupPath + @"\DATA\LOGO\ho.png");
                pictureBox12.Load(@Application.StartupPath + @"\DATA\LOGO\ao.png");
                pictureBox18.Load(@Application.StartupPath + @"\DATA\LOGO\aex.png");
                pictureBox25.Load(@Application.StartupPath + @"\DATA\LOGO\aex_v.png");
            } catch { }
            frimwares[0] = "blablabla";
            frimwares[1] = "blablabla";
            frimwares[2] = "blablabla";
            frimwares[3] = "blablabla";
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\NineVita"))
            {
                backups = Convert.ToString(reg.GetValue("BackupPath"));
                if (backups == "") { backups = @Application.StartupPath + @"\EWT\backups"; } bakdir.Text = backups;
                mbnfile = Convert.ToString(reg.GetValue("Flasher"));
                if (mbnfile == "") { mbnfile = @Application.StartupPath + @"\flasher.mbn"; } flasherdir.Text = mbnfile;
                bakex = Convert.ToString(reg.GetValue("FileExtension"));
                if (bakex == "") { bakex = "img"; } fileEx.Text = bakex;
                id = Convert.ToString(reg.GetValue("ID"));
            }
            if (id != "")
            {
				bool IsPhoto = false;
                try
                {

                    using (WebClient wc = new WebClient())
                    {
                        Uri user = new Uri("https://4pda.ru/forum/index.php?showuser=" + id);
                        string htmlCode = GetResponse(user.ToString());
                        string username = ParseTitle(htmlCode).Replace(" - 4PDA", "");
                        wc.DownloadFile(user, @Application.StartupPath + @"\DATA\profile.dat");
                        string[] profile = File.ReadAllLines(@Application.StartupPath + @"\DATA\profile.dat", Encoding.Default);
                        File.Delete(@Application.StartupPath + @"\DATA\profile.dat");
                        for (int i = 0; i < profile.Length; i++)
                        {
                            if (profile[i].Contains("photo") && (IsPhoto == false))
                            {
                                try
                                {
                                    string avp = Convert.ToString("http:" + profile[i + 1].Replace("			<img src=\"", "").Replace("\" border=\"0\" alt=\"Аватар\" title=\"" + username + "\"/>", ""));
                                    wc.DownloadFile(avp, @Application.StartupPath + @"\DATA\avatar.dat");
                                    avatar.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat";
									IsPhoto = true;
                                }
                                catch
                                {
                                    char[] charArray = username.ToCharArray();
                                    username = Convert.ToString(charArray[0]).ToLower() + username.Remove(0, 1);
                                    avp = Convert.ToString("http:" + profile[i + 1].Replace("			<img src=\"", "").Replace("\" border=\"0\" alt=\"Аватар\" title=\"" + username + "\"/>", ""));
                                    wc.DownloadFile(avp, @Application.StartupPath + @"\DATA\avatar.dat");
                                    avatar.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat";
									IsPhoto = true;
                                }
								if (File.Exists(@Application.StartupPath + @"\DATA\avatar.dat") == false) { avatar.Image = Properties.Resources.StandardAvatar; }
                            }
                            avatar.Visible = true;
                        }
                    }
                }
                catch 
                {
                    avatar.Hide();
                    try { File.Move(@Application.StartupPath + @"\DATA\avatar_old.dat", @Application.StartupPath + @"\DATA\avatar.dat"); } catch { }
                    try { avatar.ImageLocation = @Application.StartupPath + @"\DATA\avatar.dat"; avatar.Visible = true; } catch { }
                }
                panel3.Visible = false;
                panel4.Visible = false;
            }
            if (Properties.Settings.Default.HideAC == true) { panel2.Visible = false; }
            if (File.Exists(@Application.StartupPath + @"\DATA\avatar.dat") == false) { avatar.Visible = false; }
        }

        private void ADBCommander(string command)
        {
            Process process1 = new Process();
            process1.StartInfo.FileName = "cmd.exe";
            process1.StartInfo.Arguments = "/C " + @Application.StartupPath + "/adb & adb.exe " + command;
            process1.StartInfo.RedirectStandardOutput = true;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.CreateNoWindow = true;
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process1.Start();
            process1.WaitForExit();
            if ((command == "devices") || (command == "get-state")) { textBox10.Text = process1.StandardOutput.ReadToEnd(); }
            string str = "adb";
            foreach (Process process2 in Process.GetProcesses()) { if (process2.ProcessName.ToLower().Contains(str.ToLower())){ process2.Kill(); } }
            if ((command != "devices") && (command != "get-state")) { MessageBox.Show("Выполнено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); adba = process1.StandardOutput.ReadToEnd(); }
        }
    }
}