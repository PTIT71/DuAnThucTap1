using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Lidar_Maps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Timer tm = new Timer();
        int index = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            DataProcessing DATA = new DataProcessing();
            g.DrawLine(new Pen(Color.Red, 2), 400, 0, 400, 1000);
            g.DrawLine(new Pen(Color.Red, 2), 0, 400, 1000, 400);
            List<double> lstData = DATA.standarData();
            MessageBox.Show(lstData.Count.ToString());

            for(int i =0;i<lstData.Count-1;i+=2)
            {
                index = i;
                g.DrawLine(new Pen(Color.Black,3), (float)lstData[i], (float)lstData[i + 1], (float)lstData[i] + 3, (float)lstData[i + 1]);
            }

            MessageBox.Show("Vẽ xong nà!");
          

        
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            g.DrawLine(new Pen(Color.Red, 2), 400, 0, 400, 1000);
            g.DrawLine(new Pen(Color.Red, 2), 0, 400, 1000, 400);
            tm.Interval = 10;
            tm.Tick += Tm_Tick;
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
           
        }
       public static int dophangiai = 1;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dophangiai = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel1.Refresh();
            g.DrawLine(new Pen(Color.Red, 2), 400, 0, 400, 1000);
            g.DrawLine(new Pen(Color.Red, 2), 0, 400, 1000, 400);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawLine(new Pen(Color.Red, 2), 400, 0, 400, 1000);
            g.DrawLine(new Pen(Color.Red, 2), 0, 400, 1000, 400);
        }

        OpenFileDialog dlg = new OpenFileDialog();
        public static string fileName = null;
        private void button3_Click(object sender, EventArgs e)
        {
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";


            // Display OpenFileDialog by calling ShowDialog method 
            if (dlg.ShowDialog() == DialogResult.OK)
            {

               fileName = dlg.FileName;
            }
        }
    }
}
