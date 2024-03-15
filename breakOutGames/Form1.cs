using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breakOutGames
{
    public partial class Form1 : Form
    {
        public int vSpeed;
        public int hSpeed;
        public const int row = 5;
        public const int col = 6;
        public PictureBox[,] blocks; 
        //constructor

        public Form1()
        {
            vSpeed = 3;
            hSpeed = 3;
            setBlocks();
            InitializeComponent();
           
        }

        private void setBlocks()
        {
            int blockHeight = 25;
            int blockWidth = 100;

            blocks = new PictureBox[row, col];

            for(int x = 0;x  < row; x++)
            {
                for(int  y = 0; y < col; y++)
                {
                    blocks[x, y] = new PictureBox();

                    blocks[x, y].Width = blockWidth;
                    blocks[x, y].Height = blockHeight;
                    blocks[x, y].Top = blockHeight * x;
                    blocks[x, y].Left = blockHeight * y;
                    blocks[x, y].BackColor = Color.Green;
                    blocks[x, y].BorderStyle = BorderStyle.Fixed3D;

                    this.Controls.Add(blocks[x, y]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //Method Control Ball
        {
            picBall.Top += vSpeed;
            picBall.Left += hSpeed;

            if(picBall.Bottom > this.ClientSize.Height) //เงื่อไขที่ทำให้บอลไม่ออกจากแมพเด้งอยู่แค่ในหน้าwindow
            {
                vSpeed = -vSpeed;
            }

            if(picBall.Top < 0)
            {
                vSpeed = -vSpeed;
            }

            if(picBall.Right > this.ClientSize.Width)
            {
                hSpeed = -hSpeed;
            }

            if(picBall.Left < 0)
            {
                hSpeed = -hSpeed;
            }

            //When Ball Collides with paddle
            if (picBall.Bounds.IntersectsWith(pictPaddle.Bounds) ==  true )
            {
                vSpeed = -vSpeed;
                //hSpeed = -hSpeed;
            }

            //detect collision with blocks
            for(int x = 0; x < row; x++)
            {
                for(int y = 0; y < col; y++)
                {
                    if (picBall.Bounds.IntersectsWith(blocks[x, y].Bounds)&& blocks[x,y].Visible == true)
                    {
                        blocks[x, y].Visible = false;
                        vSpeed = -vSpeed;
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            pictPaddle.Left = e.X - (pictPaddle.Width / 2);
        }
    }
}
