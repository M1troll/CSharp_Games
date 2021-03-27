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
    public partial class G2048 : Form
    {
        Timer timer = new Timer();
        string Time = "";
        int min = 0;
        int h = 0;
        int timerCounter = 0;
        public byte[,] map = new byte[4, 4];
        public Label[,] labels = new Label[4, 4];
        public PictureBox[,] pics = new PictureBox[4, 4];
        public int score = 0;
        int maxBlock = 2;
        public byte questionEnd =0;
        byte checkFirstClick = 0;
        byte continueG = 1;
        int countBlocks = 2;
        public G2048()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(_keyboardEvent);

            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_TicK);
        }

        private void G2048_Load(object sender, EventArgs e)
        {
            map[0, 0] = 1;
            map[0, 1] = 1;
            createMap();
            createPics();
        }

        private void createMap()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic= new PictureBox();
                    pic.Location = new Point(12+106*j, 94+106*i);
                    pic.BackColor = Color.Gray;
                    pic.Size = new Size(100, 100);
                    this.Controls.Add(pic);
                }
            }
        }
        private void createNewPic()
        {
            Random rnd = new Random();
            int a = rnd.Next(0,4);
            int b = rnd.Next(0,4);
            while (pics[a, b]!=null)
            {
                a = rnd.Next(0, 4);
                b = rnd.Next(0, 4);
            }
            map[a, b] = 1;
            pics[a, b] = new PictureBox();
            labels[a, b] = new Label();
            labels[a, b].Text = "2";
            labels[a, b].Size = new Size(100, 100);
            labels[a, b].TextAlign = ContentAlignment.MiddleCenter;
            labels[a, b].Font = new Font(new FontFamily("Microsoft Sans Serif"), 20);
            pics[a, b].Controls.Add(labels[a, b]);
            pics[a, b].Location = new Point(12+b*106, 94+a*106);
            pics[a, b].BackColor = Color.Khaki;
            pics[a, b].Size = new Size(100, 100);
            this.Controls.Add(pics[a, b]);
            pics[a, b].BringToFront();
        }
        private void createPics()
        {
            pics[0, 0] = new PictureBox();
            labels[0, 0] = new Label();
            labels[0, 0].Text = "2";
            labels[0, 0].Size = new Size(100, 100);
            labels[0, 0].TextAlign = ContentAlignment.MiddleCenter;
            labels[0, 0].Font = new Font(new FontFamily("Microsoft Sans Serif"), 20);
            pics[0, 0].Controls.Add(labels[0, 0]);
            pics[0, 0].Location = new Point(12, 94);
            pics[0, 0].BackColor = Color.Khaki;
            pics[0, 0].Size = new Size(100, 100);
            this.Controls.Add(pics[0, 0]);
            pics[0, 0].BringToFront();

            pics[0, 1] = new PictureBox();
            labels[0, 1] = new Label();
            labels[0, 1].Text = "2";
            labels[0, 1].Size = new Size(100, 100);
            labels[0, 1].TextAlign = ContentAlignment.MiddleCenter;
            labels[0, 1].Font = new Font(new FontFamily("Microsoft Sans Serif"), 20);
            pics[0, 1].Controls.Add(labels[0, 1]);
            pics[0, 1].Location = new Point(118, 94);
            pics[0, 1].BackColor = Color.Khaki;
            pics[0, 1].Size = new Size(100, 100);
            this.Controls.Add(pics[0, 1]);
            pics[0, 1].BringToFront();
        }
        private void changeColor(int sum,int x,int y)
        {
            if (sum == 4) { pics[x, y].BackColor = Color.Pink;}
            else if (sum == 8) { pics[x, y].BackColor = Color.FromArgb(255, 165, 0);  }
            else if (sum == 16) { pics[x, y].BackColor = Color.FromArgb(255, 165, 79); }
            else if (sum == 32) { pics[x, y].BackColor = Color.FromArgb(255, 52, 179); }
            else if (sum == 64) { pics[x, y].BackColor = Color.FromArgb(244, 164, 96); }
            else if (sum == 128) { pics[x, y].BackColor = Color.FromArgb(205, 133, 63); }
            else if (sum == 256) { pics[x, y].BackColor = Color.FromArgb(255, 48, 48); }
            else if (sum == 512) { pics[x, y].BackColor = Color.FromArgb(255, 106, 106); }
            else if (sum == 1024) { pics[x, y].BackColor = Color.FromArgb(255, 69, 0); }
            else if (sum == 2048)
            {
                pics[x, y].BackColor = Color.Red;
                if (questionEnd == 0)
                {
                    DialogRestartOrContinue form = new DialogRestartOrContinue($"Congratulation !\n\rYou win !\n\rYour score : {score}\n\rDo you want to cotinue the game ?");
                    form.ShowDialog();
                    if (form.DialogResult() == '1')
                    {
                        RestartMenu_Click(0, null);
                    }
                    else if (form.DialogResult() == '0')
                    {
                        questionEnd = 1;
                    }
                    else
                    {
                        Exit_Click(0, null);
                    }
                }
            }
            else if (sum == 4096) { pics[x, y].BackColor = Color.Green; labels[x, y].ForeColor = Color.White; }
            else if (sum == 8192) { pics[x, y].BackColor = Color.Brown; labels[x, y].ForeColor = Color.White; }
            else if (sum == 16384) { pics[x, y].BackColor = Color.Black;labels[x,y].ForeColor=Color.White ; }
            if(sum>maxBlock) maxBlock = sum;
        }
        private void EndGame()
        {
            maxBlock = 2;
            score = 0;
            Score.Text = $"Score : {score}";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map[i, j] = 0;
                    this.Controls.Remove(pics[i, j]);
                    this.Controls.Remove(labels[i, j]);
                }
            }
            G2048_Load(0,null);
        }

        private void _keyboardEvent(object sender, KeyEventArgs e)
        {
            string codeKey = e.KeyCode.ToString();
            countBlocks = 2;
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (map[a, b] == 1)
                    {
                        countBlocks++;
                    }
                }
            }
            if (continueG == 1)//&&CheckEND()
            {
                switch (codeKey)
                {
                    case "Right":
                        for (int k = 0; k < 4; k++)
                        {
                            for (int l = 2; l >= 0; l--)
                            {
                                if (map[k, l] == 1)
                                {
                                    for (int j = l + 1; j < 4; j++)
                                    {
                                        if (map[k, j] == 0)
                                        {
                                            map[k, j - 1] = 0;
                                            map[k, j] = 1;
                                            pics[k, j] = pics[k, j - 1];
                                            pics[k, j - 1] = null;
                                            labels[k, j] = labels[k, j - 1];
                                            labels[k, j - 1] = null;
                                            pics[k, j].Location = new Point(pics[k, j].Location.X + 106, pics[k, j].Location.Y);
                                        }
                                        else
                                        {
                                            //CheckEND(k, j, "Right");
                                            Connection(k, j, "Right");
                                            //int a = int.Parse(labels[k, j].Text);
                                            //int b = int.Parse(labels[k, j-1].Text);
                                            //if (a == b)
                                            //{
                                            //    score += (a + b);
                                            //    Score.Text = "Score : " + score;
                                            //    labels[k, j].Text = (a + b).ToString();
                                            //    map[k, j-1] = 0;
                                            //    this.Controls.Remove(pics[k, j-1]);
                                            //    this.Controls.Remove(labels[k, j-1]);
                                            //    pics[k, j - 1] = null;
                                            //    labels[k, j - 1] = null;
                                            //    changeColor(a + b, k, j);
                                            //}
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "Left":
                        for (int k = 0; k < 4; k++)
                        {
                            for (int l = 1; l < 4; l++)
                            {
                                if (map[k, l] == 1)
                                {
                                    for (int j = l - 1; j >= 0; j--)
                                    {
                                        if (map[k, j] == 0)
                                        {
                                            map[k, j + 1] = 0;
                                            map[k, j] = 1;
                                            pics[k, j] = pics[k, j + 1];
                                            pics[k, j + 1] = null;
                                            labels[k, j] = labels[k, j + 1];
                                            labels[k, j + 1] = null;
                                            pics[k, j].Location = new Point(pics[k, j].Location.X - 106, pics[k, j].Location.Y);
                                        }
                                        else
                                        {
                                            //CheckEND(k, j, "Left");
                                            Connection(k, j, "Left");
                                            //int a = int.Parse(labels[k, j].Text);
                                            //int b = int.Parse(labels[k, j + 1].Text);
                                            //if (a == b)
                                            //{
                                            //    score += (a + b);
                                            //    Score.Text = "Score : " + score;
                                            //    labels[k, j].Text = (a + b).ToString();
                                            //    map[k, j + 1] = 0;
                                            //    this.Controls.Remove(pics[k, j + 1]);
                                            //    this.Controls.Remove(labels[k, j + 1]);
                                            //    pics[k, j + 1] = null;
                                            //    labels[k, j + 1] = null;
                                            //    changeColor(a + b, k, j);
                                            //}
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "Down":
                        for (int k = 3; k >= 0; k--)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (map[k, l] == 1)
                                {
                                    for (int j = k + 1; j < 4; j++)
                                    {
                                        if (map[j, l] == 0)
                                        {
                                            map[j - 1, l] = 0;
                                            map[j, l] = 1;
                                            pics[j, l] = pics[j - 1, l];
                                            pics[j - 1, l] = null;
                                            labels[j, l] = labels[j - 1, l];
                                            labels[j - 1, l] = null;
                                            pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y + 106);
                                        }
                                        else
                                        {
                                            //CheckEND(j,l, "Down");
                                            Connection(j, l, "Down");
                                            //int a = int.Parse(labels[j, l].Text);
                                            //int b = int.Parse(labels[j - 1, l].Text);
                                            //if (a == b)
                                            //{
                                            //    score += (a + b);
                                            //    Score.Text = "Score : " + score;
                                            //    labels[j, l].Text = (a + b).ToString();
                                            //    map[j - 1, l] = 0;
                                            //    this.Controls.Remove(pics[j - 1, l]);
                                            //    this.Controls.Remove(labels[j - 1, l]);
                                            //    pics[j - 1, l] = null;
                                            //    labels[j - 1, l] = null;
                                            //    changeColor(a + b, j, l);
                                        }
                                    }
                                }
                            }
                        }
                break;
                    case "Up":
                        for (int k = 1; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        if (map[k, l] == 1)
                        {
                            for (int j = k - 1; j >= 0; j--)
                            {
                                if (map[j, l] == 0)
                                {
                                    map[j + 1, l] = 0;
                                    map[j, l] = 1;
                                    pics[j, l] = pics[j + 1, l];
                                    pics[j + 1, l] = null;
                                    labels[j, l] = labels[j + 1, l];
                                    labels[j + 1, l] = null;
                                    pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y - 106);
                                }
                                else
                                {
                                    //CheckEND(j,l,"Up");
                                    Connection(j, l, "Up");
                                    //int a = int.Parse(labels[j, l].Text);
                                    //int b = int.Parse(labels[j + 1, l].Text);
                                    //if (a == b)
                                    //{
                                    //    score += (a + b);
                                    //    Score.Text = "Score : " + score;
                                    //    labels[j, l].Text = (a + b).ToString();
                                    //    map[j + 1, l] = 0;
                                    //    this.Controls.Remove(pics[j + 1, l]);
                                    //    this.Controls.Remove(labels[j + 1, l]);
                                    //    pics[j + 1, l] = null;
                                    //    labels[j + 1, l] = null;
                                    //    changeColor(a + b, j, l);
                                    //}
                                }
                            }
                        }
                    }
                }
                break;
            }

                if ((codeKey.Equals("Right") || codeKey.Equals("Left") || codeKey.Equals("Down") || codeKey.Equals("Up")))
                {
                    if (checkFirstClick == 0)
                    {
                        timer.Start();
                        checkFirstClick = 1;
                    }
                    createNewPic();
                }
            }
            //else if (count == 16)
            //{
            //    CheckEND();
            //}
        }
        private void CheckEND(int a,int b , string side) ////Error
        {
            //for (int a = 0; a < 4; a++)
            //{
            // for (int b = 0; b < 4; b++)
            //  {
            try
            {
                if (countBlocks < 16)
                {
                    continueG = 1;
                }
                else if (countBlocks == 16)
                {
                    continueG = 0;
                    if ((a - 1 >= 0 && labels[a, b].Text == labels[a - 1, b].Text) || (b - 1 >= 0 && labels[a, b].Text == labels[a, b - 1].Text) || (a + 1 < 4 && labels[a, b].Text == labels[a + 1, b].Text) || (b + 1 < 4 && labels[a, b].Text == labels[a, b + 1].Text))
                    {
                        Connection(a, b, side);
                    }
                    else
                    {
                        timer.Stop();
                        MessageBox.Show("You lose :-( !");
                        continueG = 0;
                    }
                }
            }
            catch (System.NullReferenceException) { }
                //}
          //  }
        }
        private void Connection(int k, int j, string side)
        {
            int x = 0; int y = 0;
            switch (side)
            {
                case "Right":
                    x = k; y = j - 1;
                    break;
                case "Left":
                    x = k; y = j + 1;
                    break;
                case "Down":
                    x = k - 1; y = j;
                    break;
                case "Up":
                    x = k + 1; y = j;
                    break;
            }
            try
            {
                int a = int.Parse(labels[k, j].Text);
                int b = int.Parse(labels[x, y].Text); //System.IndexOutOfRangeException  // в первой ячейке вправо у = -1
                if (a == b)
                {
                    score += (a + b);
                    Score.Text = "Score : " + score;
                    labels[k, j].Text = (a + b).ToString();
                    map[x, y] = 0;
                    this.Controls.Remove(pics[x, y]);
                    this.Controls.Remove(labels[x, y]);
                    pics[x, y] = null;
                    labels[x, y] = null;
                    changeColor(a + b, k, j);
                }
            }
            catch (System.IndexOutOfRangeException) { }
        }


        private void CreditsMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оболенинов Антон\n\rE-mail : oboleninoff.anton@yandex.ru\n\rInstagram : @t1roller\n\rVk : id392548774\n\rIMAM");
        }

        private void RestartMenu_Click(object sender, EventArgs e)
        {
            continueG = 1;
            countBlocks = 2;
            checkFirstClick = 0;
            min = 0;
            h = 0;
            if (timer.Enabled) { timer.Stop(); }
            timerCounter = 0;
            Clock.Text = "Timer [ 0:0 ]";
            EndGame();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Time0000ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Timer_TicK(object sender, EventArgs e)
        {
            timerCounter++;
            if (timerCounter == 60)
            {
                min++;
                timerCounter = 0;
            }
            if (min == 60) { h++; min = 0; }
            if (h == 0)
            {
                Clock.Text = $"Time [ {min}:{timerCounter} ]";
                Time = $"{min}мин {timerCounter}сек";
            }
            else
            {
                Clock.Text = $"Time [ {h}:{min}:{timerCounter} ]";
                Time = $"{h}ч {min}мин {timerCounter}сек";
            }
        }

        private void GameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

