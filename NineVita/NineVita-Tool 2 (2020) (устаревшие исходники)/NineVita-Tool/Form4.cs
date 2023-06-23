using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using SharpConfig;

namespace NineVita_Tool
{
    public partial class Form4 : Form
    {
        string nametool, donet;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Может вы когда-нибудь передумаете?",
            "Вопрос",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RightAlign);
            MessageBox.Show(
            "Мне без разницы что вы ответили, вы меня обидели :(",
            "Ответ",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RightAlign);
            Application.Exit();
        }
    }
}
