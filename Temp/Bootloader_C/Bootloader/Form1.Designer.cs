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
            this.panel_Read = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_File_Name = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_HEX = new System.Windows.Forms.RadioButton();
            this.radioButton_BIN = new System.Windows.Forms.RadioButton();
            this.panel_Write = new System.Windows.Forms.Panel();
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
            this.panel_Main = new System.Windows.Forms.Panel();
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
            this.groupBox_Sectors_Erase.Location = new System.Drawing.Point(10, 30);
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
            this.button2.Location = new System.Drawing.Point(10, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 20);
            this.button2.TabIndex = 206;
            this.button2.Text = "Erase";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 10);
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
            this.groupBox_Sectors_Read.Location = new System.Drawing.Point(10, 30);
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
            this.panel_Erase.Controls.Add(this.button2);
            this.panel_Erase.Controls.Add(this.groupBox_Sectors_Erase);
            this.panel_Erase.Location = new System.Drawing.Point(280, 0);
            this.panel_Erase.Name = "panel_Erase";
            this.panel_Erase.Size = new System.Drawing.Size(110, 310);
            this.panel_Erase.TabIndex = 209;
            // 
            // panel_Read
            // 
            this.panel_Read.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Read.Controls.Add(this.groupBox3);
            this.panel_Read.Controls.Add(this.groupBox2);
            this.panel_Read.Controls.Add(this.button3);
            this.panel_Read.Controls.Add(this.groupBox_Sectors_Read);
            this.panel_Read.Location = new System.Drawing.Point(400, 0);
            this.panel_Read.Name = "panel_Read";
            this.panel_Read.Size = new System.Drawing.Size(240, 310);
            this.panel_Read.TabIndex = 210;
            this.panel_Read.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Read_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_File_Name);
            this.groupBox3.Location = new System.Drawing.Point(110, 80);
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
            this.groupBox2.Location = new System.Drawing.Point(110, 10);
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
            this.panel_Write.Controls.Add(this.button6);
            this.panel_Write.Controls.Add(this.checkBox_Jump_To_Application);
            this.panel_Write.Controls.Add(this.checkBox_Erase_Sectors);
            this.panel_Write.Controls.Add(this.groupBox_Start_Address);
            this.panel_Write.Controls.Add(this.groupBox_Download_From_File);
            this.panel_Write.Controls.Add(this.button_Write);
            this.panel_Write.Location = new System.Drawing.Point(0, 60);
            this.panel_Write.Name = "panel_Write";
            this.panel_Write.Size = new System.Drawing.Size(270, 200);
            this.panel_Write.TabIndex = 211;
            this.panel_Write.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Write_Paint);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(180, 10);
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
            this.checkBox_Jump_To_Application.Location = new System.Drawing.Point(10, 60);
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
            this.checkBox_Erase_Sectors.Location = new System.Drawing.Point(10, 40);
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
            this.groupBox_Start_Address.Location = new System.Drawing.Point(10, 130);
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
            this.groupBox_Download_From_File.Location = new System.Drawing.Point(10, 80);
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
            this.button_Write.Location = new System.Drawing.Point(10, 10);
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
            this.progressBar1.Location = new System.Drawing.Point(130, 330);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(530, 33);
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
            this.label_STATE.Location = new System.Drawing.Point(10, 330);
            this.label_STATE.Name = "label_STATE";
            this.label_STATE.Size = new System.Drawing.Size(640, 31);
            this.label_STATE.TabIndex = 212;
            this.label_STATE.Text = "DEVICE NOT CONNECTED";
            // 
            // panel_Connect
            // 
            this.panel_Connect.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_Connect.Controls.Add(this.comboBox_Com_Ports);
            this.panel_Connect.Controls.Add(this.button_Connect);
            this.panel_Connect.Location = new System.Drawing.Point(0, 0);
            this.panel_Connect.Name = "panel_Connect";
            this.panel_Connect.Size = new System.Drawing.Size(270, 50);
            this.panel_Connect.TabIndex = 221;
            // 
            // panel_Main
            // 
            this.panel_Main.Controls.Add(this.progressBar1);
            this.panel_Main.Controls.Add(this.label_STATE);
            this.panel_Main.Controls.Add(this.panel_Connect);
            this.panel_Main.Controls.Add(this.panel_Write);
            this.panel_Main.Controls.Add(this.panel_Read);
            this.panel_Main.Controls.Add(this.panel_Erase);
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(680, 380);
            this.panel_Main.TabIndex = 222;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 454);
            this.Controls.Add(this.panel_Main);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Sectors_Erase.ResumeLayout(false);
            this.groupBox_Sectors_Erase.PerformLayout();
            this.groupBox_Sectors_Read.ResumeLayout(false);
            this.groupBox_Sectors_Read.PerformLayout();
            this.panel_Erase.ResumeLayout(false);
            this.panel_Read.ResumeLayout(false);
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
            this.panel_Main.ResumeLayout(false);
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
    }
}

