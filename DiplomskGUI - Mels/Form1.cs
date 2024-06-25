using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiplomskGUI
{
    public partial class Form1 : Form
    {

        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
            ButtonDisconnect.Visible = false;
            Start.Visible = true;
            Stop.Visible = false;
            InitializeSerialPort();
            InitializeChart();
            TimerSerial.Enabled = true;
            TimerSerial.Interval = 1000; // Set the interval to 1 second
            TimerSerial.Tick += TimerSerial_Tick;

        }
        
        private int ChartLimit = 30; 
        private void InitializeChart()
        {
            // Creating default graph
            for (int i = 0; i <= 30; i++)
            {
                chart1.Series["CurrentAngle"].Points.AddY(0);
                if (chart1.Series["CurrentAngle"].Points.Count == ChartLimit)
                {
                    chart1.Series["CurrentAngle"].Points.RemoveAt(0);
                }
            }

            // Labeling values of the graph
            chart1.ChartAreas[0].AxisY.Maximum = 50; 
            chart1.ChartAreas[0].AxisY.Minimum = -70;  
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false; // Disabling X-axis labels
        }
       
        private void UpdateChart(double value)
        {
            chart1.Series["CurrentAngle"].Points.AddY(value);
            if (chart1.Series["CurrentAngle"].Points.Count > ChartLimit)
            {
                chart1.Series["CurrentAngle"].Points.RemoveAt(0);
            }
            chart1.ResetAutoValues();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Center the form on the screen
            this.CenterToScreen();
        }
        private void buttonScan_Click(object sender, EventArgs e)
        {
            comboBoxPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            if (comboBoxPorts.Items.Count > 0)
            {
                comboBoxPorts.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No COM ports found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (comboBoxPorts.SelectedIndex != -1)
            {
                if (serialPort1.IsOpen)
                {
                    lblStatus.Text = "Status: Port Already Open";
                    MessageBox.Show("Port is already open. Please close it first.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                serialPort1.PortName = comboBoxPorts.SelectedItem.ToString();
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.DtrEnable = true;  // Sometimes needed for Arduino
                serialPort1.RtsEnable = true;  // Sometimes needed for Arduino
                

                try
                {
                    serialPort1.Open();
                    lblStatus.Text = "Status: Connected";
                    ButtonConnect.Visible = false;
                    ButtonDisconnect.Visible = true;
                    serialPort1.NewLine = "\n";
                    serialPort1.ReadTimeout = 100;
                    TimerSerial.Start();
                    

                }
                catch (UnauthorizedAccessException)
                {
                    lblStatus.Text = "Status: Unauthorized Access";
                    MessageBox.Show("Unauthorized Access. Is the port already in use?", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException)
                {
                    lblStatus.Text = "Status: IO Error";
                    MessageBox.Show("I/O Error. Check the port connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException)
                {
                    lblStatus.Text = "Status: Invalid Port";
                    MessageBox.Show("Invalid Port. Please select a valid port.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Status: Error Connecting";
                    MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblStatus.Text = "Status: Select a Port First";
            }
        }



        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                TimerSerial.Stop();
                serialPort1.Close();
                lblStatus.Text = "Status: Disconnected";
                ButtonConnect.Visible = true;
                ButtonDisconnect.Visible = false;
                
            }
        }
        private async void TimerSerial_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.WriteLine("GetStatus");
                    textLog.AppendText("GetStatus\n");
                    string data = await Task.Run(() => ReadSerialPort());
                    textLog.AppendText(data + "\n");
                    serialPort1.WriteLine("GetCurrentAngle\n");
                    textLog.AppendText("GetCurrentAngle\n");
                    data = await Task.Run(() => ReadSerialPort());
                    textLog.AppendText(data + "\n");
                    textLog.ScrollToCaret();
                    if (data.StartsWith("GetCurrentAngle "))
                    {
                        string errorValueString = data.Substring(16);
                        if (float.TryParse(errorValueString, out float errorValue))
                        {
                            UpdateChart(errorValue);
                        }
                        else
                        {
                            lblStatus.Text = "Status: Error Parsing Double";
                            MessageBox.Show("Error parsing double value from serial data.", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Status: Error Reading Data";
                    MessageBox.Show(ex.Message, "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string ReadSerialPort()
        {
            try
            {
                return serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                return string.Empty;
            }
        }
        private Task<string> ReadSerialPortAsync(SerialPort serialPort)
        {
            return Task.Run(() =>
            {
                return serialPort.ReadLine();
            });
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
 
        private void ControlTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string dataReceived = sp.ReadLine(); // Read the incoming data

                // Check if the received data is the acknowledgment
                if (dataReceived != null)
                {
                    // Update the UI in the main thread
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lblStatus.Text = "Status: Arduino Acknowledged Data";
                        MessageBox.Show("Arduino acknowledged the data", "Acknowledgment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = "Status: Error Reading Data";
                    MessageBox.Show(ex.Message, "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
            finally
            {
                // Unsubscribe from DataReceived event to prevent handling it repeatedly
                serialPort1.DataReceived -= SerialPort_DataReceived;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                // First, send the parameters
               // btnSendParameters_Click(sender, e);

                // Then, send the start command
                serialPort1.WriteLine("Start");
                Start.Visible = false;
                Stop.Visible = true;
                lblStatus.Text = "Status: PID Started";
            }
            else
            {
                lblStatus.Text = "Status: Not Connected";
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("Stop");
                Start.Visible = true;
                Stop.Visible = false;
                lblStatus.Text = "Status: PID Stopped";
            }
            else
            {
                lblStatus.Text = "Status: Not Connected";
            }
        }

        private void SendKd_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                string dataToSend = $"SetKd {textBoxKd.Text}";
                serialPort1.WriteLine(dataToSend);
                lblStatus.Text = "Status: Kd Sent";
            }
            else
            {
                lblStatus.Text = "Status: Not Connected";
            }

        }

        private void SendKi_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                string dataToSend = $"SetKi {textBoxKi.Text}";
                serialPort1.WriteLine(dataToSend);
                lblStatus.Text = "Status: Ki Sent";
            }
            else
            {
                lblStatus.Text = "Status: Not Connected";
            }
        }

        private void SendAngle_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                string dataToSend = $"SetAngle {textBoxAngle.Text}";
                serialPort1.WriteLine(dataToSend);
                lblStatus.Text = "Status: Desired Angle Sent";
            }
            else
            {
                lblStatus.Text = "Status: Not Connected";
            }
        }

        private void SendKp_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                string dataToSend = $"SetKp {textBoxKp.Text}";
                serialPort1.WriteLine(dataToSend);
                lblStatus.Text = "Status: Kp Sent";
            }
            else
            {
                lblStatus.Text = "Status: Not Connected";
            }

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
