namespace Areo_Pendulum
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.OpenPort_ToolStripMenuItem = new System.Windows.Forms.Button();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.txtSetPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.txtSI = new System.Windows.Forms.TextBox();
            this.txtSD = new System.Windows.Forms.TextBox();
            this.ComPort_ToolStripMenuItem = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.angelbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showangel = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // OpenPort_ToolStripMenuItem
            // 
            this.OpenPort_ToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.OpenPort_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPort_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.OpenPort_ToolStripMenuItem.Location = new System.Drawing.Point(5, 38);
            this.OpenPort_ToolStripMenuItem.Name = "OpenPort_ToolStripMenuItem";
            this.OpenPort_ToolStripMenuItem.Size = new System.Drawing.Size(80, 23);
            this.OpenPort_ToolStripMenuItem.TabIndex = 3;
            this.OpenPort_ToolStripMenuItem.Text = "Connect";
            this.OpenPort_ToolStripMenuItem.UseVisualStyleBackColor = false;
            this.OpenPort_ToolStripMenuItem.Click += new System.EventHandler(this.OpenPort_ToolStripMenuItem_Click);
            // 
            // btnOnOff
            // 
            this.btnOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnOff.Location = new System.Drawing.Point(3, 18);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(145, 38);
            this.btnOnOff.TabIndex = 5;
            this.btnOnOff.Text = "Motor ON";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // txtSetPoint
            // 
            this.txtSetPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetPoint.Location = new System.Drawing.Point(5, 46);
            this.txtSetPoint.MaxLength = 3;
            this.txtSetPoint.Name = "txtSetPoint";
            this.txtSetPoint.Size = new System.Drawing.Size(70, 20);
            this.txtSetPoint.TabIndex = 7;
            this.txtSetPoint.Text = "25";
            this.txtSetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSetPoint_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(22, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "input";
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(5, 22);
            this.txtSP.MaxLength = 7;
            this.txtSP.Name = "txtSP";
            this.txtSP.Size = new System.Drawing.Size(70, 20);
            this.txtSP.TabIndex = 9;
            this.txtSP.Text = "20";
            this.txtSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSP_KeyPress);
            // 
            // txtSI
            // 
            this.txtSI.Location = new System.Drawing.Point(83, 22);
            this.txtSI.MaxLength = 7;
            this.txtSI.Name = "txtSI";
            this.txtSI.Size = new System.Drawing.Size(71, 20);
            this.txtSI.TabIndex = 10;
            this.txtSI.Text = "15";
            this.txtSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSP_KeyPress);
            // 
            // txtSD
            // 
            this.txtSD.Location = new System.Drawing.Point(162, 22);
            this.txtSD.MaxLength = 7;
            this.txtSD.Name = "txtSD";
            this.txtSD.Size = new System.Drawing.Size(71, 20);
            this.txtSD.TabIndex = 11;
            this.txtSD.Text = "10";
            this.txtSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSP_KeyPress);
            // 
            // ComPort_ToolStripMenuItem
            // 
            this.ComPort_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPort_ToolStripMenuItem.FormattingEnabled = true;
            this.ComPort_ToolStripMenuItem.Location = new System.Drawing.Point(5, 15);
            this.ComPort_ToolStripMenuItem.Name = "ComPort_ToolStripMenuItem";
            this.ComPort_ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ComPort_ToolStripMenuItem.TabIndex = 23;
            this.ComPort_ToolStripMenuItem.Click += new System.EventHandler(this.ComPort_ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(19, 17);
            this.trackBar1.Maximum = 6546;
            this.trackBar1.Minimum = 3272;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(211, 45);
            this.trackBar1.TabIndex = 24;
            this.trackBar1.Value = 3273;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // angelbox
            // 
            this.angelbox.BackColor = System.Drawing.Color.White;
            this.angelbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.angelbox.Enabled = false;
            this.angelbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angelbox.ForeColor = System.Drawing.Color.Black;
            this.angelbox.Location = new System.Drawing.Point(112, 46);
            this.angelbox.MaxLength = 10;
            this.angelbox.Name = "angelbox";
            this.angelbox.ReadOnly = true;
            this.angelbox.Size = new System.Drawing.Size(110, 20);
            this.angelbox.TabIndex = 27;
            this.angelbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(142, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "output";
            // 
            // showangel
            // 
            this.showangel.AutoSize = true;
            this.showangel.Location = new System.Drawing.Point(151, 29);
            this.showangel.Name = "showangel";
            this.showangel.Size = new System.Drawing.Size(83, 17);
            this.showangel.TabIndex = 31;
            this.showangel.Text = "Show Angle";
            this.showangel.UseVisualStyleBackColor = true;
            this.showangel.CheckedChanged += new System.EventHandler(this.showangel_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "P Gain";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(95, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "I  Gain";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(172, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "D Gain";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSD);
            this.groupBox1.Controls.Add(this.txtSI);
            this.groupBox1.Controls.Add(this.txtSP);
            this.groupBox1.Location = new System.Drawing.Point(10, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 71);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PID Tuning";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.angelbox);
            this.groupBox2.Controls.Add(this.txtSetPoint);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(10, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 78);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Angle Status";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.showangel);
            this.groupBox3.Controls.Add(this.btnOnOff);
            this.groupBox3.Location = new System.Drawing.Point(10, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 68);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.trackBar1);
            this.groupBox4.Location = new System.Drawing.Point(10, 315);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 68);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Manually Adjust the Motor Speed";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ComPort_ToolStripMenuItem);
            this.groupBox5.Controls.Add(this.OpenPort_ToolStripMenuItem);
            this.groupBox5.Location = new System.Drawing.Point(10, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(93, 67);
            this.groupBox5.TabIndex = 42;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Port Select";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(14, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Reset Encoder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Location = new System.Drawing.Point(109, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(138, 67);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Encoder Reset";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            chartArea1.AxisX.Title = "time(ms)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea1.AxisY.Title = "Angle";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Right;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            legend1.BackSecondaryColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 11.79487F;
            legend1.Position.Width = 17.13781F;
            legend1.Position.X = 80F;
            legend1.Position.Y = 8F;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(253, 0);
            this.chart1.Name = "chart1";
            series1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.CustomProperties = "EmptyPointValue=Zero";
            series1.Legend = "Legend1";
            series1.Name = "output";
            series1.YValuesPerPoint = 2;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "input";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(567, 391);
            this.chart1.TabIndex = 48;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(820, 391);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(836, 430);
            this.MinimumSize = new System.Drawing.Size(836, 430);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tag = "";
            this.Text = "Aero Pendulum";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button OpenPort_ToolStripMenuItem;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.TextBox txtSetPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.TextBox txtSI;
        private System.Windows.Forms.TextBox txtSD;
        private System.Windows.Forms.ComboBox ComPort_ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox angelbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showangel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

