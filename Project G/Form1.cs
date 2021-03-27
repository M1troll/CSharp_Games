using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_G
{
    public partial class Project_G : Form
    {
        public Project_G()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XO_Click(object sender, EventArgs e)
        {
            XO form = new XO();
            form.ShowDialog();
        }

        private void Sappering_Click(object sender, EventArgs e)
        {
            Sapper form = new Sapper();
            form.ShowDialog();
        }

        private void CreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оболенинов Антон\n\rE-mail : oboleninoff.anton@yandex.ru\n\rInstagram : @t1roller\n\rVk : id392548774\n\rIMAM");
        }

        private void Taging_Click(object sender, EventArgs e)
        {
            Tags form = new Tags();
            form.ShowDialog();
        }

        private void K2048_Click(object sender, EventArgs e)
        {
            G2048 form = new G2048();
            form.ShowDialog();
        }
    }
}
