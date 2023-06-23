using System;
using System.Windows.Forms;

namespace NineVita_Tool
{
    public partial class SecretForm : Form
    {
        public SecretForm()
        {
            InitializeComponent();
        }

        private void SecretForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://fanserials.network/infinity-train/");
            this.Close();
        }
    }
}
