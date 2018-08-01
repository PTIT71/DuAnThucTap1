using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Read_File__Line
{
    class Map
    {
        struct GPS
        {
            public double top, left, right, top1;
        }
        GPS G;
        public List<Dot> lstDot;

        public Map()
        {
            lstDot = new List<Dot>();
        }
        
        public void GetGPS()
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
                if (Convert.ToInt32(dt.Angle)==270&& G.left ==0)
                {
                    G.left = dt.Dist;

                }
                if (Convert.ToInt32(dt.Angle) == 271 && G.left == 0)
                {
                    G.left = dt.Dist;

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
    }
}
