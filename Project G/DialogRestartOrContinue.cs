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
    public partial class DialogRestartOrContinue : Form
    {
        char b = '1';
        public DialogRestartOrContinue()
        {
            InitializeComponent();
        }
        public DialogRestartOrContinue(string question)
        {
            InitializeComponent();
            QLabel.Text = question;
        }

        public new char DialogResult()
        {
            return b;
        }

        private void QContinue(object sender, EventArgs e)
        {
            Close();
            b = '0';
        }

        private void QRestart(object sender, EventArgs e)
        {
            Close();
            b = '1';
        }
        private void DialogRestartOrContinue_Close(object sender, EventArgs e)
        {
            b='1';
        }
        private void DialogRestartOrContinue_Load(object sender, EventArgs e)
        {
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
            b = '2';   
        }
    }
}
