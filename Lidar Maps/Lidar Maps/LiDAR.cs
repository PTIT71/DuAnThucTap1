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
            // --------------------------------------------------------------------------------------------------------------
            if (DelTop == 0) // LiDAR di chuyển qua trái || phải
            {
                if(DelLeft == 0 || DelRight == 0)
                {
                    if(DelLeft == 0 && DelRight == 0) // LiDAR không di chuyển // DelTop == 0 && DelLeft == 0 && DelRight == 0
                    {

                    }
                    else // DelLeft == 0 || DelRight == 0
                    {
                        if(DelLeft == 0) // DelRight != 0 // Có thể có vật cản bên phải
                        {
                            if(DelRight < -20 || DelRight > 20) // Trường hợp là vật cản bên phải
                            {

                            }
                            else // Đây là trường hợp rung lắc
                            {

                            }
                        }
                        else // DelRight == 0 && DelLeft != 0 // Có thể có vật cản bên trái
                        {
                            if (DelLeft < -20 || DelLeft > 20) // Trường hợp là vật cản bên trái
                            {

                            }
                            else // Đây là trường hợp rung lắc
                            {

                            }
                        }
                    }
                }
                else // DelLeft != 0 && DelRight != 0 && DelTop == 0
                {
                    if ((DelLeft >= -20 && DelLeft <= 20) || (DelRight >= -20 && DelRight <= 20))
                    {
                        if((DelLeft >= -20 && DelLeft <= 20) && (DelRight >= -20 && DelRight <= 20))
                        {

                        }
                        else
                        {
                            if(DelLeft >= -20 && DelLeft <= 20) // DelRight < -20 || DelRight > 20 // Di chuyển trái,có vật cản bên phải
                            {

                            }
                            else // DelRight >= -20 && DelRight <= 20 && (DelLeft < -20 || DelLeft > 20) // Di chuyển bên phải, có vật cản bên trái
                            {

                            }
                        }
                    }
                    else // (DelLeft < -20 || DelLeft > 20) && (DelRight < -20 || DelRight > 20) // Có vật cản 2 bên
                    {
                        
                    }
                }
            }
            else
            {
// --------------------------------------------------------------------------------------------------------------
                if(DelTop >= -20 && DelTop <= 20)
                {
                    if (DelLeft == 0 || DelRight == 0)
                    {
                        if (DelLeft == 0 && DelRight == 0) // LiDAR di chuyển tiến/lùi thẳng // DelTop >= -20 && DelTop <= 20 && DelLeft == 0 && DelRight == 0
                        {

                        }
                        else // (DelLeft == 0 && DelRight != 0) || (DelRight == 0 && DelLeft != 0) && (DelTop >= -20 && DelTop <= 20)
                        // TH :
                        //- Đi thẳng, gặp vật cản trái
                        //- Đi thẳng, gặp vật cản phải
                        {
                            if (DelLeft == 0) // DelRight != 0 // Có thể có vật cản bên phải
                            {
                                if (DelRight < -20 || DelRight > 20) // Trường hợp đi thẳng, gặp vật cản bên phải
                                                                     // (DelTop >= -20 && DelTop <= 20) && DelLeft == 0 && ( DelRight < -20 || DelRight > 20 )
                                {

                                }
                                else // Đây là trường hợp rung lắc
                                {
                                    // Trường hợp này bỏ qua
                                }
                            }
                            else // DelRight == 0 && DelLeft != 0 // Có thể có vật cản bên trái
                            {
                                if (DelLeft < -20 || DelLeft > 20) // Trường hợp đi thẳng, gặp vật cản bên trái
                                                                   // (DelTop >= -20 && DelTop <= 20) && DelRight == 0 && ( DelLeft < -20 || DelLeft > 20 )
                                {

                                }
                                else // Đây là trường hợp rung lắc
                                {
                                    // Trường hợp này bỏ qua
                                }
                            }
                        }
                    }
                    else // DelLeft != 0 && DelRight != 0 && ( DelTop >= -20 && DelTop <= 20 )
                    // TH:
                    // - Đi thẳng, gặp vật cản 2 bên // TH : lòi ra || thụt vô 
                    // - Đi thẳng, qua trái , gặp vật cản phải
                    // - Đi thẳng, qua phải , gặp vật cản trái
                    // - ? Đi thẳng, qua trái, gặp vật cản trái
                    // - ? Đi thẳng, qua phải, gặp vật cản trái
                    {
                        if ((DelLeft >= -20 && DelLeft <= 20) || (DelRight >= -20 && DelRight <= 20))
                        {
                            if ((DelLeft >= -20 && DelLeft <= 20) && (DelRight >= -20 && DelRight <= 20)) //&& && ( DelTop >= -20 && DelTop <= 20 )
                                // TH : - đi thẳng xiên quá trái hoặc phải
                            {
                                if(DelLeft < 0 && DelRight > 0) // Chương trình qua trái
                                {

                                }
                                else
                                {
                                    if(DelRight > 0 && DelLeft < 0) // Chương trình qua phải
                                    {

                                    }
                                    else // TH : - DelLeft, DelRight cùng lớn hơn hoặc nhỏ hơn 0 // Không phải trường hợp VC // Không phải trường hợp VC 2 bên // Có thể do rung lắc
                                    {

                                    }
                                }
                            }
                            else
                            {
                                if (DelLeft >= -20 && DelLeft <= 20) // DelRight < -20 || DelRight > 20 // Di chuyển trái,có vật cản bên phải
                                {

                                }
                                else // DelRight >= -20 && DelRight <= 20 && (DelLeft < -20 || DelLeft > 20) // Di chuyển bên phải, có vật cản bên trái
                                {

                                }
                            }
                        }
                        else // (DelLeft < -20 || DelLeft > 20) && (DelRight < -20 || DelRight > 20) && ( DelTop >= -20 && DelTop <= 20 ) // Có vật cản 2 bên
                        {

                        }
                    }
                }
// --------------------------------------------------------------------------------------------------------------
                else // DelTop < -20 || DelTop > 20 // Trường hợp vật cản || Qua trái , phải có vật cản phía trên
                {
                    if (DelLeft < 0 && DelRight > 0) // Chương trình qua trái
                    {

                    }
                    else
                    {
                        if (DelRight > 0 && DelLeft < 0) // Chương trình qua phải
                        {

                        }
                        else // TH : - DelLeft, DelRight cùng lớn hơn hoặc nhỏ hơn 0 // Không phải trường hợp VC 2 bên // Có thể do rung lắc
                        {

                        }
                    }
                }
            }


            
        }
    }
}
