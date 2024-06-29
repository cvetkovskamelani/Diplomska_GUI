namespace DiplomskGUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TextBox = new System.Windows.Forms.Panel();
            this.SendKp = new System.Windows.Forms.Button();
            this.SendAngle = new System.Windows.Forms.Button();
            this.SendKi = new System.Windows.Forms.Button();
            this.SendKd = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKd = new System.Windows.Forms.TextBox();
            this.textBoxKi = new System.Windows.Forms.TextBox();
            this.textBoxKp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.ControlTitle = new System.Windows.Forms.Label();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.TimerSerial = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.TextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBox.Controls.Add(this.SendKp);
            this.TextBox.Controls.Add(this.SendAngle);
            this.TextBox.Controls.Add(this.SendKi);
            this.TextBox.Controls.Add(this.SendKd);
            this.TextBox.Controls.Add(this.Stop);
            this.TextBox.Controls.Add(this.Start);
            this.TextBox.Controls.Add(this.button2);
            this.TextBox.Controls.Add(this.textBoxAngle);
            this.TextBox.Controls.Add(this.label4);
            this.TextBox.Controls.Add(this.textBoxKd);
            this.TextBox.Controls.Add(this.textBoxKi);
            this.TextBox.Controls.Add(this.textBoxKp);
            this.TextBox.Controls.Add(this.label3);
            this.TextBox.Controls.Add(this.label2);
            this.TextBox.Controls.Add(this.label1);
            this.TextBox.Controls.Add(this.ButtonConnect);
            this.TextBox.Controls.Add(this.comboBoxPorts);
            this.TextBox.Controls.Add(this.buttonScan);
            this.TextBox.Controls.Add(this.ControlTitle);
            this.TextBox.Controls.Add(this.ButtonDisconnect);
            this.TextBox.Location = new System.Drawing.Point(80, 50);
            this.TextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(1344, 248);
            this.TextBox.TabIndex = 0;
            // 
            // SendKp
            // 
            this.SendKp.BackColor = System.Drawing.Color.Green;
            this.SendKp.ForeColor = System.Drawing.SystemColors.Control;
            this.SendKp.Location = new System.Drawing.Point(568, 80);
            this.SendKp.Name = "SendKp";
            this.SendKp.Size = new System.Drawing.Size(60, 34);
            this.SendKp.TabIndex = 20;
            this.SendKp.Text = "Send";
            this.SendKp.UseVisualStyleBackColor = false;
            this.SendKp.Click += new System.EventHandler(this.SendKp_Click);
            // 
            // SendAngle
            // 
            this.SendAngle.BackColor = System.Drawing.Color.Green;
            this.SendAngle.ForeColor = System.Drawing.SystemColors.Control;
            this.SendAngle.Location = new System.Drawing.Point(568, 179);
            this.SendAngle.Name = "SendAngle";
            this.SendAngle.Size = new System.Drawing.Size(60, 34);
            this.SendAngle.TabIndex = 19;
            this.SendAngle.Text = "Send";
            this.SendAngle.UseVisualStyleBackColor = false;
            this.SendAngle.Click += new System.EventHandler(this.SendAngle_Click);
            // 
            // SendKi
            // 
            this.SendKi.BackColor = System.Drawing.Color.Green;
            this.SendKi.ForeColor = System.Drawing.SystemColors.Control;
            this.SendKi.Location = new System.Drawing.Point(1246, 80);
            this.SendKi.Name = "SendKi";
            this.SendKi.Size = new System.Drawing.Size(60, 34);
            this.SendKi.TabIndex = 18;
            this.SendKi.Text = "Send";
            this.SendKi.UseVisualStyleBackColor = false;
            this.SendKi.Click += new System.EventHandler(this.SendKi_Click);
            // 
            // SendKd
            // 
            this.SendKd.BackColor = System.Drawing.Color.Green;
            this.SendKd.ForeColor = System.Drawing.SystemColors.Control;
            this.SendKd.Location = new System.Drawing.Point(928, 78);
            this.SendKd.Name = "SendKd";
            this.SendKd.Size = new System.Drawing.Size(60, 34);
            this.SendKd.TabIndex = 17;
            this.SendKd.Text = "Send";
            this.SendKd.UseVisualStyleBackColor = false;
            this.SendKd.Click += new System.EventHandler(this.SendKd_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.Red;
            this.Stop.ForeColor = System.Drawing.SystemColors.Control;
            this.Stop.Location = new System.Drawing.Point(41, 193);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(139, 34);
            this.Stop.TabIndex = 16;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.SeaGreen;
            this.Start.ForeColor = System.Drawing.SystemColors.Control;
            this.Start.Location = new System.Drawing.Point(40, 193);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(139, 34);
            this.Start.TabIndex = 14;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(40, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 34);
            this.button2.TabIndex = 15;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxAngle.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxAngle.Location = new System.Drawing.Point(415, 185);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(132, 23);
            this.textBoxAngle.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(411, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desired angle";
            // 
            // textBoxKd
            // 
            this.textBoxKd.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxKd.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxKd.Location = new System.Drawing.Point(773, 84);
            this.textBoxKd.Name = "textBoxKd";
            this.textBoxKd.Size = new System.Drawing.Size(132, 23);
            this.textBoxKd.TabIndex = 10;
            // 
            // textBoxKi
            // 
            this.textBoxKi.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxKi.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxKi.Location = new System.Drawing.Point(1093, 86);
            this.textBoxKi.Name = "textBoxKi";
            this.textBoxKi.Size = new System.Drawing.Size(132, 23);
            this.textBoxKi.TabIndex = 9;
            // 
            // textBoxKp
            // 
            this.textBoxKp.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxKp.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxKp.Location = new System.Drawing.Point(415, 86);
            this.textBoxKp.Name = "textBoxKp";
            this.textBoxKp.Size = new System.Drawing.Size(132, 23);
            this.textBoxKp.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(769, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Derivative (Kd) parameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(1089, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Integral (Ki) parameter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(411, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proportional (Kp) parameter";
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.BackColor = System.Drawing.Color.SeaGreen;
            this.ButtonConnect.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonConnect.Location = new System.Drawing.Point(40, 143);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(139, 34);
            this.ButtonConnect.TabIndex = 3;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = false;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.BackColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPorts.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(174, 84);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(145, 25);
            this.comboBoxPorts.TabIndex = 2;
            // 
            // buttonScan
            // 
            this.buttonScan.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonScan.Location = new System.Drawing.Point(40, 76);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(110, 42);
            this.buttonScan.TabIndex = 1;
            this.buttonScan.Text = "Scan port";
            this.buttonScan.UseVisualStyleBackColor = false;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // ControlTitle
            // 
            this.ControlTitle.AutoSize = true;
            this.ControlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.ControlTitle.Location = new System.Drawing.Point(35, 22);
            this.ControlTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ControlTitle.Name = "ControlTitle";
            this.ControlTitle.Size = new System.Drawing.Size(209, 36);
            this.ControlTitle.TabIndex = 0;
            this.ControlTitle.Text = "Control Panel";
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.BackColor = System.Drawing.Color.Red;
            this.ButtonDisconnect.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonDisconnect.Location = new System.Drawing.Point(40, 143);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(139, 34);
            this.ButtonDisconnect.TabIndex = 4;
            this.ButtonDisconnect.Text = "Disconnect";
            this.ButtonDisconnect.UseVisualStyleBackColor = false;
            this.ButtonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(80, 350);
            this.chart1.Name = "chart1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "CurrentAngle";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1344, 323);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "ControlChart";
            // 
            // TimerSerial
            // 
            this.TimerSerial.Interval = 250;
            this.TimerSerial.Tick += new System.EventHandler(this.TimerSerial_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblStatus.Location = new System.Drawing.Point(77, 686);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(325, 36);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status: Disconnected ";
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(80, 751);
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(1344, 305);
            this.textLog.TabIndex = 4;
            this.textLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 1068);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.TextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextBox.ResumeLayout(false);
            this.TextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TextBox;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Label ControlTitle;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKp;
        private System.Windows.Forms.TextBox textBoxKd;
        private System.Windows.Forms.TextBox textBoxKi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer TimerSerial;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button SendKd;
        private System.Windows.Forms.Button SendKi;
        private System.Windows.Forms.Button SendAngle;
        private System.Windows.Forms.Button SendKp;
        private System.Windows.Forms.RichTextBox textLog;
    }
}

