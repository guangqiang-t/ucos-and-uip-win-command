namespace WinCommand
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxTcp = new System.Windows.Forms.GroupBox();
            this.labelIsLink = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSeverPort = new System.Windows.Forms.TextBox();
            this.textBoxSeverIP = new System.Windows.Forms.TextBox();
            this.textBoxReceiveBuffer = new System.Windows.Forms.TextBox();
            this.groupBoxSendReceiveData = new System.Windows.Forms.GroupBox();
            this.buttonSendReceive = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSendBuffer = new System.Windows.Forms.TextBox();
            this.timerAutoSend = new System.Windows.Forms.Timer(this.components);
            this.buttonAutoSend = new System.Windows.Forms.Button();
            this.groupBoxPWM = new System.Windows.Forms.GroupBox();
            this.buttonColorSelect = new System.Windows.Forms.Button();
            this.buttonColorLed = new System.Windows.Forms.Button();
            this.labelMotorPWM = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarMotor = new System.Windows.Forms.TrackBar();
            this.labelLedPwm = new System.Windows.Forms.Label();
            this.trackBarLed = new System.Windows.Forms.TrackBar();
            this.colorDialogColorLed = new System.Windows.Forms.ColorDialog();
            this.groupBoxRELAY = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBarTemp = new System.Windows.Forms.ProgressBar();
            this.my_check_box_relay_hk = new WindowsFormsApplication1.my_check_box();
            this.my_check_box_relay_lk = new WindowsFormsApplication1.my_check_box();
            this.groupBoxTcp.SuspendLayout();
            this.groupBoxSendReceiveData.SuspendLayout();
            this.groupBoxPWM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMotor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLed)).BeginInit();
            this.groupBoxRELAY.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(8, 54);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(108, 30);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxTcp
            // 
            this.groupBoxTcp.Controls.Add(this.labelIsLink);
            this.groupBoxTcp.Controls.Add(this.label2);
            this.groupBoxTcp.Controls.Add(this.label1);
            this.groupBoxTcp.Controls.Add(this.textBoxSeverPort);
            this.groupBoxTcp.Controls.Add(this.textBoxSeverIP);
            this.groupBoxTcp.Controls.Add(this.buttonConnect);
            this.groupBoxTcp.Location = new System.Drawing.Point(16, 16);
            this.groupBoxTcp.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTcp.Name = "groupBoxTcp";
            this.groupBoxTcp.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxTcp.Size = new System.Drawing.Size(448, 140);
            this.groupBoxTcp.TabIndex = 1;
            this.groupBoxTcp.TabStop = false;
            this.groupBoxTcp.Text = "TCP";
            // 
            // labelIsLink
            // 
            this.labelIsLink.AutoSize = true;
            this.labelIsLink.Location = new System.Drawing.Point(123, 61);
            this.labelIsLink.Name = "labelIsLink";
            this.labelIsLink.Size = new System.Drawing.Size(112, 16);
            this.labelIsLink.TabIndex = 2;
            this.labelIsLink.Text = "DisConnected!";
            this.labelIsLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(246, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "SeverPort";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "SeverIP";
            // 
            // textBoxSeverPort
            // 
            this.textBoxSeverPort.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSeverPort.Location = new System.Drawing.Point(334, 23);
            this.textBoxSeverPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSeverPort.MaxLength = 5;
            this.textBoxSeverPort.Name = "textBoxSeverPort";
            this.textBoxSeverPort.Size = new System.Drawing.Size(95, 26);
            this.textBoxSeverPort.TabIndex = 4;
            this.textBoxSeverPort.Text = "8080";
            this.textBoxSeverPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSeverPort_KeyPress);
            // 
            // textBoxSeverIP
            // 
            this.textBoxSeverIP.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSeverIP.Location = new System.Drawing.Point(80, 20);
            this.textBoxSeverIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSeverIP.MaxLength = 15;
            this.textBoxSeverIP.Name = "textBoxSeverIP";
            this.textBoxSeverIP.Size = new System.Drawing.Size(158, 26);
            this.textBoxSeverIP.TabIndex = 3;
            this.textBoxSeverIP.Text = "192.168.0.128";
            // 
            // textBoxReceiveBuffer
            // 
            this.textBoxReceiveBuffer.Location = new System.Drawing.Point(6, 46);
            this.textBoxReceiveBuffer.Multiline = true;
            this.textBoxReceiveBuffer.Name = "textBoxReceiveBuffer";
            this.textBoxReceiveBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceiveBuffer.Size = new System.Drawing.Size(445, 297);
            this.textBoxReceiveBuffer.TabIndex = 4;
            // 
            // groupBoxSendReceiveData
            // 
            this.groupBoxSendReceiveData.Controls.Add(this.buttonSendReceive);
            this.groupBoxSendReceiveData.Controls.Add(this.label4);
            this.groupBoxSendReceiveData.Controls.Add(this.label3);
            this.groupBoxSendReceiveData.Controls.Add(this.textBoxSendBuffer);
            this.groupBoxSendReceiveData.Controls.Add(this.textBoxReceiveBuffer);
            this.groupBoxSendReceiveData.Location = new System.Drawing.Point(471, 16);
            this.groupBoxSendReceiveData.Name = "groupBoxSendReceiveData";
            this.groupBoxSendReceiveData.Size = new System.Drawing.Size(457, 554);
            this.groupBoxSendReceiveData.TabIndex = 5;
            this.groupBoxSendReceiveData.TabStop = false;
            this.groupBoxSendReceiveData.Text = "Send/Received";
            // 
            // buttonSendReceive
            // 
            this.buttonSendReceive.Location = new System.Drawing.Point(9, 506);
            this.buttonSendReceive.Name = "buttonSendReceive";
            this.buttonSendReceive.Size = new System.Drawing.Size(129, 42);
            this.buttonSendReceive.TabIndex = 8;
            this.buttonSendReceive.Text = "SendReceive";
            this.buttonSendReceive.UseVisualStyleBackColor = true;
            this.buttonSendReceive.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Send";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Received";
            // 
            // textBoxSendBuffer
            // 
            this.textBoxSendBuffer.Location = new System.Drawing.Point(6, 365);
            this.textBoxSendBuffer.Multiline = true;
            this.textBoxSendBuffer.Name = "textBoxSendBuffer";
            this.textBoxSendBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSendBuffer.Size = new System.Drawing.Size(445, 135);
            this.textBoxSendBuffer.TabIndex = 5;
            // 
            // timerAutoSend
            // 
            this.timerAutoSend.Interval = 1000;
            this.timerAutoSend.Tick += new System.EventHandler(this.timerAutoSend_Tick);
            // 
            // buttonAutoSend
            // 
            this.buttonAutoSend.Location = new System.Drawing.Point(350, 522);
            this.buttonAutoSend.Name = "buttonAutoSend";
            this.buttonAutoSend.Size = new System.Drawing.Size(96, 32);
            this.buttonAutoSend.TabIndex = 6;
            this.buttonAutoSend.Text = "AutoSend";
            this.buttonAutoSend.UseVisualStyleBackColor = true;
            this.buttonAutoSend.Click += new System.EventHandler(this.buttonAutoSend_Click);
            // 
            // groupBoxPWM
            // 
            this.groupBoxPWM.Controls.Add(this.buttonColorSelect);
            this.groupBoxPWM.Controls.Add(this.buttonColorLed);
            this.groupBoxPWM.Controls.Add(this.labelMotorPWM);
            this.groupBoxPWM.Controls.Add(this.label6);
            this.groupBoxPWM.Controls.Add(this.label5);
            this.groupBoxPWM.Controls.Add(this.trackBarMotor);
            this.groupBoxPWM.Controls.Add(this.labelLedPwm);
            this.groupBoxPWM.Controls.Add(this.trackBarLed);
            this.groupBoxPWM.Location = new System.Drawing.Point(16, 163);
            this.groupBoxPWM.Name = "groupBoxPWM";
            this.groupBoxPWM.Size = new System.Drawing.Size(448, 172);
            this.groupBoxPWM.TabIndex = 7;
            this.groupBoxPWM.TabStop = false;
            this.groupBoxPWM.Text = "PWM";
            // 
            // buttonColorSelect
            // 
            this.buttonColorSelect.Location = new System.Drawing.Point(19, 123);
            this.buttonColorSelect.Name = "buttonColorSelect";
            this.buttonColorSelect.Size = new System.Drawing.Size(219, 29);
            this.buttonColorSelect.TabIndex = 7;
            this.buttonColorSelect.Text = "Sel Color";
            this.buttonColorSelect.UseVisualStyleBackColor = true;
            this.buttonColorSelect.Click += new System.EventHandler(this.buttonColorSelect_Click);
            // 
            // buttonColorLed
            // 
            this.buttonColorLed.Location = new System.Drawing.Point(265, 123);
            this.buttonColorLed.Name = "buttonColorLed";
            this.buttonColorLed.Size = new System.Drawing.Size(140, 29);
            this.buttonColorLed.TabIndex = 6;
            this.buttonColorLed.Text = "Sync Color";
            this.buttonColorLed.UseVisualStyleBackColor = true;
            this.buttonColorLed.Click += new System.EventHandler(this.buttonColorLed_Click);
            // 
            // labelMotorPWM
            // 
            this.labelMotorPWM.AutoSize = true;
            this.labelMotorPWM.Location = new System.Drawing.Point(411, 89);
            this.labelMotorPWM.Name = "labelMotorPWM";
            this.labelMotorPWM.Size = new System.Drawing.Size(16, 16);
            this.labelMotorPWM.TabIndex = 5;
            this.labelMotorPWM.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Motor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "LED";
            // 
            // trackBarMotor
            // 
            this.trackBarMotor.Location = new System.Drawing.Point(15, 89);
            this.trackBarMotor.Maximum = 100;
            this.trackBarMotor.Name = "trackBarMotor";
            this.trackBarMotor.Size = new System.Drawing.Size(392, 45);
            this.trackBarMotor.TabIndex = 2;
            this.trackBarMotor.ValueChanged += new System.EventHandler(this.trackBarMotor_ValueChanged);
            this.trackBarMotor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarMotor_MouseUp);
            // 
            // labelLedPwm
            // 
            this.labelLedPwm.AutoSize = true;
            this.labelLedPwm.Location = new System.Drawing.Point(411, 41);
            this.labelLedPwm.Name = "labelLedPwm";
            this.labelLedPwm.Size = new System.Drawing.Size(16, 16);
            this.labelLedPwm.TabIndex = 1;
            this.labelLedPwm.Text = "0";
            // 
            // trackBarLed
            // 
            this.trackBarLed.Location = new System.Drawing.Point(13, 41);
            this.trackBarLed.Maximum = 100;
            this.trackBarLed.Name = "trackBarLed";
            this.trackBarLed.Size = new System.Drawing.Size(392, 45);
            this.trackBarLed.TabIndex = 0;
            this.trackBarLed.ValueChanged += new System.EventHandler(this.trackBarPWM_ValueChanged);
            this.trackBarLed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPWM_MouseUp);
            // 
            // colorDialogColorLed
            // 
            this.colorDialogColorLed.AnyColor = true;
            this.colorDialogColorLed.FullOpen = true;
            // 
            // groupBoxRELAY
            // 
            this.groupBoxRELAY.Controls.Add(this.label8);
            this.groupBoxRELAY.Controls.Add(this.label7);
            this.groupBoxRELAY.Controls.Add(this.my_check_box_relay_hk);
            this.groupBoxRELAY.Controls.Add(this.my_check_box_relay_lk);
            this.groupBoxRELAY.Location = new System.Drawing.Point(12, 341);
            this.groupBoxRELAY.Name = "groupBoxRELAY";
            this.groupBoxRELAY.Size = new System.Drawing.Size(330, 70);
            this.groupBoxRELAY.TabIndex = 8;
            this.groupBoxRELAY.TabStop = false;
            this.groupBoxRELAY.Text = "RELAY";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "LK:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "HK:";
            // 
            // progressBarTemp
            // 
            this.progressBarTemp.Location = new System.Drawing.Point(132, 484);
            this.progressBarTemp.Name = "progressBarTemp";
            this.progressBarTemp.Size = new System.Drawing.Size(100, 23);
            this.progressBarTemp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTemp.TabIndex = 9;
            this.progressBarTemp.Value = 30;
            // 
            // my_check_box_relay_hk
            // 
            this.my_check_box_relay_hk.BackColor = System.Drawing.Color.Transparent;
            this.my_check_box_relay_hk.Checked = 0;
            this.my_check_box_relay_hk.CheckStyleX = WindowsFormsApplication1.CheckStyle.style1;
            this.my_check_box_relay_hk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.my_check_box_relay_hk.Location = new System.Drawing.Point(211, 25);
            this.my_check_box_relay_hk.Name = "my_check_box_relay_hk";
            this.my_check_box_relay_hk.Size = new System.Drawing.Size(87, 27);
            this.my_check_box_relay_hk.TabIndex = 11;
            this.my_check_box_relay_hk.Click += new System.EventHandler(this.my_check_box_relay_hk_Click);
            // 
            // my_check_box_relay_lk
            // 
            this.my_check_box_relay_lk.BackColor = System.Drawing.Color.Transparent;
            this.my_check_box_relay_lk.Checked = 0;
            this.my_check_box_relay_lk.CheckStyleX = WindowsFormsApplication1.CheckStyle.style1;
            this.my_check_box_relay_lk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.my_check_box_relay_lk.Location = new System.Drawing.Point(47, 25);
            this.my_check_box_relay_lk.Name = "my_check_box_relay_lk";
            this.my_check_box_relay_lk.Size = new System.Drawing.Size(87, 27);
            this.my_check_box_relay_lk.TabIndex = 10;
            this.my_check_box_relay_lk.Click += new System.EventHandler(this.my_check_box_relay_lk_click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 597);
            this.Controls.Add(this.progressBarTemp);
            this.Controls.Add(this.groupBoxRELAY);
            this.Controls.Add(this.groupBoxPWM);
            this.Controls.Add(this.buttonAutoSend);
            this.Controls.Add(this.groupBoxSendReceiveData);
            this.Controls.Add(this.groupBoxTcp);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMian";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxTcp.ResumeLayout(false);
            this.groupBoxTcp.PerformLayout();
            this.groupBoxSendReceiveData.ResumeLayout(false);
            this.groupBoxSendReceiveData.PerformLayout();
            this.groupBoxPWM.ResumeLayout(false);
            this.groupBoxPWM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMotor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLed)).EndInit();
            this.groupBoxRELAY.ResumeLayout(false);
            this.groupBoxRELAY.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxTcp;
        private System.Windows.Forms.TextBox textBoxSeverIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSeverPort;
        private System.Windows.Forms.Label labelIsLink;
        private System.Windows.Forms.TextBox textBoxReceiveBuffer;
        private System.Windows.Forms.GroupBox groupBoxSendReceiveData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSendBuffer;
        private System.Windows.Forms.Button buttonSendReceive;
        private System.Windows.Forms.Timer timerAutoSend;
        private System.Windows.Forms.Button buttonAutoSend;
        private System.Windows.Forms.GroupBox groupBoxPWM;
        private System.Windows.Forms.TrackBar trackBarLed;
        private System.Windows.Forms.Label labelLedPwm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarMotor;
        private System.Windows.Forms.Label labelMotorPWM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialogColorLed;
        private System.Windows.Forms.Button buttonColorLed;
        private System.Windows.Forms.Button buttonColorSelect;
        private System.Windows.Forms.GroupBox groupBoxRELAY;
        private System.Windows.Forms.ProgressBar progressBarTemp;
        private WindowsFormsApplication1.my_check_box my_check_box_relay_lk;
        private WindowsFormsApplication1.my_check_box my_check_box_relay_hk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

