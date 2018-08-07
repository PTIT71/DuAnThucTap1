using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidar_Maps
{
    public class Dot
    {
        //Properties
       public  double Angle { get; set; }
        public double Dist { get; set; }

        public double x { get; set; }
        public double y { get; set; }

        public Dot()
        {

        }
        public Dot(double angl, double dist)
        {
            this.Angle = angl;
            this.Dist = dist;
            this.x = dist * Math.Sin(DegreeToRadius(Angle));
            this.y = dist * Math.Cos(DegreeToRadius(Angle));


        }
        static double DegreeToRadius(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }

        public void Show()
        {
            Console.WriteLine("Angle: " + this.Angle + "      Dist: " + Dist + "        X: " + this.x + "     y: " + this.y);
           
        }


    }
}
