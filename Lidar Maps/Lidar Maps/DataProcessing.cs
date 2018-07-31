using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lidar_Maps
{
    class DataProcessing
    {
        //Lấy dữ liệu từ file lên mảng chứa:
        public List<double> GetData()
        {

            List<Double> lstDuLieu = new List<double>();
            var fileStream = new FileStream(Form1.fileName, FileMode.Open, FileAccess.Read);
          
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                string recycleLine;
                for (int i = 0; i < 3; i++)
                {
                    streamReader.ReadLine();
                }
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
        public List<double> standarData()
        {
             List<double> lstData = RotateAxis( GetData());

           // List<double> lstData = GetData();

            List<double> lstDataStandar = new List<double>();


            for (int i = 0; i < lstData.Count - 3; i += 3)
            {
                //double x = (lstData[i + 1] * Math.Cos(DegreeToRadius(lstData[i]))) *0.1 +300;
                //double y = (lstData[i + 1] * Math.Sin(DegreeToRadius(lstData[i]))) * 0.1 +300;

                double x = (lstData[i + 1] * Math.Cos(DegreeToRadius(lstData[i]))) * Form1.dophangiai/100 + 400;
                double y = (lstData[i + 1] * Math.Sin(DegreeToRadius(lstData[i]))) * Form1.dophangiai/100 + 400;

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
        //Xoay Hệ trục tọa độ 180 độ: chuyển hệ trục lập trình sang hệ trục normal
        public List<double> RotateAxis(List<double> lst)
        {
            for(int i =0;i<lst.Count-3;i+=3)
            {
                lst[i] -=90;
            }
            return lst;
        }
        //chuyển dổi độ sang radian ứng dụng trong hàm sin cos trong standarData Function
        static double DegreeToRadius(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }

         

    }
}
