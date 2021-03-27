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
    public partial class Tags : Form
    {
        int weight = 3;
        int height = 3;
        Button[,] buttons;
        List<Image> images;
        public Tags()
        {
            InitializeComponent();
        }

        private void Tags_Load(object sender, EventArgs e)
        {
            FillTheArrayOfButtons();
            images = new List<Image>();
            buttons = new Button[weight, height];
            for (int i = 1; i < weight * height; i++)
            {
                Bitmap img = new Bitmap(@"C:\Users\orochi\source\repos\Project G\Project G\img\Tags\Dragons\"+i+".jpg");
                images.Add(img);
                    //Image.FromFile("C:\\Users\\orochi\\source\\repos\\Project G\\Project G\\img\\Tags\\Dragons\\1.jpg"));
            }
            SetUpGame();
        }

        private void SetUpGame()
        {
            Random rand = new Random();
            for (int x = 0; x < weight; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int randomImageIndex = rand.Next(0, images.Count);
                    buttons[x, y].Image = images[randomImageIndex];
                    images.RemoveAt(randomImageIndex);
                }
            }
        }


        private void FillTheArrayOfButtons()
        {
            buttons = new Button[3, 3];
            buttons[0, 0] = button1;
            buttons[1, 0] = button2;
            buttons[2, 0] = button3;
            buttons[0, 1] = button4;
            buttons[1, 1] = button5;
            buttons[2, 1] = button6;
            buttons[0, 2] = button7;
            buttons[1, 2] = button8;
            buttons[2, 2] = button9;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Image != null)
            {
                for (int x = 0; x < weight; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (buttons[x, y] == but)
                        {
                            CheckNeighbors(but.Location.X, but.Location.Y);
                        }
                    }
                }
            }
        }
        private void CheckNeighbors(int xB, int yB)
        {
            for (int x = xB - 1; x < xB + 1; x++)
            {
                for (int y = yB - 1; y < yB + 1; x++)
                {
                    if (x >= 0 && x < weight && y >= 0 && y < height && (xB == x||yB==y))
                    {
                        if (buttons[x, y].Image == null)
                        {
                            buttons[x, y].Image = buttons[xB, yB].Image;
                            buttons[xB, yB].Image = null;
                        }
                    }
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
