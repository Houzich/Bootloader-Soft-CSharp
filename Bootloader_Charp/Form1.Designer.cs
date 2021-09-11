namespace Bootloader
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.button_Connect = new System.Windows.Forms.Button();
            this.comboBox_Com_Ports = new System.Windows.Forms.ComboBox();
            this.groupBox_Sectors_Erase = new System.Windows.Forms.GroupBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox_Sectors_Read = new System.Windows.Forms.GroupBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.panel_Erase = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_Read = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_File_Name = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_HEX = new System.Windows.Forms.RadioButton();
            this.radioButton_BIN = new System.Windows.Forms.RadioButton();
            this.panel_Write = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Verify_After_Download = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox_Jump_To_Application = new System.Windows.Forms.CheckBox();
            this.checkBox_Erase_Sectors = new System.Windows.Forms.CheckBox();
            this.groupBox_Start_Address = new System.Windows.Forms.GroupBox();
            this.comboBox_Start_Address = new System.Windows.Forms.ComboBox();
            this.groupBox_Download_From_File = new System.Windows.Forms.GroupBox();
            this.textBox_File_Name_Write = new System.Windows.Forms.TextBox();
            this.button_Write = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_STATE = new System.Windows.Forms.Label();
            this.panel_Connect = new System.Windows.Forms.Panel();
            this.label_Version = new System.Windows.Forms.Label();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_BID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_PID = new System.Windows.Forms.TextBox();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel_Write_Protect = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Write_Protect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_Sectors_Write_Protect = new System.Windows.Forms.GroupBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.checkBox31 = new System.Windows.Forms.CheckBox();
            this.checkBox32 = new System.Windows.Forms.CheckBox();
            this.checkBox33 = new System.Windows.Forms.CheckBox();
            this.checkBox34 = new System.Windows.Forms.CheckBox();
            this.checkBox35 = new System.Windows.Forms.CheckBox();
            this.checkBox36 = new System.Windows.Forms.CheckBox();
            this.groupBox_Sectors_Erase.SuspendLayout();
            this.groupBox_Sectors_Read.SuspendLayout();
            this.panel_Erase.SuspendLayout();
            this.panel_Read.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_Write.SuspendLayout();
            this.groupBox_Start_Address.SuspendLayout();
            this.groupBox_Download_From_File.SuspendLayout();
            this.panel_Connect.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.panel_Write_Protect.SuspendLayout();
            this.groupBox_Sectors_Write_Protect.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.Parity = System.IO.Ports.Parity.Even;
            this.serialPort.ReadTimeout = 5000;
            this.serialPort.WriteTimeout = 5000;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // button_Connect
            // 
            this.button_Connect.BackColor = System.Drawing.Color.Green;
            this.button_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Connect.Location = new System.Drawing.Point(10, 10);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(130, 30);
            this.button_Connect.TabIndex = 201;
            this.button_Connect.Tag = "Start";
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = false;
            this.button_Connect.EnabledChanged += new System.EventHandler(this.button_Connect_EnabledChanged);
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // comboBox_Com_Ports
            // 
            this.comboBox_Com_Ports.FormattingEnabled = true;
            this.comboBox_Com_Ports.Items.AddRange(new object[] {
            "None",
            "Stack My",
            "Stack Player 1",
            "Stack Player 2",
            "Stack Player 3",
            "Stack Player 4",
            "Stack Player 5",
            "Bet My",
            "Bet Player 1",
            "Bet Player 2",
            "Bet Player 3",
            "Bet Player 4",
            "Bet Player 5",
            "Pot",
            "Call",
            "Raise",
            "Header",
            "Header Dollar Bitmap",
            "Pot Dollar Bitmap",
            "Bet Dollar Bitmap",
            "Call/Raise Dollar Bitmap",
            "Stack Dollar Bitmap"});
            this.comboBox_Com_Ports.Location = new System.Drawing.Point(150, 15);
            this.comboBox_Com_Ports.Name = "comboBox_Com_Ports";
            this.comboBox_Com_Ports.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Com_Ports.TabIndex = 147;
            // 
            // groupBox_Sectors_Erase
            // 
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox12);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox11);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox10);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox9);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox8);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox7);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox6);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox5);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox4);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox3);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox2);
            this.groupBox_Sectors_Erase.Controls.Add(this.checkBox1);
            this.groupBox_Sectors_Erase.Location = new System.Drawing.Point(10, 50);
            this.groupBox_Sectors_Erase.Name = "groupBox_Sectors_Erase";
            this.groupBox_Sectors_Erase.Size = new System.Drawing.Size(90, 270);
            this.groupBox_Sectors_Erase.TabIndex = 205;
            this.groupBox_Sectors_Erase.TabStop = false;
            this.groupBox_Sectors_Erase.Text = "Sectors";
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(10, 240);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(72, 17);
            this.checkBox12.TabIndex = 11;
            this.checkBox12.Tag = "11";
            this.checkBox12.Text = "Sector 11";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(10, 220);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(72, 17);
            this.checkBox11.TabIndex = 10;
            this.checkBox11.Tag = "10";
            this.checkBox11.Text = "Sector 10";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(10, 200);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(66, 17);
            this.checkBox10.TabIndex = 9;
            this.checkBox10.Tag = "9";
            this.checkBox10.Text = "Sector 9";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(10, 180);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(66, 17);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.Tag = "8";
            this.checkBox9.Text = "Sector 8";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(10, 160);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(66, 17);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Tag = "7";
            this.checkBox8.Text = "Sector 7";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(10, 140);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(66, 17);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Tag = "6";
            this.checkBox7.Text = "Sector 6";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(10, 120);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(66, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Tag = "5";
            this.checkBox6.Text = "Sector 5";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(10, 100);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Tag = "4";
            this.checkBox5.Text = "Sector 4";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(10, 80);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "3";
            this.checkBox4.Text = "Sector 3";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(10, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "2";
            this.checkBox3.Text = "Sector 2";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "1";
            this.checkBox2.Text = "Sector 1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "0";
            this.checkBox1.Text = "Sector 0";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 20);
            this.button2.TabIndex = 206;
            this.button2.Text = "Erase";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 20);
            this.button3.TabIndex = 208;
            this.button3.Text = "Read";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox_Sectors_Read
            // 
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox13);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox14);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox15);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox16);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox17);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox18);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox19);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox20);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox21);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox22);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox23);
            this.groupBox_Sectors_Read.Controls.Add(this.checkBox24);
            this.groupBox_Sectors_Read.Location = new System.Drawing.Point(10, 50);
            this.groupBox_Sectors_Read.Name = "groupBox_Sectors_Read";
            this.groupBox_Sectors_Read.Size = new System.Drawing.Size(90, 270);
            this.groupBox_Sectors_Read.TabIndex = 207;
            this.groupBox_Sectors_Read.TabStop = false;
            this.groupBox_Sectors_Read.Text = "Sectors";
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(10, 240);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(72, 17);
            this.checkBox13.TabIndex = 11;
            this.checkBox13.Tag = "11";
            this.checkBox13.Text = "Sector 11";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(10, 220);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(72, 17);
            this.checkBox14.TabIndex = 10;
            this.checkBox14.Tag = "10";
            this.checkBox14.Text = "Sector 10";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(10, 200);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(66, 17);
            this.checkBox15.TabIndex = 9;
            this.checkBox15.Tag = "9";
            this.checkBox15.Text = "Sector 9";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(10, 180);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(66, 17);
            this.checkBox16.TabIndex = 8;
            this.checkBox16.Tag = "8";
            this.checkBox16.Text = "Sector 8";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(10, 160);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(66, 17);
            this.checkBox17.TabIndex = 7;
            this.checkBox17.Tag = "7";
            this.checkBox17.Text = "Sector 7";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(10, 140);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(66, 17);
            this.checkBox18.TabIndex = 6;
            this.checkBox18.Tag = "6";
            this.checkBox18.Text = "Sector 6";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(10, 120);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(66, 17);
            this.checkBox19.TabIndex = 5;
            this.checkBox19.Tag = "5";
            this.checkBox19.Text = "Sector 5";
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(10, 100);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(66, 17);
            this.checkBox20.TabIndex = 4;
            this.checkBox20.Tag = "4";
            this.checkBox20.Text = "Sector 4";
            this.checkBox20.UseVisualStyleBackColor = true;
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Location = new System.Drawing.Point(10, 80);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(66, 17);
            this.checkBox21.TabIndex = 3;
            this.checkBox21.Tag = "3";
            this.checkBox21.Text = "Sector 3";
            this.checkBox21.UseVisualStyleBackColor = true;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(10, 60);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(66, 17);
            this.checkBox22.TabIndex = 2;
            this.checkBox22.Tag = "2";
            this.checkBox22.Text = "Sector 2";
            this.checkBox22.UseVisualStyleBackColor = true;
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(10, 40);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(66, 17);
            this.checkBox23.TabIndex = 1;
            this.checkBox23.Tag = "1";
            this.checkBox23.Text = "Sector 1";
            this.checkBox23.UseVisualStyleBackColor = true;
            // 
            // checkBox24
            // 
            this.checkBox24.AutoSize = true;
            this.checkBox24.Location = new System.Drawing.Point(10, 20);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(66, 17);
            this.checkBox24.TabIndex = 0;
            this.checkBox24.Tag = "0";
            this.checkBox24.Text = "Sector 0";
            this.checkBox24.UseVisualStyleBackColor = true;
            // 
            // panel_Erase
            // 
            this.panel_Erase.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Erase.Controls.Add(this.label4);
            this.panel_Erase.Controls.Add(this.button2);
            this.panel_Erase.Controls.Add(this.groupBox_Sectors_Erase);
            this.panel_Erase.Location = new System.Drawing.Point(280, 0);
            this.panel_Erase.Name = "panel_Erase";
            this.panel_Erase.Size = new System.Drawing.Size(110, 360);
            this.panel_Erase.TabIndex = 209;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 222;
            this.label4.Text = "Erase";
            // 
            // panel_Read
            // 
            this.panel_Read.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Read.Controls.Add(this.label5);
            this.panel_Read.Controls.Add(this.groupBox3);
            this.panel_Read.Controls.Add(this.groupBox2);
            this.panel_Read.Controls.Add(this.button3);
            this.panel_Read.Controls.Add(this.groupBox_Sectors_Read);
            this.panel_Read.Location = new System.Drawing.Point(400, 0);
            this.panel_Read.Name = "panel_Read";
            this.panel_Read.Size = new System.Drawing.Size(240, 360);
            this.panel_Read.TabIndex = 210;
            this.panel_Read.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Read_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 19);
            this.label5.TabIndex = 223;
            this.label5.Text = "Upload from device";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_File_Name);
            this.groupBox3.Location = new System.Drawing.Point(110, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 50);
            this.groupBox3.TabIndex = 213;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File Name";
            // 
            // textBox_File_Name
            // 
            this.textBox_File_Name.Location = new System.Drawing.Point(10, 20);
            this.textBox_File_Name.Name = "textBox_File_Name";
            this.textBox_File_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_File_Name.TabIndex = 212;
            this.textBox_File_Name.Text = "Test";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_HEX);
            this.groupBox2.Controls.Add(this.radioButton_BIN);
            this.groupBox2.Location = new System.Drawing.Point(110, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 60);
            this.groupBox2.TabIndex = 211;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Format";
            // 
            // radioButton_HEX
            // 
            this.radioButton_HEX.AutoSize = true;
            this.radioButton_HEX.Location = new System.Drawing.Point(10, 40);
            this.radioButton_HEX.Name = "radioButton_HEX";
            this.radioButton_HEX.Size = new System.Drawing.Size(47, 17);
            this.radioButton_HEX.TabIndex = 210;
            this.radioButton_HEX.Text = "HEX";
            this.radioButton_HEX.UseVisualStyleBackColor = true;
            // 
            // radioButton_BIN
            // 
            this.radioButton_BIN.AutoSize = true;
            this.radioButton_BIN.Checked = true;
            this.radioButton_BIN.Location = new System.Drawing.Point(10, 20);
            this.radioButton_BIN.Name = "radioButton_BIN";
            this.radioButton_BIN.Size = new System.Drawing.Size(43, 17);
            this.radioButton_BIN.TabIndex = 209;
            this.radioButton_BIN.TabStop = true;
            this.radioButton_BIN.Text = "BIN";
            this.radioButton_BIN.UseVisualStyleBackColor = true;
            // 
            // panel_Write
            // 
            this.panel_Write.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Write.Controls.Add(this.label3);
            this.panel_Write.Controls.Add(this.checkBox_Verify_After_Download);
            this.panel_Write.Controls.Add(this.button6);
            this.panel_Write.Controls.Add(this.checkBox_Jump_To_Application);
            this.panel_Write.Controls.Add(this.checkBox_Erase_Sectors);
            this.panel_Write.Controls.Add(this.groupBox_Start_Address);
            this.panel_Write.Controls.Add(this.groupBox_Download_From_File);
            this.panel_Write.Controls.Add(this.button_Write);
            this.panel_Write.Location = new System.Drawing.Point(0, 120);
            this.panel_Write.Name = "panel_Write";
            this.panel_Write.Size = new System.Drawing.Size(270, 240);
            this.panel_Write.TabIndex = 211;
            this.panel_Write.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Write_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 19);
            this.label3.TabIndex = 221;
            this.label3.Text = "Download to device";
            // 
            // checkBox_Verify_After_Download
            // 
            this.checkBox_Verify_After_Download.AutoSize = true;
            this.checkBox_Verify_After_Download.Checked = true;
            this.checkBox_Verify_After_Download.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Verify_After_Download.Enabled = false;
            this.checkBox_Verify_After_Download.Location = new System.Drawing.Point(10, 100);
            this.checkBox_Verify_After_Download.Name = "checkBox_Verify_After_Download";
            this.checkBox_Verify_After_Download.Size = new System.Drawing.Size(125, 17);
            this.checkBox_Verify_After_Download.TabIndex = 220;
            this.checkBox_Verify_After_Download.Tag = "6";
            this.checkBox_Verify_After_Download.Text = "Verify after download";
            this.checkBox_Verify_After_Download.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(180, 30);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 20);
            this.button6.TabIndex = 219;
            this.button6.Text = "Open File";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox_Jump_To_Application
            // 
            this.checkBox_Jump_To_Application.AutoSize = true;
            this.checkBox_Jump_To_Application.Checked = true;
            this.checkBox_Jump_To_Application.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Jump_To_Application.Enabled = false;
            this.checkBox_Jump_To_Application.Location = new System.Drawing.Point(10, 80);
            this.checkBox_Jump_To_Application.Name = "checkBox_Jump_To_Application";
            this.checkBox_Jump_To_Application.Size = new System.Drawing.Size(145, 17);
            this.checkBox_Jump_To_Application.TabIndex = 217;
            this.checkBox_Jump_To_Application.Tag = "6";
            this.checkBox_Jump_To_Application.Text = "Jump to the user program";
            this.checkBox_Jump_To_Application.UseVisualStyleBackColor = true;
            // 
            // checkBox_Erase_Sectors
            // 
            this.checkBox_Erase_Sectors.AutoSize = true;
            this.checkBox_Erase_Sectors.Checked = true;
            this.checkBox_Erase_Sectors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Erase_Sectors.Enabled = false;
            this.checkBox_Erase_Sectors.Location = new System.Drawing.Point(10, 60);
            this.checkBox_Erase_Sectors.Name = "checkBox_Erase_Sectors";
            this.checkBox_Erase_Sectors.Size = new System.Drawing.Size(141, 17);
            this.checkBox_Erase_Sectors.TabIndex = 216;
            this.checkBox_Erase_Sectors.Tag = "5";
            this.checkBox_Erase_Sectors.Text = "Erase necessary sectors";
            this.checkBox_Erase_Sectors.UseVisualStyleBackColor = true;
            // 
            // groupBox_Start_Address
            // 
            this.groupBox_Start_Address.Controls.Add(this.comboBox_Start_Address);
            this.groupBox_Start_Address.Enabled = false;
            this.groupBox_Start_Address.Location = new System.Drawing.Point(10, 180);
            this.groupBox_Start_Address.Name = "groupBox_Start_Address";
            this.groupBox_Start_Address.Size = new System.Drawing.Size(250, 50);
            this.groupBox_Start_Address.TabIndex = 215;
            this.groupBox_Start_Address.TabStop = false;
            this.groupBox_Start_Address.Text = "Start Address";
            // 
            // comboBox_Start_Address
            // 
            this.comboBox_Start_Address.FormattingEnabled = true;
            this.comboBox_Start_Address.Items.AddRange(new object[] {
            "SECTOR 0  (0x08000000)",
            "SECTOR 1  (0x08004000)",
            "SECTOR 2  (0x08008000)",
            "SECTOR 3  (0x0800C000)",
            "SECTOR 4  (0x08010000)",
            "SECTOR 5  (0x08020000)",
            "SECTOR 6  (0x08040000)",
            "SECTOR 7  (0x08060000)",
            "SECTOR 8  (0x08080000)",
            "SECTOR 9  (0x080A0000)",
            "SECTOR 10 (0x080C0000)",
            "SECTOR 11 (0x080E0000)"});
            this.comboBox_Start_Address.Location = new System.Drawing.Point(10, 20);
            this.comboBox_Start_Address.Name = "comboBox_Start_Address";
            this.comboBox_Start_Address.Size = new System.Drawing.Size(230, 21);
            this.comboBox_Start_Address.TabIndex = 214;
            // 
            // groupBox_Download_From_File
            // 
            this.groupBox_Download_From_File.Controls.Add(this.textBox_File_Name_Write);
            this.groupBox_Download_From_File.Enabled = false;
            this.groupBox_Download_From_File.Location = new System.Drawing.Point(10, 120);
            this.groupBox_Download_From_File.Name = "groupBox_Download_From_File";
            this.groupBox_Download_From_File.Size = new System.Drawing.Size(250, 50);
            this.groupBox_Download_From_File.TabIndex = 213;
            this.groupBox_Download_From_File.TabStop = false;
            this.groupBox_Download_From_File.Text = "Download from file";
            // 
            // textBox_File_Name_Write
            // 
            this.textBox_File_Name_Write.Location = new System.Drawing.Point(10, 20);
            this.textBox_File_Name_Write.Name = "textBox_File_Name_Write";
            this.textBox_File_Name_Write.ReadOnly = true;
            this.textBox_File_Name_Write.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_File_Name_Write.Size = new System.Drawing.Size(230, 20);
            this.textBox_File_Name_Write.TabIndex = 212;
            this.textBox_File_Name_Write.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_Write
            // 
            this.button_Write.Enabled = false;
            this.button_Write.Location = new System.Drawing.Point(10, 30);
            this.button_Write.Name = "button_Write";
            this.button_Write.Size = new System.Drawing.Size(80, 20);
            this.button_Write.TabIndex = 208;
            this.button_Write.Text = "Write";
            this.button_Write.UseVisualStyleBackColor = true;
            this.button_Write.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar1.Location = new System.Drawing.Point(130, 380);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(680, 33);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 218;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "BIN files (*.bin)|*.bin|HEX files (*.hex)|*.hex";
            // 
            // label_STATE
            // 
            this.label_STATE.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_STATE.ForeColor = System.Drawing.Color.Red;
            this.label_STATE.Location = new System.Drawing.Point(10, 381);
            this.label_STATE.Name = "label_STATE";
            this.label_STATE.Size = new System.Drawing.Size(640, 31);
            this.label_STATE.TabIndex = 212;
            this.label_STATE.Text = "DEVICE NOT CONNECTED";
            // 
            // panel_Connect
            // 
            this.panel_Connect.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Connect.Controls.Add(this.label_Version);
            this.panel_Connect.Controls.Add(this.textBox_Version);
            this.panel_Connect.Controls.Add(this.label2);
            this.panel_Connect.Controls.Add(this.textBox_BID);
            this.panel_Connect.Controls.Add(this.label1);
            this.panel_Connect.Controls.Add(this.textBox_PID);
            this.panel_Connect.Controls.Add(this.comboBox_Com_Ports);
            this.panel_Connect.Controls.Add(this.button_Connect);
            this.panel_Connect.Location = new System.Drawing.Point(0, 0);
            this.panel_Connect.Name = "panel_Connect";
            this.panel_Connect.Size = new System.Drawing.Size(270, 110);
            this.panel_Connect.TabIndex = 221;
            // 
            // label_Version
            // 
            this.label_Version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Version.AutoSize = true;
            this.label_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Version.Location = new System.Drawing.Point(6, 80);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(62, 13);
            this.label_Version.TabIndex = 218;
            this.label_Version.Text = "VERSION";
            this.label_Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Version
            // 
            this.textBox_Version.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox_Version.Location = new System.Drawing.Point(70, 76);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.ReadOnly = true;
            this.textBox_Version.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Version.Size = new System.Drawing.Size(60, 20);
            this.textBox_Version.TabIndex = 217;
            this.textBox_Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(140, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 216;
            this.label2.Text = "BID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_BID
            // 
            this.textBox_BID.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox_BID.Location = new System.Drawing.Point(170, 50);
            this.textBox_BID.Name = "textBox_BID";
            this.textBox_BID.ReadOnly = true;
            this.textBox_BID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_BID.Size = new System.Drawing.Size(60, 20);
            this.textBox_BID.TabIndex = 215;
            this.textBox_BID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 214;
            this.label1.Text = "PID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_PID
            // 
            this.textBox_PID.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox_PID.Location = new System.Drawing.Point(70, 50);
            this.textBox_PID.Name = "textBox_PID";
            this.textBox_PID.ReadOnly = true;
            this.textBox_PID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_PID.Size = new System.Drawing.Size(60, 20);
            this.textBox_PID.TabIndex = 213;
            this.textBox_PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel_Main
            // 
            this.panel_Main.Controls.Add(this.panel_Write_Protect);
            this.panel_Main.Controls.Add(this.progressBar1);
            this.panel_Main.Controls.Add(this.label_STATE);
            this.panel_Main.Controls.Add(this.panel_Connect);
            this.panel_Main.Controls.Add(this.panel_Write);
            this.panel_Main.Controls.Add(this.panel_Read);
            this.panel_Main.Controls.Add(this.panel_Erase);
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(810, 420);
            this.panel_Main.TabIndex = 222;
            // 
            // panel_Write_Protect
            // 
            this.panel_Write_Protect.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Write_Protect.Controls.Add(this.label6);
            this.panel_Write_Protect.Controls.Add(this.button_Write_Protect);
            this.panel_Write_Protect.Controls.Add(this.button1);
            this.panel_Write_Protect.Controls.Add(this.groupBox_Sectors_Write_Protect);
            this.panel_Write_Protect.Enabled = false;
            this.panel_Write_Protect.Location = new System.Drawing.Point(650, 0);
            this.panel_Write_Protect.Name = "panel_Write_Protect";
            this.panel_Write_Protect.Size = new System.Drawing.Size(160, 360);
            this.panel_Write_Protect.TabIndex = 222;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 19);
            this.label6.TabIndex = 223;
            this.label6.Text = "Set write protection";
            // 
            // button_Write_Protect
            // 
            this.button_Write_Protect.Enabled = false;
            this.button_Write_Protect.Location = new System.Drawing.Point(80, 30);
            this.button_Write_Protect.Name = "button_Write_Protect";
            this.button_Write_Protect.Size = new System.Drawing.Size(60, 20);
            this.button_Write_Protect.TabIndex = 207;
            this.button_Write_Protect.Text = "Write";
            this.button_Write_Protect.UseVisualStyleBackColor = true;
            this.button_Write_Protect.Click += new System.EventHandler(this.button_Write_Protect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 20);
            this.button1.TabIndex = 206;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox_Sectors_Write_Protect
            // 
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox25);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox26);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox27);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox28);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox29);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox30);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox31);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox32);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox33);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox34);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox35);
            this.groupBox_Sectors_Write_Protect.Controls.Add(this.checkBox36);
            this.groupBox_Sectors_Write_Protect.Enabled = false;
            this.groupBox_Sectors_Write_Protect.Location = new System.Drawing.Point(10, 50);
            this.groupBox_Sectors_Write_Protect.Name = "groupBox_Sectors_Write_Protect";
            this.groupBox_Sectors_Write_Protect.Size = new System.Drawing.Size(90, 270);
            this.groupBox_Sectors_Write_Protect.TabIndex = 205;
            this.groupBox_Sectors_Write_Protect.TabStop = false;
            this.groupBox_Sectors_Write_Protect.Text = "Sectors";
            // 
            // checkBox25
            // 
            this.checkBox25.AutoSize = true;
            this.checkBox25.Location = new System.Drawing.Point(10, 240);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(72, 17);
            this.checkBox25.TabIndex = 11;
            this.checkBox25.Tag = "11";
            this.checkBox25.Text = "Sector 11";
            this.checkBox25.UseVisualStyleBackColor = true;
            // 
            // checkBox26
            // 
            this.checkBox26.AutoSize = true;
            this.checkBox26.Location = new System.Drawing.Point(10, 220);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(72, 17);
            this.checkBox26.TabIndex = 10;
            this.checkBox26.Tag = "10";
            this.checkBox26.Text = "Sector 10";
            this.checkBox26.UseVisualStyleBackColor = true;
            // 
            // checkBox27
            // 
            this.checkBox27.AutoSize = true;
            this.checkBox27.Location = new System.Drawing.Point(10, 200);
            this.checkBox27.Name = "checkBox27";
            this.checkBox27.Size = new System.Drawing.Size(66, 17);
            this.checkBox27.TabIndex = 9;
            this.checkBox27.Tag = "9";
            this.checkBox27.Text = "Sector 9";
            this.checkBox27.UseVisualStyleBackColor = true;
            // 
            // checkBox28
            // 
            this.checkBox28.AutoSize = true;
            this.checkBox28.Location = new System.Drawing.Point(10, 180);
            this.checkBox28.Name = "checkBox28";
            this.checkBox28.Size = new System.Drawing.Size(66, 17);
            this.checkBox28.TabIndex = 8;
            this.checkBox28.Tag = "8";
            this.checkBox28.Text = "Sector 8";
            this.checkBox28.UseVisualStyleBackColor = true;
            // 
            // checkBox29
            // 
            this.checkBox29.AutoSize = true;
            this.checkBox29.Location = new System.Drawing.Point(10, 160);
            this.checkBox29.Name = "checkBox29";
            this.checkBox29.Size = new System.Drawing.Size(66, 17);
            this.checkBox29.TabIndex = 7;
            this.checkBox29.Tag = "7";
            this.checkBox29.Text = "Sector 7";
            this.checkBox29.UseVisualStyleBackColor = true;
            // 
            // checkBox30
            // 
            this.checkBox30.AutoSize = true;
            this.checkBox30.Location = new System.Drawing.Point(10, 140);
            this.checkBox30.Name = "checkBox30";
            this.checkBox30.Size = new System.Drawing.Size(66, 17);
            this.checkBox30.TabIndex = 6;
            this.checkBox30.Tag = "6";
            this.checkBox30.Text = "Sector 6";
            this.checkBox30.UseVisualStyleBackColor = true;
            // 
            // checkBox31
            // 
            this.checkBox31.AutoSize = true;
            this.checkBox31.Location = new System.Drawing.Point(10, 120);
            this.checkBox31.Name = "checkBox31";
            this.checkBox31.Size = new System.Drawing.Size(66, 17);
            this.checkBox31.TabIndex = 5;
            this.checkBox31.Tag = "5";
            this.checkBox31.Text = "Sector 5";
            this.checkBox31.UseVisualStyleBackColor = true;
            // 
            // checkBox32
            // 
            this.checkBox32.AutoSize = true;
            this.checkBox32.Location = new System.Drawing.Point(10, 100);
            this.checkBox32.Name = "checkBox32";
            this.checkBox32.Size = new System.Drawing.Size(66, 17);
            this.checkBox32.TabIndex = 4;
            this.checkBox32.Tag = "4";
            this.checkBox32.Text = "Sector 4";
            this.checkBox32.UseVisualStyleBackColor = true;
            // 
            // checkBox33
            // 
            this.checkBox33.AutoSize = true;
            this.checkBox33.Location = new System.Drawing.Point(10, 80);
            this.checkBox33.Name = "checkBox33";
            this.checkBox33.Size = new System.Drawing.Size(66, 17);
            this.checkBox33.TabIndex = 3;
            this.checkBox33.Tag = "3";
            this.checkBox33.Text = "Sector 3";
            this.checkBox33.UseVisualStyleBackColor = true;
            // 
            // checkBox34
            // 
            this.checkBox34.AutoSize = true;
            this.checkBox34.Location = new System.Drawing.Point(10, 60);
            this.checkBox34.Name = "checkBox34";
            this.checkBox34.Size = new System.Drawing.Size(66, 17);
            this.checkBox34.TabIndex = 2;
            this.checkBox34.Tag = "2";
            this.checkBox34.Text = "Sector 2";
            this.checkBox34.UseVisualStyleBackColor = true;
            // 
            // checkBox35
            // 
            this.checkBox35.AutoSize = true;
            this.checkBox35.Location = new System.Drawing.Point(10, 40);
            this.checkBox35.Name = "checkBox35";
            this.checkBox35.Size = new System.Drawing.Size(66, 17);
            this.checkBox35.TabIndex = 1;
            this.checkBox35.Tag = "1";
            this.checkBox35.Text = "Sector 1";
            this.checkBox35.UseVisualStyleBackColor = true;
            // 
            // checkBox36
            // 
            this.checkBox36.AutoSize = true;
            this.checkBox36.Enabled = false;
            this.checkBox36.Location = new System.Drawing.Point(10, 20);
            this.checkBox36.Name = "checkBox36";
            this.checkBox36.Size = new System.Drawing.Size(66, 17);
            this.checkBox36.TabIndex = 0;
            this.checkBox36.Tag = "0";
            this.checkBox36.Text = "Sector 0";
            this.checkBox36.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(812, 416);
            this.Controls.Add(this.panel_Main);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Bootloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Sectors_Erase.ResumeLayout(false);
            this.groupBox_Sectors_Erase.PerformLayout();
            this.groupBox_Sectors_Read.ResumeLayout(false);
            this.groupBox_Sectors_Read.PerformLayout();
            this.panel_Erase.ResumeLayout(false);
            this.panel_Erase.PerformLayout();
            this.panel_Read.ResumeLayout(false);
            this.panel_Read.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel_Write.ResumeLayout(false);
            this.panel_Write.PerformLayout();
            this.groupBox_Start_Address.ResumeLayout(false);
            this.groupBox_Download_From_File.ResumeLayout(false);
            this.groupBox_Download_From_File.PerformLayout();
            this.panel_Connect.ResumeLayout(false);
            this.panel_Connect.PerformLayout();
            this.panel_Main.ResumeLayout(false);
            this.panel_Write_Protect.ResumeLayout(false);
            this.panel_Write_Protect.PerformLayout();
            this.groupBox_Sectors_Write_Protect.ResumeLayout(false);
            this.groupBox_Sectors_Write_Protect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.ComboBox comboBox_Com_Ports;
        private System.Windows.Forms.GroupBox groupBox_Sectors_Erase;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox_Sectors_Read;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox checkBox24;
        private System.Windows.Forms.Panel panel_Erase;
        private System.Windows.Forms.Panel panel_Read;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_HEX;
        private System.Windows.Forms.RadioButton radioButton_BIN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_File_Name;
        private System.Windows.Forms.Panel panel_Write;
        private System.Windows.Forms.GroupBox groupBox_Start_Address;
        private System.Windows.Forms.ComboBox comboBox_Start_Address;
        private System.Windows.Forms.GroupBox groupBox_Download_From_File;
        private System.Windows.Forms.TextBox textBox_File_Name_Write;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.CheckBox checkBox_Jump_To_Application;
        private System.Windows.Forms.CheckBox checkBox_Erase_Sectors;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_STATE;
        private System.Windows.Forms.Panel panel_Connect;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.CheckBox checkBox_Verify_After_Download;
        private System.Windows.Forms.Panel panel_Write_Protect;
        private System.Windows.Forms.Button button_Write_Protect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox_Sectors_Write_Protect;
        private System.Windows.Forms.CheckBox checkBox25;
        private System.Windows.Forms.CheckBox checkBox26;
        private System.Windows.Forms.CheckBox checkBox27;
        private System.Windows.Forms.CheckBox checkBox28;
        private System.Windows.Forms.CheckBox checkBox29;
        private System.Windows.Forms.CheckBox checkBox30;
        private System.Windows.Forms.CheckBox checkBox31;
        private System.Windows.Forms.CheckBox checkBox32;
        private System.Windows.Forms.CheckBox checkBox33;
        private System.Windows.Forms.CheckBox checkBox34;
        private System.Windows.Forms.CheckBox checkBox35;
        private System.Windows.Forms.CheckBox checkBox36;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_BID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_PID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}

