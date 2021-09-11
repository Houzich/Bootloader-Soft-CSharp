#define DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using BootloaderInterface;
using System.IO;


namespace Bootloader
{
    public partial class Form1 : Form
    {
        BootloaderInterface.BootloaderClass Bootloader = new BootloaderInterface.BootloaderClass();
        bool Connect_Flag = false;
        bool Process_Flag = false;
        bool Com_Ports_Flag = false;
        int ProgressBar_Width = 0;
        string Curr_Com_Port = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            Check_COM_Ports();
            SET_Flag(ref Process_Flag, true);
            if (button_Connect.Text == "Connect")
            {
                serialPort.Close();

                serialPort.PortName = ((string)comboBox_Com_Ports.SelectedItem);

                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    Show_Message("CAN'T OPEN THE PORT " + serialPort.PortName);
                    Clear_All_Flag();
                    goto EXIT_CLEAR;
                }
                
                if (!Bootloader.Start_Bootloader_Mode(ref serialPort))
                {
                    Show_Message("ERROR: DEVICE NOT FOUND");
                    serialPort.Close();
                    Clear_All_Flag();
                    goto EXIT_CLEAR;
                }

                var cmd_get = new GetCommandScript(ref serialPort);
                if (!cmd_get.Command())
                {
                    Show_Message("ERROR: GET VERSION");
                    serialPort.Close();
                    Clear_All_Flag();
                    goto EXIT_CLEAR;
                }

                var cmd_get_id = new GetIDCommandScript(ref serialPort);
                if (!cmd_get_id.Command())
                {
                    Show_Message("ERROR: GET PID");
                    serialPort.Close();
                    Clear_All_Flag();
                    goto EXIT_CLEAR;
                }
                UInt32 address = (UInt32)0x1FFF77DE;
                byte[] bid = new byte[2];
                if (!Bootloader.Read_Data(ref serialPort, address, bid))
                {
                    Show_Message("ERROR: GET BID");
                    serialPort.Close();
                    Clear_All_Flag();
                    goto EXIT_CLEAR;
                }

                Curr_Com_Port = comboBox_Com_Ports.Text;
                Connect_Flag = true;
                textBox_PID.Text = cmd_get_id.PID[0].ToString("X2") + cmd_get_id.PID[1].ToString("X2");
                textBox_BID.Text = bid[0].ToString("X2").Insert(1, ".");
                textBox_Version.Text = cmd_get.Bootloader_Version[0].ToString("X2").Insert(1, ".");
                Console.WriteLine("CONNECT TO DEVICE OK");
            }
            else
            {
                Disconnect();
                goto EXIT_CLEAR;
            }

            EXIT:
            SET_Flag(ref Process_Flag, false);
            return;
            EXIT_CLEAR:
            textBox_PID.Text = "";
            textBox_BID.Text = "";
            textBox_Version.Text = "";
            SET_Flag(ref Process_Flag, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check_COM_Ports();
            SET_Flag(ref Process_Flag, true);
            int Number_Of_Sectors = 0;
            int[] Sector_Codes = new int[0];
            foreach (Control cbx in groupBox_Sectors_Erase.Controls)
                if (cbx is CheckBox)
                    if ((cbx as CheckBox).Checked)
                    {
                        Number_Of_Sectors++;
                        Sector_Codes = Sector_Codes.Concat(new int[] { Convert.ToInt32((cbx as CheckBox).Tag) }).ToArray();
                    }


            if (Number_Of_Sectors == 0) goto EXIT;

            ProgressBar_Start(ref progressBar1, 2);
            progressBar1.Value++;
            progressBar1.Value--;
            progressBar1.Value++;
            progressBar1.Refresh();

            if (!Bootloader.Erase_Sector(ref serialPort, Number_Of_Sectors, Sector_Codes))
            {
                Show_Message("ERROR ERASE FLASH");
                Clear_All_Flag();
                goto EXIT;
            }
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Value--;
            progressBar1.Value++;           
            progressBar1.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            Show_Message("ERASE FLASH OK");
            EXIT:
            ProgressBar_Start(ref progressBar1, 0);
            SET_Flag(ref Process_Flag, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number_of_sectors = 0;
            int[] sector_codes = new int[0];

            Check_COM_Ports();
            SET_Flag(ref Process_Flag, true);

            //File.WriteAllBytes(file_name, flash_data);
            //flash_data.Save(Application.StartupPath + textBox_File_Name.Text + ".bin");            

            foreach (Control cbx in groupBox_Sectors_Read.Controls)
                if (cbx is CheckBox)
                    if ((cbx as CheckBox).Checked)
                    {
                        number_of_sectors++;
                        sector_codes = sector_codes.Concat(new int[] { Convert.ToInt32((cbx as CheckBox).Tag) }).ToArray();
                    }
            Array.Sort(sector_codes);
            if (number_of_sectors == 0)
            {
                Show_Message("PLEASE SELECT A SECTOR!");
                goto EXIT;
            }

            byte[] flash_data = new byte[0];
            string[] flash_lines = new string[0];
            string file_name;

            if (radioButton_BIN.Checked)
            {
                file_name = textBox_File_Name.Text + ".bin";
                if (!Read_BIN(ref progressBar1, sector_codes, ref flash_data))
                {
                    Show_Message("ERROR: READ FIRMWARE");
                    goto EXIT_ERR;
                }
                File.WriteAllBytes(file_name, flash_data);
            }
            else
            {
                file_name = textBox_File_Name.Text + ".hex";
                if (!Read_HEX(ref progressBar1, sector_codes, ref flash_lines))
                {
                    Show_Message("ERROR: READ FIRMWARE");
                    goto EXIT_ERR;
                }
                File.WriteAllLines(file_name, flash_lines);
            }

            Show_Message("DATA SAVED IN FILE " + file_name);
            EXIT:
            SET_Flag(ref Process_Flag, false);
            return;
            EXIT_ERR:
            Clear_All_Flag();
            SET_Flag(ref Process_Flag, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file_name = textBox_File_Name_Write.Text;
            string file_extension = Path.GetExtension(file_name);
            UInt32 start_address = 0;

            Check_COM_Ports();
            SET_Flag(ref Process_Flag, true);
            if (file_extension == ".bin")
            {
                Bootloader.Get_Sector_Addresses(comboBox_Start_Address.SelectedIndex, out start_address, out UInt32 end_address);
                if(!Write_BIN(ref progressBar1, file_name, start_address, checkBox_Erase_Sectors.Checked))
                {
                    Show_Message("ERROR: WRITE FIRMWARE");
                    goto EXIT_ERR;
                }
                if (checkBox_Verify_After_Download.Checked)
                {
                    Console.WriteLine("START VERIFY FIRMWARE");
                    if (!Verify_BIN(ref progressBar1, file_name, start_address))
                    {
                        Show_Message("ERROR: VERIFY FIRMWARE");
                        goto EXIT_ERR;
                    }
                    Console.WriteLine("VERIFY FIRMWARE OK");
                }
            }
            else if (file_extension == ".hex")
            {
                start_address = Write_HEX(ref progressBar1, file_name, checkBox_Erase_Sectors.Checked);
                if (start_address == 0)
                {
                    Show_Message("ERROR: WRITE FIRMWARE");
                    goto EXIT_ERR;
                }
                if (checkBox_Verify_After_Download.Checked)
                {
                    Console.WriteLine("START VERIFY FIRMWARE");
                    if (!Verify_HEX(ref progressBar1, file_name))
                    {
                        Show_Message("ERROR: VERIFY FIRMWARE");
                        goto EXIT_ERR;
                    }
                    Console.WriteLine("VERIFY FIRMWARE OK");
                }
            }
            else
            {
                Show_Message("ERROR: INVALID FILENAME");
                goto EXIT;
            }


            if (checkBox_Jump_To_Application.Checked) {
                if (!Bootloader.Jump_To_Application(ref serialPort, start_address))
                {
                    Show_Message("ERROR: JUMP TO APPLICATION");
                    goto EXIT_ERR;
                }
                Disconnect();
            }

            
            Show_Message("WRITE FIRMWARE OK");
            EXIT:
            SET_Flag(ref Process_Flag, false);
            return;
            EXIT_ERR:
            Clear_All_Flag();
            SET_Flag(ref Process_Flag, false);
        }

        UInt32 Write_HEX(ref ProgressBar bar, string file_name, bool enable_erase)
        {
            UInt32 start_address = 0;
            string[] lines = File.ReadAllLines(file_name);
            bool[] sectors_erase = new bool[12];
            ProgressBar_Start(ref bar, lines.Length);
            HEX_Parse parse = new HEX_Parse();
            for (int i = 0; i < lines.Length; i++)
            {
                bar.Value = i;
                string ret = parse.Parse(lines[i]);
                switch (ret)
                {
                    case HEX_Record_Type.DATA:
                        if (start_address == 0) { start_address = parse.Address_Memory_Data_Located; }
                        int? curr_sector = Bootloader.Get_Sector(parse.Address_Memory_Data_Located);
                        if (curr_sector == null)
                        {
                            Show_Message("ERROR ADDRESS WRITE FLASH");
                            goto EXIT_ERR;
                        }
                        if ((!sectors_erase[(int)curr_sector]) && (enable_erase))
                        {
                            int[] sector_codes = { (int)curr_sector };
                            //ProgressBar barnull = null;
                            if (!Bootloader.Erase_Sector(ref serialPort, 1, sector_codes))
                            {
                                Show_Message("ERROR ERASE FLASH");
                                goto EXIT_ERR;
                            }
                            sectors_erase[(int)curr_sector] = true;
                        }
                        if (!Bootloader.Write_Data(ref serialPort, parse.Address_Memory_Data_Located, parse.Data))
                        {
                            Show_Message("ERROR WRITE FLASH");
                            goto EXIT_ERR;
                        }
                        bar.Value--;
                        bar.Value++;
                        bar.Refresh();
                        break;
                    case HEX_Record_Type.END_OF_FILE:
                        goto EXIT;

                    case HEX_Record_Type.ERROR:
                        Show_Message("ERROR PARSE HEX");
                        goto EXIT_ERR;
                }
            }

            EXIT:
            bar.Value = bar.Maximum;
            bar.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            ProgressBar_Start(ref bar, 0);
            return start_address;

            EXIT_ERR:
            ProgressBar_Start(ref bar, 0);
            return 0;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/        
        bool Verify_HEX(ref ProgressBar bar, string file_name)
        {
            string[] lines = File.ReadAllLines(file_name);
            ProgressBar_Start(ref bar, lines.Length);
            HEX_Parse parse = new HEX_Parse();
            for (int i = 0; i < lines.Length; i++)
            {
                
                string ret = parse.Parse(lines[i]);
                switch (ret)
                {
                    case HEX_Record_Type.DATA:
                        byte[] data_verify = new byte[parse.Data.Length];
                        if (!Bootloader.Read_Data(ref serialPort, parse.Address_Memory_Data_Located, data_verify))
                        {
                            Console.WriteLine("ERROR WRITE FLASH");
                            goto EXIT_ERR;
                        }
                        int x = 0;
                        int curr_data_size = parse.Data.Length;
                        while ((x < curr_data_size) && (parse.Data[x] == data_verify[x])) x++;
                        bool result = (x == curr_data_size);
                        if (!result)
                        {
                            Console.WriteLine("ERROR VERIFY FLASH");
                            goto EXIT_ERR;
                        }
                        bar.Value = i;
                        bar.Refresh();
                        break;
                    case HEX_Record_Type.END_OF_FILE:
                        goto EXIT;

                    case HEX_Record_Type.ERROR:
                        Console.WriteLine("ERROR PARSE HEX");
                        goto EXIT_ERR;
                }
            }

            EXIT:
            bar.Value = bar.Maximum;
            bar.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            ProgressBar_Start(ref bar, 0);
            return true;

            EXIT_ERR:
            ProgressBar_Start(ref bar, 0);
            return false;
        }



        bool Write_BIN(ref ProgressBar bar, string file_name, UInt32 start_address, bool enable_erase)
        {
            byte[] flash_data = File.ReadAllBytes(file_name);

            UInt32 start_address_application = start_address;
            UInt32 end_address_application = start_address + (UInt32)flash_data.Length;

            if (end_address_application > Sector_Address.ADDR_FLASH_END)
            {
                Console.WriteLine("ERROR END ADDRESS!!!");
                goto EXIT_ERR;
            }

            int start_sector_application = (int)Bootloader.Get_Sector(start_address_application);
            int end_sector_application = (int)Bootloader.Get_Sector(end_address_application);
            int curr_sector = start_sector_application;
            int curr_application_size = flash_data.Length;
            int curr_byte_index = 0;
            ProgressBar_Start(ref bar, flash_data.Length / 256);
            while (curr_application_size > 0)
            {
                if (!Bootloader.Get_Sector_Addresses(comboBox_Start_Address.SelectedIndex, out start_address, out UInt32 end_address))
                {
                    Console.WriteLine("ERROR START ADDRESS!!!");
                    goto EXIT_ERR;
                }
                int curr_sector_size = (int)(end_address - start_address) + 1;
                int curr_data_size = curr_sector_size;
                if (curr_application_size < curr_sector_size)
                    curr_data_size = curr_application_size;
                curr_application_size -= curr_data_size;

                byte[] data = new byte[curr_data_size];
                Array.Copy(flash_data, curr_byte_index, data, 0, curr_data_size);
                curr_byte_index += curr_data_size;

                if (enable_erase)
                {
                    if (!Bootloader.Erase_Sector(ref serialPort, 1, new int[] { curr_sector }))
                    {
                        Console.WriteLine("ERROR ERASE FLASH");
                        goto EXIT_ERR;
                    }
                }

                if (!Bootloader.Write_Sector(ref serialPort, curr_sector, data, ref bar))
                {
                    Console.WriteLine("ERROR WRITE FLASH");
                    goto EXIT_ERR;
                }
                curr_sector++;
                bar.Value--;
                bar.Value++;
                bar.Refresh();
            }

            bar.Value = bar.Maximum;
            bar.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            ProgressBar_Start(ref bar, 0);
            return true;
            EXIT_ERR:
            ProgressBar_Start(ref bar, 0);
            return false;
        }

        bool Verify_BIN(ref ProgressBar bar, string file_name, UInt32 start_address)
        {
            byte[] file_data = File.ReadAllBytes(file_name);

            UInt32 start_address_application = start_address;
            UInt32 end_address_application = start_address + (UInt32)file_data.Length;

            int curr_application_size = file_data.Length;
            int curr_byte_index = 0;
            ProgressBar_Start(ref bar, file_data.Length / 256);
            while (curr_application_size > 0)
            {
                int curr_data_size = 256;
                if (curr_application_size < 256)
                    curr_data_size = curr_application_size;
                curr_application_size -= curr_data_size;

                byte[] read_data = new byte[curr_data_size];
                byte[] verify_data = new byte[curr_data_size];
                Array.Copy(file_data, curr_byte_index, verify_data, 0, curr_data_size);
                //

                if (!Bootloader.Read_Data(ref serialPort, (UInt32)(start_address + curr_byte_index), read_data))
                {
                    Console.WriteLine("ERROR READ FLASH");
                    goto EXIT_ERR;
                }

                int i = 0;
                while ((i < curr_data_size) && (read_data[i] == verify_data[i])) i++;
                bool result = (i == curr_data_size);
                if(!result)
                {
                    Console.WriteLine("ERROR VERIFY FLASH BYTE {0}", (curr_byte_index+i));
                    goto EXIT_ERR;
                }

                curr_byte_index += curr_data_size;
                bar.Increment(1);
                bar.Value--;
                bar.Value++;
                bar.Refresh();
            }
            bar.Value = bar.Maximum;
            bar.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            ProgressBar_Start(ref bar, 0);
            return true;
            EXIT_ERR:
            ProgressBar_Start(ref bar, 0);
            return false;
        }

        bool Read_HEX(ref ProgressBar bar, int[] sector_codes, ref string[] lines)
        {
            Array.Sort(sector_codes);
            string[] lines_start = { ":020000040800F2", ":020000020000FC" };

            ProgressBar_Start(ref bar, Bootloader.Get_Sectors_Size(sector_codes) / 256);
            int number_of_sectors = sector_codes.Length;
            for (int sector = 0; sector < number_of_sectors; sector++)
            {
                lines = lines.Concat(lines_start).ToArray();
                byte[] data = new byte[0];
                if (!Bootloader.Read_Sector(ref serialPort, sector_codes[sector], ref data, ref bar))
                {
                    Console.WriteLine("ERROR READ SECTOR!!!");
                    goto EXIT;
                }

                Bootloader.Get_Sector_Addresses(sector_codes[sector], out UInt32 start_address, out UInt32 end_address);
                UInt32 curr_address = start_address;
                int curr_byte = 0;
                while (curr_address < end_address)
                {
                    string st = ":20" + ((UInt16)curr_address).ToString("X4") + HEX_Record_Type.DATA;
                    for (int i = 0; i < 32; i++) st += data[curr_byte + i].ToString("X2");
                    curr_byte += 32;
                    curr_address += 32;

                    byte сhecksum = 0;
                    for (int i = 1; i < st.Length; i += 2)
                        сhecksum += Convert.ToByte(st.Substring(i, 2), 16);
                    сhecksum = (byte)(~сhecksum + 0x01);

                    st += сhecksum.ToString("X2");
                    lines = lines.Concat(new string[] { st }).ToArray();
                }
            }

            bar.Value = bar.Maximum;
            bar.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            ProgressBar_Start(ref bar, 0);
            return true;
            EXIT:
            ProgressBar_Start(ref bar, 0);
            return false;
        }

        bool Read_BIN(ref ProgressBar bar, int[] sector_codes, ref byte[] flash_data)
        {
            int sectors_size = Bootloader.Get_Sectors_Size(sector_codes);
#if DEBUG
            Console.WriteLine("SECTORS SIZE: {0}", sectors_size);
#endif
            ProgressBar_Start(ref bar, sectors_size / 256);
            int number_of_sectors = sector_codes.Length;
            int curr_sector = sector_codes[0] - 1;
            for (int sector = 0; sector < number_of_sectors; sector++)
            {

                while (sector_codes[sector] != curr_sector + 1)
                {
                    Bootloader.Get_Sector_Addresses(sector_codes[sector], out UInt32 start_address, out UInt32 end_address);
                    byte[] data_null = new byte[(end_address - start_address) + 1];
                    for (int i = 0; i < data_null.Length; i++) { data_null[i] = (byte)0xFF; }
                    flash_data = flash_data.Concat(data_null).ToArray();
                    curr_sector++;
                }
                byte[] data = new byte[0];
                if (!Bootloader.Read_Sector(ref serialPort, sector_codes[sector], ref data, ref bar))
                {
                    Console.WriteLine("ERROR READ SECTOR {0}", sector_codes[sector]);
                    goto EXIT;
                }

                flash_data = flash_data.Concat(data).ToArray();
                curr_sector = sector_codes[sector];
                
                //Application.DoEvents();
            }

            bar.Value = bar.Maximum;
            bar.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
#if DEBUG
            Console.WriteLine("FLASH DATA SIZE: {0}", flash_data.Length);
#endif
            ProgressBar_Start(ref bar, 0);
            return true;
            EXIT:
            ProgressBar_Start(ref bar, 0);
            return false;
        }


        void ProgressBar_Start(ref ProgressBar bar, int end)
        {
            bar.Minimum = 0;
            bar.Maximum = end;
            //if (end > 0 && end <= bar.Width)
            //{
            //    bar.Width = (ProgressBar_Width / end) * end;
            //}
            //else
            //{
            //    bar.Width = ProgressBar_Width;
            //}
            bar.Value = 0;
            bar.Update();
            bar.Refresh();
            var t = Task.Run(async delegate { await Task.Delay(1000); return 42; });
            t.Wait();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            textBox_File_Name_Write.Text = filename;
            Check_Form_State();
        }

        void Check_Form_State()
        {            
            this.SuspendLayout();
            if (Process_Flag)
            {
                panel_Write.Enabled = false;
                panel_Erase.Enabled = false;
                panel_Read.Enabled = false;
                panel_Connect.Enabled = false;
                panel_Write_Protect.Enabled = false;
                progressBar1.Visible = true;
                label_STATE.Text = "WAIT...";
                label_STATE.ForeColor = Color.Red;
                goto EXIT;
            }
            else
            {
                panel_Connect.Enabled = true;

                progressBar1.Visible = false;

                if (Connect_Flag)
                {
                    button_Connect.Text = "Disconnect";
                    button_Connect.BackColor = Color.Red;
                    label_STATE.Text = "DEVICE CONNECTED";
                    label_STATE.ForeColor = Color.Green;
                    comboBox_Com_Ports.Enabled = false;
                    panel_Write.Enabled = true;
                    panel_Erase.Enabled = true;
                    panel_Read.Enabled = true;
                    panel_Write_Protect.Enabled = true;
                }
                else
                {
                    button_Connect.Text = "Connect";
                    button_Connect.BackColor = Color.Green;
                    label_STATE.Text = "DEVICE NOT CONNECTED";
                    label_STATE.ForeColor = Color.Red;
                    comboBox_Com_Ports.Enabled = true;
                    panel_Write.Enabled = false;
                    panel_Erase.Enabled = false;
                    panel_Read.Enabled = false;
                    panel_Write_Protect.Enabled = false;
                    groupBox_Sectors_Write_Protect.Enabled = false;
                    button_Write_Protect.Enabled = false;
                    textBox_PID.Text = "";
                    textBox_BID.Text = "";
                    textBox_Version.Text = "";
                }

                if (!Com_Ports_Flag)
                {
                    Show_Message("ERROR: NO AVAILABLE SERIAL PORTS");
                    button_Connect.BackColor = Color.Gray;
                    button_Connect.Enabled = false;
                }
                else
                {
                    button_Connect.Enabled = true;
                }
            }

            string st = "";
            //Path.GetFileNameWithoutExtension(textBox_File_Name_Write.Text);
            st = Path.GetExtension(textBox_File_Name_Write.Text);
            if ((st == ".bin") || (st == ".hex"))
            {
                if (st == ".bin")
                {
                    groupBox_Start_Address.Enabled = true;
                    if(comboBox_Start_Address.SelectedIndex == -1) comboBox_Start_Address.SelectedIndex = 0;
                }
                else
                {
                    groupBox_Start_Address.Enabled = false;
                    comboBox_Start_Address.SelectedIndex = -1;
                }

                groupBox_Download_From_File.Enabled = true;
                button_Write.Enabled = true;
                foreach (Control chbx in panel_Write.Controls)
                    if (chbx is CheckBox)
                        chbx.Enabled = true;
            }
            else
            {
                groupBox_Start_Address.Enabled = false;
                comboBox_Start_Address.SelectedIndex = -1;
                groupBox_Download_From_File.Enabled = false;
                button_Write.Enabled = false;
                foreach (Control chbx in panel_Write.Controls)
                    if (chbx is CheckBox)
                        chbx.Enabled = false;
            }

            EXIT:
            this.ResumeLayout();
            panel_Main.Refresh();
        }



        void Check_COM_Ports()
        {
            Com_Ports_Flag = false;
            string curr_com_port = comboBox_Com_Ports.Text;
            comboBox_Com_Ports.Items.Clear();
            serialPort.Close();

            foreach (string portName in SerialPort.GetPortNames())
            {
                try
                {
                    serialPort.PortName = portName;
                    serialPort.Open();
                    serialPort.Close();
                    comboBox_Com_Ports.Items.Add(portName);
                }
                catch (Exception ex)
                {
                }
            }
            if (comboBox_Com_Ports.Items.Count > 0)
            {
                if ((Curr_Com_Port != curr_com_port) || (curr_com_port == ""))
                {
                    comboBox_Com_Ports.SelectedIndex = 0;
                }
                else
                {
                    comboBox_Com_Ports.SelectedIndex = comboBox_Com_Ports.Items.IndexOf(Curr_Com_Port);
                    serialPort.PortName = Curr_Com_Port;
                    serialPort.Open();
                }
                Com_Ports_Flag = true;
            }
            else
            {
                comboBox_Com_Ports.Text = "";
                Clear_All_Flag();
            }
        }

        void Show_Message(string message)
        {
            MessageBox.Show(message);
            Console.WriteLine(message);
        }
        void Display_Message(string message)
        {
            progressBar1.Visible = false;
            label_STATE.Text = message;
            progressBar1.Refresh();
            label_STATE.Refresh();
        }

        void SET_Flag(ref bool flag, bool set)
        {
            flag = set;
            Check_Form_State();
        }

        void Clear_All_Flag()
        {
            Process_Flag = false;
            Connect_Flag = false;
        }

        void Disconnect()
        {
            serialPort.Close();
            Connect_Flag = false;
            Console.WriteLine("DISCONNECT OK");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Check_COM_Ports();
            Check_Form_State();
            ProgressBar_Width = progressBar1.Width;
        }

        private void panel_Write_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Connect_EnabledChanged(object sender, EventArgs e)
        {
            if (!button_Connect.Enabled) button_Connect.BackColor = Color.Gray;
        }

        private void panel_Read_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Check_COM_Ports();
            SET_Flag(ref Process_Flag, true);
            bool[] sector_wrp = new bool[12];
            ProgressBar_Start(ref progressBar1, 1);

            UInt32 address = (UInt32)User_Const.OPTCR_BYTE2_ADDRESS;
            byte[] optcr_byte34 = new byte[2];
            if (!Bootloader.Read_Data(ref serialPort, address, optcr_byte34))
            {
                Show_Message("ERROR: READ FLASH_OPTCR REGISTER");
                serialPort.Close();
                Clear_All_Flag();
                goto EXIT_CLEAR;
            }
           int optcr = BitConverter.ToUInt16(optcr_byte34, 0);
            for(int i=0;i<12;i++)
                if ((optcr & (1 << i)) == 0) sector_wrp[i] = true;
                else sector_wrp[i] = false;

            for (int i = 1; i < 12; i++)
                foreach (Control cbx in groupBox_Sectors_Write_Protect.Controls)
                    if ((cbx is CheckBox) && (Convert.ToInt32((cbx as CheckBox).Tag) == i))
                        (cbx as CheckBox).Checked = sector_wrp[i];


            EXIT:
            ProgressBar_Start(ref progressBar1, 0);
            SET_Flag(ref Process_Flag, false);
            groupBox_Sectors_Write_Protect.Enabled = true;
            button_Write_Protect.Enabled = true;
            return;
            EXIT_CLEAR:
            foreach (Control cbx in groupBox_Sectors_Write_Protect.Controls)
                if (cbx is CheckBox) (cbx as CheckBox).Checked = false;
            ProgressBar_Start(ref progressBar1, 0);
            SET_Flag(ref Process_Flag, false);
        }

        private void button_Write_Protect_Click(object sender, EventArgs e)
        {
            Check_COM_Ports();
            SET_Flag(ref Process_Flag, true);

            int Number_Of_Sectors = 0;
            int[] Sector_Codes = new int[0];
            foreach (Control cbx in groupBox_Sectors_Write_Protect.Controls)
                if (cbx is CheckBox)
                    if ((cbx as CheckBox).Checked)
                    {
                        Number_Of_Sectors++;
                        Sector_Codes = Sector_Codes.Concat(new int[] { Convert.ToInt32((cbx as CheckBox).Tag) }).ToArray();
                    }

            ProgressBar_Start(ref progressBar1, 1);

            if (!Bootloader.Set_Write_Protect_Sectors(ref serialPort, Number_Of_Sectors, Sector_Codes, ref progressBar1))
            {
                Show_Message("ERROR SET WRITE PROTECTION FLASH");
                Clear_All_Flag();
                goto EXIT_CLEAR;
            }
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Value--;
            progressBar1.Value++;
            progressBar1.Refresh();
            var t_end = Task.Run(async delegate { await Task.Delay(1000); return 42; }); t_end.Wait();
            Show_Message("SET WRITE PROTECTION FLASH OK");
            EXIT:
            ProgressBar_Start(ref progressBar1, 0);
            SET_Flag(ref Process_Flag, false);
            return;
            EXIT_CLEAR:
            foreach (Control cbx in groupBox_Sectors_Write_Protect.Controls)
                if (cbx is CheckBox) (cbx as CheckBox).Checked = false;
            ProgressBar_Start(ref progressBar1, 0);
            SET_Flag(ref Process_Flag, false);
        }
    }
}
