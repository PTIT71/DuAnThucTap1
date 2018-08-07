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
           
                // Deltop=0
                if (DelTop == 0)  // -3 hay 3 là độ sai số
                {
                    //Qua Trái
                    if (DelLeft < 0 && DelRight > 0)
                    {
                        this.x += DelLeft * Map.Pis;
                        // this.y += DelTop * Map.Pis; /// nhẽ rea không cần thiết nhưng vì do sai số

                        this.top = newTop;
                        this.right = newRight;
                        this.left = newLeft;
                    }
                    else
                    {
                        //Qua Phải
                        if (DelLeft > 0 && DelRight < 0)
                        {
                            this.x -= DelRight * Map.Pis;
                            //   this.y += DelTop * Map.Pis; /// nhẽ rea không cần thiết nhưng vì do sai số

                            this.top = newTop;
                            this.right = newRight;
                            this.left = newLeft;
                        }
                        // còn lại là cho đứng yên hết Đứng yên (Delleft=0 && Delright =0)
                        else
                        {
                            this.right = newRight;
                            this.left = newLeft;
                            Console.WriteLine("Đứng yên");
                        }

                    }
                }
                else
                {
                    //  (-) Giới hạnh vật cản < Deltop < (+) Giới hạn vật cản
                    if (DelTop > -50 && DelTop < 50)
                    {
                        //Tiến Trái
                        if (DelTop < 0 && DelRight > 0 && DelLeft < 0)
                        {
                            this.x += DelLeft * Map.Pis;
                            this.y += DelTop * Map.Pis;

                            this.top = newTop;
                            this.right = newRight;
                            this.left = newLeft;
                            Console.WriteLine("Thẳng-Trái");
                        }
                        else
                        {
                            //Lùi Trái
                            if (DelTop > 0 && DelRight > 0 && DelLeft < 0)
                            {
                                this.x += DelLeft * Map.Pis;
                                this.y += DelTop * Map.Pis;

                                this.top = newTop;
                                this.right = newRight;
                                this.left = newLeft;
                                Console.WriteLine("Lùi phải");
                            }
                            else
                            {
                                //Đi Thẳng && Đi Lùi
                                if (DelLeft == 0 && DelRight == 0)
                                {
                                    this.y += DelTop * Map.Pis;

                                    this.top = newTop;
                                    this.right = newRight;
                                    this.left = newLeft;
                                    Console.WriteLine("Thẳng");
                                }
                                else
                                {
                                    //Tiến Phải
                                    if (DelTop < 0 && DelRight < 0 && DelLeft > 0)
                                    {
                                        this.x -= DelRight * Map.Pis;
                                        this.y += DelTop * Map.Pis;

                                        this.top = newTop;
                                        this.right = newRight;
                                        this.left = newLeft;
                                        Console.WriteLine("Tiến phải");
                                    }
                                    else
                                    {
                                        //Lùi Phải
                                        if (DelTop > 0 && DelRight < 0 && DelLeft > 0)
                                        {
                                            this.x -= DelRight * Map.Pis;
                                            this.y += DelTop * Map.Pis;

                                            this.top = newTop;
                                            this.right = newRight;
                                            this.left = newLeft;
                                            Console.WriteLine("Lùi Phải");
                                        }
                                    }
                                }
                            }
                        }


                    }
                    else
                    {
                        //  Deltop < (-) Giới Hạn Vật Cản, Deltop > (+) Giới hạn vật cản
                        if (DelTop < -50 || DelTop > 50)
                        {
                            //Vật cản trái

                            //Vật cản phải
                        }
                    }
                }
           
               
           
        }
    }
}
