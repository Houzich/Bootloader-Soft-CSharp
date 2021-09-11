using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace BootloaderInterface
{


    public class HEX_Record_Type
    {
        public const string DATA = "00";
        public const string END_OF_FILE = "01";
        public const string EXTENDED_SEGMENT_ADDRESS = "02";
        public const string EXTENDED_LINEAR_ADDRESS = "04";
        public const string START_LINEAR_ADDRESS = "05";
        public const string ERROR = "ER";
    }

    public enum HEX_Parse_State
    {
        READY = 0,
        DATA,
        END_OF_FILE,
        EXTENDED_SEGMENT_ADDRESS,
        EXTENDED_LINEAR_ADDRESS,
        START_LINEAR_ADDRESS,
        ERROR,
    }
    public enum HEX_Parse_Error
    {
        OK = 0,
        ERROR_CHECKSUM,
        ERROR_RECORD_TYPE,
    }
    public class HEX_Parse
    {
        public HEX_Parse_Error Error { get; set; } = HEX_Parse_Error.OK;
        public HEX_Parse_State State { get; set; } = HEX_Parse_State.READY;
        public byte Number_Of_Data_Bytes { get; set; } = 0;
        public string Record_Type { get; set; } = "";
        public byte Checksum { get; set; } = 0;
        public UInt16 Address_Data_Located { get; set; } = 0;
        public UInt16 Address_Extended_Segment { get; set; } = 0;
        public UInt16 Address_Extended_Linear { get; set; } = 0;
        public UInt32 Address_Start_Application { get; set; } = 0;
        public UInt32 Address_Memory_Data_Located { get; set; } = 0;
        public byte[] Data { get; set; } = null;

        void Set_Error(HEX_Parse_Error err)
        {
            State = HEX_Parse_State.ERROR;
            Error = err;
        }
            public string Parse(string line)
        {
            string st = "";
            if (line[0] != ':') return HEX_Record_Type.ERROR;
            st = line.Substring(1, 2);
            Number_Of_Data_Bytes = Convert.ToByte(st, 16);
            st = line.Substring(3, 4);
            Address_Data_Located = Convert.ToUInt16(st, 16);
            st = line.Substring(7, 2);
            Record_Type = st;
            Data = new byte[Number_Of_Data_Bytes];
            int position = 9;
            switch (Record_Type)
            {
                case HEX_Record_Type.DATA:
                    for (int i = 0; i < Number_Of_Data_Bytes; i++)
                    {
                        st = line.Substring(position, 2);
                        position += 2;
                        Data[i] = Convert.ToByte(st, 16);
                    }
                    if (Address_Extended_Segment == 0) { Address_Memory_Data_Located = (UInt32)Address_Extended_Linear << 16 | (UInt32)Address_Data_Located; }
                    else { Address_Memory_Data_Located = (UInt32)(((UInt32)Address_Extended_Segment << 1) + (UInt32)Address_Data_Located); }
                    State = HEX_Parse_State.DATA;
                    break;

                case HEX_Record_Type.END_OF_FILE:
                    State = HEX_Parse_State.END_OF_FILE;
                    break;

                case HEX_Record_Type.EXTENDED_SEGMENT_ADDRESS:
                    st = line.Substring(position, 4);
                    position += 4;
                    Address_Extended_Segment = Convert.ToUInt16(st, 16);
                    State = HEX_Parse_State.EXTENDED_SEGMENT_ADDRESS;
                    break;

                case HEX_Record_Type.EXTENDED_LINEAR_ADDRESS:
                    st = line.Substring(position, 4);
                    position += 4;
                    Address_Extended_Linear = Convert.ToUInt16(st, 16);
                    Address_Extended_Segment = 0;
                    State = HEX_Parse_State.EXTENDED_LINEAR_ADDRESS;
                    break;

                case HEX_Record_Type.START_LINEAR_ADDRESS:
                    st = line.Substring(position, 8);
                    position += 8;
                    Address_Start_Application = Convert.ToUInt32(st, 16);
                    State = HEX_Parse_State.START_LINEAR_ADDRESS;
                    break;

                default:
                    Set_Error(HEX_Parse_Error.ERROR_RECORD_TYPE);
                    return HEX_Record_Type.ERROR;
            }

            st = line.Substring(position, 2);
            Checksum = Convert.ToByte(st, 16);

            byte сhecksum = 0;
            for (int i = 1; i < position; i+=2)
                сhecksum += Convert.ToByte(line.Substring(i, 2), 16);
            сhecksum = (byte)(~сhecksum + 0x01);

            if (сhecksum!= Checksum)
            {
                Set_Error(HEX_Parse_Error.ERROR_CHECKSUM);
                return HEX_Record_Type.ERROR;
            }

            return Record_Type;
        }

    }










    public class Command_ID
    {
        public const ushort GET = 0x00FF;
        public const ushort GET_VERSION = 0x00FE;
        public const ushort GET_ID = 0x02FD;
        public const ushort READ_MEMORY = 0x11EE;
        public const ushort GO = 0x21DE;
        public const ushort WRITE_MEMORY = 0x31CE;
        public const ushort ERASE_MEMORY = 0x44BB;
        public const ushort EXTENDED_ERASE_MEMORY = 0x44BB;
        public const ushort WRITE_PROTECT = 0x639C;
        public const ushort WRITE_UNPROTECT = 0x738C;
        public const ushort READOUT_PROTECT = 0x827D;
        public const ushort READOUT_UNPROTECT = 0x926D;

        public ushort htons(ushort id)
        {
            return (ushort)(((id & 0x00FF) << 8) | ((id & 0xFF00) >> 8));
        }
    };

    public class Command_Byte
    {
        public const byte GET = 0x00;
        public const byte GET_VERSION = 0x01;
        public const byte GET_ID = 0x02;
        public const byte READ_MEMORY = 0x11;
        public const byte GO = 0x21;
        public const byte WRITE_MEMORY = 0x31;
        public const byte ERASE_MEMORY = 0x43;
        public const byte EXTENDED_ERASE_MEMORY = 0x44;
        public const byte WRITE_PROTECT = 0x63;
        public const byte WRITE_UNPROTECT = 0x73;
        public const byte READOUT_PROTECT = 0x82;
        public const byte READOUT_UNPROTECT = 0x92;
        public const byte XOR = 0x00;
        public const byte ACK = 0x79;
        public const byte NACK = 0x1F;
        public const byte START = 0x7F;
    };

    public class Sector_Address
    {
        /* Base address of the Flash sectors Bank 1 */
        public const UInt32 ADDR_FLASH_SECTOR_0 = 0x08000000;  /* Base @ of Sector 0, 16 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_1 = 0x08004000;  /* Base @ of Sector 1, 16 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_2 = 0x08008000;  /* Base @ of Sector 2, 16 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_3 = 0x0800C000;  /* Base @ of Sector 3, 16 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_4 = 0x08010000;  /* Base @ of Sector 4, 64 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_5 = 0x08020000;  /* Base @ of Sector 5, 128 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_6 = 0x08040000;  /* Base @ of Sector 6, 128 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_7 = 0x08060000;  /* Base @ of Sector 7, 128 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_8 = 0x08080000;  /* Base @ of Sector 8, 128 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_9 = 0x080A0000;  /* Base @ of Sector 9, 128 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_10 = 0x080C0000; /* Base @ of Sector 10, 128 Kbytes */
        public const UInt32 ADDR_FLASH_SECTOR_11 = 0x080E0000; /* Base @ of Sector 11, 128 Kbytes */
        public const UInt32 ADDR_FLASH_END = 0x080FFFFF;
    };

    public class Sector_Number
    {
        public const UInt16 FLASH_SECTOR_0 = 0;  /*!< Sector Number 0   */
        public const UInt16 FLASH_SECTOR_1 = 1;  /*!< Sector Number 1   */
        public const UInt16 FLASH_SECTOR_2 = 2;  /*!< Sector Number 2   */
        public const UInt16 FLASH_SECTOR_3 = 3;  /*!< Sector Number 3   */
        public const UInt16 FLASH_SECTOR_4 = 4;  /*!< Sector Number 4   */
        public const UInt16 FLASH_SECTOR_5 = 5;  /*!< Sector Number 5   */
        public const UInt16 FLASH_SECTOR_6 = 6;  /*!< Sector Number 6   */
        public const UInt16 FLASH_SECTOR_7 = 7;  /*!< Sector Number 7   */
        public const UInt16 FLASH_SECTOR_8 = 8;  /*!< Sector Number 8   */
        public const UInt16 FLASH_SECTOR_9 = 9;  /*!< Sector Number 9   */
        public const UInt16 FLASH_SECTOR_10 = 10; /*!< Sector Number 10  */
        public const UInt16 FLASH_SECTOR_11 = 11; /*!< Sector Number 11  */
    };

    public class User_Const
    {
        /* Base address of the Flash sectors Bank 1 */
        public const UInt16 FLASH_BOOTLOADER_SECTOR = Sector_Number.FLASH_SECTOR_0;  /* Base @ of Sector 0, 16 Kbytes */
        public const UInt32 FLASH_BOOTLOADER_SECTOR_ADDR = Sector_Address.ADDR_FLASH_SECTOR_0;  /* Base @ of Sector 1, 16 Kbytes */
        public const UInt16 FLASH_APPLICATION_SECTOR = Sector_Number.FLASH_SECTOR_1;  /* Base @ of Sector 2, 16 Kbytes */
        public const UInt32 FLASH_APPLICATION_SECTOR_ADDR = Sector_Address.ADDR_FLASH_SECTOR_1;  /* Base @ of Sector 3, 16 Kbytes */
        public const UInt32 FLASH_APPLICATION_END_ADDR = 0x08010000;  /* Base @ of Sector 4, 64 Kbytes */
        public const UInt32 OPTIONS_BYTES_BASE = 0x1FFFC000;  /* Base @ of Sector 5, 128 Kbytes */
        public const UInt32 OPTIONS_BYTES_END = 0x1FFFC00F;  /* Base @ of Sector 6, 128 Kbytes */
    };



    public class BOOT_Packet
    {
        public byte?[] Buffer { get; set; } = null;
        public int? Count { get; set; } = null;
        public BOOT_Packet(byte?[] buffer, int? count)
        {
            Buffer = buffer;
            Count = count;
        }
    }

    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class GetCommandScript
    {
        public byte[] ID { get; set; } = null;
        public byte[] Data { get; set; } = new byte[1];
        public byte[] Number_Of_Bytes { get; set; } = new byte[1];
        public byte[] Bootloader_Version { get; set; } = new byte[1];
        public byte[] Supported_Command_Codes { get; set; } = null;
        public SerialPort Port;
        public GetCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.GET));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, Number_Of_Bytes, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, Bootloader_Version, 1)) != true) return false;
            Supported_Command_Codes = new byte[(int)Number_Of_Bytes[0]];
            if ((ret = BootloaderClass.Receive_Data(ref Port, Supported_Command_Codes, (int)Number_Of_Bytes[0])) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class GetVersionCommandScript
    {
        public byte[] ID { get; set; } = null;
        public byte[] Data { get; set; } = new byte[1];
        public byte[] Bootloader_Version { get; set; } = new byte[1];
        public byte[] Option_Byte_1 { get; set; } = new byte[1];
        public byte[] Option_Byte_2 { get; set; } = new byte[1];
        public SerialPort Port;
        public GetVersionCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.GET_VERSION));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, Bootloader_Version, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, Option_Byte_1, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, Option_Byte_2, 1)) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class GetIDCommandScript
    {
        public byte[] ID { get; set; } = null;
        public byte[] Data { get; set; } = new byte[1];
        public byte[] Number_Of_Bytes { get; set; } = new byte[1];
        public byte[] PID { get; set; } = new byte[2];
        public SerialPort Port;
        public GetIDCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.GET_ID));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, Number_Of_Bytes, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_Data(ref Port, PID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK(ref Port, Data, 1)) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class ReadoutUnprotectCommandScript
    {
        public byte[] ID { get; set; } = null;
        public byte[] Data { get; set; } = new byte[1];
        public SerialPort Port;
        public ReadoutUnprotectCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.READOUT_UNPROTECT));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class ReadoutProtectCommandScript
    {
        public byte[] ID { get; set; } = null;
        public byte[] Data { get; set; } = new byte[1];
        public SerialPort Port;
        public ReadoutProtectCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.READOUT_PROTECT));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class WriteUnprotectCommandScript
    {
        public byte[] ID { get; set; } = null;
        public byte[] Data { get; set; } = new byte[1];
        public SerialPort Port;
        public WriteUnprotectCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.WRITE_UNPROTECT));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class WriteProtectCommandScript
    {
        public byte[] ID { get; set; } = null;
        public SerialPort Port;
        public byte[] Number_Of_Sectors { get; set; } = new byte[1];
        public byte[] Sector_Codes { get; set; }
        public byte[] Checksum { get; set; } = new byte[1];
        public byte[] Data { get; set; } = new byte[1];
        public WriteProtectCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.WRITE_PROTECT));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            if ((ret = BootloaderClass.Send_Data(ref Port, Number_Of_Sectors, 1)) != true) return false;
            if ((ret = BootloaderClass.Send_Data(ref Port, Sector_Codes, Number_Of_Sectors[0])) != true) return false;
            Checksum[0] = 0;
            foreach (byte x in Sector_Codes)
            {
                Checksum[0] ^= x;
            }
            Checksum[0] ^= Number_Of_Sectors[0];
            if ((ret = BootloaderClass.Send_Data(ref Port, Checksum, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class EraseMemoryCommandScript
    {
        public byte[] ID { get; set; } = null;
        public SerialPort Port;
        public byte[] Special_Erase { get; set; } = null;
        public byte[] Sector_Codes { get; set; } = null;
        public byte Checksum { get; set; } = 0;
        public byte[] Data { get; set; } = new byte[1];
        public EraseMemoryCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.ERASE_MEMORY));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true)
            {
                Console.WriteLine("ERROR ERASE MEMORY| NOT RECEIVE ACK AFTER SEND ID. BYTE: 0x" + Data[0].ToString("X2"));
                return false;
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR ERASE MEMORY| NOT RECEIVE ACK AFTER SEND ID. BYTE: 0x" + Data[0].ToString("X2"));
                return false;
            }

            Port.ReadTimeout = 20000;

            if ((BitConverter.ToUInt16(Special_Erase,0)==(ushort)0xFFFF) ||
                (BitConverter.ToUInt16(Special_Erase, 0) == (ushort)0xFFFE) ||
                (BitConverter.ToUInt16(Special_Erase, 0) == (ushort)0xFFFD))
            {
                Console.WriteLine("NOT SUPPORTED!!!!!!!");
                goto EXIT_ERR;
            }
            else
            {
                if ((ret = BootloaderClass.Send_Data(ref Port, Special_Erase, 2)) != true)
                {
                    Console.WriteLine("ERROR ERASE MEMORY| SEND NUM SECTORS: {0}", Special_Erase);
                    goto EXIT_ERR;
                }
                if ((ret = BootloaderClass.Send_Data(ref Port, Sector_Codes, Sector_Codes.Length)) != true)
                {
                    Console.Write("ERROR ERASE MEMORY| SEND SECTOR CODES: ");
                    for (int i = 0; i < Sector_Codes.Length; i++) Console.Write(Sector_Codes[i].ToString() + " ");
                    Console.WriteLine("");
                    goto EXIT_ERR;
                }
                Checksum = 0;
                foreach (byte x in Sector_Codes) Checksum ^= x;
                foreach (byte x in Special_Erase) Checksum ^= x;
                Data[0] = Checksum;
                if ((ret = BootloaderClass.Send_Data(ref Port, Data, 1)) != true)
                {
                    Console.WriteLine("ERROR ERASE MEMORY| SEND CHECKSUM: 0x{0}", Data[0].ToString("X2"));
                    goto EXIT_ERR;
                }
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR ERASE MEMORY| NOT RECEIVE ACK AFTER SEND CHECKSUM| BYTE: 0x{0}", Data[0].ToString("X2"));
                goto EXIT_ERR;
            }

            return true;
            EXIT_ERR:
            Port.ReadTimeout = 5000;
            return false;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class WriteMemoryCommandScript
    {
        public byte[] ID { get; set; } = null;
        public SerialPort Port;
        public UInt32 Start_Address { get; set; } = 0;
        public byte[] Checksum_Address { get; set; } = new byte[1];
        public byte[] Data { get; set; } = null;
        public byte[] Checksum_Data { get; set; } = new byte[1];
        public WriteMemoryCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.WRITE_MEMORY));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| SEND ID");
                return false;
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| NOT RECEIVE ACK AFTER SEND ID. BYTE: 0x" + Data[0].ToString("X2"));
                return false;
            }
            byte[] start_address = new byte[4];
            start_address = BitConverter.GetBytes(BootloaderClass.HTONL(Start_Address));
            //Console.WriteLine("Send Start Address: 0x" + Start_Address.ToString("X8"));
            if ((ret = BootloaderClass.Send_Data(ref Port, start_address, 4)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| SEND ADDRESS: 0x{0}", Start_Address.ToString("X8"));
                return false;
            }
            Checksum_Address[0] = 0;
            foreach (byte x in start_address) Checksum_Address[0] ^= x;
            if ((ret = BootloaderClass.Send_Data(ref Port, Checksum_Address, 1)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| SEND CHECKSUM ADDRESS: 0x{0}", Checksum_Address[0].ToString("X2"));
                return false;
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| NOT RECEIVE ACK AFTER SEND ADDRESS| BYTE: 0x{0}", Data[0].ToString("X2"));
                return false;
            }

            byte[] number_of_bytes = new byte[1];
            number_of_bytes[0] = (byte)(Data.Length-1);
            if ((ret = BootloaderClass.Send_Data(ref Port, number_of_bytes, 1)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| SEND NUMBER OF BYTES: 0x" + number_of_bytes[0].ToString("X2"));
                return false;
            }
            //Console.WriteLine("Send_Data| Count: {0}| Buffer: ", Data.Length);
            //for (int i = 0; i < Data.Length; i++) Console.Write(Data[i].ToString("X2") + " ");
            //Console.WriteLine("");
            if ((ret = BootloaderClass.Send_Data(ref Port, Data, Data.Length)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| SEND DATA| SIZE: {0}| ADDRESS: 0x{1}", Data.Length, Start_Address.ToString("X8"));
                return false;
            }
            Checksum_Data[0] = 0;
            foreach (byte x in Data) Checksum_Data[0] ^= x;
            if ((ret = BootloaderClass.Send_Data(ref Port, Checksum_Data, 1)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| SEND CHECKSUM DATA: 0x{0}", Checksum_Data[0].ToString("X2"));
                return false;
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR WRITE MEMORY| NOT RECEIVE ACK AFTER SEND DATA| BYTE: 0x{0}", Data[0].ToString("X2"));
                return false;
            }
            //Console.WriteLine("WRITE MEMORY OK");
            return true;
        }
    };
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class ReadMemoryCommandScript
    {
        public byte[] ID { get; set; } = null;
        public SerialPort Port;
        public UInt32 Start_Address { get; set; } = 0;
        public byte[] Checksum_Address { get; set; } = new byte[1];
        public int Number_Of_Bytes { get; set; } = 0;
        public byte[] Checksum_Number_Of_Bytes { get; set; } = new byte[1];
        public byte[] Data { get; set; } = null;
        public ReadMemoryCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.READ_MEMORY));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| SEND ID");
                return false;
            }           
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| NOT RECEIVE ACK AFTER SEND ID| BYTE: 0x" + Data[0].ToString("X2"));
                return false;
            }

            byte[] start_address = new byte[4];
            start_address = BitConverter.GetBytes(BootloaderClass.HTONL(Start_Address));
            if ((ret = BootloaderClass.Send_Data(ref Port, start_address, 4)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| SEND ADDRESS: 0x{0}", Start_Address.ToString("X8"));
                return false;
            }
            Checksum_Address[0] = 0;
            foreach (byte x in start_address) Checksum_Address[0] ^= x;
            if ((ret = BootloaderClass.Send_Data(ref Port, Checksum_Address, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| SEND CHECKSUM ADDRESS: 0x{0}", Checksum_Address[0].ToString("X2"));
                return false;
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| NOT RECEIVE ACK AFTER SEND ADDRESS| BYTE: 0x" + Data[0].ToString("X2"));
                return false;
            }

            byte[] number_of_bytes = new byte[1];
            number_of_bytes[0] = (byte)(Number_Of_Bytes - 1);
            if ((ret = BootloaderClass.Send_Data(ref Port, number_of_bytes, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| SEND NUMBER OF BYTES: 0x" + number_of_bytes[0].ToString("X2"));
                return false;
            }
            Checksum_Number_Of_Bytes[0] = 0xFF;
            foreach (byte x in number_of_bytes) Checksum_Number_Of_Bytes[0] ^= x;
            if ((ret = BootloaderClass.Send_Data(ref Port, Checksum_Number_Of_Bytes, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| SEND CHECKSUM NUMBER OF BYTES: 0x" + Checksum_Number_Of_Bytes[0].ToString("X2"));
                return false;
            }
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| NOT RECEIVE ACK AFTER SEND NUMBER OF BYTES| BYTE: 0x" + Data[0].ToString("X2"));
                return false;
            }
            Data = new byte[Number_Of_Bytes];
            if ((ret = BootloaderClass.Receive_Data(ref Port, Data, Data.Length)) != true)
            {
                Console.WriteLine("ERROR READ MEMORY| RECEIVE DATA SIZE: {0}| ADDRESS: 0x{1}", Data.Length, Start_Address.ToString("X8"));
                return false;
            }
            return true;
        }
    };


    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /*##################################################################################################################*/
    /**/
    public class GoCommandScript
    {
        public byte[] ID { get; set; } = null;
        public SerialPort Port;
        public UInt32 Start_Address { get; set; } = 0;
        public byte[] Checksum_Address { get; set; } = new byte[1];
        public byte[] Data { get; set; } = new byte[1];
        public GoCommandScript(ref SerialPort port)
        {
            Port = port;
            ID = new byte[2];
            ID = BitConverter.GetBytes(BootloaderClass.HTONS(Command_ID.GO));
        }

        public bool Command()
        {
            bool ret = false;
            if ((ret = BootloaderClass.Send_Data(ref Port, ID, 2)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;

            byte[] start_address = new byte[4];
            start_address = BitConverter.GetBytes(BootloaderClass.HTONL(Start_Address));
            if ((ret = BootloaderClass.Send_Data(ref Port, start_address, 4)) != true) return false;
            Checksum_Address[0] = 0;
            foreach (byte x in start_address) Checksum_Address[0] ^= x;
            if ((ret = BootloaderClass.Send_Data(ref Port, Checksum_Address, 1)) != true) return false;
            if ((ret = BootloaderClass.Receive_ACK_Or_NACK(ref Port, Data, 1)) != true) return false;
            return true;
        }
    };

    class BootloaderClass
    {
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public static ushort HTONS(ushort id)
        {
            return (ushort)(((id & 0x00FF) << 8) | ((id & 0xFF00) >> 8));
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public static UInt32 HTONL(UInt32 x)
        {
            return (UInt32)(((x & 0x000000FF) << 24) | ((x & 0x0000FF00) << 8) | ((x & 0x00FF0000) >> 8) | ((x & 0xFF000000) >> 24));
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Start_Bootloader_Mode(ref SerialPort port)
        {
            byte[] buffer = { Command_Byte.START };
            Console.WriteLine("CONNECT TO DEVICE");
            if (!Send_Data(ref port, buffer, 1)) return false;
            if (!Receive_Data(ref port, buffer, 1)) return false;
            if (buffer[0] != Command_Byte.ACK) return false;           
            Console.WriteLine("DEVICE IN NETWORK");
            Console.WriteLine("CONNECT TO DEVICE OK");
            return true;

        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Read_Sector(ref SerialPort port, int sector, out byte[] data, ref System.Windows.Forms.ProgressBar bar)
        {
            data = new byte[0];
            var cmd = new ReadMemoryCommandScript(ref port);
            Console.WriteLine("READ SECTOR| Sector: {0}", sector);
            if (!Get_Sector_Addresses(sector, out UInt32 start_address, out UInt32 end_address)) return false;
            UInt32 curr_address = start_address;
            data = new byte[(end_address - start_address) + 1];
            while (curr_address< end_address)
            {
                if (bar != null)
                {
                    bar.Increment(1);
                }
                cmd.Number_Of_Bytes = 256;
                cmd.Start_Address = curr_address;
                if (cmd.Command() != true)
                {
                    Console.WriteLine("ERROR READ SECTOR| Sector: {0}", sector);
                    return false;
                }                   
                Array.Copy(cmd.Data, 0, data, curr_address - start_address, 256);

                curr_address += 256;
            }

            Console.WriteLine("READ SECTORS {0} OK", sector);
            return true;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Write_Sector(ref SerialPort port, int sector, byte[] data, ref System.Windows.Forms.ProgressBar bar)
        {
            var cmd = new WriteMemoryCommandScript(ref port);
            if (!Get_Sector_Addresses(sector, out UInt32 start_address, out UInt32 end_address)) return false;
            Console.WriteLine("WRITE IN SECTOR| Sector: {0}| Data size: {1}", sector, data.Length);
            UInt32 curr_address = start_address;
            int data_size = data.Length;
            while ((curr_address < end_address)&&(data_size>0))
            {
                if (bar != null)
                {
                    bar.Increment(1);
                 
                }
                int size = 256;
                if (data_size < size) size = data_size;
                cmd.Data = new byte[size];
                Array.Copy(data, curr_address - start_address, cmd.Data, 0, size);
                cmd.Start_Address = curr_address;
                if (cmd.Command() != true) return false;

                data_size -= size;
                curr_address += (UInt32)size;
            }
            Console.WriteLine("WRITE IN SECTOR {0} OK", sector);
            return true;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Write_Data(ref SerialPort port, UInt32 start_address, byte[] data)
        {
            var cmd = new WriteMemoryCommandScript(ref port);
            int data_size = data.Length;
            if (data_size > 256) return false;
            cmd.Data = (byte[])data.Clone();
            cmd.Start_Address = start_address;
            if (cmd.Command() != true) return false;
            return true;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Read_Data(ref SerialPort port, UInt32 start_address, byte[] data)
        {
            var cmd = new ReadMemoryCommandScript(ref port);
            int data_size = data.Length;
            if (data_size > 256) return false;
            cmd.Number_Of_Bytes = data_size;            
            cmd.Start_Address = start_address;
            if (cmd.Command() != true) return false;
            Array.Copy(data, 0, cmd.Data, 0, data_size);
            return true;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Jump_To_Application(ref SerialPort port, UInt32 start_address)
        {
            var cmd = new GoCommandScript(ref port);
            cmd.Start_Address = start_address;
            Console.WriteLine("JUMP_TO_APPLICATION| Address: 0x" + start_address.ToString("X8"));
            if (cmd.Command() != true) return false;
            Console.WriteLine("JUMP_TO_APPLICATION OK");
            return true;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public bool Erase_Sector(ref SerialPort port, int number_of_sectors, int[] sector_codes, ref System.Windows.Forms.ProgressBar bar)
        {
            Array.Sort(sector_codes);
            if (number_of_sectors == 0) return false;

            byte[] sector_codes_byte = new byte[0];
            for (int i = 0; i < sector_codes.Length; i++)
            {
                if (bar != null)
                {
                    bar.Increment(1);
                    bar.Refresh();
                }
                byte[] bytes = BitConverter.GetBytes(HTONS((UInt16)sector_codes[i]));
                sector_codes_byte = sector_codes_byte.Concat(bytes).ToArray();
            }
            byte[] number_of_sectors_byte = BitConverter.GetBytes(HTONS((UInt16)(number_of_sectors - 1)));
            var cmd = new EraseMemoryCommandScript(ref port);
            cmd.Special_Erase = (byte[])number_of_sectors_byte.Clone();
            cmd.Sector_Codes = (byte[])sector_codes_byte.Clone();

            Console.Write("ERASE SECTORS| Sectors: ");
            for (int i = 0; i < sector_codes.Length; i++) Console.Write(sector_codes[i].ToString() + " ");
            Console.WriteLine("| Count: {0}| ", number_of_sectors);
            bool ret = cmd.Command();

            if (ret) {
                Console.Write("ERASE SECTORS ");
                for (int i = 0; i < sector_codes.Length; i++) Console.Write(sector_codes[i].ToString() + " ");
                Console.WriteLine("OK");
            }
            else { Console.WriteLine("ERROR ERASE SECTORS"); }

            return ret;
        }


        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public static bool Receive_Data(ref SerialPort port, byte[] buffer, int count)
        {
            //for (int i = 0; i < count; i++)
            //    buffer[i] = (byte)i;
            //Console.WriteLine("Receive_Data| Count: {0}| Buffer: ", count);
            //for (int i = 0; i < count; i++)
            //    Console.Write(buffer[i].ToString("X2") + " ");
            //Console.WriteLine("");
            //return true;
            try
            {
                for(int i=0; i<count; i++) buffer[i] = (byte)port.ReadByte();
                //port.Read(buffer, 0, (int)count);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public static bool Send_Data(ref SerialPort port, byte[] buffer, int count)
        {
            //Console.WriteLine("Send_Data| Count: {0}| Buffer: ", count);
            //for (int i = 0; i < count; i++)
            //    Console.Write(buffer[i].ToString("X2") + " ");
            //Console.WriteLine("");
            //return true;
            try
            {
                port.DiscardInBuffer();
                port.DiscardOutBuffer();
                port.Write(buffer, 0, (int)count);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public static bool Receive_ACK(ref SerialPort port, byte[] buffer, int count)
        {
            //Console.WriteLine("Receive_ACK");
            //Console.WriteLine("Count: {0}", count);
            //return true;
            buffer[0] = 0;
            Receive_Data(ref port, buffer, 1);
            if (buffer[0] == Command_Byte.ACK) return true;
            return false;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public static bool Receive_ACK_Or_NACK(ref SerialPort port, byte[] buffer, int count)
        {
            //Console.WriteLine("Receive_ACK_Or_NACK");
            //Console.WriteLine("Count: {0}", count);
            //return true;
            buffer[0] = 0;
            Receive_Data(ref port, buffer, 1);
            if (buffer[0] == Command_Byte.ACK) return true;
            else if (buffer[0] == Command_Byte.NACK) return false;
            return false;
        }


        public int? Get_Sector(UInt32 address)
        {
            int? sector = 0;
            if ((address < Sector_Address.ADDR_FLASH_SECTOR_1) && (address >= Sector_Address.ADDR_FLASH_SECTOR_0))
                sector = Sector_Number.FLASH_SECTOR_0; 
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_2) && (address >= Sector_Address.ADDR_FLASH_SECTOR_1))
                sector = Sector_Number.FLASH_SECTOR_1;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_3) && (address >= Sector_Address.ADDR_FLASH_SECTOR_2))
                sector = Sector_Number.FLASH_SECTOR_2;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_4) && (address >= Sector_Address.ADDR_FLASH_SECTOR_3))
                sector = Sector_Number.FLASH_SECTOR_3;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_5) && (address >= Sector_Address.ADDR_FLASH_SECTOR_4))
                sector = Sector_Number.FLASH_SECTOR_4;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_6) && (address >= Sector_Address.ADDR_FLASH_SECTOR_5))
                sector = Sector_Number.FLASH_SECTOR_5;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_7) && (address >= Sector_Address.ADDR_FLASH_SECTOR_6))
                sector = Sector_Number.FLASH_SECTOR_6;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_8) && (address >= Sector_Address.ADDR_FLASH_SECTOR_7))
                sector = Sector_Number.FLASH_SECTOR_7;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_9) && (address >= Sector_Address.ADDR_FLASH_SECTOR_8))
                sector = Sector_Number.FLASH_SECTOR_8;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_10) && (address >= Sector_Address.ADDR_FLASH_SECTOR_9))
                sector = Sector_Number.FLASH_SECTOR_9;
            else if ((address < Sector_Address.ADDR_FLASH_SECTOR_11) && (address >= Sector_Address.ADDR_FLASH_SECTOR_10))
                sector = Sector_Number.FLASH_SECTOR_10;
            else if ((address <= Sector_Address.ADDR_FLASH_END) && (address >= Sector_Address.ADDR_FLASH_SECTOR_11))
                sector = Sector_Number.FLASH_SECTOR_11;
            else sector = null;
            return sector;
        }

        public bool Get_Sector_Addresses(int sector, out UInt32 start_address, out UInt32 end_address)
        {
            bool ret = false;
            start_address = 0;
            end_address = 0;
            switch (sector)
            {
                case Sector_Number.FLASH_SECTOR_0:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_0;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_1 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_1:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_1;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_2 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_2:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_2;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_3 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_3:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_3;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_4 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_4:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_4;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_5 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_5:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_5;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_6 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_6:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_6;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_7 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_7:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_7;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_8 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_8:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_8;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_9 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_9:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_9;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_10 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_10:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_10;
                    end_address = Sector_Address.ADDR_FLASH_SECTOR_11 - 1;
                    ret = true;
                    break;
                case Sector_Number.FLASH_SECTOR_11:
                    start_address = Sector_Address.ADDR_FLASH_SECTOR_11;
                    end_address = Sector_Address.ADDR_FLASH_END;
                    ret = true;
                    break;
                default:
                    start_address = 0;
                    end_address = 0;
                    ret = false;
                    break;
            }
            return ret;
        }

        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public int Get_Sectors_Size(int[] sector_codes)
        {
            int size = 0;
            foreach (int sector in sector_codes)
                size+= Get_Sector_Size(sector);
            return size;
        }
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /*##################################################################################################################*/
        /**/
        public int Get_Sector_Size(int sector)
        {
            int size = 0;
            if ((sector == Sector_Number.FLASH_SECTOR_0) || (sector == Sector_Number.FLASH_SECTOR_1) || (sector == Sector_Number.FLASH_SECTOR_2) ||
                (sector == Sector_Number.FLASH_SECTOR_3))
            {
                size = 16 * 1024;
            }
            else if (sector == Sector_Number.FLASH_SECTOR_4)
            {
                size = 64 * 1024;
            }
            else
            {
                size = 128 * 1024;
            }
            return size;
        }

    }
}

