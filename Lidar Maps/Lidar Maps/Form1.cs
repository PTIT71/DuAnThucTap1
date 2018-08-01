﻿using System;
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

        Map OriginMap = new Map();
        Map CurrentMap = new Map();

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            DataProcessing DATA = new DataProcessing();
            g.DrawLine(new Pen(Color.Red, 2), 400, 0, 400, 1000);
            g.DrawLine(new Pen(Color.Red, 2), 0, 400, 1000, 400);

            List<Map> lstData = DATA.GetData();
            OriginMap = lstData[0];
            for (int i = 0; i < lstData.Count; i++)
            {

                //Tính độ dịch
                double DelTop = lstData[i].GetGPS().top - OriginMap.GetGPS().top;
                //Console.WriteLine("deltop: " + DelTop);
                //Vẽ
                Console.WriteLine("Map " + i);
                lstData[i].DrawMap(g, DelTop, 0, 0);
            }

            //for (int i = 0; i < lstData.Count; i++)
            //{
            //    Console.WriteLine("Map: " + (i + 1).ToString());
            //    //lstData[i].ShowGPS();
            //    lstData[i].Show();

            //    Console.WriteLine();
            //}

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
