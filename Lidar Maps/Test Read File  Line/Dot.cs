using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Read_File__Line
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
            this.x = dist * Math.Cos(DegreeToRadius(angl));
            this.y = dist * Math.Sin(DegreeToRadius(angl));

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
