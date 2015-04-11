extern alias direct;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dayz_toolkit
{
    public class memoryFunctions
    {

        static int DELETE = 0x00010000;
        static int READ_CONTROL = 0x00020000;
        static int WRITE_DAC = 0x00040000;
        static int WRITE_OWNER = 0x00080000;
        static int SYNCHRONIZE = 0x00100000;
        static int END = 0xFFF; //if you have Windows XP or Windows Server 2003 you must change this to 0xFFFF
        static int PROCESS_ALL_ACCESS = (DELETE | READ_CONTROL | WRITE_DAC | WRITE_OWNER | SYNCHRONIZE | END);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess,
          IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
          byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        public static IntPtr findDayzProcess()
        {
            IntPtr hand = IntPtr.Zero;
            try
            {
                Process process = Process.GetProcessesByName("Dayz")[0];
                hand = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
            }
            catch (System.IndexOutOfRangeException)
            {
                return hand;
            }
            
            

            return hand;
        }


        //INTEGER READS
        public static int readInt(IntPtr hProcess, int baseAdress, int size){
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)baseAdress, buffer, buffer.Length, ref o);
            int objectPointer = BitConverter.ToInt32(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static int readInt(IntPtr hProcess, int baseAdress, int offset1, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            int objectPointer = BitConverter.ToInt32(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static int readInt(IntPtr hProcess, int baseAdress, int offset1, int offset2, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref );
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(buffer,0) + offset2), buffer, buffer.Length, ref o);
            int objectPointer = BitConverter.ToInt32(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static int readInt(IntPtr hProcess, int baseAdress, int offset1, int offset2, int offset3, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(buffer, 0) + offset2), buffer, buffer.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(buffer, 0) + offset3), buffer, buffer.Length, ref o);
            int objectPointer = BitConverter.ToInt32(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        //INTEGER WRITES
        public static void writeInt(IntPtr hProcess, int baseAdress, int value, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            buffer = BitConverter.GetBytes(value);
            WriteProcessMemory(hProcess, (IntPtr)baseAdress, buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }
        public static void writeInt(IntPtr hProcess, int baseAdress, int value, int offset1, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            buffer = BitConverter.GetBytes(value);
            WriteProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }
        public static void writeInt(IntPtr hProcess, int baseAdress, int value, int offset1, int offset2, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            byte[] temp = new byte[size];
            buffer = BitConverter.GetBytes(value);
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), temp, temp.Length, ref o);
            WriteProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(temp, 0) + offset2), buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }
        public static void writeInt(IntPtr hProcess, int baseAdress, int value, int offset1, int offset2, int offset3, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            byte[] temp = new byte[size];
            buffer = BitConverter.GetBytes(value);
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), temp, temp.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(temp, 0) + offset2), temp, temp.Length, ref o);
            WriteProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(temp, 0) + offset3), buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }



        //FLOAT READS
        public static float readFloat(IntPtr hProcess, int baseAdress, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)baseAdress, buffer, buffer.Length, ref o);
            float objectPointer = BitConverter.ToSingle(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static float readFloat(IntPtr hProcess, int baseAdress, int offset1, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            float objectPointer = BitConverter.ToSingle(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static float readFloat(IntPtr hProcess, int baseAdress, int offset1, int offset2, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(buffer, 0) + offset2), buffer, buffer.Length, ref o);
            float objectPointer = BitConverter.ToSingle(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static float readFloat(IntPtr hProcess, int baseAdress, int offset1, int offset2, int offset3, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(buffer, 0) + offset2), buffer, buffer.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(buffer, 0) + offset3), buffer, buffer.Length, ref o);
            float objectPointer = BitConverter.ToSingle(buffer, 0);
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        //FLOAT WRITES
        public static void writeFloat(IntPtr hProcess, int baseAdress, float value, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            buffer = BitConverter.GetBytes(value);
            WriteProcessMemory(hProcess, (IntPtr)baseAdress, buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }
        public static void writeFloat(IntPtr hProcess, int baseAdress, float value, int offset1, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            buffer = BitConverter.GetBytes(value);
            WriteProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }
        public static void writeFloat(IntPtr hProcess, int baseAdress, float value, int offset1, int offset2, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            byte[] temp = new byte[size];
            buffer = BitConverter.GetBytes(value);
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), temp, temp.Length, ref o);
            WriteProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(temp, 0) + offset2), buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }
        public static void writeFloat(IntPtr hProcess, int baseAdress, float value, int offset1, int offset2, int offset3, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            byte[] temp = new byte[size];
            buffer = BitConverter.GetBytes(value);
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset1), temp, temp.Length, ref o);
            ReadProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(temp, 0) + offset2), temp, temp.Length, ref o);
            WriteProcessMemory(hProcess, (IntPtr)(BitConverter.ToInt32(temp, 0) + offset3), buffer, buffer.Length, ref o);
            Marshal.FreeHGlobal(hProcess);
        }

        //OTHER READS
        public static string readString(IntPtr hProcess, int baseAdress, int size)
        {
            int o = 0;
            byte[] buffer = new byte[size];
            ReadProcessMemory(hProcess, (IntPtr)baseAdress, buffer, buffer.Length, ref o);
            ASCIIEncoding ascii = new ASCIIEncoding();
            string objectPointer = ascii.GetString(buffer);
            return objectPointer;
        }

        public static int readByte(IntPtr hProcess, int baseAdress, int offset)
        {
            int o = 0;
            byte[] buffer = new byte[1];
            ReadProcessMemory(hProcess, (IntPtr)(baseAdress + offset), buffer, buffer.Length, ref o);
            int objectPointer = buffer[0];
            Marshal.FreeHGlobal(hProcess);
            return objectPointer;
        }
        public static void writeByte(IntPtr hProcess, int baseAdress, int value, int offset)
        {
            int o = 0;
            byte[] buffer = new byte[1];
            buffer[0] = (byte)value;
            WriteProcessMemory(hProcess, (IntPtr)(baseAdress + offset), buffer, buffer.Length, ref o);
        }

    }
}
