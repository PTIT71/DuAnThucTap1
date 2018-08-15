using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lidar_Draw_Map
{
    class DataProcessing
    {
        public List<Map> ConvertMap(List<Map> lstMap)
        {
            List<Map> newListMap = new List<Map>();
            foreach (Map map in lstMap)
            {
                Map newMap;
                List<Dot> tempListDot = new List<Dot>();
                double S = 0;
                int n = 1;
                S += map.lstDot[0].Dist;
                for (int i = 0; i < map.lstDot.Count - 1; i++)
                {
                    Dot tempDot;
                    if ((int)(map.lstDot[i].Angle) == (int)(map.lstDot[i + 1].Angle))
                    {
                        n++;
                        S += map.lstDot[i + 1].Dist;
                    }
                    else
                    {

                        tempDot = new Dot((int)(map.lstDot[i].Angle), (S / n));
                        tempListDot.Add(tempDot);
                        S = map.lstDot[i + 1].Dist;
                        n = 1;

                    }
                }
                newMap = new Map(tempListDot);
                newListMap.Add(newMap);
            }
            return newListMap;
        }
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
                        if (newDot.Angle < oldDot.Angle && ((oldDot.Angle) >= (300)) && (newDot.Angle <= 15)) // -90 quay hình
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

        public List<Map> xulydulieu()
        {
            List<Map> lst = GetData();
            List<Map> realMAp = new List<Map>();
            for(int i =0;i<lst.Count;i++)
            {
                double valueSave = 0;
                int count = 0;
                double TBAge = 0;
                double TBDis = 0;
                Map mn = new Map();
                for(int j =0;j<lst[i].lstDot.Count;j++)
                {
                    if((int)lst[i].lstDot[j].Angle!=valueSave )
                    {
                        TBAge = TBAge / (double)count;
                        TBDis = TBDis / (double)count;

                        if(!(TBDis==0 && TBAge==0))
                        {
                            Dot d = new Dot(TBAge, TBDis);
                            mn.lstDot.Add(d);
                        }
                    }
                }
                realMAp.Add(mn);
            }
            return realMAp;
        }
    }
}
