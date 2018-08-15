using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar_Draw_Map
{
    public class LiDAR
    {
        public double x { get; set; }
        public double y { get; set; }
        public double top { get; set; }
        public double left { get; set; }
        public double right { get; set; }

        public double With { get; set; }
        public double Height { get; set; }
        public LiDAR(double x, double y, double W, double H)
        {
            this.x = x;
            this.y = y;
            this.top = 0;
            this.left = 0;
            this.right = 0;
            this.With = W;
            this.Height = H;
        }
        public LiDAR()
        {

        }
        static double DegreeToRadius(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }
        public void drawLiDAR(Graphics g, double degre)
        {
            //if (degre == 0 || degre == 180)
            //{
            //    g.FillRectangle(new SolidBrush(Color.Black), (float)(x - ((With / 2) * Form1.Pis)), (float)(y - ((Height+50) * Form1.Pis)), (float)(With * Form1.Pis), (float)(Height * Form1.Pis));
            //}
            //if (degre == 90 || degre == 270)
            //{
            //    //D=R va R=D
            //    g.FillRectangle(new SolidBrush(Color.Black), (float)(x - ((Height+50) * Form1.Pis)), (float)(y - ((With / 2) * Form1.Pis)), (float)(Height * Form1.Pis), (float)(With * Form1.Pis));
            //}

            g.FillRectangle(new SolidBrush(Color.Orange), (float)(x - 60 * Form1.Pis), (float)(y - 60 * Form1.Pis), (float)(120 * Form1.Pis), (float)(120 * Form1.Pis));
        }

        public void setGPS(double top, double left, double right)
        {
            this.top = top;
            this.left = left;
            this.right = right;
        }

        public void Update(double newTop, double newLeft, double newRight, int Degree)
        {
            double DelTop = newTop - this.top;
            double DelLeft = newLeft - this.left;
            double DelRight = newRight - this.right;
            Console.WriteLine("DelTop : " + DelTop + ", DelLeft : " + DelLeft + ", DelRight : " + DelRight);

            if (Degree == 0)
            {
                this.y += DelTop *Form1.Pis;
                this.top = newTop;
            }
            if (Degree == 90)
            {
                this.x += DelTop * Form1.Pis;
                this.top = newTop;
            }
            if (Degree == 180)
            {
                this.y -= DelTop * Form1.Pis;
                this.top = newTop;
            }
            if (Degree == 270)
            {
                this.x -= DelTop * Form1.Pis;
                this.top = newTop;
            }
        }
    } 
        
    
}
