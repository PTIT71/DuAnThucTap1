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

        public void DrawMap(Graphics g, double DeltaTop, double DeltaRight, double DeltaLeft)
        {
            //Console.WriteLine("Top : " + G.top);
            //Console.WriteLine("DE : " + DeltaTop);
            //Console.WriteLine("--------------------------------------");
            for (int i = 0; i < lstDot.Count; i++)
            {
                lstDot[i].x = lstDot[i].x ;
                lstDot[i].y = lstDot[i].y ;
                
                lstDot[i].x += 400 - DeltaTop;
                lstDot[i].y += 400 ;
                


                g.DrawLine(new Pen(Color.Red, 2), (int)lstDot[i].x, (int)lstDot[i].y, (int)lstDot[i].x + 2, (int)lstDot[i].y);
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
