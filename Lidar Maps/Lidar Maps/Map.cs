using Lidar_Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar_Maps
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
        
        public GPS GetGPS()
        {
            G = new GPS();
            foreach(Dot dt in lstDot)
            {
                if ( Convert.ToInt32( dt.Angle) ==0 && G.top== 0)
                {
                    G.top = dt.Dist;
                }
                if (Convert.ToInt32(dt.Angle) == 1 && G.top == 0)
                {
                    G.top = dt.Dist;
                }
                if (Convert.ToInt32(dt.Angle)==90 &&G.right == 0)
                {
                    G.right=dt.Dist;
                }
                if (Convert.ToInt32(dt.Angle) == 91 && G.right == 0)
                {
                    G.right = dt.Dist;
                }
                if (Convert.ToInt32(dt.Angle)== 270&& G.left ==0)
                {
                    G.left = dt.Dist;

                }
                if (Convert.ToInt32(dt.Angle) == 271 && G.left == 0)
                {
                    G.left = dt.Dist;

                }

            }
            return G;
        }
        double Pis = 0.5;
        public void DrawGPS(Graphics g)
        {
          
            //  
            Console.WriteLine("TOP: " + G.top + "  LEFT: " + G.left + "  RIGHT: " + G.right);

        } 
        public void DrawMap(Graphics g, double DeltaTop, double DeltaRight, double DeltaLeft)
        {
            //Console.WriteLine("Top : " + G.top);
            //Console.WriteLine("DE : " + DeltaTop);
            //Console.WriteLine("--------------------------------------");
            for (int i = 0; i < lstDot.Count; i++)
            {
               
                lstDot[i].x = lstDot[i].x*Pis ;
                lstDot[i].y = lstDot[i].y * Pis;
                
                lstDot[i].x += 400 - DeltaTop * Pis;
                lstDot[i].y += 400 - DeltaRight*Pis;

                //Xoay 90 do

              //  double X = lstDot[i].y;
              //  double Y = (-lstDot[i].x)+800;

                //Console.WriteLine(X + "  " + Y);
                Pen p = new Pen(Color.GreenYellow);
                g.DrawLine(new Pen(Color.Red, 2), (int)lstDot[i].x, (int)lstDot[i].y, (int)lstDot[i].x + 1, (int)lstDot[i].y);
                // g.DrawLine(p, (int)X, (int)Y, (int)X + 1, (int)Y);
               

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
    }
}
