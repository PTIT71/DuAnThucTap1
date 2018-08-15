using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar_Draw_Map
{
    public class Map
    {
        public struct GPS
        {
            public double top, left, right;
        }
        public GPS G;
        public List<Dot> lstDot;

        public Map()
        {
            lstDot = new List<Dot>();
        }
        public Map(List<Dot> listDot)
        {
            this.lstDot = listDot;
        }
        public GPS GetGPS()
        {
            G = new GPS();
            foreach(Dot dt in lstDot)
            {
                if ( Convert.ToInt32( dt.Angle) ==0 && G.top== 0)
                {
                    G.top = dt.Dist;
                }
                if (Convert.ToInt32(dt.Angle) <= 5 && G.top == 0)
                {
                    G.top = dt.Dist;
                }
                if (Convert.ToInt32(dt.Angle)==90 &&G.right == 0)
                {
                    G.right=dt.Dist;
                }
                if (dt.Angle >= 88 && dt.Angle <= 90 && G.left == 0)
                {
                    G.right = dt.Dist;

                }
                if (Convert.ToInt32(dt.Angle)== 270&& G.left ==0)
                {
                    G.left = dt.Dist;

                }
                if (dt.Angle >= 270 && dt.Angle <= 272 && G.left == 0)
                {
                    G.left = dt.Dist;

                }

            }
            return G;
        }
       
        public void DrawGPS(Graphics g)
        {
            Console.WriteLine("TOP: " + G.top + "  LEFT: " + G.left + "  RIGHT: " + G.right);
        }
        public void DrawMap(int Degree, Graphics g, LiDAR liDAR)
        {
            for (int i = 0; i < lstDot.Count; i++)
            {
                if (lstDot[i].Dist<=6000)
                {
                    lstDot[i].x = lstDot[i].x * Form1.Pis;
                    lstDot[i].y = lstDot[i].y * Form1.Pis;

                    double X = lstDot[i].x * Math.Cos(DegreeToRadius(Degree)) - lstDot[i].y * Math.Sin(DegreeToRadius(Degree));
                    double Y = lstDot[i].x * Math.Sin(DegreeToRadius(Degree)) + lstDot[i].y * Math.Cos(DegreeToRadius(Degree));

                    X += liDAR.x;
                    Y = liDAR.y - Y;

                    Pen p = new Pen(Color.GreenYellow);
                    g.DrawLine(p, (int)X, (int)Y, (int)X + 1, (int)Y);
                }
            }
        }
        public void ShowGPS()
        {
            GetGPS();
            Console.WriteLine("Top: " + G.top+  "    Left: " + G.left + "   Right: " + G.right);
        }

        public void Show()
        {
            for(int i =0;i<lstDot.Count;i++)
            {
                lstDot[i].Show();
            }
        }
        static double DegreeToRadius(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }
    }
}
