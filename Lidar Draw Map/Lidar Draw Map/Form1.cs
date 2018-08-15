using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lidar_Draw_Map
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DrawScreen ScreenView = new DrawScreen(1200, 690, new Point(2,0));

        Timer TimerDraw;

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //Add panel hiển thị vẽ vào Form
            ScreenView.Anchor = (AnchorStyles.Right);
            ScreenView = new DrawScreen(pn2.Width, pn2.Height, new Point(2, 0));
            pn2.Controls.Add(ScreenView);

            //Combobox chọn 0 độ là đầu tiên
            cmbDreg.SelectedIndex = 0;

            //Setup ban đầu tỷ  lệ là 0.02
            trackRate.Value = 2;
            Pis = trackRate.Value / 100.0;
            textRate.Text = string.Format("{0:0.00}", Pis);

            //setup Timer
            TimerDraw = new Timer();
            TimerDraw.Interval = 10;
            TimerDraw.Tick += TimerDraw_Tick;
            TimerDraw.Start();

            
           
        }

        private void TimerDraw_Tick(object sender, EventArgs e)
        {
            //Luôn luôn vẽ lại màn hình (những gì có trên màn hình)
            ScreenView.RePaint();

            //Khi bấm nút draw thì cờ boolIsDraw được khởi động và vẽ máp
            if (bIsDraw==true)
            {   
                ScreenView.DrawMapOnScreen(liDAR,ProcessingMap(),deg,(indexCurentMap-1));
            }
            //Lúc này chưa set tọa độ của trục tọa độ
            if (DrawScreen.bCoordAxis==false)
            {
                //Xóa liên mục đặng cập nhật trục tọa độ hiện tại
                ScreenView.Clear();
            }
            //. Bắt đầu chương trình chỉnh sửa lúc này đã bấm nút"Earse" hệ thống đã lưu bitmap hiện tại => MapsBackground
            if (bIsDelete)
            {
                //Luon luôn vẽ lại map đã chụp trước đó.
                ScreenView.DrawMapEdit(MapsBackground);

                //Khi con chuộc di chuyển trên panel
                if(DrawScreen.bIsMouseMove)
                {
                    //Vẽ cây bút tô để xóa hình => vẽ chồng lên
                    ScreenView.drawTool();
                }

                //Khi chuộc bấm xuống (trong lúc chế độ xóa)
                if (DrawScreen.isdown)
                {
                    //Vẽ hình xóa (hình tròn)
                    ScreenView.erase();
                    //Chụp lại map hiện tại (khi đã xóa cái gì đó rồi á)
                    MapsBackground = new Bitmap(ScreenView.CurrentMapView());
                }
            }
            //Luôn luôn vẽ tọa độ ban đầu (trục tọa độ) Hoặc cột mốc giống Google hahaha
                ScreenView.DrawAxis();
        }
        
        //Trong cùng một file, lưu giá trị Map đang xử lý
        int indexCurentMap = 0;

        //Xủa lý map trước khi đưa ra vẽ ( update vị trí của lidar)
        public Map ProcessingMap()
        {
            //Trong khi đang xử lý Map chưa là map cuối cùng
            if(indexCurentMap<lstData.Count-1)
            {
                //Nếu đây là map đầu tiên trong danh sách
                if (indexCurentMap == 0)
                {
                    //Lidar được set GPS của Map thứ 0
                    liDAR.setGPS(lstData[0].GetGPS().top, lstData[0].GetGPS().left, lstData[0].GetGPS().right);
                }
                //Ở đây chủ yếu xửa lý từ map thứ 2. Nhưng Map thứ 0 vẫn chạy code này nhưng không có sự thay đổi
                //Nếu như có sự thay đổi về TOP => có sự di chuyển
                if (lstData[indexCurentMap].GetGPS().top != 0) //&& lstData[i].GetGPS().left != 0 && lstData[i].GetGPS().right != 0
                {
                    //Setup lại vị trí của lidar
                    liDAR.Update(lstData[indexCurentMap].GetGPS().top, lstData[indexCurentMap].GetGPS().left, lstData[indexCurentMap].GetGPS().right, deg);
                }
                //Tăng lên thứ tự map lên đạng cho lần sau
                indexCurentMap++;
                //Trả về Map trước đó dang xử lý
                return lstData[indexCurentMap - 1];
            }
            // Đã đến mao cuối cùng
            else
            {
                //setup lại Map thứ 0 đặng qua file khác
                indexCurentMap = 0;
                //Khôn chạy hàm trong timer nữa
                bIsDraw = false;
                MessageBox.Show("Just painted mapping", "Hey you !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        OpenFileDialog dlg = new OpenFileDialog();
        public static string fileName = null;
        private void btnImportFile_Click(object sender, EventArgs e)
        {
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";


            // Display OpenFileDialog by calling ShowDialog method 
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                fileName = dlg.FileName;
            }
            if (fileName != null)
            {
                btnDraw.Enabled = true;
            }
        }

        //Ghi nhận độ xoay của lidar
        public static int deg = 0;

        LiDAR liDAR = new LiDAR();

        public static bool bIsDraw = false;

        List<Map> lstData;
        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (bIsDraw == false)
            {
                if (bIsNew)
                {
                    liDAR = new LiDAR(DrawScreen.PStartLidar.X, DrawScreen.PStartLidar.Y, 1300, 200);
                    bIsNew = false;
                }
                if (indexCurentMap == 0)
                {
                    deg = Convert.ToInt32(cmbDreg.Text);

                    liDAR.top = liDAR.left = liDAR.right = 0;

                    DataProcessing DATA = new DataProcessing();

                    lstData= DATA.ConvertMap(DATA.GetData());
                  //  lstData = DATA.GetData();
                }
                bIsDraw = true;
                btnDraw.BackColor = Color.FromArgb(255, 255, 153);
            }
            else
            {
                bIsDraw = false;
                btnDraw.BackColor = Color.FromName("ControlLight");

            }

        }

        public static double Pis = 0;
        private void trackRate_Scroll(object sender, EventArgs e)
        {
            Pis = trackRate.Value / 100.0;
            textRate.Text = string.Format("{0:0.00}", Pis);
            ScreenView.Clear();
            liDAR = new LiDAR(DrawScreen.PStartLidar.X, DrawScreen.PStartLidar.Y, 1550 * Pis, 300 * Pis);
            indexCurentMap = 0;
           
        }

        public static bool bIsNew = true;
        private void btnClean_Click(object sender, EventArgs e)
        {
            bIsNew = true;
            bIsDraw = false;
            DrawScreen.bCoordAxis = false;

            liDAR.x = liDAR.y = 0;
            indexCurentMap = 0;

            ScreenView.Clear();

        }

        public static bool bIsDelete =false;
        private void btnToolDraw_Click(object sender, EventArgs e)
        {
            if (bIsDelete == false)
            {
                MapsBackground = new Bitmap( ScreenView.CurrentMapView());

                bIsDelete = true;
                bIsDraw = false;

                btnTool.BackColor = Color.FromArgb(255, 255, 153);

            }
            else
            {
                bIsDelete = false;
                btnTool.BackColor = Color.FromName("ControlLight");
            }
        }

        public static double PisArcDelete = 1;

      public static Bitmap MapsBackground;
        private void trackBarDelete_Scroll(object sender, EventArgs e)
        {
            PisArcDelete = trackBarDelete.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bIsDraw = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            Bitmap format = ScreenView.CurrentMapView();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                format.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                MapsBackground.Save("Mapa.png", System.Drawing.Imaging.ImageFormat.Png);
        }

    }
}
