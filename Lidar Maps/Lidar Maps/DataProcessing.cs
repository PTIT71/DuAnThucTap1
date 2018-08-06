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
        public bool IsReadFile = false;
        //Lấy dữ liệu từ file lên mảng chứa:
        public List<Map> GetData()
        {
            //Danh sách các map mỗi lần wet
            List<Map> lstMap = new List<Map>();
            //Mỗi Map đơn vị: Chứa listdot
            Map map = new Map();
            lstMap.Add(map);
            //Đọc file
            var fileStream = new FileStream(Form1.fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                ////đọc 3 line rác
                //for (int i = 0; i < 3; i++)
                //{
                //    streamReader.ReadLine();
                //}
                ////Start Get data
                //string line;
                //Dot newDot;
                //Dot oldDot = new Dot(-1, -1);
                //while ((line = streamReader.ReadLine()) != null)
                //{
                //    string[] data = line.Split(' ');
                //    newDot = new Dot(Convert.ToDouble(data[0]), Convert.ToDouble(data[1]));

                //    if (newDot.Angle < oldDot.Angle && ((oldDot.Angle) >= (359))&&(newDot.Angle <= 2)) // -90 quay hình
                //    {
                //        //Qua map mới
                //        map = new Map();
                //        lstMap.Add(map);
                //        lstMap[lstMap.Count - 1].lstDot.Add(newDot);
                //        oldDot = newDot;
                //    }
                //    else //Ngay lần đầu làm việc ấy; nó đã vào đây. Cho đến khi đụng phần tử của map mới
                //    {
                //        //Bỏ vô Map hiện tại
                //        lstMap[lstMap.Count - 1].lstDot.Add(newDot);
                //        oldDot = newDot;
                //    }

                //}

                //Start Get data
                //Ngay từ đầu vào đã cho đọc rồi
                string line;
                Dot newDot = new Dot(-1,-1);
                Dot oldDot = new Dot(-1, -1);
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    if (IsReadFile)
                    {
                        newDot = new Dot(Convert.ToDouble(data[0]), Convert.ToDouble(data[1]));
                        if (newDot.Angle < oldDot.Angle && ((oldDot.Angle) >= (359)) && (newDot.Angle <= 2)) // -90 quay hình
                        {
                            //Qua map mới
                            map = new Map();
                            lstMap.Add(map);
                            lstMap[lstMap.Count - 1].lstDot.Add(newDot);
                            oldDot = newDot;
                        }
                        else //Ngay lần đầu làm việc ấy; nó đã vào đây. Cho đến khi đụng phần tử của map mới
                        {
                            //Bỏ vô Map hiện tại
                            lstMap[lstMap.Count - 1].lstDot.Add(newDot);
                            oldDot = newDot;
                        }
                    }
                    else
                    {
                        if(CheckDataValid(line))
                        {
                            data = line.Split(' ');
                            newDot = new Dot(Convert.ToDouble(data[0]), Convert.ToDouble(data[1]));
                            if (newDot.Angle < oldDot.Angle && ((oldDot.Angle) >= (359)) && (newDot.Angle <= 2)) // -90 quay hình
                            {
                                //Qua map mới
                                map = new Map();
                                lstMap.Add(map);
                                lstMap[lstMap.Count - 1].lstDot.Add(newDot);
                                oldDot = newDot;
                            }
                            else //Ngay lần đầu làm việc ấy; nó đã vào đây. Cho đến khi đụng phần tử của map mới
                            {
                                //Bỏ vô Map hiện tại
                                lstMap[lstMap.Count - 1].lstDot.Add(newDot);
                                oldDot = newDot;
                            }
                            IsReadFile = true;

                        }
                    }
                   

                  

                }


            }
            IsReadFile = false;
            return lstMap;
        }

        public bool CheckDataValid(string Line)
        {
            try
            {
                string []data = Line.Split(' ');
                Dot newDot = new Dot(Convert.ToDouble(data[0]), Convert.ToDouble(data[1]));

                if((int)newDot.Angle == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /*
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
        */
         

    }
}
