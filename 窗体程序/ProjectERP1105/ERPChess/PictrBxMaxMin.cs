using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing ;

namespace ERPChess
{
    class PictrBxMaxMin
    {
        Timer mytimer = new Timer();
        private PointF stoppoint;
        PictureBox pictureBox;
        double gradient;
        int size;
        public PictrBxMaxMin(PointF stoppoint, PictureBox picturebox,int size)
        {
            this.stoppoint = stoppoint;
            this.pictureBox = picturebox;
            this.size=size;
            gradient = (pictureBox.Location.Y - stoppoint.Y) / (pictureBox.Location.X - stoppoint.X);
            mytimer.Interval = 10;
        }
        public void PictureStretch()
        {
            mytimer.Tick +=new EventHandler(mytimer_Tick);
            mytimer.Start ();
        }
        private void mytimer_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Location.X > stoppoint.X && pictureBox.Location.Y > stoppoint.Y)
            {
                Size temp = new Size(pictureBox.Size.Width + size, pictureBox.Size.Height + (int)(size * gradient));
                pictureBox.Size = temp;
                Point p = new Point(pictureBox.Location.X - size, pictureBox.Location.Y - (int)(size * gradient));
                pictureBox.Location = p;
            }
            else
            {
                mytimer.Stop();
            }
        }      
    }
}
