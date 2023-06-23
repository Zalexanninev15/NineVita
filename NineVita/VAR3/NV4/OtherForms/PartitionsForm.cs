using System;
using System.Windows.Forms;
namespace NineVita
{
    public partial class PartitionsForm : Form
    {
        public PartitionsForm() { InitializeComponent(); this.Size = new System.Drawing.Size(450, 370); }
        private void button1_Click(object sender, EventArgs e) { this.Close(); }
    }
}
