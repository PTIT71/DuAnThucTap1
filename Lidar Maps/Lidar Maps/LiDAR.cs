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
            Console.WriteLine("LiDAR : Top : " + top + ", Left : " + left + ", Right : " + right);
            Console.WriteLine("DelTop : " + DelTop + ", DelLeft : " + DelLeft + ", DelRight : " + DelRight);
            //Code mới

            if(DelTop == 0)
            {
                if(DelLeft<0 && DelRight > 0) // Đi qua trái
                {
                    this.x += DelLeft;
                    this.left = newLeft;
                    this.right = newRight;
                }
                else
                {
                    if(DelLeft>0 && DelRight<0) //Đi qua phải
                    {
                        this.x -= DelRight;
                        this.left = newLeft;
                        this.right = newRight;
                    }
                    else // TH này chưa tính tới
                    {

                    }
                }
            }
            else
            {
                if(DelTop > -20 && DelTop < 20) // Đi thẳng
                {
                    if(DelLeft == 0 || DelRight == 0)
                    {
                        if(DelLeft ==0 && DelRight ==0)
                        {
                            this.y += DelTop;
                            this.top = newTop;
                        }
                        else // TH này chưa tính tới // TH vật cản
                        {

                        }
                    }
                    else // DelLeft != 0 && DelRight != 0
                    {
                        if (DelLeft < 0 && DelRight > 0) // Đi qua trái
                        {
                            this.y += DelTop;
                            this.top = newTop;

                            this.x += DelLeft;
                            this.left = newLeft;
                            this.right = newRight;
                        }
                        else
                        {
                            if (DelLeft > 0 && DelRight < 0) //Đi qua phải
                            {
                                this.y += DelTop;
                                this.top = newTop;

                                this.x -= DelRight;
                                this.left = newLeft;
                                this.right = newRight;
                            }
                            else // TH này chưa tính tới
                            {

                            }
                        }
                    }
                }
                else // (DelTop <= -20 || DelTop >= 20)
                {
                    if (DelLeft < 0 && DelRight > 0) // Đi qua trái
                    {
                        this.x += DelLeft;
                        this.left = newLeft;
                        this.right = newRight;
                    }
                    else
                    {
                        if (DelLeft > 0 && DelRight < 0) //Đi qua phải
                        {
                            this.x -= DelRight;
                            this.left = newLeft;
                            this.right = newRight;
                        }
                        else // TH này chưa tính tới
                        {

                        }
                    }
                }
            }


            
        }
    }
}
