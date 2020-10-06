using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using rtChart;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Diagnostics;
using System.IO.Ports;

namespace Areo_Pendulum
{
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch(); 

        bool on_off = false ,new_data = false;

        double Kp = 1;
        double Ki = 0;                       
        double Kd = 0;

        int time_mili = 0;
        int Angel = 0;
        int setpoint = 0;

        int x = 0, axisx=150;
        
        string data_out;
        char dot = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
   

        public Form1()
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-30, 100);
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, axisx);

            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[1].Points.AddXY(0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Invoke(new EventHandler(timer1_Tick));
        }


        private void ClosePort_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!on_off && !showangel.Checked)
            {
                serialPort1.Close();
                sw.Stop();sw.Reset();
                OpenPort_ToolStripMenuItem.BackColor = Color.Red;
                OpenPort_ToolStripMenuItem.Text = "Connect";

                OpenPort_ToolStripMenuItem.Click -= this.ClosePort_ToolStripMenuItem_Click;
                OpenPort_ToolStripMenuItem.Click += this.OpenPort_ToolStripMenuItem_Click;
            }
        }

        private void OpenPort_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                MessageBox.Show("قبلا پورتی باز شده است");
            }
            else
            {
                if (ComPort_ToolStripMenuItem.SelectedIndex == -1)
                {
                    MessageBox.Show("داش پورت مد نظر رو انتخاب کن و \nبعد رو بر قراری ارتباط کلیک کن");
                    return;
                }

                serialPort1.PortName = ComPort_ToolStripMenuItem.SelectedItem.ToString();

                try
                {
                    serialPort1.Open();
                    sw.Start();

                    OpenPort_ToolStripMenuItem.Text = "Disconnect";
                    OpenPort_ToolStripMenuItem.BackColor = Color.Green;

                    OpenPort_ToolStripMenuItem.Click -= this.OpenPort_ToolStripMenuItem_Click;
                    OpenPort_ToolStripMenuItem.Click += this.ClosePort_ToolStripMenuItem_Click;


                }
                catch
                {
                    MessageBox.Show("این پورت توسط دستگاه دیگری استفاده میشود\nیا این که این پورت وجود ندارد و بسته شده\nپورت دیگری را انتخاب کنید");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OpenPort_ToolStripMenuItem.BackColor == Color.Green && !serialPort1.IsOpen)
            {
                Invoke(new EventHandler(ClosePort_ToolStripMenuItem_Click));
            }

            string[] items = new string[10];
            int pos = 0;
            foreach (string s in SerialPort.GetPortNames())
            {
                items[pos++] = s;
            }

            if (ComPort_ToolStripMenuItem.Items.Count != ArrayDataSize(items))
            {
                if (ArrayDataSize(items) == 0)
                {
                    ComPort_ToolStripMenuItem.Items.Clear();
                }
                else
                {
                    ComPort_ToolStripMenuItem.Items.Clear();

                    for (int j = 0; j < ArrayDataSize(items); j++)
                    {
                        ComPort_ToolStripMenuItem.Items.Add(items[j]);
                    }

                    ComPort_ToolStripMenuItem.SelectedIndex = 0;
                }
            }
            else
            {
                for (int i = 0; i < ArrayDataSize(items); i++)
                {
                    if (items[i] != ComPort_ToolStripMenuItem.Items[i].ToString())
                    {
                        ComPort_ToolStripMenuItem.Items.Clear();

                        for (int j = 0; j < ArrayDataSize(items); j++)
                        {
                            ComPort_ToolStripMenuItem.Items.Add(items[j]);
                        }

                        ComPort_ToolStripMenuItem.SelectedIndex = 0;

                        break;
                    }
                }
            }


            if (ComPort_ToolStripMenuItem.Items.Count != 0 && (ComPort_ToolStripMenuItem.Text == "ComPort" || ComPort_ToolStripMenuItem.Text == ""))
            {
                ComPort_ToolStripMenuItem.SelectedIndex = 0;
            }

            if (ComPort_ToolStripMenuItem.Items.Count == 0)
            {
                ComPort_ToolStripMenuItem.Text = string.Empty;
            }
        }

        int ArrayDataSize(string[] ArraryName)
        {
            for (int i = 0; i < ArraryName.Length; i++)
            {
                if (ArraryName[i] == null)
                {
                    return i;
                }
            }

            return 0;
        }

        private void btnSetPoint_Click(object sender, EventArgs e)
        {
            if (txtSetPoint.Text == "") txtSetPoint.Text = "0";
            setpoint = Convert.ToInt16(txtSetPoint.Text);
            if (setpoint > 90)
            {
                setpoint = 90;
                txtSetPoint.Text = 90.ToString();
            }

            chart1.Series[1].Points.AddXY(x, setpoint);
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }

            else if (value.Contains("Angle:"))
            {
                string data = value.Substring(6, 4);
                double zavye;
                bool result = double.TryParse(data, out zavye);
                if (result)
                {
                    Angel = (int)zavye;

                    angelbox.Text = zavye.ToString();
                }

                if (value.Contains("time:"))   //time:020154
                {
                    data = value.Substring(5, 6);
                    double time;
                    result = double.TryParse(data, out time);
                    if (result)
                    {
                        time_mili = (int)time;
                        chart1.Series[0].Points.AddXY(time_mili, Angel);
                    }
                }
            }


        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string strNewData = serialPort1.ReadLine();

            AppendTextBox(strNewData);
        }

        private void txtSetPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8)))
                
                    e.Handled = true;
        }

        private void txtSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = ((Control)sender).Text;

            if (e.KeyChar == '.' && text.Length > 0 && !text.Contains("."))
            {
                e.Handled = false;
                return;
            }
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }


        private void btnOnOff_Click(object sender, EventArgs e)
        {
            
            
            if (serialPort1.IsOpen && !checkBox1.Checked && !showangel.Checked)
            {
                if (!on_off)
                {
                    on_off = true;
                    btnOnOff.Text = "Motor OFF";
                    txtSP.Text = txtSP.Text.Replace(".", dot.ToString());
                    if (txtSP.Text == "") txtSP.Text = "0";
                    Kp = Convert.ToDouble(txtSP.Text);

                    txtSI.Text = txtSI.Text.Replace(".", dot.ToString());
                    if (txtSI.Text == "") txtSI.Text = "0";
                    Ki = Convert.ToDouble(txtSI.Text);

                    txtSD.Text = txtSD.Text.Replace(".", dot.ToString());
                    if (txtSD.Text == "") txtSD.Text = "0";
                    Kd = Convert.ToDouble(txtSD.Text);

                    for (int i = 2; i < 5; i++) chart1.Series[i].Points.AddXY(x, 0);
                    integral = 0;
                    derivative = 0;
                    timer2.Enabled = true;
                }
                else 
                {
                    on_off = false;
                    timer2.Enabled = false;
                    btnOnOff.Text = "Motor ON";
                    serialPort1.Write("PWM:3272\r\n");
                    System.Threading.Thread.Sleep(50);
                    serialPort1.Write("PWM:3272\r\n");
                    System.Threading.Thread.Sleep(50);
                    serialPort1.Write("PWM:3272\r\n");
                    System.Threading.Thread.Sleep(50);
                    serialPort1.Write("PWM:3272\r\n");

                }
            }
            
        }


        private void ComPort_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                Invoke(new EventHandler(ClosePort_ToolStripMenuItem_Click));
                Invoke(new EventHandler(OpenPort_ToolStripMenuItem_Click));
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen && checkBox1.Checked && !on_off)
                {
                    serialPort1.Write(string.Format("PWM:{0}\r\n", trackBar1.Value));
                }
            }
            catch
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && !checkBox1.Checked)
            {
                serialPort1.Write("PWM:3272\r\n");
            }
            else if (serialPort1.IsOpen && checkBox1.Checked && !on_off)
            {
                
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("zenc\r\n");
                System.Threading.Thread.Sleep(50);
                serialPort1.Write("Angle?\r\n");
            }
        }

        private void showangel_CheckedChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen || on_off)
            {
                showangel.Checked = false;
            } 


            Task.Factory.StartNew(() =>
            {
                while (showangel.Checked)
                {
                    
                    serialPort1.Write("Angle?\r\n");
                    System.Threading.Thread.Sleep(50);
                    if (new_data==true)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            chart1.Series[1].Points.AddXY(x, setpoint);
                            chart1.Series[2].Points.AddXY(x, 0);
                            chart1.Series[3].Points.AddXY(x, 0);
                            chart1.Series[4].Points.AddXY(x, 0);

                            chart1.ChartAreas[0].AxisX.ScaleView.Size = axisx;
                            chart1.ChartAreas[1].AxisX.ScaleView.Size = chart1.ChartAreas[0].AxisX.ScaleView.Size;
                            if (x > axisx)
                            {
                                chart1.ChartAreas[0].AxisX.ScaleView.Position = x - axisx;
                                chart1.ChartAreas[1].AxisX.ScaleView.Position = x - axisx;
                            }
                        }));

                        data_out += string.Format("{0,4:0000},{1,4:000},{2,4:000},{3,8:0000.00},{4,8:0000.00},{5,8:0000.00}\r\n",
                                    x, Angel, 0, 0, 0, 0);
                        new_data = false;
                    }
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data_out = "";
            x = 0;
            sw.Stop();sw.Reset();sw.Start();
            for (byte i = 0; i < 5; i++) chart1.Series[i].Points.Clear();
            for (byte i = 0; i < 5; i++) chart1.Series[i].Points.AddXY(0, 0);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-30, 100);
            chart1.ChartAreas[1].AxisY.ScaleView.Zoom(-100, 100);
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, axisx);
            chart1.ChartAreas[1].AxisX.ScaleView.Zoom(0, axisx);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("Angle?\r\n");
            System.Threading.Thread.Sleep(5);

            if (new_data)
            {
                error = setpoint - Angel;

                integral = (Ki * (error + previous_error) * dt / 2) + integral;

                N = (1.0 / dt) * 0.4;
                filter += dt * derivative;
                derivative = (Kd * error - filter) * N;

                P = Kp * error;

                PID = Convert.ToInt32(P + integral + derivative) + min;

                if (PID > max) PID = max;
                if (PID < min) PID = min;

                previous_error = error;

                serialPort1.Write(string.Format("PWM:{0}\r\n", PID));

                chart1.Series[0].Points.AddXY(x, Angel);
                chart1.Series[1].Points.AddXY(x, setpoint);
                chart1.Series[2].Points.AddXY(x, P);
                chart1.Series[3].Points.AddXY(x, integral);
                chart1.Series[4].Points.AddXY(x, derivative);
                chart1.Series[5].Points.AddXY(x, PID);

                chart1.ChartAreas[0].AxisX.ScaleView.Size = axisx;
                chart1.ChartAreas[1].AxisX.ScaleView.Size = axisx;
                if (x > axisx)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.Position = x - axisx;
                    chart1.ChartAreas[1].AxisX.ScaleView.Position = x - axisx;
                }

                data_out += string.Format("{0,4:0000},{1,4:000},{2,4:000},{3,8:0000.00},{4,8:0000.00},{5,8:0000.00}\r\n",
                    x, Angel, setpoint, P, integral, derivative);
                new_data = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!on_off)
            {
                saveFileDialog1.Filter = "CSV(Comma delimited)(*.csv)|*.csv";
                saveFileDialog1.FileName = String.Empty;
                saveFileDialog1.DefaultExt = ".csv";
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(data_out);
                    writer.Close();
                }
            }

            /*double P = 0.0025, I = 0.25, D = 55.25;
            TextWriter tw = new StreamWriter("D:\\sample.txt");

            textBox1.Text += "\t," + P.ToString() + "\t," + I.ToString() + "\t," + D.ToString() + "\r\n";
            tw.Write(textBox1.Text);
            tw.Close();*/
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            ChartArea ca1 = chart1.ChartAreas[0];
            ChartArea ca2 = chart1.ChartAreas[1];
            Axis ax1 = ca1.AxisX;
            Axis ax2 = ca2.AxisX;

            if (e.Axis == ax1)
            {
                ax2.ScaleView.Size = ax1.ScaleView.Size;
                ax2.ScaleView.Position = ax1.ScaleView.Position;
            }
            if (e.Axis == ax2)
            {
                ax1.ScaleView.Size = ax2.ScaleView.Size;
                ax1.ScaleView.Position = ax2.ScaleView.Position;
            }
        }
    }
}