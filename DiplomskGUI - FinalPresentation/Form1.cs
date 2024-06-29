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
        private const int ChartLimit = 30;
        
        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            ButtonDisconnect.Visible = false;
            Start.Visible = true;
            Stop.Visible = false;
            InitializeSerialPort();
            InitializeChart();
            TimerSerial.Enabled = true;
            TimerSerial.Interval = 1000; // Set the interval to 1 second
            TimerSerial.Tick += TimerSerial_Tick;
        }

        private void InitializeChart()
        {
            // Creating default graph
            for (int i = 0; i <= ChartLimit; i++)
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
            this.CenterToScreen(); // Center the form on the screen
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
                    ShowError("Port is already open. Please close it first.", "Connection Error");
                    return;
                }

                ConfigureSerialPort();

                try
                {
                    serialPort1.Open();
                    lblStatus.Text = "Status: Connected";
                    ToggleConnectButton(false);
                    TimerSerial.Start();
                }
                catch (Exception ex) when (ex is UnauthorizedAccessException || ex is IOException || ex is ArgumentException)
                {
                    HandleSerialPortException(ex);
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message, "Connection Error");
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
                ToggleConnectButton(true);
            }
        }

        private async void TimerSerial_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    await SendAndLogCommand("GetStatus");
                    await SendAndLogCommand("GetCurrentAngle");
                    string data = await ReadSerialDataAsync();

                    if (data.StartsWith("GetCurrentAngle "))
                    {
                        ProcessAngleData(data.Substring(16));
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message, "Read Error");
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            SendCommand("Start", "Status: PID Started", "Status: Not Connected");
            ToggleStartStopButtons(false);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            SendCommand("Stop", "Status: PID Stopped", "Status: Not Connected");
            ToggleStartStopButtons(true);
        }

        private void SendKd_Click(object sender, EventArgs e)
        {
            SendParameterCommand("SetKd", textBoxKd.Text, "Status: Kd Sent");
        }

        private void SendKi_Click(object sender, EventArgs e)
        {
            SendParameterCommand("SetKi", textBoxKi.Text, "Status: Ki Sent");
        }

        private void SendAngle_Click(object sender, EventArgs e)
        {
            SendParameterCommand("SetAngle", textBoxAngle.Text, "Status: Desired Angle Sent");
        }

        private void SendKp_Click(object sender, EventArgs e)
        {
            SendParameterCommand("SetKp", textBoxKp.Text, "Status: Kp Sent");
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string dataReceived = ((SerialPort)sender).ReadLine();

                if (dataReceived != null)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lblStatus.Text = "Status: Arduino Acknowledged Data";
                        MessageBox.Show("Arduino acknowledged the data", "Acknowledgment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, "Read Error");
            }
            finally
            {
                serialPort1.DataReceived -= SerialPort_DataReceived;
            }
        }

        private void ToggleConnectButton(bool isConnected)
        {
            ButtonConnect.Visible = isConnected;
            ButtonDisconnect.Visible = !isConnected;
        }

        private void ToggleStartStopButtons(bool isStartVisible)
        {
            Start.Visible = isStartVisible;
            Stop.Visible = !isStartVisible;
        }

        private void ConfigureSerialPort()
        {
            serialPort1.PortName = comboBoxPorts.SelectedItem.ToString();
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
            serialPort1.DtrEnable = true;
            serialPort1.RtsEnable = true;
            serialPort1.NewLine = "\n";
            serialPort1.ReadTimeout = 100;
        }

        private void HandleSerialPortException(Exception ex)
        {
            string message = ex switch
            {
                UnauthorizedAccessException => "Unauthorized Access. Is the port already in use?",
                IOException => "I/O Error. Check the port connection.",
                ArgumentException => "Invalid Port. Please select a valid port.",
                _ => "Error Connecting"
            };

            ShowError(message, "Connection Error");
        }

        private async Task SendAndLogCommand(string command)
        {
            serialPort1.WriteLine(command);
            textLog.AppendText($"{command}\n");
            string data = await ReadSerialDataAsync();
            textLog.AppendText($"{data}\n");
            textLog.ScrollToCaret();
        }

        private void ProcessAngleData(string data)
        {
            if (float.TryParse(data, out float angle))
            {
                UpdateChart(angle);
            }
            else
            {
                ShowError("Error parsing double value from serial data.", "Parse Error");
            }
        }

        private async Task<string> ReadSerialDataAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    return serialPort1.ReadLine();
                }
                catch (TimeoutException)
                {
                    return string.Empty;
                }
            });
        }

        private void SendCommand(string command, string successStatus, string failureStatus)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(command);
                lblStatus.Text = successStatus;
            }
            else
            {
                lblStatus.Text = failureStatus;
            }
        }

        private void SendParameterCommand(string command, string parameter, string successStatus)
        {
            SendCommand($"{command} {parameter}", successStatus, "Status: Not Connected");
        }

        private void ShowError(string message, string title)
        {
            lblStatus.Text = $"Status: {title}";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
