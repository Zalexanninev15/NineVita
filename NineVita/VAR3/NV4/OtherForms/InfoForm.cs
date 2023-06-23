using System;
using System.Windows.Forms;
namespace NineVita
{
    public partial class InfoForm : Form
    {
        public InfoForm() { InitializeComponent(); }
        private void Form8_Load(object sender, EventArgs e) { this.ControlBox = false; this.Size = new System.Drawing.Size(458, 229); }
        private void button1_Click(object sender, EventArgs e) { this.Close(); }
    }
}