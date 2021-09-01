using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spawn_Objects_Randomly_in_the_Form_MOO_ICT
{
    public partial class Form1 : Form
    {

        List<PictureBox> items = new List<PictureBox>();
        Random rand = new Random();

        int x, y;
        int playerSpeed = 8;
        int spawnTime = 20;

        Color[] newColor = {Color.Red, Color.Turquoise, Color.Gold, Color.LimeGreen };

        bool goUp, goDown, goLeft, goRight;
        public Form1()
        {
            InitializeComponent();
        }

        private void MakePictureBox()
        {
            PictureBox new_pic = new PictureBox();
            new_pic.Height = 30;
            new_pic.Width = 30;
            new_pic.BackColor = newColor[rand.Next(0, newColor.Length)];

            x = rand.Next(10, this.ClientSize.Width - new_pic.Width);
            y = rand.Next(10, this.ClientSize.Height - new_pic.Height);

            new_pic.Location = new Point(x, y);

            items.Add(new_pic); // add to the list
            this.Controls.Add(new_pic); // add to the form
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            // do the player movement below

            if (goLeft)
            {
                player.Left -= playerSpeed;
            }
            if (goRight)
            {
                player.Left += playerSpeed;
            }
            if (goUp)
            {
                player.Top -= playerSpeed;
            }
            if (goDown)
            {
                player.Top += playerSpeed;
            }

            // end of player movement

            lblItemsCount.Text = "Items: " + items.Count();
            // show the total number of items available inside of the list

            spawnTime -= 1;

            if (spawnTime < 1)
            {
                MakePictureBox();
                spawnTime = 20;
            }

            // collision between the player the items picturebox

            foreach (PictureBox item in items.ToList())
            {
                if (player.Bounds.IntersectsWith(item.Bounds))
                {
                    // if the collision happened do the following
                    items.Remove(item);
                    this.Controls.Remove(item);
                }

            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }
    }
}
