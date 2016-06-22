using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Input;

namespace RapidRoll
{
    public partial class Form1 : Form
    {
        Button[] myButton = new Button[5];
        RoundButton rButton = new RoundButton();
        int Xposition;
        int Yposition;
        static int rButtonPositionX;
        static int rButtonPositionY;
        Random randomNumber;
        Point[] bPoint = new Point[5];

        public Form1()
        {
            InitializeComponent();
            //ClientSize = new Size(900, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            randomNumber = new Random();

            for (int i = 0; i < myButton.Length; i++)
            {
                myButton[i] = new Button();
                myButton[i].Width = 100;
                myButton[i].Height = 20;
                myButton[i].Enabled = false;
                myButton[i].BackColor = Color.Beige;
                Xposition = randomNumber.Next(0, panel1.Width - 100);  // except the button width
                Yposition = randomNumber.Next(0, panel1.Height);

                bPoint[i] = new Point(Xposition, Yposition);
                myButton[i].Location = bPoint[i];
                panel1.Controls.Add(myButton[i]);
            }


            rButtonPositionX = 30;
            rButtonPositionY = 30;
            rButton.Location = new Point(rButtonPositionX, rButtonPositionY);
            rButton.Width = 25;
            rButton.Height = 25;
            rButton.Enabled = false;
            panel1.Controls.Add(rButton);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < myButton.Length; i++)
            {
                myButton[i].Location = new Point(bPoint[i].X, bPoint[i].Y -= 2);
                if (bPoint[i].Y < 0)
                {
                    bPoint[i].X = randomNumber.Next(0, panel1.Width - 100);
                    bPoint[i].Y = panel1.Height;
                }

                
                if (rButtonPositionY > panel1.Height)    //if the button go below
                {
                    rButtonPositionX = randomNumber.Next(0, panel1.Width - 25);
                    rButtonPositionY = randomNumber.Next(0, panel1.Height - 25);
                }
                if (rButton.Bounds.IntersectsWith(myButton[i].Bounds))  //if the button go up
                {

                    rButton.Location = new Point(rButtonPositionX, rButtonPositionY -= 2);
                    if (rButtonPositionY < 0)
                    {
                        rButtonPositionX = randomNumber.Next(0, panel1.Width - 25);
                        rButtonPositionY = randomNumber.Next(0, panel1.Height - 25);
                    }
                }
                if (rButton.Bounds.IntersectsWith(myButton[i].Bounds))
                {
                    rButton.Location = new Point(rButtonPositionX, rButtonPositionY += 1);
                }
            }            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //int x = 0;
            //int y = 0;
            //e.Graphics.DrawLine(Pens.Red, x + 20, 0, x + 20, ClientSize.Height);
            //e.Graphics.DrawLine(Pens.Red, 0, y + 20, ClientSize.Width, y + 20);
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                rButton.Location = new Point(rButtonPositionX += 5, rButtonPositionY);
            }
            if (e.KeyCode == Keys.Left)
            {
                rButton.Location = new Point(rButtonPositionX -= 5, rButtonPositionY);
                e.ToString();
            }
        }
    }
}
