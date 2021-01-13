using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elfmeter
{
    public partial class Elfmeter : Form
    {

        Random rnd = new Random();

        List<string> keeperPosition = new List<string> { "left", "right", "top", "topleft", "topright", "center" };

        int ballX = 0;
        int ballY = 0;

        string state;
        string playerTarget;

        bool aimSet = false;

        int goal;
        int miss;
        int total;

        public Elfmeter()
        {
            InitializeComponent();
        }

        private void checkScore()
        {
            if (state == "left" && playerTarget == "left"
                || state == "right" && playerTarget == "right"
                || state == "top" && playerTarget == "top"
                || state == "left" && playerTarget == "left"
                || state == "topleft" && playerTarget == "topleft"
                || state == "topright" && playerTarget == "topright"
                || state == "center" && playerTarget == "center")
            {
                miss++;
                missText.Text = "Missed: " + miss;
            }
            else
            {
                goal++;
                goalText.Text = "Goals: " + goal;
            }
        }

        private void changeState()
        {
            // sollte auch so gehen
            //keeperTimer.Start();
            int i = rnd.Next(0, keeperPosition.Count());

            state = keeperPosition[i].ToString();

            switch (i)
            {
                case 0:
                    goalkeeper.Image = Properties.Resources.left_save_small;
                    break;
                case 1:
                    goalkeeper.Image = Properties.Resources.right_save_small;
                    break;
                case 2:
                    goalkeeper.Image = Properties.Resources.top_save_small;
                    break;
                case 3:
                    goalkeeper.Image = Properties.Resources.top_left_save_small;
                    break;
                case 4:
                    goalkeeper.Image = Properties.Resources.top_right_save_small;
                    break;
                case 5:
                    goalkeeper.Image = Properties.Resources.stand_small;
                    break;
            }
        }

        private void shootball(object sender, EventArgs e)
        {

            football.Left -= ballX;
            football.Top -= ballY;

            if (football.Bounds.IntersectsWith(right.Bounds) && playerTarget == "right"
                || football.Bounds.IntersectsWith(topright.Bounds) && playerTarget == "topright"
                || football.Bounds.IntersectsWith(top.Bounds) && playerTarget == "top"
                || football.Bounds.IntersectsWith(left.Bounds) && playerTarget == "left"
                || football.Bounds.IntersectsWith(topleft.Bounds) && playerTarget == "topleft"
                || football.Bounds.IntersectsWith(center.Bounds) && playerTarget == "center"
                    )
            {
                //alles auf Anfang wenn Ball sein Ziel erreicht
                football.Left = 431;
                football.Top = 500;
                ballX = 0;
                ballY = 0;
                aimSet = false;
                ballTimer.Stop();
                right.BackColor = Color.Yellow;
                topright.BackColor = Color.Yellow;
                top.BackColor = Color.Yellow;
                topleft.BackColor = Color.Yellow;
                left.BackColor = Color.Yellow;
                center.BackColor = Color.Yellow;
            }

        }

        private void moveKeeper(object sender, EventArgs e)
        {
            switch (state)
            {
                case "left":
                    if (goalkeeper.Left > 192)
                    {
                        goalkeeper.Left -= 6;
                        goalkeeper.Top = 206;
                    }
                    else
                    {
                        // auf Anfang
                        goalkeeper.Left = 421;
                        goalkeeper.Top = 162;
                        goalkeeper.Image = Properties.Resources.stand_small;
                        keeperTimer.Stop();
                    }

                    break;
                case "right":
                    if (goalkeeper.Left < 548)
                    {
                        goalkeeper.Left += 6;
                        goalkeeper.Top = 209;
                    }
                    else
                    {
                        // auf Anfang
                        goalkeeper.Left = 421;
                        goalkeeper.Top = 162;
                        goalkeeper.Image = Properties.Resources.stand_small;
                        keeperTimer.Stop();
                    }
                    break;
                case "top":
                    if (goalkeeper.Top > 71)
                    {
                        goalkeeper.Top -= 3;
                    }
                    else
                    {
                        // auf Anfang
                        goalkeeper.Left = 421;
                        goalkeeper.Top = 162;
                        goalkeeper.Image = Properties.Resources.stand_small;
                        keeperTimer.Stop();
                    }
                    break;
                case "topleft":
                    if (goalkeeper.Top > 71)
                    {
                        goalkeeper.Left -= 8;
                        goalkeeper.Top -= 3;
                    }
                    else
                    {
                        // auf Anfang
                        goalkeeper.Left = 421;
                        goalkeeper.Top = 162;
                        goalkeeper.Image = Properties.Resources.stand_small;
                        keeperTimer.Stop();
                    }
                    break;
                case "topright":
                    if (goalkeeper.Top > 71)
                    {
                        goalkeeper.Left += 5;
                        goalkeeper.Top -= 3;
                    }
                    else
                    {
                        // auf Anfang
                        goalkeeper.Left = 421;
                        goalkeeper.Top = 162;
                        goalkeeper.Image = Properties.Resources.stand_small;
                        keeperTimer.Stop();
                    }
                    break;
                case "center":
                    {
                        // auf Anfang
                        goalkeeper.Left = 421;
                        goalkeeper.Top = 162;
                        goalkeeper.Image = Properties.Resources.stand_small;
                        keeperTimer.Stop();
                    }
                    break;
            }
        }

        private void setTarget(object sender, EventArgs e)
        {
            if (aimSet)
            {
                return;
            } // mehrfachauswahl wird verhindert

            ballTimer.Start();
            keeperTimer.Start();

            changeState();

            // Hintergrund des gewählten Ziels ändern
            var senderObject = (PictureBox)sender;
            senderObject.BackColor = Color.Beige;



            if (senderObject.Tag.ToString() == "left")
            {
                ballX = 8;
                ballY = 11;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            if (senderObject.Tag.ToString() == "topleft")
            {
                ballX = 8;
                ballY = 15;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            if (senderObject.Tag.ToString() == "top")
            {
                ballX = 0;
                ballY = 20;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            if (senderObject.Tag.ToString() == "topright")
            {
                ballX = -7;
                ballY = 15;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            if (senderObject.Tag.ToString() == "right")
            {
                ballX = -11;
                ballY = 15;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            if (senderObject.Tag.ToString() == "center")
            {
                ballX = 0;
                ballY = 8;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            checkScore();

        }
    }
}
