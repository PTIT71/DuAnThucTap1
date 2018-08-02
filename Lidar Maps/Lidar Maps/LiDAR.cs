using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar_Maps
{
    public class LiDAR
    {
        public double x { get; set; }
        public double y { get; set; }
        public double top { get; set; }
        public double left { get; set; }
        public double right { get; set; }

        public LiDAR(double x,double y)
        {
            this.x = x;
            this.y = y;
            this.top = 0;
            this.left = 0;
            this.right = 0;
        }

        public void drawLiDAR(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Orange), (float)x - 1, (float)y - 1, 2, 2);
        }

        public void setGPS(double top,double left,double right)
        {
            this.top = top;
            this.left = left;
            this.right = right;
        }

        public void Update(double newTop,double newLeft, double newRight)
        {
            double DelTop = newTop - this.top;
            double DelLeft = newLeft - this.left;
            double DelRight = newRight - this.right;
            Console.WriteLine("DelTop : " + DelTop + ", DelLeft : " + DelLeft + ", DelRight : " + DelRight);
            //Code mới

            if(DelTop == 0) // Không đi thẳng
            {
                if (DelLeft == 0 || DelRight == 0)
                {
                    if (DelLeft == 0 && DelRight == 0) // đi thẳng
                    {

                    }
                    else //Không làm, thay đổi địa hình
                    {

                    }
                }
                else
                {
                    if (DelLeft * DelRight < 0)
                    {
                        if (DelLeft < 0)
                        {
                            DelLeft = DelLeft * -1;
                            this.y = this.y - ((DelLeft + DelRight) / 2) * Map.Pis;
                        }
                        else
                        {
                            DelRight = DelRight * -1;
                            this.y = this.y + ((DelLeft + DelRight) / 2) * Map.Pis;
                        }
                    }
                    else //thay đổi địa hình
                    {

                    }
                }
                this.top = newTop;
                this.left = newLeft;
                this.right = newRight;
            }
            else // Có đi thẳng
            {
                if (DelTop > -50)
                {
                    this.x = this.x - DelTop * Map.Pis; // đi thẳng

                    this.top = newTop;
                    this.left = newLeft;
                    this.right = newRight;
                }
                else
                {
                    this.top = this.top;
                    this.left = newLeft;
                    this.right = newRight;
                }
                if(DelLeft == 0 || DelRight == 0)
                {
                    if(DelLeft == 0 && DelRight == 0) // đi thẳng
                    {

                    }
                    else //Không làm, thay đổi địa hình
                    {
                        
                    }
                }
                else
                {
                    if(DelLeft*DelRight < 0)
                    {
                        if(DelLeft < 0)
                        {
                            DelLeft = DelLeft * -1;
                            this.y = this.y - ((DelLeft + DelRight)/2) * Map.Pis;
                        }
                        else
                        {
                            DelRight = DelRight * -1;
                            this.y = this.y + ((DelLeft + DelRight) / 2) * Map.Pis;
                        }
                    }
                    else //thay đổi địa hình
                    {

                    }
                }
            }


            
        }
    }
}
