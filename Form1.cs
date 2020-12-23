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
        int file_name = 1;
        bool on_off = false;
        bool timer_off = true;
        //double Kp = 1;
        //double Ki = 0;                       
        //double Kd = 0;

        int time_mili = 0;
        int Angel = 0;
        int setpoint = 0;

        int x = 0, axisx = 3000;

        string SP, KP, KI, KD;
        string data_out;

        string[] data_in = new string[500];
        bool new_data = false;
        int count = 0;

        char dot = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);


        public Form1()
        {
            InitializeComponent();

            //chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-30, 100);
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, axisx);

            //chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[1].Points.AddXY(0, 0);


            bool exit = true;
            while (exit)
            {
                string path = Environment.CurrentDirectory + "\\Log" + file_name.ToString() + ".txt";
                if (File.Exists(path))
                {
                    file_name++;
                    //MessageBox.Show("فایل مورد نظر وجود دارد");
                }
                else
                {
                    exit = false;
                    file_name--;
                    //MessageBox.Show("فایل مورد نظر وجود ندارد");
                }
            }
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
                sw.Stop(); sw.Reset();
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

            else
            {
                if (!timer_off)
                {
                    data_in[count++] = value;
                    new_data = true;
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
                    data_out = "";
                    btnOnOff.Text = "Motor OFF";

                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                    chart1.Series[0].Points.AddXY(0, 0);

                    chart1.ChartAreas[0].AxisX.ScaleView.Size = axisx;
                    chart1.ChartAreas[0].AxisX.ScaleView.Position = 0;

                    // file create
                    file_name++;
                    string path = Environment.CurrentDirectory + "\\Log" + file_name.ToString() + ".txt";
                    using (FileStream fs = File.Create(path))
                    {

                    }

                    //txtSetPoint.Text = txtSetPoint.Text.Replace(".", dot.ToString());
                    if (txtSetPoint.Text == "") txtSetPoint.Text = "0";
                    SP = txtSetPoint.Text;
                    setpoint = Convert.ToInt16(txtSetPoint.Text);
                    if (setpoint > 45)
                    {
                        setpoint = 45;
                        txtSetPoint.Text = "45";
                    }
                    chart1.Series[1].Points.AddXY(0, setpoint);

                    //txtSP.Text = txtSP.Text.Replace(".", dot.ToString());
                    if (txtSP.Text == "") txtSP.Text = "0";
                    KP = txtSP.Text;
                    //Kp = Convert.ToDouble(txtSP.Text);

                    //txtSI.Text = txtSI.Text.Replace(".", dot.ToString());
                    if (txtSI.Text == "") txtSI.Text = "0";
                    KI = txtSI.Text;
                    //Ki = Convert.ToDouble(txtSI.Text);

                    //txtSD.Text = txtSD.Text.Replace(".", dot.ToString());
                    if (txtSD.Text == "") txtSD.Text = "0";
                    KD = txtSD.Text;
                    //Kd = Convert.ToDouble(txtSD.Text);

                    //kp%fki%fkd%fsp%dtime%d
                    string data = "kp" + KP + "ki" + KI + "kd" + KD + "sp" + SP + "time555";
                    serialPort1.Write(data + "\r\n");
                    timer_off = false;
                    timer2.Enabled = true;
                }
                else
                {
                    on_off = false;
                    btnOnOff.Text = "Motor ON";

                    string data = "kp" + KP + "ki" + KI + "kd" + KD + "sp" + SP + "time444";
                    serialPort1.Write(data + "\r\n");

                    string path = Environment.CurrentDirectory + "\\Log" + file_name.ToString() + ".txt";

                    if (File.Exists(path))
                    {
                        FileStream fileStream = new FileStream(path, FileMode.Append);
                        try
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(data_out);
                            fileStream.Write(info, 0, info.Length);
                            fileStream.Close();
                        }
                        catch
                        {
                            //MessageBox.Show("error to save data");
                        }
                    }
                    else
                    {
                        file_name--;
                        path = Environment.CurrentDirectory + "\\Log" + file_name.ToString() + ".txt";
                        using (FileStream fs = File.Create(path))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes(data_out);
                            fs.Write(info, 0, info.Length);
                        }
                    }
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

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (timer_off) timer2.Enabled = false;

            if (new_data)
            {
                double zavye = 0;
                double time;
                count--;

                for (int i = 0; i <= count; i++)
                {
                    string[] stringValues = data_in[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);


                    bool result = double.TryParse(stringValues[1], out zavye);
                    if (result)
                    {
                        Angel = (int)zavye;
                    }

                    result = double.TryParse(stringValues[2], out time);
                    if (result)
                    {
                        time_mili = (int)time;
                        chart1.Series[0].Points.AddXY(time_mili, Angel);
                        chart1.Series[1].Points.AddXY(time_mili, setpoint);

                        chart1.ChartAreas[0].AxisX.ScaleView.Size = axisx;
                        if (time_mili > axisx)
                        {
                            chart1.ChartAreas[0].AxisX.ScaleView.Position = time_mili - axisx;
                        }

                        data_out += Angel.ToString() + "," + time_mili.ToString() + "\r\n";
                    }
                }
                angelbox.Text = zavye.ToString();
                count = 0;
                new_data = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen && checkBox1.Checked)
                {
                    serialPort1.Write(string.Format("PWM:{0}\r\n", trackBar1.Value));
                    System.Threading.Thread.Sleep(50);
                }
            }
            catch
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!checkBox1.Checked && !showangel.Checked)
                {
                    serialPort1.Write("PWM:3272\r\n");
                }
                else if (checkBox1.Checked && showangel.Checked)
                {
                    checkBox1.Checked = false;
                }
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
                angelbox.Text = "0";
                //System.Threading.Thread.Sleep(250);
                //serialPort1.Write("Angle?\r\n");
            }
        }

        private void showangel_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && !checkBox1.Checked)
            {
                if (showangel.Checked)
                {
                    timer_off = false;
                    timer2.Enabled = true;
                    string data = "kp0" + "ki0" + "kd0" + "sp0" + "time555";
                    serialPort1.Write(data + "\r\n");

                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                    chart1.Series[0].Points.AddXY(0, 0);
                }
                if (!showangel.Checked)
                {
                    timer_off = true;
                    if (txtSetPoint.Text == "") txtSetPoint.Text = "0";
                    SP = txtSetPoint.Text;
                    if (txtSP.Text == "") txtSP.Text = "0";
                    KP = txtSP.Text;
                    if (txtSI.Text == "") txtSI.Text = "0";
                    KI = txtSI.Text;
                    if (txtSD.Text == "") txtSD.Text = "0";
                    KD = txtSD.Text;
                    string data = "kp" + KP + "ki" + KI + "kd" + KD + "sp" + SP + "time444";
                    serialPort1.Write(data + "\r\n");
                }
            }
            else
            {
                showangel.Checked = false;
            }

        }

        /*
        private void button3_Click(object sender, EventArgs e)
        {
            data_out = "";
            x = 0;
            sw.Stop();sw.Reset();sw.Start();
            for (byte i = 0; i < 5; i++) chart1.Series[i].Points.Clear();
            for (byte i = 0; i < 5; i++) chart1.Series[i].Points.AddXY(0, 0);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-30, 100);
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, axisx);
        }
        */


        /*
        private void timer2_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("Angle?\r\n");
            System.Threading.Thread.Sleep(5);

                chart1.Series[0].Points.AddXY(x, Angel);
                chart1.Series[1].Points.AddXY(x, setpoint);

                data_out += string.Format("{0,4:0000},{1,4:000},{2,4:000},{3,8:0000.00},{4,8:0000.00},{5,8:0000.00}\r\n",
                    x, Angel, setpoint, P, integral, derivative);

        }
        */

    }
}