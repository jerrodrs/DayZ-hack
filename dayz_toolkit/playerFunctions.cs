using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace dayz_toolkit
{
    class playerFunctions
    {

        public static string getPlayerName(IntPtr hProcess, int pEntityID)
        {
            string playername = "-";
            int pPLAYERINFO = 0x010A9788;
            int curPtr = memoryFunctions.readInt(hProcess, pPLAYERINFO, 0x28, 4);
            int cnt = memoryFunctions.readInt(hProcess, curPtr, 0x10, 4);
            curPtr = memoryFunctions.readInt(hProcess, curPtr, 0x0C, 4);
            for (int i = 0; i < cnt; i++)
            {
                int curObj = curPtr + i * 0xE8;
                int idx = memoryFunctions.readInt(hProcess, curObj, 0x4, 4);

                

                if (idx == pEntityID)
                {
                    int val = memoryFunctions.readInt(hProcess, curObj, 0x80, 4);
                    String name = getString(hProcess, val);
                    //name = Regex.Replace(name, @"[^\w\.@-]", String.Empty);
                    //if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) { name = "-"; }
                    playername = name;
                    break;
                }
            }
            return playername;
        }

        public static string getItemName(IntPtr hProcess, int itemObj)
        {
            string itemName = "-";

            int name = memoryFunctions.readInt(hProcess, itemObj, 0x70, 4);
            name = memoryFunctions.readInt(hProcess, name, 0x34, 4);
            int size = memoryFunctions.readInt(hProcess, name, 0x4, 4);
            String tempName = memoryFunctions.readString(hProcess, name + 0x8, size);

            tempName = Regex.Replace(tempName, @"[^\w\.@-]", String.Empty);
            if (String.IsNullOrEmpty(tempName) || String.IsNullOrWhiteSpace(tempName)) { tempName = "-"; }
            itemName = tempName;

            return itemName;
        }

        public static string getString(IntPtr hProcess, int itemObj)
        {
            string itemName = "-";

            int name = itemObj;
            int size = memoryFunctions.readInt(hProcess, name, 0x4, 4);
            string tempName = memoryFunctions.readString(hProcess, name + 0x8, size-1);
            
            //tempName = Regex.Replace(tempName, @"[^\w\.@-]", String.Empty);
            //if (String.IsNullOrEmpty(tempName) || String.IsNullOrWhiteSpace(tempName)) { tempName = "-"; }
            itemName = tempName;

            return itemName;
        }



    }
}
