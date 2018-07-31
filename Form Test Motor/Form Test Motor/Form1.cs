using RPLidarSerial.RPLidar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_CShape_Source;


namespace Form_Test_Motor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       Graphics g;
        List<Double> lstPoint = new List<double>();
        static Test_CShape_Source.RPLidarSerialDevice RPLidar;
        //List<double> lstDataPoint = new List<double>();
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            RPLidar = new RPLidarSerialDevice();
            //Set output parameters
            RPLidar.Verbose = false;
            RPLidar.WriteOutCoordinates = false;
            if (RPLidar.Connect() == 0)
                textBox1.Text = "Chưa";
            else
            {
                textBox1.Text = "rồi";
                RPLidar.StopMotor();
            }
            RPLidar.GetDeviceInfo();
            //Get Device Health
            RPLidar.GetDeviceHealth();
            //Get Data Event
             RPLidar.Data += RPLidar_Data;

           // RPLidar_Data();

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RPLidar.StopMotor();
            MessageBox.Show("OFF");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RPLidar.StartMotor();
            RPLidar.StartScan();
            MessageBox.Show("ON");
        }
        bool FlatFirstScan = true;
        void RPLidar_Data(List<Response_PointFormat> Frames)
        {
            List<double> arrayMark = new List<double>();
            
            //Handle data here
            foreach (Response_PointFormat _frame in Frames)
            {
                Console.WriteLine("X: " + _frame.X.ToString() + " Y: " + _frame.Y.ToString());
                    lstPoint.Add(_frame.X);
                    lstPoint.Add(_frame.Y);
                if(FlatFirstScan)
                {
                   
                    if((int)_frame.AngleDegrees==90)
                    {
                        arrayMark[1] = _frame.Distance;
                    }
                    if((int)_frame.AngleDegrees==270)
                    {
                        arrayMark[2] = _frame.Distance;
                    }
                    if ((int)_frame.AngleDegrees == 1)
                    {
                        arrayMark[0] = _frame.Distance;
                    }
                }
           
            }
            if (FlatFirstScan)
                MessageBox.Show(arrayMark[0].ToString() + arrayMark[1] + arrayMark[2]);
            FlatFirstScan = false;
            
            panel1.Invalidate();
           
        }

        bool KiemTraTrungToaDo(double x, double y)
        {
            for (int i = 0; i < lstPoint.Count - 1; i += 2)
            {
                if (lstPoint[i]-x<=0.5&&lstPoint[i+1]-y<=0.5 ||   x-lstPoint[i] <= 0.5 &&   y-lstPoint[i + 1] <= 0.5)
                    return true;
            }
            return false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            //MessageBox.Show(lstPoint.Count.ToString());
            textBox2.Text = lstPoint.Count.ToString();
            for(int i =0;i<lstPoint.Count-1;i+=2)
            {
                g.DrawLine(new Pen(Color.Red, 2), (float)lstPoint[i] + 500, (float)lstPoint[i+1] + 500, (float)lstPoint[i] + 1 + 500, (float)lstPoint[i+1] + 500);

            }
            if (lstPoint.Count > 1000)
                lstPoint.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            RPLidar.offDeice();
            RPLidar.Disconnect();
            Application.Exit();
            
        }
    }
}
