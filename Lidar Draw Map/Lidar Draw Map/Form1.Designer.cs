namespace Lidar_Draw_Map
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDreg = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTool = new System.Windows.Forms.Button();
            this.trackBarDelete = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textRate = new System.Windows.Forms.TextBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackRate = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.pn2 = new System.Windows.Forms.Panel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.cmbDreg);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnTool);
            this.panel1.Controls.Add(this.trackBarDelete);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textRate);
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.trackRate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDraw);
            this.panel1.Controls.Add(this.btnImportFile);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1369, 46);
            this.panel1.TabIndex = 0;
            // 
            // cmbDreg
            // 
            this.cmbDreg.FormattingEnabled = true;
            this.cmbDreg.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cmbDreg.Location = new System.Drawing.Point(702, 12);
            this.cmbDreg.Name = "cmbDreg";
            this.cmbDreg.Size = new System.Drawing.Size(52, 21);
            this.cmbDreg.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(929, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTool
            // 
            this.btnTool.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTool.Location = new System.Drawing.Point(761, 12);
            this.btnTool.Name = "btnTool";
            this.btnTool.Size = new System.Drawing.Size(75, 23);
            this.btnTool.TabIndex = 1;
            this.btnTool.Text = "Erase";
            this.btnTool.UseVisualStyleBackColor = true;
            this.btnTool.Click += new System.EventHandler(this.btnToolDraw_Click);
            // 
            // trackBarDelete
            // 
            this.trackBarDelete.Location = new System.Drawing.Point(842, 12);
            this.trackBarDelete.Minimum = 1;
            this.trackBarDelete.Name = "trackBarDelete";
            this.trackBarDelete.Size = new System.Drawing.Size(81, 45);
            this.trackBarDelete.TabIndex = 3;
            this.trackBarDelete.Value = 1;
            this.trackBarDelete.Scroll += new System.EventHandler(this.trackBarDelete_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Lidar_Draw_Map.Properties.Resources.images;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // textRate
            // 
            this.textRate.Location = new System.Drawing.Point(452, 12);
            this.textRate.Name = "textRate";
            this.textRate.Size = new System.Drawing.Size(50, 20);
            this.textRate.TabIndex = 2;
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Location = new System.Drawing.Point(291, 12);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 1;
            this.btnClean.Text = "New";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(603, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Degree Map:";
            // 
            // trackRate
            // 
            this.trackRate.Location = new System.Drawing.Point(510, 12);
            this.trackRate.Name = "trackRate";
            this.trackRate.Size = new System.Drawing.Size(90, 45);
            this.trackRate.TabIndex = 0;
            this.trackRate.Scroll += new System.EventHandler(this.trackRate_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rate Map: ";
            // 
            // btnDraw
            // 
            this.btnDraw.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraw.Location = new System.Drawing.Point(210, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw Map";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnImportFile
            // 
            this.btnImportFile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFile.Location = new System.Drawing.Point(129, 12);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(75, 23);
            this.btnImportFile.TabIndex = 1;
            this.btnImportFile.Text = "Import";
            this.btnImportFile.UseVisualStyleBackColor = true;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // pn2
            // 
            this.pn2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn2.Location = new System.Drawing.Point(0, 54);
            this.pn2.Name = "pn2";
            this.pn2.Size = new System.Drawing.Size(1362, 691);
            this.pn2.TabIndex = 1;
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(1021, 12);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 11;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pn2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw Map By LiDAR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textRate;
        private System.Windows.Forms.Button btnTool;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.TrackBar trackRate;
        private System.Windows.Forms.TrackBar trackBarDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pn2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbDreg;
        private System.Windows.Forms.Button btnUndo;
    }
}

