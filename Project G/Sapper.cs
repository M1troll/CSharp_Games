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
    public partial class Sapper : Form
    {
        Random rnd = new Random();
        Timer timer = new Timer();
        string Time = "";
        int min = 0;
        int h = 0;
        int timerCounter = 0;
        int height = 10;
        int width = 10;
        int distance = 35;
        byte status = 0;
        int remainsBombs_Visual = 0;
        int CountBombs = 0;
        Color flagColor = new Color();//Color.FromArgb(255, 00, 00);
        Point center = new Point();
        ButtonExtended[,] allButtons;
        Color defColor = new Color();
        public Sapper()
        {
            InitializeComponent();
            this.Cursor = new Cursor(@"C:\Users\orochi\source\repos\Project G\Project G\img\fire.ico");
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_TicK);
            flagColor = Color.FromArgb(rnd.Next(0,256), rnd.Next(0, 256), rnd.Next(0, 256));
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Create()
        {
            min = 0;
            h = 0;
            if (timer.Enabled) { timer.Stop(); }
            timerCounter = 0;
            Clock.Text = "Timer [ 0:0 ]";
            remainsBombs_Visual = 0;
            status = 0;
            CountBombs = 0;
            allButtons = new ButtonExtended[width, height];
            Random rand = new Random();
            for (int x = 12; (x - 12) < width * distance; x += distance)
            {
                for (int y = 38; (y - 38) < height * distance; y += distance)
                {
                    ButtonExtended button = new ButtonExtended();
                    defColor = button.BackColor;
                    button.Font = new Font("Arial", 15, FontStyle.Bold);
                    button.Location = new Point(x, y);
                    button.Size = new Size(30, 30);
                    button.BackColor = Color.FromArgb(204,204,204);
                    if (rand.Next(0, 101) < 20)
                    {
                        button.isBomb = true;
                        remainsBombs_Visual++;
                        CountBombs++;
                    }
                    allButtons[(x - 12) / distance, (y - 38) / distance] = button;
                    Controls.Add(button);
                    button.Click += new EventHandler(FieldClick);
                    button.MouseUp += new MouseEventHandler(Flag);
                }
            }
            RemainsToolStripMenuItem_Click(0, null);
            this.Size = new Size(35*(width+1),35*(height+3)-23);
        }

        private void Flag(object sender, MouseEventArgs e)
        {
            ButtonExtended button = (ButtonExtended)sender;
            if (e.Button == MouseButtons.Right && button.Text == "" && status == 0)
            {
                if (!timer.Enabled) { timer.Start(); }
                if (button.isFlag == false)
                {
                    button.isFlag = true;
                    button.BackColor = flagColor;
                    remainsBombs_Visual--;
                    RemainsToolStripMenuItem_Click(0, null);
                }
                else
                {
                    button.isFlag = false;
                    button.BackColor = Color.FromArgb(204, 204, 204);
                    remainsBombs_Visual++;
                    RemainsToolStripMenuItem_Click(0, null);
                }
            }
            CheckWin();
        }
        private void FieldClick(object sender, EventArgs e)
        {
            ButtonExtended but = (ButtonExtended)sender;
            if (but.Text == "" && but.isFlag == false && status == 0)
            {
                if (!timer.Enabled) { timer.Start(); }
                if (but.isBomb)
                {
                    Explode(but);
                }
                else
                {
                    EmptyFieldClick(but);
                }
            }
            if (but.Text != "" && !but.isFlag && status == 0)
            {
                OpenNeighbors(but);
            }
            CheckWin();
        }
        private void Explode(ButtonExtended b)
        {
            if (timer.Enabled) { timer.Stop(); }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (allButtons[x, y].isBomb)
                    {
                        allButtons[x, y].Text = "*";
                    }
                }
            }
            DialogRestartOrContinue form = new DialogRestartOrContinue($"You lose :-( (\n\rYour time is {Time}");
            form.ShowDialog();
            if (form.DialogResult() == '1')
            {
                RestartToolStripMenuItem_Click(0, null);
            }
            else if (form.DialogResult() == '0')
            {
                status = 1;
            }
            else { Close(); }
            //MessageBox.Show($"Вы проиграли (\n\rВаше время - {Time}");
            //status = 1;
        }
        private void OpenNeighbors(ButtonExtended button)
        {
            int xB = (button.Location.X - 12) / distance;
            int yB = (button.Location.Y - 38) / distance;
            int bombs = 0;
            if (button.Text != "*")
            {
                bombs = Convert.ToInt32(button.Text);
            }
            else { bombs++; }
            int flags = 0;
            for (int x = xB - 1; x <= xB + 1; x++)
            {
                for (int y = yB - 1; y <= yB + 1; y++)
                {
                    if (x >= 0 && x < width && y >= 0 && y < height && allButtons[x, y].isClearAround == true && allButtons[x, y].isFlag && (x != xB || y != yB))
                    {
                        flags++;//считаем отметки вокруг
                    }
                }
            }
            if (bombs == flags)//если они совпадают , то открываем все клетки вокруг
            {
                for (int x = xB - 1; x <= xB + 1; x++)
                {
                    for (int y = yB - 1; y <= yB + 1; y++)
                    {
                        if (x >= 0 && x < width && y >= 0 && y < height && allButtons[x, y].isClearAround == true && (x != xB || y != yB) && allButtons[x, y].Text == "" && !allButtons[x, y].isFlag)
                        {
                            if (allButtons[x, y].isBomb)//если одна из клеток оказалась бомбой , то отметки были отмечены неправильно => проигрыш
                            {
                                Explode(allButtons[x, y]);
                            }
                            else//если же все клетки оказались пустыми , метки поставлены верно 
                            {
                                EmptyFieldClick(allButtons[x, y]);//изменить клетку на открытую
                            }

                        }
                    }
                }
            }
        }
        private void EmptyFieldClick(ButtonExtended b)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (allButtons[x, y] == b)
                    {
                        b.Text = Convert.ToString(CountBombAround(x, y));
                        if (Convert.ToInt32(b.Text) == 0)
                        {
                            b.Text = "";
                            b.isClearAround = false;
                            FindSpace(x, y);
                        }
                        b.BackColor = Color.FromArgb(255, 255, 255);
                    }
                }
            }
        }
        private void FindSpace(int xB, int yB)
        {
            int check = 0;
            for (int x = xB - 1; x <= xB + 1; x++)
            {
                for (int y = yB - 1; y <= yB + 1; y++)
                {
                    if (x >= 0 && x < width && y >= 0 && y < height && allButtons[x, y].isClearAround == true && (x != xB || y != yB) && !allButtons[x, y].isFlag)
                    {
                        check = CountBombAround(x, y);
                        if (check == 0)
                        {
                            allButtons[x, y].Text = "";
                            allButtons[x, y].isClearAround = false;
                            FindSpace(x, y);
                        }
                        else
                        {
                            allButtons[x, y].Text = Convert.ToString(check);
                        }
                        allButtons[x, y].BackColor = Color.FromArgb(255, 255, 255);
                    }
                }
            }
        }
        public int CountBombAround(int xB, int yB)
        {
            int bombCount = 0;
            for (int x = xB - 1; x <= xB + 1; x++)
            {
                for (int y = yB - 1; y <= yB + 1; y++)
                {
                    if (x >= 0 && x < width && y >= 0 && y < height)
                    {
                        if (allButtons[x, y].isBomb)
                        {
                            bombCount++;
                        }
                    }
                }
            }
            return bombCount;
        }
        private void CheckWin()
        {
            if (status == 0)
            {
                int check = 0;
                int allOpen = 0;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (allButtons[x, y].isBomb && allButtons[x, y].isFlag)
                        {
                            check++;
                        }
                        if (!allButtons[x, y].isBomb && (allButtons[x, y].Text != "" || allButtons[x, y].isClearAround == false))
                        {
                            allOpen++;
                        }
                    }
                }
                if (check == CountBombs || CountBombs + allOpen == allButtons.Length)
                {
                    if (timer.Enabled) { timer.Stop(); }
                    DialogRestartOrContinue form = new DialogRestartOrContinue($"You win !!!\n\rYour time is {Time}");
                    form.ShowDialog();
                    if (form.DialogResult() == '1')
                    {
                        RestartToolStripMenuItem_Click(0, null);
                    }
                    else if (form.DialogResult() == '0')
                    {
                        status = 1;
                    } else {Close(); }
                }
            }

        }
        private void ClearArea()          ///???
        {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Controls.Remove(allButtons[x, y]);
                    }
                }
        }
        private void Timer_TicK(object sender,EventArgs e)
        {
            timerCounter++;
            if (timerCounter == 60)
            {
                min++;
                timerCounter = 0;
            }
            if (min == 60) { h++;min = 0; }
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
        private void Sapper_Load(object sender, EventArgs e)
        {
            center = this.Location;
            width = 10;
            height = 10;
            Create();
        }
        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.AutoScroll = false;
            this.Location = center;
            ClearArea();
            width = 16;
            height = 16;
            Create();
        }
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.AutoScroll = false;
            this.Location = center;
            ClearArea();
            width = 10;
            height = 10;
            Create();
        }
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.AutoScroll = false;
            this.Location = center;
            ClearArea();
            width = 7;
            height = 7;
            Create();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearArea();
            Create();
        }

        private void RemainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remainsToolStripMenuItem.Text = $"Remains : {remainsBombs_Visual}";
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ClearArea();
            width = 45;
            height = 20;
            Create();
            this.MaximizeBox = true;
            this.AutoScroll = true;
            this.Location = new Point(0, 0);
        }
        private void Color_Changes_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            switch (i.Text)
            {
                case "Red":
                    flagColor = Color.FromArgb(255,0,0);
                    break;
                case "Orange":
                    flagColor = Color.FromArgb(255,140,0);
                    break;
                case "Yellow":
                    flagColor = Color.FromArgb(255,255,0);
                    break;
                case "Green":
                    flagColor = Color.FromArgb(0,255,0);
                    break;
                case "Blue Light":
                    flagColor = Color.FromArgb(0,191,255);
                    break;
                case "Blue":
                    flagColor = Color.FromArgb(0,0,255);
                    break;
                case "Purple":
                    flagColor = Color.FromArgb(160,32,240);
                    break;
                case "Black":
                    flagColor = Color.FromArgb(0,0,0);
                    break;
            }
        }

        private void Time0000ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оболенинов Антон\n\rE-mail : oboleninoff.anton@yandex.ru\n\rInstagram : @t1roller\n\rVk : id392548774\n\rIMAM");
        }
    }
   public class ButtonExtended:Button
    {
        public bool isBomb;
        public bool isFlag;
        public bool isClearAround = true;
    }
}
