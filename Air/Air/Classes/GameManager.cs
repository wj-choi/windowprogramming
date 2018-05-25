﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    class GameManager
    {
        public DateTime updateFlag;
        public DateTime timeFlag;
        public bool checkTime = true;
        public float waitForSeconds = 4.5f;

        public string sceneName = "Logo";

        public bool update = false;
        public bool playing = false;
        public bool initialization = true;
        public static double score;

        public void gameOver(Player player)
        {
            player.isGrounded = player.location.Y > 720 - 150 ? true : false;

            if (player.isGrounded)
            {
                score = Math.Round(player.flightDistance, 0);
                player.gameStart = false;

                if (player.speed > 0)
                {
                    player.speed -= (player.airResistance) / player.slidingValue + 2;
                    player.location.X += (int)player.speed;
                }

                else
                {
                    if (checkTime)
                    {
                        timeFlag = DateTime.Now;
                        checkTime = false;
                    }

                    TimeSpan currentTime = DateTime.Now - timeFlag;

                    if (currentTime.TotalSeconds > waitForSeconds)
                    {
                        playing = false;

                        scoreForm scoreForm = new scoreForm();

                        scoreForm.StartPosition = FormStartPosition.Manual;
                        scoreForm.Location = new Point(1280 / 2 - (scoreForm.Size.Width / 10), ((720 / 2) - scoreForm.Size.Height / 3));
                        scoreForm.ShowDialog();    // this is modeless
                    }
                }
            }
        }
    }
}