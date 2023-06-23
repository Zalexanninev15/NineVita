using System;
using System.Windows.Forms;
namespace NineVita
{
    public partial class DelForm : Form
    {
        public DelForm() { InitializeComponent(); this.Size = new System.Drawing.Size(396, 458); }
        private void button1_Click(object sender, EventArgs e) { this.Close(); }
    }
}