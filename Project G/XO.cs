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
    public partial class XO : Form
    {
        public bool xTurn { get; set; } = true;
        public XO()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button senderB = (Button)sender;
            if (senderB.Text == "")
            {
                senderB.Font = new Font("Arial", 25, FontStyle.Bold);
                if (xTurn)
                {
                    senderB.Text = "X";
                }
                else
                {
                    senderB.Text = "O";
                }
                xTurn = !xTurn;
            }
            Check_Win(senderB);
        }
        private void ClearTable()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }
        private void Check_Win(Button pressBut)
        {
            if (button1.Text == button2.Text && button2.Text == button3.Text && button2.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button5.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button7.Text == button8.Text && button8.Text == button9.Text && button8.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button4.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button2.Text == button5.Text && button5.Text == button8.Text && button5.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button3.Text == button6.Text && button6.Text == button9.Text && button6.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button5.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            else if (button3.Text == button5.Text && button5.Text == button7.Text && button5.Text != "")
            {
                MessageBox.Show("Победили " + pressBut.Text + "-ки !");
                ClearTable();
            }
            if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                MessageBox.Show("Ничья !");
                ClearTable();
            }

        }
        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTable();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оболенинов Антон\n\rE-mail : oboleninoff.anton@yandex.ru\n\rInstagram : @t1roller\n\rVk : id392548774\n\rIMAM");
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xTurn = true;
            ClearTable();
        }

        private void OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xTurn = false;
            ClearTable();
        }
    }
}
