using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dayz_toolkit
{
    public partial class playerItems : Form
    {
        public playerItems()
        {
            InitializeComponent();
            this.Visible = true;
        }


        public struct itemStruct
        {
            public int itemID;
            public String itemName;

            public itemStruct(int ID, String name)
            {
                itemID = ID;
                itemName = name;
            }
        }

        List<String> itemBrowserList = new List<String>();
        List<itemStruct> itemStructList = new List<itemStruct>();
        static IntPtr hProcess = memoryFunctions.findDayzProcess();
        
        int baseAddress = memoryFunctions.readInt(hProcess, 0x010810D0, 4);

        public void itemList(){
                int baseAddress = memoryFunctions.readInt(hProcess, 0x010810D0, 4);
                int localPlayer = memoryFunctions.readInt(hProcess, baseAddress, 0x15C4, 4);
                int localPlayerPointer = memoryFunctions.readInt(hProcess, localPlayer, 0x4, 4);
                int localPlayerPosition = memoryFunctions.readInt(hProcess, localPlayerPointer, 0x20, 4);
                int localPlayerID = memoryFunctions.readInt(hProcess, localPlayerPointer, 0x07E0, 4);
                //foreign values for this table
                int foreignPlayerPointer = memoryFunctions.readInt(hProcess, baseAddress, 0x778, 4);
                int foreignPlayerTable = memoryFunctions.readInt(hProcess, foreignPlayerPointer, 0xC, 4);
                int foreignPlayerCount = memoryFunctions.readInt(hProcess, foreignPlayerPointer, 0x4, 4);


                    int nearItemSize = memoryFunctions.readInt(hProcess, baseAddress, 0x11B8, 4);
                    int nearItemTable = memoryFunctions.readInt(hProcess, baseAddress, 0x11B4, 4);


                    int oldItemCount = itemBrowserList.Count();
                    itemBrowserList.Clear();
                    itemStructList.Clear();

                    for (int z = 0; z < nearItemSize; z++)
                    {

                        int itemObj, itemLocation = 0;
                        float itemX, itemY, itemZ = 0;
                        itemObj = memoryFunctions.readInt(hProcess, nearItemTable, z * 0x4, 4);
                        itemLocation = memoryFunctions.readInt(hProcess, itemObj, 0x20, 4);
                        itemX = memoryFunctions.readFloat(hProcess, itemLocation, 0x28, 4);
                        itemY = memoryFunctions.readFloat(hProcess, itemLocation, 0x30, 4);
                        itemZ = memoryFunctions.readFloat(hProcess, itemLocation, 0x2C, 4);

                        float xPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
                        float yPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
                        float zPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

                        float deltaX = itemX - xPos;
                        float deltaY = itemY - yPos;
                        float deltaZ = itemZ - zPos;

                        String itemName = playerFunctions.getItemName(hProcess, itemObj);
                        itemName = itemName.ToLower();

                        double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));


                        if (itemName.Contains(filterBox.Text) && filterBox.Text != null)
                        {
                            if (itemBrowserList.Contains(itemName) == false)
                            {
                                itemBrowserList.Add(itemName);
                                itemStruct newItem = new itemStruct(itemObj, itemName);
                                itemStructList.Add(newItem);
                            }
                        }

                    }

                    int droppedSize = memoryFunctions.readInt(hProcess, baseAddress, 0xFC0, 4);
                    int dropepdTable = memoryFunctions.readInt(hProcess, baseAddress, 0x0FBC, 4);

                    for (int z = 0; z < droppedSize; z++)
                    {

                        int itemObj, itemLocation = 0;
                        float itemX, itemY, itemZ = 0;
                        itemObj = memoryFunctions.readInt(hProcess, dropepdTable, z * 0x4, 4);
                        itemLocation = memoryFunctions.readInt(hProcess, itemObj, 0x20, 4);
                        itemX = memoryFunctions.readFloat(hProcess, itemLocation, 0x28, 4);
                        itemY = memoryFunctions.readFloat(hProcess, itemLocation, 0x30, 4);
                        itemZ = memoryFunctions.readFloat(hProcess, itemLocation, 0x2C, 4);

                        float xPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
                        float yPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
                        float zPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

                        float deltaX = itemX - xPos;
                        float deltaY = itemY - yPos;
                        float deltaZ = itemZ - zPos;

                        String itemName = playerFunctions.getItemName(hProcess, itemObj);
                        itemName = itemName.ToLower();

                        double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));
                        if (itemName.Contains(filterBox.Text) && filterBox.Text != null)
                        {
                            if (itemBrowserList.Contains(itemName) == false)
                            {
                                itemBrowserList.Add(itemName);
                                itemStruct newItem = new itemStruct(itemObj, itemName);
                                itemStructList.Add(newItem);
                            }
                        }
                       



                    }

                    if (oldItemCount != itemBrowserList.Count())
                    {
                        itemListBox.DataSource = null;
                        itemListBox.DataSource = itemBrowserList;
                    }



        }

        private void itemRefresh_Tick(object sender, EventArgs e)
        {
            this.itemList();
        }

        private void getItem_Click(object sender, EventArgs e)
        {
            String travelTo = itemListBox.Text;

            itemStruct item = itemStructList.FirstOrDefault(o => o.itemName == travelTo);
            int itemLocation = memoryFunctions.readInt(hProcess, item.itemID, 0x20, 4);

            int localPlayer = memoryFunctions.readInt(hProcess, baseAddress, 0x15C4, 4);
            int localPlayerPointer = memoryFunctions.readInt(hProcess, localPlayer, 0x4, 4);
            int localPlayerPosition = memoryFunctions.readInt(hProcess, localPlayerPointer, 0x20, 4);

            float localX = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
            float localY = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
            float localZ = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

            memoryFunctions.writeFloat(hProcess, itemLocation, (float)(localX + 0.5), 0x28, 4);
            memoryFunctions.writeFloat(hProcess, itemLocation, (float)(localY + 0.5), 0x30, 4);
            memoryFunctions.writeFloat(hProcess, itemLocation, localZ + 1, 0x2C, 4);

        }
        
    }
}
