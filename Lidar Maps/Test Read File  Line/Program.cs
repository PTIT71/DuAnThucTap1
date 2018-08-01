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

            //Console.Write("Top: "); x0 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Left: "); z0 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Right: "); y0 = Convert.ToInt32(Console.ReadLine());

            XuatDuLieuLenManHinh();

            Console.ReadKey();

        }

        static int head = 0;
        static int last = 0;
        public static void ConvertToaDo()
        {
          
        }
        static public void XuatDuLieuLenManHinh()
        {
            List<Map> lstMap = GetData();

            for(int i=0;i<lstMap.Count;i++)
            {
                Console.WriteLine("Map: " + (i+1).ToString());
                // lstMap[i].ShowGPS();
                lstMap[i].Show();

                Console.WriteLine();
            }
           
        }
        //static public List<double> standarData()
        //{
            //// List<double> lstData = RotateAxis180( GetData());

            //List<double> lstData =GetData();

            //List<double> lstDataStandar = new List<double>();


            //for (int i = 0; i < lstData.Count - 3; i += 3)
            //{
            //    double x = (lstData[i + 1] * Math.Cos(DegreeToRadius(lstData[i])))*0.1;
            //    double y = (lstData[i + 1] * Math.Sin(DegreeToRadius(lstData[i])))*0.1;

            //    //Test đọc giá trị được tính tóa
            //   // Console.WriteLine("Khoang Cach: " + lstData[i + 1] + " " + "Angle: " + lstData[i]);
            //    //

            //    //Hết test
            //    lstDataStandar.Add(x);
            //    lstDataStandar.Add(y);
            //}

            //Console.WriteLine("So Dong: " + lstDataStandar.Count);
            //return lstDataStandar;
        //}
        static double DegreeToRadius(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }
        
        static public List<Map> GetData()
        {
            //Danh sách các map mỗi lần wet
            List<Map> lstMap = new List<Map>();
            //Mỗi Map đơn vị: Chứa listdot
            Map map = new Map();
            lstMap.Add(map);
            //Đọc file
            var fileStream = new FileStream("DuLieu.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                //đọc 3 line rác
                string recycleLine;
                for (int i = 0; i < 3; i++)
                {
                    streamReader.ReadLine();
                }
                //Start Get data
                string line;
                Dot newDot;
                Dot oldDot = new Dot(-1,-1);
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    newDot = new Dot(Convert.ToDouble(data[0]), Convert.ToDouble(data[1]));
                    
                    if(newDot.Angle<oldDot.Angle &&(oldDot.Angle)>359)
                    {
                        //Qua map mới
                        map = new Map();
                        lstMap.Add(map);
                        lstMap[lstMap.Count-1].lstDot.Add(newDot);
                        oldDot = newDot;
                    }
                    else //Ngay lần đầu làm việc ấy; nó đã vào đây. Cho đến khi đụng phần tử của map mới
                    {
                        //Bỏ vô Map hiện tại
                        lstMap[lstMap.Count-1].lstDot.Add(newDot);
                        oldDot = newDot;
                    }
                    
                }
            }
            return lstMap;
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
