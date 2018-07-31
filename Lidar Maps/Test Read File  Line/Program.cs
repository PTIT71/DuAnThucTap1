using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_Read_File__Line
{
    class Program
    {
        public static int z0 = 0, y0 = 0, x0 = 0;
        public static double deltaX = 0, deltaY = 0, deltaZ = 0;
        static void Main(string[] args)
        {

            Console.Write("Top: "); x0 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Left: "); z0 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Right: "); y0 = Convert.ToInt32(Console.ReadLine());

            ConvertToaDo();

            Console.ReadKey();

        }

        static int head = 0;
        static int last = 0;
        public static void ConvertToaDo()
        {
            //Lấy dữ liệu từ file
            List<double> lstDuLieu = new List<double>();
            lstDuLieu = GetData();

            for(int i =head+9;i<lstDuLieu.Count;i+=3)
            {
                if((int)lstDuLieu[i]==0 || (int)lstDuLieu[i] == 1)
                {
                    last = i;
                    break;
                }
            }




            //for (int i = head; i < last; i += 3)
            //{
            //    Console.WriteLine("Angle: " + lstDuLieu[i] + " " + "Dist: " + lstDuLieu[i + 1]);
            //}

            Console.Write(Math.Cos(270));


            Console.Write("Xong");
        }
        static public void XuatDuLieuLenManHinh()
        {

            List<double> lstDuLieu = new List<double>();
            // lstDuLieu = standarData();
            lstDuLieu = GetData();
            Console.WriteLine(lstDuLieu.Count());
            for (int i = 0; i < lstDuLieu.Count; i += 3)
            {
                Console.WriteLine("Angle: " + lstDuLieu[i] + " " + "Dist: " + lstDuLieu[i + 1]);
            }
        }
        static public List<double> standarData()
        {
            // List<double> lstData = RotateAxis180( GetData());

            List<double> lstData =GetData();

            List<double> lstDataStandar = new List<double>();


            for (int i = 0; i < lstData.Count - 3; i += 3)
            {
                double x = (lstData[i + 1] * Math.Cos(DegreeToRadius(lstData[i])))*0.1;
                double y = (lstData[i + 1] * Math.Sin(DegreeToRadius(lstData[i])))*0.1;

                //Test đọc giá trị được tính tóa
               // Console.WriteLine("Khoang Cach: " + lstData[i + 1] + " " + "Angle: " + lstData[i]);
                //

                //Hết test
                lstDataStandar.Add(x);
                lstDataStandar.Add(y);
            }

            Console.WriteLine("So Dong: " + lstDataStandar.Count);
            return lstDataStandar;
        }
        static double DegreeToRadius(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }
        static public List<double> GetData()
        {
            List<Double> lstDuLieu = new List<double>();
            var fileStream = new FileStream("DuLieu.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    foreach (string number in data)
                    {
                        lstDuLieu.Add(Convert.ToDouble(number));
                    }
                }
            }
            return lstDuLieu;
        }
       static List<double> RotateAxis180(List<double> lst)
        {
            for (int i = 0; i < lst.Count - 3; i += 3)
            {
                lst[i] += 90;
            }
            return lst;
        }

    }
}
