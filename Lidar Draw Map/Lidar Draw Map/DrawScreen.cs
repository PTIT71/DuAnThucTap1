using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lidar_Draw_Map
{
    class DrawScreen:Panel
    {

        #region Properties

        Graphics DrawOnScreen;
        Graphics DrawOnBitmap;
        Bitmap BackgroundBoard;
        public static Point PStartLidar = new Point();
        public static Point PMouseDelete = new Point();
        public static bool isdown = false;

        #endregion

        #region Constructor
        public DrawScreen(int width, int height, Point location)
        {
            this.Width = width;
            this.Height = height;
            this.Location = location;
            this.BackColor = Color.Black;

             DrawOnScreen = this.CreateGraphics();

            BackgroundBoard = new Bitmap(this.Width, this.Height);
            DrawOnBitmap = Graphics.FromImage(BackgroundBoard);

            DrawOnBitmap.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawOnScreen.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.MouseMove += DrawScreen_MouseMove;
            this.MouseDown += DrawScreen_MouseDown;
            this.MouseLeave += DrawScreen_MouseLeave;
            this.MouseUp += DrawScreen_MouseUp;

            this.DoubleBuffered = true;

           
        }
        #endregion

        #region Mouse
        private void DrawScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (Form1.bIsDelete)
            {
                isdown = false;
            }
        }
        public static bool bIsMouseMove = false;
        private void DrawScreen_MouseLeave(object sender, EventArgs e)
        {
            bIsMouseMove = false;
        }
        private void DrawScreen_MouseDown(object sender, MouseEventArgs e)
        {
            //  MessageBox.Show("Donwn");
            if (bCoordAxis == false)
            {
                MessageBox.Show(PStartLidar.ToString(), "Vị trí trục tọa độ");
                string message = "Đây là vị trí bắt đầu của LiDar?";
                string caption = "Thông báo";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Đã set được tọa độ của hệ trục tọa độ
                    bCoordAxis = true;
                    Clear(); // Xóa trục tung và trục hoành. đặng vẽ điểm mốc bắt đầu
                    RePaint();
                }
            }

            if (Form1.bIsDelete)
            {
                if (Control.MouseButtons == System.Windows.Forms.MouseButtons.Left)
                    isdown = true;


            }
        }
        public static bool bCoordAxis = false;
        private void DrawScreen_MouseMove(object sender, MouseEventArgs e)
        {
            bIsMouseMove = true;
            //Chưa vẽ hệ trục tọa độ
            if (bCoordAxis == false)
            {
                PStartLidar = e.Location;
            }
            //Đang trong chế chộ Edit
            if (Form1.bIsDelete)
            {
                PMouseDelete = e.Location;
            }
        }

        #endregion

        #region Method
        public void drawTool()
        {
            double w = 20 * Form1.PisArcDelete;
            double h = 20 * Form1.PisArcDelete;

            DrawOnBitmap.DrawArc(new Pen(Color.LightGray, 1), new Rectangle(PMouseDelete.X - (int)w / 2, PMouseDelete.Y - (int)h / 2, (int)w, (int)h), 0, 360);
            SolidBrush brs = new SolidBrush(Color.Black);
            DrawOnBitmap.FillEllipse(brs, new Rectangle(PMouseDelete.X - (int)w / 2, PMouseDelete.Y - (int)h / 2, (int)w, (int)h));
        }

        public void erase()
        {
            double w = 20 * Form1.PisArcDelete;
            double h = 20 * Form1.PisArcDelete;
            DrawOnBitmap.DrawArc(new Pen(Color.Black, 3), new Rectangle(PMouseDelete.X - (int)w / 2, PMouseDelete.Y - (int)h / 2, (int)w, (int)h), 0, 360);
            SolidBrush brs = new SolidBrush(Color.Black);
            DrawOnBitmap.FillEllipse(brs, new Rectangle(PMouseDelete.X - (int)w / 2, PMouseDelete.Y - (int)h / 2, (int)w, (int)h));
        }

       
      
        public void DrawMapOnScreen(LiDAR Lidar, Map Map,int  deg, int index)
        {
            DrawOnScreen.DrawImage(DrawMapOnBitmap(Lidar, Map, deg, index), new Point(0, 0));
        }
        
        public void DrawPenDelete()
        {
            double w = 20 * Form1.PisArcDelete;
            double h = 20 * Form1.PisArcDelete;
            DrawOnBitmap.DrawArc(new Pen(Color.Red,1), new Rectangle(PMouseDelete.X - (int)w/2, PMouseDelete.Y - (int) h/2, (int)w, (int)h), 0, 360);
            SolidBrush brs = new SolidBrush(Color.Orange);
            DrawOnBitmap.FillEllipse(brs, new Rectangle(PMouseDelete.X - (int)w / 2, PMouseDelete.Y - (int)h / 2, (int)w, (int)h));
           
        }
        public void DrawAxis()
        {
            if (bCoordAxis == false)
            {
                DrawOnBitmap.DrawLine(new Pen(Color.Gray, 2), new Point(0, PStartLidar.Y), new Point(this.Width, PStartLidar.Y));
                DrawOnBitmap.DrawLine(new Pen(Color.Gray, 2), new Point(PStartLidar.X, 0), new Point(PStartLidar.X, Height));
            }
            else
            {
                DrawOnBitmap.DrawImage(Image.FromFile("StartMark.png"), PStartLidar.X - (float)(250 * Form1.Pis), PStartLidar.Y - (float)(1000 * Form1.Pis), (float)(500 * Form1.Pis), (float)(1000 * Form1.Pis));

            }
        }
        Bitmap DrawMapOnBitmap(LiDAR liDAR, Map Map,int  deg, int index)
        {
            if (Map != null)
            {
                liDAR.drawLiDAR(DrawOnBitmap, deg);
                Map.DrawMap(deg, DrawOnBitmap, liDAR);
                //Vẽ
                SolidBrush brs = new SolidBrush(Color.Black);
                DrawOnBitmap.FillRectangle(brs, new Rectangle(0, 0,150, 30));
                SolidBrush br = new SolidBrush(Color.Yellow);
                DrawOnBitmap.DrawString("MAP: " + index, new Font("Arial", 16), br, 0, 0);
            }
            return BackgroundBoard;
        }

        public void DrawMapEdit(Bitmap bm)
        {
            DrawOnBitmap.DrawImage(Form1.MapsBackground, new Point(0, 0));
        }
        public  Bitmap CurrentMapView()
        {
            return BackgroundBoard;
        }

        public void RePaint()
        {
            DrawOnScreen.DrawImage(BackgroundBoard, new Point(0, 0));
        }

        public void Clear()
        {
            DrawOnBitmap.Clear(Color.Black);
        }

        #endregion
    }
}
