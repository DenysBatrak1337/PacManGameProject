using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PAC_MAN_GAME
{
    public partial class LevelForm : Form
    {

        bool Pacman_Right = false;
        bool Pacman_Left = false;
        bool Pacman_Up = false;
        bool Pacman_Down = false;

        bool Red_Ghost_Right = false;
        bool Red_Ghost_Left = false;
        bool Red_Ghost_Up = false;
        bool Red_Ghost_Down = false;
        bool Red_Ghost_Frightened_Mode = false;
        bool Red_Ghost_Dead = false;

        bool Pink_Ghost_Right = false;
        bool Pink_Ghost_Left = false;
        bool Pink_Ghost_Up = false;
        bool Pink_Ghost_Down = false;
        bool Pink_Ghost_Frightened_Mode = false;
        bool Pink_Ghost_Dead = false;

        bool Blue_Ghost_Right = false;
        bool Blue_Ghost_Left = false;
        bool Blue_Ghost_Up = false;
        bool Blue_Ghost_Down = false;
        bool Blue_Ghost_Frightened_Mode = false;
        bool Blue_Ghost_Dead = false;

        bool Orange_Ghost_Right = false;
        bool Orange_Ghost_Left = false;
        bool Orange_Ghost_Up = false;
        bool Orange_Ghost_Down = false;
        bool Orange_Ghost_Frightened_Mode = false;
        bool Orange_Ghost_Dead = false;

        bool Scatter_Mode = false;
        int Mode_counter = 0;
        int phase_counter = 1;

        bool Game_Over = false;
        int Pacman_Lives = 3;
        bool Pacman_Catched = false;
        int Pacman_Catched_Phase_Counter = 0;

        Random rnd = new Random();

        bool Frightened_Mode = false;
        int Frightened_Time_Counter = 0;

        int score = 0;
        int eaten_bait = 0;
        int eaaten_bait_after_catched = 0;

        public Panel[,] baits = new Panel[22, 17];


        public LevelForm()
        {
            InitializeComponent();

            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.BackColor == Color.Red)
                    {
                        pb.BackColor = SystemColors.ActiveCaptionText;
                    }
                    if (pb.BackColor == Color.Violet)
                    {
                        pb.BackColor = SystemColors.ControlText;
                    }
                    if (pb.BackColor == Color.Yellow)
                    {
                        pb.BackColor = SystemColors.Desktop;
                    }
                    if (pb.BackColor == Color.Green)
                    {
                        pb.BackColor = SystemColors.InactiveCaptionText;
                    }
                }
            }
            create_baits();
        }

            public void create_baits()
            {
                for (int i = 0; i < 0; i++)
                {
                    for (int k = 0; k < 0; k++)
                    {
                        var panelbait = new Panel();

                        baits[k, i] = panelbait;

                        panelbait.Name = "bait" + k + "," + i + "_panel1";

                        panelbait.Size = new Size(50, 50);

                        panelbait.BackColor = Color.Black;

                        panelbait.Location = new Point(0 + (k * 0), 0 + (i * 0));

                        panelbait.Paint += Bait_Dynamic_Panel_Paint;

                        Main_panel1.Controls.Add(panelbait);
                    }
                }
            }

        private void Bait_Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel baitpanel = sender as Panel;
            Graphics g = baitpanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Yellow);
            g.FillEllipse(sb, 15, 15, 25, 25);
        }
        private void Bait_Dynamic_Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel baitpanel = sender as Panel;
            Graphics g = baitpanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Yellow);
            g.FillEllipse(sb, 20, 20, 10, 10);
        }
        private void Bait_Panel_VisibleChanged(object sender, EventArgs e)
        {
            if (score > 10)
            {
                Frightened_Mode = true;
                Red_Ghost_Frightened_Mode = true;
                Pink_Ghost_Frightened_Mode = true;
                Blue_Ghost_Frightened_Mode = true;
                Orange_Ghost_Frightened_Mode = true;
                Frightened_Time_Counter = 0;
            }
        }


        private void LevelForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Pacman_Movement_timer1.Enabled && !Pacman_Catched && !Game_Over &&
                (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                Pacman_Movement_timer1.Enabled = true;
                Mode_timer1.Enabled = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                Pacman_Left = false;
                Pacman_Up = false;
                Pacman_Down = false;
                Pacman_Right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                Pacman_Right = false;
                Pacman_Up = false;
                Pacman_Down = false;
                Pacman_Left = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                Pacman_Right = false;
                Pacman_Left = false;
                Pacman_Down = false;
                Pacman_Up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                Pacman_Right = false;
                Pacman_Left = false;
                Pacman_Up = false;
                Pacman_Down = true;
            }
        }
        /////////////////////////////////////////////////////////////////////////////PACMAN START\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void Pacman_Movement_timer1_Tick(object sender, EventArgs e)
        {
            if (Pacman_Right && !All_Characters_limitcontrol(Pacman_Left, Pacman_Right, Pacman_Up, Pacman_Down, Pacman_pictureBox1))
            {
                Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.right;
                Pacman_pictureBox1.Left = Pacman_pictureBox1.Location.X + 6;
            }
            if (Pacman_Left && !All_Characters_limitcontrol(Pacman_Left, Pacman_Right, Pacman_Up, Pacman_Down, Pacman_pictureBox1))
            {
                Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.left;
                Pacman_pictureBox1.Left = Pacman_pictureBox1.Location.X - 6;
            }
            if (Pacman_Up && !All_Characters_limitcontrol(Pacman_Left, Pacman_Right, Pacman_Up, Pacman_Down, Pacman_pictureBox1))
            {
                Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Up;
                Pacman_pictureBox1.Top = Pacman_pictureBox1.Location.Y - 6;
            }
            if (Pacman_Down && !All_Characters_limitcontrol(Pacman_Left, Pacman_Right, Pacman_Up, Pacman_Down, Pacman_pictureBox1))
            {
                Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.down;
                Pacman_pictureBox1.Top = Pacman_pictureBox1.Location.Y + 6;
            }

            foreach (Control c in Main_panel1.Controls)
            {
                if (c is PictureBox)
                { 
                    if ((string)c.Tag == "coin" && c.Visible == true)
                    {
                        if (Pacman_pictureBox1.Bounds.IntersectsWith(c.Bounds))
                        {
                            c.Visible = false;
                            score = score + 10;
                            score_label1.Text = "Score: " + score;
                            eaten_bait++;
                            eaaten_bait_after_catched++;
                            
                        }
                    }
                }
            }

            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    Panel p = c as Panel;

                    if (p.Name.Contains("bait") && p.Visible && Pacman_pictureBox1.Bounds.IntersectsWith(p.Bounds))
                    {
                        p.Visible = false;
                        score = score + 10;
                        score_label1.Text = "Score: " + score;
                        eaten_bait++;
                        eaaten_bait_after_catched++;
                    }
                }
            }


            if (eaten_bait == 260)
            {
                Game_Over = true;

                Pacman_Movement_timer1.Enabled = false;
                Red_Ghost_Movement_timer1.Enabled = false;
                Pink_Ghost_Movement_timer1.Enabled = false;
                Blue_Ghost_Movement_timer1.Enabled = false;
                Orange_Ghost_Movement_timer1.Enabled = false;

                Pacman_pictureBox1.Location = new Point(50, 370);
                Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.right;
                Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Right;
                Red_Ghost_pictureBox1.Location = new Point(580, 230);
                Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Rink_Right;
                Pink_Ghost_pictureBox1.Location = new Point(360, 230);
                Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Right;
                Blue_Ghost_pictureBox1.Location = new Point(480, 230);
                Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Right;
                Orange_Ghost_pictureBox1.Location = new Point(460, 230);
                New_Game_label1.Visible = true;
                Game_Over_label1.Visible = true;

                eaaten_bait_after_catched = 0;

                MessageBox.Show("Перемога!");
            }
            if (eaaten_bait_after_catched == 1 && !Red_Ghost_Movement_timer1.Enabled)
            {
                Red_Ghost_Left = true;
                Red_Ghost_Movement_timer1.Enabled = true;
            }
            if (eaaten_bait_after_catched == 3 && !Pink_Ghost_Movement_timer1.Enabled)
            {
                Pink_Ghost_Up = true;
                Pink_Ghost_Movement_timer1.Enabled = true;
            }
            if (eaaten_bait_after_catched == 5 && !Blue_Ghost_Movement_timer1.Enabled)
            {
                Blue_Ghost_Right = true;
                Blue_Ghost_Movement_timer1.Enabled = true;
            }
            if (eaaten_bait_after_catched == 7 && !Orange_Ghost_Movement_timer1.Enabled)
            {
                Orange_Ghost_Right = true;
                Orange_Ghost_Movement_timer1.Enabled = true;
            }
            if(Pacman_pictureBox1.Bounds.IntersectsWith(Red_Ghost_pictureBox1.Bounds) && Red_Ghost_Frightened_Mode)
            {
                Red_Ghost_Frightened_Mode = false;
                Red_Ghost_Dead = true;
            }
            if (Pacman_pictureBox1.Bounds.IntersectsWith(Pink_Ghost_pictureBox1.Bounds) && Pink_Ghost_Frightened_Mode)
            {
                Pink_Ghost_Frightened_Mode = false;
                Pink_Ghost_Dead = true;
            }
            if (Pacman_pictureBox1.Bounds.IntersectsWith(Blue_Ghost_pictureBox1.Bounds) && Blue_Ghost_Frightened_Mode)
            {
                Blue_Ghost_Frightened_Mode = false;
                Blue_Ghost_Dead = true;
            }
            if (Pacman_pictureBox1.Bounds.IntersectsWith(Orange_Ghost_pictureBox1.Bounds) && Orange_Ghost_Frightened_Mode)
            {
                Orange_Ghost_Frightened_Mode = false;
                Orange_Ghost_Dead = true;
            }
            if(Pacman_pictureBox1.Bounds.IntersectsWith(Red_Ghost_pictureBox1.Bounds) && !Red_Ghost_Frightened_Mode && !Red_Ghost_Dead
                || Pacman_pictureBox1.Bounds.IntersectsWith(Pink_Ghost_pictureBox1.Bounds) && !Pink_Ghost_Frightened_Mode && !Pink_Ghost_Dead
                || Pacman_pictureBox1.Bounds.IntersectsWith(Blue_Ghost_pictureBox1.Bounds) && !Blue_Ghost_Frightened_Mode && !Blue_Ghost_Dead
                || Pacman_pictureBox1.Bounds.IntersectsWith(Orange_Ghost_pictureBox1.Bounds) && !Orange_Ghost_Frightened_Mode && !Orange_Ghost_Dead)
            {
                Pacman_Lives--;

                Pacman_Catched = true;
                Pacman_Movement_timer1.Enabled = false;
                Red_Ghost_Movement_timer1.Enabled = false;
                Pink_Ghost_Movement_timer1.Enabled = false;
                Blue_Ghost_Movement_timer1.Enabled = false;
                Orange_Ghost_Movement_timer1.Enabled = false;
                Mode_timer1.Enabled = false;

                if(Pacman_Lives > 0)
                {
                    eaaten_bait_after_catched = 0; 
                }
                else
                {
                    Game_Over = true;
                }
                Pacman_Catched_timer1.Enabled = true;
            }
        }


        /////////////////////////////////////////////////////////////////////////////PACMAN END\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void pause_label1_Click(object sender, EventArgs e)
        {
            if (pause_label1.Text == ";")
            {
                Pacman_Movement_timer1.Enabled = false;
                Red_Ghost_Movement_timer1.Enabled = false;
                Pink_Ghost_Movement_timer1.Enabled = false;
                Blue_Ghost_Movement_timer1 .Enabled = false;
                Orange_Ghost_Movement_timer1.Enabled = false;
                Mode_timer1.Enabled = false;
                pause_label1.Text = "4";
            }
            else
            {
                Pacman_Movement_timer1.Enabled = true;
                Red_Ghost_Movement_timer1.Enabled = true;
                Pink_Ghost_Movement_timer1.Enabled = true;
                Blue_Ghost_Movement_timer1.Enabled= true;
                Orange_Ghost_Movement_timer1.Enabled = true;
                Mode_timer1.Enabled = true;
                pause_label1.Text = ";";
            }
        }

        /////////////////////////////////////////////////////////////////////////////RED GHOST START\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void Red_Ghost_Movement_timer1_Tick(object sender, EventArgs e)
        {
            if (Red_Ghost_Right && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
            {
                Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Right;
                Red_Ghost_pictureBox1.Left = Red_Ghost_pictureBox1.Location.X + 5;
            }
            if (Red_Ghost_Left && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
            {
                Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Left;
                Red_Ghost_pictureBox1.Left = Red_Ghost_pictureBox1.Location.X - 5;               
            }
            if (Red_Ghost_Up && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
            {
                Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Up;
                Red_Ghost_pictureBox1.Top = Red_Ghost_pictureBox1.Location.Y - 5;               
            }
            if (Red_Ghost_Down && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
            {
                Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Down;
                Red_Ghost_pictureBox1.Top = Red_Ghost_pictureBox1.Location.Y + 5;               
            }
            if(Red_Ghost_Frightened_Mode)
            {
                Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Frig_Ghost;
            }
            if(Red_Ghost_Dead)
            {
                if (Red_Ghost_Right && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
                {
                    Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Right;
                    Red_Ghost_pictureBox1.Left = Red_Ghost_pictureBox1.Location.X + 5;
                }
                if (Red_Ghost_Left && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
                {
                    Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Left;
                    Red_Ghost_pictureBox1.Left = Red_Ghost_pictureBox1.Location.X - 5;
                }
                if (Red_Ghost_Up && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
                {
                    Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Up;
                    Red_Ghost_pictureBox1.Top = Red_Ghost_pictureBox1.Location.Y - 5;
                }
                if (Red_Ghost_Down && !All_Characters_limitcontrol(Red_Ghost_Left, Red_Ghost_Right, Red_Ghost_Up, Red_Ghost_Down, Red_Ghost_pictureBox1))
                {
                    Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Down;
                    Red_Ghost_pictureBox1.Top = Red_Ghost_pictureBox1.Location.Y + 5;
                }
            }
            if(Red_Ghost_Dead && Red_Ghost_pictureBox1.Bounds.IntersectsWith(Ghost_House_pictureBox1.Bounds))
            {
                Red_Ghost_Dead = false;
            }

            All_Ghosts_Target(Red_Ghost_Frightened_Mode, Red_Ghost_Dead, ref Red_Ghost_Left, ref Red_Ghost_Right, ref Red_Ghost_Up, ref Red_Ghost_Down, Red_Ghost_pictureBox1,
            true, false, false, false);
        }
        /////////////////////////////////////////////////////////////////////////////RED GHOST END\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        /////////////////////////////////////////////////////////////////////////////PINK GHOST START\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void Pink_Ghost_Movement_timer1_Tick(object sender, EventArgs e)
        {
            if (Pink_Ghost_Right && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
            {
                Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Rink_Right;
                Pink_Ghost_pictureBox1.Left = Pink_Ghost_pictureBox1.Location.X + 5;
            }
            if (Pink_Ghost_Left && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
            {
                Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Pink_Left;
                Pink_Ghost_pictureBox1.Left = Pink_Ghost_pictureBox1.Location.X - 5;
            }
            if (Pink_Ghost_Up && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
            {
                Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Pink_Up;
                Pink_Ghost_pictureBox1.Top = Pink_Ghost_pictureBox1.Location.Y - 5;
            }
            if (Pink_Ghost_Down && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
            {
                Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Pink_Down;
                Pink_Ghost_pictureBox1.Top = Pink_Ghost_pictureBox1.Location.Y + 5;
            }
            if (Pink_Ghost_Frightened_Mode)
            {
                Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Frig_Ghost;
            }
            if(Pink_Ghost_Dead)
            {
                if (Pink_Ghost_Right && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
                {
                    Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Right;
                    Pink_Ghost_pictureBox1.Left = Pink_Ghost_pictureBox1.Location.X + 5;
                }
                if (Pink_Ghost_Left && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
                {
                    Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Left;
                    Pink_Ghost_pictureBox1.Left = Pink_Ghost_pictureBox1.Location.X - 5;
                }
                if (Pink_Ghost_Up && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
                {
                    Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Up;
                    Pink_Ghost_pictureBox1.Top = Pink_Ghost_pictureBox1.Location.Y - 5;
                }
                if (Pink_Ghost_Down && !All_Characters_limitcontrol(Pink_Ghost_Left, Pink_Ghost_Right, Pink_Ghost_Up, Pink_Ghost_Down, Pink_Ghost_pictureBox1))
                {
                    Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Down;
                    Pink_Ghost_pictureBox1.Top = Pink_Ghost_pictureBox1.Location.Y + 5;
                }
                
            }
            if (Pink_Ghost_Dead && Pink_Ghost_pictureBox1.Bounds.IntersectsWith(Ghost_House_pictureBox1.Bounds))
            {
                Pink_Ghost_Dead = false;
            }


            All_Ghosts_Target(Pink_Ghost_Frightened_Mode, Pink_Ghost_Dead, ref Pink_Ghost_Left, ref Pink_Ghost_Right, ref Pink_Ghost_Up, ref Pink_Ghost_Down, Pink_Ghost_pictureBox1,
            false, true, false, false);
        }
        /////////////////////////////////////////////////////////////////////////////PINK GHOST END\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /////////////////////////////////////////////////////////////////////////////Blue GHOST START\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void Blue_Ghost_Movement_timer1_Tick(object sender, EventArgs e)
        {
            if (Blue_Ghost_Right && !All_Characters_limitcontrol(Blue_Ghost_Left, Blue_Ghost_Right, Blue_Ghost_Up, Blue_Ghost_Down, Blue_Ghost_pictureBox1))
            {
                Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Right;
                Blue_Ghost_pictureBox1.Left = Blue_Ghost_pictureBox1.Location.X + 5;
            }
            if (Blue_Ghost_Left)
            {
                Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Left;
                Blue_Ghost_pictureBox1.Left = Blue_Ghost_pictureBox1.Location.X - 5;
            }
            if (Blue_Ghost_Up)
            {
                Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Up;
                Blue_Ghost_pictureBox1.Top = Blue_Ghost_pictureBox1.Location.Y - 5;
            }
            if (Blue_Ghost_Down)
            {
                Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Down1;
                Blue_Ghost_pictureBox1.Top = Blue_Ghost_pictureBox1.Location.Y + 5;
            }
            if (Blue_Ghost_Frightened_Mode)
            {
                Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Frig_Ghost;  
            }
            if(Blue_Ghost_Dead)
            {
                if (Blue_Ghost_Right && !All_Characters_limitcontrol(Blue_Ghost_Left, Blue_Ghost_Right, Blue_Ghost_Up, Blue_Ghost_Down, Blue_Ghost_pictureBox1))
                {
                    Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Right;
                    Blue_Ghost_pictureBox1.Left = Blue_Ghost_pictureBox1.Location.X + 5;
                }
                if (Blue_Ghost_Left)
                {
                    Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Left;
                    Blue_Ghost_pictureBox1.Left = Blue_Ghost_pictureBox1.Location.X - 5;
                }
                if (Blue_Ghost_Up)
                {
                    Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Up;
                    Blue_Ghost_pictureBox1.Top = Blue_Ghost_pictureBox1.Location.Y - 5;
                }
                if (Blue_Ghost_Down)
                {
                    Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Down;
                    Blue_Ghost_pictureBox1.Top = Blue_Ghost_pictureBox1.Location.Y + 5;
                }
            }
            if (Blue_Ghost_Dead && Blue_Ghost_pictureBox1.Bounds.IntersectsWith(Ghost_House_pictureBox1.Bounds))
            {
                Blue_Ghost_Dead = false;
            }
            All_Ghosts_Target(Blue_Ghost_Frightened_Mode, Blue_Ghost_Dead, ref Blue_Ghost_Left, ref Blue_Ghost_Right, ref Blue_Ghost_Up, ref Blue_Ghost_Down, Blue_Ghost_pictureBox1,
            false, false, true, false);
        }
        /////////////////////////////////////////////////////////////////////////////BLUE GHOST END\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        


        /////////////////////////////////////////////////////////////////////////////ORANGE GHOST START\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void Orange_Ghost_Movement_timer1_Tick(object sender, EventArgs e)
        {
            if (Orange_Ghost_Right && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
            {
                Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Right;
                Orange_Ghost_pictureBox1.Left = Orange_Ghost_pictureBox1.Location.X + 5;
            }
            if (Orange_Ghost_Left && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
            {
                Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Left;
                Orange_Ghost_pictureBox1.Left = Orange_Ghost_pictureBox1.Location.X - 5;
            }
            if (Orange_Ghost_Up && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
            {
                Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Up;
                Orange_Ghost_pictureBox1.Top = Orange_Ghost_pictureBox1.Location.Y - 5;
            }
            if (Orange_Ghost_Down && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
            {
                Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Down;
                Orange_Ghost_pictureBox1.Top = Orange_Ghost_pictureBox1.Location.Y + 5;
            }
            if (Orange_Ghost_Frightened_Mode)
            {
                Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Frig_Ghost;
            }
            if(Orange_Ghost_Dead)
            {
                if (Orange_Ghost_Right && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
                {
                    Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Right;
                    Orange_Ghost_pictureBox1.Left = Orange_Ghost_pictureBox1.Location.X + 5;
                }
                if (Orange_Ghost_Left && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
                {
                    Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Left;
                    Orange_Ghost_pictureBox1.Left = Orange_Ghost_pictureBox1.Location.X - 5;
                }
                if (Orange_Ghost_Up && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
                {
                    Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Up;
                    Orange_Ghost_pictureBox1.Top = Orange_Ghost_pictureBox1.Location.Y - 5;
                }
                if (Orange_Ghost_Down && !All_Characters_limitcontrol(Orange_Ghost_Left, Orange_Ghost_Right, Orange_Ghost_Up, Orange_Ghost_Down, Orange_Ghost_pictureBox1))
                {
                    Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Down;
                    Orange_Ghost_pictureBox1.Top = Orange_Ghost_pictureBox1.Location.Y + 5;
                }
            }
            if (Orange_Ghost_Dead && Orange_Ghost_pictureBox1.Bounds.IntersectsWith(Ghost_House_pictureBox1.Bounds))
            {
                Orange_Ghost_Dead = false;
            }
            All_Ghosts_Target(Orange_Ghost_Frightened_Mode, Orange_Ghost_Dead, ref Orange_Ghost_Left, ref Orange_Ghost_Right, ref Orange_Ghost_Up, ref Orange_Ghost_Down, Orange_Ghost_pictureBox1,
            false, false, false, true);
        }
        /////////////////////////////////////////////////////////////////////////////ORANGE GHOST END\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\













        public bool All_Characters_limitcontrol(bool All_Characters_Left, bool All_Characters_Right, bool All_Characters_Up, bool All_Characters_Down, PictureBox All_Characters_PictureBox)
        {
            bool limit = false;

            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (All_Characters_Left && pb.BackColor == SystemColors.ActiveCaptionText
                        || All_Characters_Right && pb.BackColor == SystemColors.ControlText
                        || All_Characters_Up && pb.BackColor == SystemColors.Desktop
                        || All_Characters_Down && pb.BackColor == SystemColors.InactiveCaptionText)
                    {
                        if (All_Characters_PictureBox.Bounds.IntersectsWith(pb.Bounds))
                        {
                            limit = true;
                        }
                    }
                }
            }

            return limit;
        }

 
      
























        public void All_Ghosts_Target(bool All_Ghosts_Frightened_Mode, bool All_Ghosts_Dead, ref bool All_Ghosts_Left, ref bool All_Ghosts_Right, ref bool All_Ghosts_Up, ref bool All_Ghosts_Down,
          PictureBox All_Ghosts_pictureBox1, bool Red, bool Pink, bool Blue, bool Orange)
        {
            All_Ghosts_Right = false;
            All_Ghosts_Left = false;
            All_Ghosts_Up = false;
            All_Ghosts_Down = false;

            int target_x = 0;
            int target_y = 0;

            int All_up_move_x = All_Ghosts_pictureBox1.Location.X;
            int All_up_move_y = All_Ghosts_pictureBox1.Location.Y - 5;
            int All_left_move_x = All_Ghosts_pictureBox1.Location.X - 5;
            int All_left_move_y = All_Ghosts_pictureBox1.Location.Y;
            int All_down_move_x = All_Ghosts_pictureBox1.Location.X;
            int All_down_move_y = All_Ghosts_pictureBox1.Location.Y + 5;
            int All_right_move_x = All_Ghosts_pictureBox1.Location.X + 5;
            int All_right_move_y = All_Ghosts_pictureBox1.Location.Y;

            if (Scatter_Mode)
            {
                if (Red)
                {
                    target_x = Pacman_pictureBox1.Location.X;
                    target_y = Pacman_pictureBox1.Location.Y;
                    red_target_label1.Location = new Point(target_x, target_y);
                }
                if (Pink)
                {
                    target_x = Pacman_pictureBox1.Location.X;
                    target_y = Pacman_pictureBox1.Location.Y;
                    pink_target_label1.Location = new Point(target_x, target_y);
                }
                if (Blue)
                {
                    target_x = Pacman_pictureBox1.Location.X;
                    target_y = Pacman_pictureBox1.Location.Y;
                    blue_target_label1.Location = new Point(target_x, target_y);
                }
                if (Orange)
                {
                    target_x = Pacman_pictureBox1.Location.X;
                    target_y = Pacman_pictureBox1.Location.Y;
                    orange_target_label1.Location = new Point(target_x, target_y);
                }

            }
            else
            {
                if (Red)
                {
                    target_x = Pacman_pictureBox1.Location.X - 100;
                    target_y = Pacman_pictureBox1.Location.Y + 100;
                   
                    red_target_label1.Location = new Point(target_x, target_y);
                }
                if (Pink)
                {
                    if (Pacman_Up)
                    {
                        target_x = Pacman_pictureBox1.Location.X;
                        target_y = Pacman_pictureBox1.Location.Y - 100;
                    }
                    if (Pacman_Left)
                    {
                        target_x = Pacman_pictureBox1.Location.X - 100;
                        target_y = Pacman_pictureBox1.Location.Y;
                    }
                    if (Pacman_Down)
                    {
                        target_x = Pacman_pictureBox1.Location.X;
                        target_y = Pacman_pictureBox1.Location.Y + 100;
                    }
                    if (Pacman_Right)
                    {
                        target_x = Pacman_pictureBox1.Location.X + 100;
                        target_y = Pacman_pictureBox1.Location.Y;
                    }

                    pink_target_label1.Location = new Point(target_x, target_y);
                }
                if (Blue)
                {
                    int center_x = 0;
                    int center_y = 0;

                    if (Pacman_Up)
                    {
                        center_x = Pacman_pictureBox1.Location.X;
                        center_y = Pacman_pictureBox1.Location.Y - 150;
                    }
                    if (Pacman_Left)
                    {
                        center_x = Pacman_pictureBox1.Location.X - 150;
                        center_y = Pacman_pictureBox1.Location.Y;
                    }
                    if (Pacman_Down)
                    {
                        center_x = Pacman_pictureBox1.Location.X;
                        center_y = Pacman_pictureBox1.Location.Y + 150;
                    }
                    if (Pacman_Right)
                    {
                        center_x = Pacman_pictureBox1.Location.X + 150;
                        center_y = Pacman_pictureBox1.Location.Y;
                    }

                    int Red_point_x = Red_Ghost_pictureBox1.Location.X;
                    int Red_point_y = Red_Ghost_pictureBox1.Location.Y;

                    target_x = center_x + (center_x - Red_point_x);
                    target_y = center_y + (center_y - Red_point_y);

                    blue_target_label1.Location = new Point(target_x, target_y);
                }
                if(Orange)
                {
                    int center_x = 0;
                    int center_y = 0;

                    if (Pacman_Up)
                    {
                        center_x = Pacman_pictureBox1.Location.X;
                        center_y = Pacman_pictureBox1.Location.Y - 100;
                    }
                    if (Pacman_Left)
                    {
                        center_x = Pacman_pictureBox1.Location.X - 100;
                        center_y = Pacman_pictureBox1.Location.Y;
                    }
                    if (Pacman_Down)
                    {
                        center_x = Pacman_pictureBox1.Location.X;
                        center_y = Pacman_pictureBox1.Location.Y + 100;
                    }
                    if (Pacman_Right)
                    {
                        center_x = Pacman_pictureBox1.Location.X + 100;
                        center_y = Pacman_pictureBox1.Location.Y;
                    }

                    int Red_point_x = Red_Ghost_pictureBox1.Location.X;
                    int Red_point_y = Red_Ghost_pictureBox1.Location.Y;

                    target_x = center_x + (center_x - Red_point_x);
                    target_y = center_y + (center_y - Red_point_y);

                    orange_target_label1.Location = new Point(target_x, target_y);
                }
            }

            if (All_Ghosts_Frightened_Mode)
            {
                target_x = rnd.Next(0, 1222);
                target_y = rnd.Next(0, 850);
            }

            if(All_Ghosts_Dead)
            {              
                    if (Red)
                    {
                        target_x = Ghost_House_pictureBox1.Location.X;
                        target_y = Ghost_House_pictureBox1.Location.Y;                
                    }
                    if (Pink)
                    {
                        target_x = Ghost_House_pictureBox1.Location.X;
                        target_y = Ghost_House_pictureBox1.Location.Y;
                    }
                    if (Blue)
                    {
                        target_x = Ghost_House_pictureBox1.Location.X;
                        target_y = Ghost_House_pictureBox1.Location.Y;
                    }
                    if (Orange)
                    {
                        target_x = Ghost_House_pictureBox1.Location.X;
                        target_y = Ghost_House_pictureBox1.Location.Y;
                    }
            }




            double up_distance = Math.Pow((target_x - All_up_move_x), 2) + Math.Pow((target_y - All_up_move_y), 2);
            double left_distance = Math.Pow((target_x - All_left_move_x), 2) + Math.Pow((target_y - All_left_move_y), 2);
            double down_distance = Math.Pow((target_x - All_down_move_x), 2) + Math.Pow((target_y - All_down_move_y), 2);
            double right_distance = Math.Pow((target_x - All_right_move_x), 2) + Math.Pow((target_y - All_right_move_y), 2);

            double[] distance = new double[4] { up_distance, left_distance, down_distance, right_distance };
            string[] direction = new string[4] { "up", "left", "down", "right" };

            for (int i = distance.Length - 1; i > -1; i--)
            {
                if (All_Characters_limitcontrol(direction[i] == "left", direction[i] == "right", direction[i] == "up", direction[i] == "down", All_Ghosts_pictureBox1))
                {
                    List<double> deleted_distance = new List<double>(distance);
                    deleted_distance.RemoveAt(i);
                    distance = deleted_distance.ToArray();

                    List<string> deleted_direction = new List<string>(direction);
                    deleted_direction.RemoveAt(i);
                    direction = deleted_direction.ToArray();
                }
            }

            double distance_temp;
            string direction_temp;

            for (int i = 0; i < distance.Length - 1; i++)
            {
                for (int j = i; j < distance.Length; j++)
                {
                    if (distance[i] > distance[j])
                    {
                        distance_temp = distance[i];
                        distance[i] = distance[j];
                        distance[j] = distance_temp;

                        direction_temp = direction[i];
                        direction[i] = direction[j];
                        direction[j] = direction_temp;

                    }
                }
            }

            if (distance.Length > 3 && distance[0] == distance[3])
            {
                All_Ghosts_Up = true;
            }
            else
            {
                if (distance.Length > 2 && distance[0] == distance[2])
                {
                    if (distance.Length > 3)
                    {
                        direction = direction.Take(direction.Count() - 1).ToArray();
                    }

                    if (direction.Contains("up"))
                    {
                        All_Ghosts_Up = true;
                    }
                    else
                    {
                        All_Ghosts_Left = true;
                    }
                }
                else
                {
                    if (distance.Length > 1 && distance[0] == distance[1])
                    {
                        if (distance.Length > 3)
                        {
                            direction = direction.Take(direction.Count() - 2).ToArray();
                        }
                        else
                        {
                            if (distance.Length > 2)
                            {
                                direction = direction.Take(direction.Count() - 1).ToArray();
                            }
                        }

                        if (direction.Contains("up"))
                        {
                            All_Ghosts_Up = true;
                        }
                        else
                        {
                            if (direction.Contains("left"))
                            {
                                All_Ghosts_Left = true;
                            }
                            else
                            {
                                All_Ghosts_Down = true;
                            }
                        }
                    }
                    else
                    {
                        if (direction[0] == "up")
                        {
                            All_Ghosts_Up = true;
                        }
                        else
                        {
                            if (direction[0] == "left")
                            {
                                All_Ghosts_Left = true;
                            }
                            else
                            {
                                if (direction[0] == "down")
                                {
                                    All_Ghosts_Down = true;
                                }
                                else
                                {
                                    All_Ghosts_Right = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Mode_timer1_Tick(object sender, EventArgs e)
        {
            if (Frightened_Mode)
            {
                Frightened_Time_Counter++;
                if (Frightened_Time_Counter == 20)
                {
                    Frightened_Mode = false;
                    Red_Ghost_Frightened_Mode = false;
                    Pink_Ghost_Frightened_Mode = false;
                    Blue_Ghost_Frightened_Mode = false;
                    Orange_Ghost_Frightened_Mode = false;
                    Frightened_Time_Counter = 0;
                }
            }
            else
            {
                Mode_counter++;

                if (Mode_counter == 20 && !Scatter_Mode && (phase_counter == 1 || phase_counter == 3 || phase_counter == 5))
                {
                    Scatter_Mode = true;
                    Mode_counter = 0;
                    phase_counter++;
                }
                if (Mode_counter == 7 && Scatter_Mode && (phase_counter == 2 || phase_counter == 4))
                {
                    Scatter_Mode = false;
                    Mode_counter = 0;
                    phase_counter++;
                }
                if (Mode_counter == 5 && Scatter_Mode && (phase_counter == 6))
                {
                    Scatter_Mode = false;
                    Mode_counter = 0;
                    phase_counter++;
                }
            }
        }

        private void LevelForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(980, 780);
            FormBorderStyle = FormBorderStyle.None;
            CenterToScreen();
        }

        private void Pacman_Catched_timer1_Tick(object sender, EventArgs e)
        {
            if(Pacman_Catched)
            {
                Pacman_Catched_Phase_Counter++;

                if (Pacman_Catched_Phase_Counter == 1)
                {
                    Red_Ghost_pictureBox1.Visible = false;
                    Pink_Ghost_pictureBox1.Visible = false;
                    Blue_Ghost_pictureBox1.Visible = false;
                    Orange_Ghost_pictureBox1.Visible = false;

                    if (Pacman_Lives == 2)
                    {
                        Pacman_Lives1_pictureBox1.Visible = false;
                    }
                    if (Pacman_Lives == 1)
                    {
                        Pacman_Lives2_pictureBox1.Visible = false;
                    }
                    if (Pacman_Lives == 0)
                    {
                        Pacman_Lives3_pictureBox1.Visible = false;
                    }
                }
                if (Pacman_Catched_Phase_Counter == 2)
                {
                    if (Pacman_Right)
                    {
                        Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Pacman;
                    }
                    if (Pacman_Left)
                    {
                        Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Pacman;
                    }
                    if (Pacman_Up)
                    {
                        Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Pacman;
                    }
                    if (Pacman_Down)
                    {
                        Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Dead_Pacman;
                    }
                }
                if (Pacman_Catched_Phase_Counter == 5)
                {
                    Pacman_pictureBox1.Image = null;
                    Pacman_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.right;

                    if (Pacman_Lives > 0)
                    {
                        Pacman_pictureBox1.Location = new Point(50, 370);
                        Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Right;
                        Red_Ghost_pictureBox1.Location = new Point(580, 230);
                        Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Rink_Right;
                        Pink_Ghost_pictureBox1.Location = new Point(360, 230);
                        Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Right;
                        Blue_Ghost_pictureBox1.Location = new Point(480, 230);
                        Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Right;
                        Orange_Ghost_pictureBox1.Location = new Point(460, 230);
                    }
                    else
                    {
                        Pacman_pictureBox1.Location = Pacman_Zero_Lives_Location_pictureBox1.Location;
                        Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Down;
                        Red_Ghost_pictureBox1.Location = Red_Zero_Lives_Location_pictureBox1.Location;
                        Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Pink_Left;
                        Pink_Ghost_pictureBox1.Location = Pink_Zero_Lives_Location_pictureBox1.Location;
                        Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Up;
                        Blue_Ghost_pictureBox1.Location = Blue_Zero_Lives_Location_pictureBox1.Location;
                        Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Right;
                        Orange_Ghost_pictureBox1.Location = Orange_Zero_Lives_Location_pictureBox1.Location;
                        New_Game_label1.Visible = true;
                        Game_Over_label1.Visible = true;
                    }
                    Red_Ghost_pictureBox1.Visible = true;
                    Pink_Ghost_pictureBox1.Visible = true;
                    Blue_Ghost_pictureBox1.Visible = true;
                    Orange_Ghost_pictureBox1.Visible = true;
                    Pacman_Catched = false;
                    Pacman_Catched_Phase_Counter = 0;
                    Pacman_Catched_timer1.Enabled = false;
                }
            }
        }

        private void New_Game_label1_MouseHover(object sender, EventArgs e)
        {
            New_Game_label1.BackColor = Color.DarkBlue;
        }

        private void New_Game_label1_MouseLeave(object sender, EventArgs e)
        {
            New_Game_label1.BackColor = Color.SteelBlue;
        }

        private void New_Game_label1_Click(object sender, EventArgs e)
        {
            foreach (Control c in Main_panel1.Controls)
            {
                if (c is PictureBox)
                {
                    if ((string)c.Tag == "coin" && !c.Visible)
                    {
                        c.Visible = true;
                    }
                }
            }
            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    Panel p = c as Panel;

                    if (!p.Visible)
                    {
                        p.Visible = true;
                    }
                }
            }
            Pacman_pictureBox1.Location = new Point(50, 370);
            Red_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Red_Right;
            Red_Ghost_pictureBox1.Location = new Point(580, 230);
            Pink_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Rink_Right;
            Pink_Ghost_pictureBox1.Location = new Point(360, 230);
            Blue_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Blue_Right;
            Blue_Ghost_pictureBox1.Location = new Point(480, 230);
            Orange_Ghost_pictureBox1.Image = PAC_MAN_GAME.Properties.Resources.Orange_Right;
            Orange_Ghost_pictureBox1.Location = new Point(460, 230);
            Pacman_Lives1_pictureBox1.Visible = true;
            Pacman_Lives2_pictureBox1.Visible = true;
            Pacman_Lives3_pictureBox1.Visible = true;

            Scatter_Mode = false;
            Mode_counter = 0;
            phase_counter = 1;

            Frightened_Mode = false;
            Frightened_Time_Counter = 0;

            Game_Over = false;
            Pacman_Lives = 3;
            Pacman_Catched = false;
            Pacman_Catched_Phase_Counter = 0;

            score = 0;
            eaten_bait = 0;
            eaaten_bait_after_catched = 0;

            score_label1.Text = "Score: 0";
            New_Game_label1.Visible = false;
            Game_Over_label1.Visible = false;

            Pacman_Right = false;
            Pacman_Left = false;
            Pacman_Up = false;
            Pacman_Down = false;

            Red_Ghost_Right = false;
            Red_Ghost_Left = false;
            Red_Ghost_Up = false;
            Red_Ghost_Down = false;
            Red_Ghost_Frightened_Mode = false;
            Red_Ghost_Dead = false;

            Pink_Ghost_Right = false;
            Pink_Ghost_Left = false;
            Pink_Ghost_Up = false;
            Pink_Ghost_Down = false;
            Pink_Ghost_Frightened_Mode = false;
            Pink_Ghost_Dead = false;

            Blue_Ghost_Right = false;
            Blue_Ghost_Left = false;
            Blue_Ghost_Up = false;
            Blue_Ghost_Down = false;
            Blue_Ghost_Frightened_Mode = false;
            Blue_Ghost_Dead = false;

            Orange_Ghost_Right = false;
            Orange_Ghost_Left = false;
            Orange_Ghost_Up = false;
            Orange_Ghost_Down = false;
            Orange_Ghost_Frightened_Mode = false;
            Orange_Ghost_Dead = false;


        }

        private void label1_Click(object sender, EventArgs e)
        { 
                MainMenuForm mainMenuForm = new MainMenuForm();
                this.Hide();
                mainMenuForm.ShowDialog();  
        }

    }
}

