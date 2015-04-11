using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using Microsoft.DirectX.Direct3D;
using System.Diagnostics;
using Microsoft.DirectX.PrivateImplementationDetails;


namespace dayz_toolkit
{
    public partial class gameOverlay : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]

        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]

        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]

        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);


        public const int GWL_EXSTYLE = -20;

        public const int WS_EX_LAYERED = 0x80000;

        public const int WS_EX_TRANSPARENT = 0x20;

        public const int LWA_ALPHA = 0x2;

        public const int LWA_COLORKEY = 0x1;



        //OFFSETS
        const int baseAddr = 0x010B5228;
        const int stance = 0x1300;
        const int playerIden = 0x0800;
        const int noRecoil = 0x0C54;
        const int fatigueDiff = 0x0C70;
        const int noFatigue = 0x0C74;




        public struct player
        {


            public int playerID;
            public string playerName;
            public int playerListNumber;
            public int playerObject;

            public float xPos;
            public float yPos;
            public float zPos;

            public float xDirc;
            public float yDirc;


            public player(int _playerID, string _playerName, int _playerListNumber, int _playerObject, float _xPos, float _yPos, float _zPos, float _xDirc, float _yDirc)
            {
                playerID = _playerID;
                playerName = _playerName;
                playerListNumber = _playerListNumber;
                playerObject = _playerObject;
                xPos = _xPos;
                yPos = _yPos;
                zPos = _zPos;

                xDirc = _xDirc;
                yDirc = _yDirc;
            }

        }
        static IntPtr hProcess = memoryFunctions.findDayzProcess();

        public void setConsoleText(string message)
        {

            this.consoleTxt.Text = message;

        }

        public gameOverlay()
        {

            InitializeComponent();
            //paintIt();
            //Make the window's border completely transparant
           SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) ^ WS_EX_LAYERED ^ WS_EX_TRANSPARENT));
 
            //Set the Alpha on the Whole Window to 255 (solid)
           
            SetLayeredWindowAttributes(this.Handle, 0, 255, LWA_ALPHA);
            BackColor = Color.Black;
            TransparencyKey = Color.Black;

        }

        public struct mapLocations
        {
            public string locationName;
            public int locationX;
            public int locationY;

            public mapLocations(string name, int x, int y)
            {
                locationName = name;
                locationX = x;
                locationY = y;
            }

            public string getName()
            {
                return locationName;
            }
            public int getX()
            {
                return locationX;
            }
            public int getY()
            {
                return locationY;
            }

        }



        private void gameOverlay_Load(object sender, EventArgs e)
        {
            drawingBoard.Paint += new PaintEventHandler(graphicsOverlay_Paint);
            drawingBoard.Width = this.Width;
            drawingBoard.Height = this.Height;
            


            mapLocations berezino = new mapLocations("Berezino", 12855, 9709);
            locations.Add(berezino);
            locationNames.Add("Berezino");

            mapLocations belota = new mapLocations("Belota", 4600, 2660);
            locations.Add(belota);
            locationNames.Add("Belota");

            mapLocations neaf = new mapLocations("NEAF (Small)", 11891, 12336);
            locations.Add(neaf);
            locationNames.Add("NEAF (Small)");

            mapLocations cherno = new mapLocations("Cherno", 6800, 2460);
            locations.Add(cherno);
            locationNames.Add("Cherno");

            mapLocations nwaf = new mapLocations("NWAF (Large)", 4800, 10660);
            locations.Add(nwaf);
            locationNames.Add("NWAF (Large)");

            mapLocations elektro = new mapLocations("Elektro", 10400, 1960);
            locations.Add(elektro);
            locationNames.Add("Elektro");

            mapLocations kamy = new mapLocations("Kamyshovo", 12100, 3660);
            locations.Add(kamy);
            locationNames.Add("Kamyshovo");

            mapLocations soly = new mapLocations("Solnichniy", 13200, 6460);
            locations.Add(soly);
            locationNames.Add("Solnichniy");

            mapLocations novo = new mapLocations("Novodmitrovsk", 11200, 14560);
            locations.Add(novo);
            locationNames.Add("Novodmitrovsk");

            mapLocations greenmnt = new mapLocations("Green Mountain", 3700, 5660);
            locations.Add(greenmnt);
            locationNames.Add("Green Mountain");

            locationComboBox.DataSource = locationNames;

        }

        List<mapLocations> locations = new List<mapLocations>();
        List<String> locationNames = new List<string>();

        public GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
        {
            GraphicsPath path = new GraphicsPath();
            // Convert font size into appropriate coordinates
            float emSize = dpi * font.SizeInPoints / 72;
            path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

            return path;
        }

        public bool weaponCheck(string weaponString)
        {
            if (weaponString.Contains("mosin"))
            {
                return true;
            }
            if (weaponString.Contains("sks"))
            {
                return true;
            }
            if (weaponString.Contains("m4"))
            {
                return true;
            }
            if (weaponString.Contains("ammo"))
            {
                return true;
            }
            if (weaponString.Contains("mp5"))
            {
                return true;
            }
            if (weaponString.Contains("ruger"))
            {
                return true;
            }
            if (weaponString.Contains("axe"))
            {
                return true;
            }
            if (weaponString.Contains("cr75"))
            {
                return true;
            }
            if (weaponString.Contains("22"))
            {
                return true;
            }
            if (weaponString.Contains("75"))
            {
                return true;
            }
            if (weaponString.Contains("cr75"))
            {
                return true;
            }

            return false;
        }

        public bool stopRefresh = false;

        //important variables
        public static IntPtr handle = memoryFunctions.findDayzProcess();

        public static int baseAddress = memoryFunctions.readInt(handle, baseAddr, 4);

        //local players
        public static int localPlayer = memoryFunctions.readInt(handle, baseAddress, 0x1694, 4);
        public static int localPlayerPointer = memoryFunctions.readInt(handle, localPlayer, 0x4, 4);
        public static int localPlayerPosition = memoryFunctions.readInt(handle, localPlayerPointer, 0x24, 4);
        public static int localPlayerID = memoryFunctions.readInt(handle, localPlayerPointer, 0x07E8, 4);

        //foreign players
        public static int foreignPlayerPointer = memoryFunctions.readInt(handle, baseAddress, 0x778, 4);

        public void getVariables()
        {
            //local players
            localPlayer = memoryFunctions.readInt(handle, baseAddress, 0x1694, 4);
            localPlayerPointer = memoryFunctions.readInt(handle, localPlayer, 0x4, 4);
            localPlayerPosition = memoryFunctions.readInt(handle, localPlayerPointer, 0x24, 4);
            localPlayerID = memoryFunctions.readInt(handle, localPlayerPointer, playerIden, 4);

            //foreign players
            foreignPlayerPointer = memoryFunctions.readInt(handle, baseAddress, 0x778, 4);
        }

        /////

        //random bools and codes for most of the checkboxes
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        static FontFamily fontFamily = new FontFamily("Lucida Console");
        static Font font = new Font(fontFamily, 12, FontStyle.Bold, GraphicsUnit.Pixel);

        static bool fallCheck = false;
        static bool recoilCheck = false;
        static bool zombieESP = false;
        static bool itemESP = false;
        static bool playerESP = false;
        static bool itemMagnet = false;
        static bool weaponESP = false;
        static bool weatherCheck = false;
        static bool hoverCheck = false;
        static bool corpseEsp = false;

        float oldZ;

        int landContact;



        static List<string> _playerIDs = new List<string>();
        static List<string> _playerIDsCombo = new List<string>();
        static List<string> _playerIDCompare = new List<string>();

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

        public void graphicsOverlay_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            if (stopRefresh == true)
            {
                e.Graphics.Clear(Color.Black);
                if (isConnected == 0)
                {
                    consoleTxt.Text = "Local Player Disconnect, Waiting...";
                    playerList.DataSource = null;
                }
                else if (isDead == 1)
                {
                    consoleTxt.Text = "Local Player Dead, Waiting...";
                    playerList.DataSource = null;
                }
            }
            else
            {
                consoleTxt.Text = "Local Player Connected";
                getVariables();
                //random bools and codes for most checkboxes
                //tele vars
                float xDirc = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x1C, 4);
                float yDirc = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x24, 4);
                float xPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
                float yPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
                float zPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

                //anti fall
                fallCheck = antiFallChk.Checked;
                //no recoil
                recoilCheck = noRecoilChk.Checked;
                //show zombies
                zombieESP = showZmbChk.Checked;
                //show items
                itemESP = itemEspChk.Checked;
                //show players
                playerESP = playerESPChk.Checked;
                //item magnet
                itemMagnet = itemMagChk.Checked;
                //weapon ESP
                weaponESP = weaponESPChk.Checked;
                //weatherCheck
                weatherCheck = weatherChk.Checked;
                //corpse
                corpseEsp = corpseChk.Checked;

                //hover function check
                if (hoverCheck == true)
                {
                    if (hoverTimer.Enabled == false)
                    {
                        hoverTimer.Start();
                    }

                }
                if (hoverCheck == false)
                {
                    if (hoverTimer.Enabled == true)
                    {
                        hoverTimer.Stop();
                    }
                }

                //no grass
                memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x0758, 4);

                Debug.WriteLine(memoryFunctions.readFloat(hProcess,baseAddress, 0x0758, 4));

                //time of day
                if (weatherCheck == true)
                {
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x16D8, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x16DC, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x16F0, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x16F4, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x16E4, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x16E8, 4);
                }


                float timeOfDay = (this.timeOfDayBar.Value) / 10;

                memoryFunctions.writeFloat(hProcess, baseAddress, (float)timeOfDay, 0x170C, 4);

                oldZ = zPos;




                landContact = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0199);

                if (fallCheck == true && hoverCheck == false)
                {
                    landContact = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0199);


                    if (landContact == 0 && hoverCheck == false)
                    {
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, -2, 0x4C, 4);
                    }

                }

                if (recoilCheck == true)
                {
                    memoryFunctions.writeFloat(hProcess, localPlayerPointer, 0, noRecoil, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPointer, 0, fatigueDiff, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPointer, 1, noFatigue, 4);
                    
                    
                }





                this.localXNum.Value = (decimal)xPos;
                this.localYNum.Value = (decimal)yPos;
                this.localZNum.Value = (decimal)zPos;
                //foreign values for this table
                int foreignPlayerPointer = memoryFunctions.readInt(hProcess, baseAddress, 0x778, 4);
                int foreignPlayerTable = memoryFunctions.readInt(hProcess, foreignPlayerPointer, 0x0, 4);
                int foreignPlayerCount = memoryFunctions.readInt(hProcess, foreignPlayerPointer, 0x4, 4);

                int Starter = memoryFunctions.readInt(hProcess, 0x010D10FC, 4);
                int dwTransData = memoryFunctions.readInt(hProcess, Starter, 0x94, 4);
                VECTOR3 InvViewRight = ReadVECTOR3(dwTransData + 0x4);
                VECTOR3 InvViewUp = ReadVECTOR3(dwTransData + 0x10);
                VECTOR3 InvViewForward = ReadVECTOR3(dwTransData + 0x1C);
                VECTOR3 InvViewTranslation = ReadVECTOR3(dwTransData + 0x28);
                VECTOR3 ViewPortMatrix = ReadVECTOR3(dwTransData + 0x54);
                VECTOR3 ProjD1 = ReadVECTOR3(dwTransData + 0xCC);
                VECTOR3 ProjD2 = ReadVECTOR3(dwTransData + 0xD8);
                string className = "-";
                if (playerESP == true)
                {
                    int oldPlayerCount = _playerIDs.Count();
                    _playerIDs.Clear();
                    _playerIDsCombo.Clear();
                    for (int i = 0; i < foreignPlayerCount; i++)
                    {
                        int foreignPlayerID, foreignPlayerObj, foreignPlayerLocation = 0;
                        float foreignX, foreignY, foreignZ = 0;
                        foreignPlayerObj = memoryFunctions.readInt(hProcess, memoryFunctions.readInt(hProcess, foreignPlayerTable, i * 0x2C, 4), 0x4, 4);
                        foreignPlayerID = memoryFunctions.readInt(hProcess, foreignPlayerObj, playerIden, 4);
                        foreignPlayerLocation = memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x24, 4);
                        foreignX = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x28, 4);
                        foreignY = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x30, 4);
                        foreignZ = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x2C, 4);
                        VECTOR3 playerVec = new VECTOR3() { x = foreignX, y = foreignY, z = foreignZ };

                        float deltaX = foreignX - xPos;
                        float deltaY = foreignY - yPos;
                        float deltaZ = foreignZ - zPos;


                        double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));
                        playerVec = W2SN(playerVec, InvViewRight, InvViewUp, InvViewForward, InvViewTranslation, ViewPortMatrix, ProjD1, ProjD2);

                        int t1 = memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x70, 4);
                        t1 = memoryFunctions.readInt(hProcess, t1, 0x44, 4);
                        t1 = memoryFunctions.readInt(hProcess, t1, 0x70, 4);

                        className = memoryFunctions.readString(hProcess, t1 + 0x8, 25);
                        //Debug.WriteLine(className);
                       // Debug.WriteLine(" ");
                        int isDead = memoryFunctions.readByte(hProcess, foreignPlayerObj, 0x0274);

                        if (playerVec.z > 0.1 && foreignPlayerID > 1 && distanceToPlayer < 1000 && isDead == 0 && foreignPlayerID != localPlayerID)
                            {
                                
                                string playerName = playerFunctions.getPlayerName(hProcess, foreignPlayerID);
                                if (memoryFunctions.readByte(hProcess, foreignPlayerObj, stance) == 0)
                                {
                                    e.Graphics.DrawString("STAND", font, Brushes.Aqua, playerVec.x, playerVec.y + 30);
                                }
                                else if (memoryFunctions.readByte(hProcess, foreignPlayerObj, stance) == 1)
                                {
                                    e.Graphics.DrawString("CROUCH", font, Brushes.Aqua, playerVec.x, playerVec.y + 30);
                                }
                                else if (memoryFunctions.readByte(hProcess, foreignPlayerObj, stance) == 2)
                                {
                                    e.Graphics.DrawString("PRONE", font, Brushes.Aqua, playerVec.x, playerVec.y + 30);
                                }
                                e.Graphics.FillRectangle(Brushes.Red, playerVec.x, playerVec.y, 5, 5);

                                e.Graphics.DrawString(playerName, font, Brushes.Aqua, playerVec.x, playerVec.y + 10);

                                String nameId = playerName;
                                _playerIDsCombo.Add(nameId);
                                nameId = playerName;
                                _playerIDs.Add(nameId);

                                e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Aqua, playerVec.x, playerVec.y + 20);
                                string currentWeapon = "-";

                                //hands

                                if (memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x0A34, 4) != 0)
                                {
                                    currentWeapon = playerFunctions.getItemName(hProcess, memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x0A34, 4));
                                    if (currentWeapon != "-")
                                    {
                                        e.Graphics.DrawString(currentWeapon, font, Brushes.LimeGreen, playerVec.x, playerVec.y + 40);
                                    }
                                }


                            }else

                            if (foreignPlayerID == 1 && playerVec.z > 0.1 && foreignPlayerID != localPlayerID && className.Contains("soldier") && isDead == 0 && distanceToPlayer < 1000)
                            {
                                e.Graphics.DrawString("DISCONNECT", font, Brushes.Violet, playerVec.x, playerVec.y + 20);
                                e.Graphics.FillRectangle(Brushes.Purple, playerVec.x, playerVec.y, 5, 5);
                                e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Violet, playerVec.x, playerVec.y + 10);
                                string currentWeapon = playerFunctions.getItemName(hProcess, memoryFunctions.readInt(hProcess, foreignPlayerObj, 0xA14, 4));
                                if (currentWeapon != "-")
                                {
                                    //e.Graphics.DrawString(currentWeapon, font, Brushes.Violet, playerVec.x, playerVec.y + 30);
                                }
                            }else

                                if (foreignPlayerID == 1 && playerVec.z > 0.1 && foreignPlayerID != localPlayerID && className.Contains("soldier") && isDead == 1 && corpseEsp == true && distanceToPlayer < 1000)
                            {
                                e.Graphics.DrawString("DEAD", font, Brushes.Yellow, playerVec.x, playerVec.y + 20);
                                e.Graphics.FillRectangle(Brushes.Yellow, playerVec.x, playerVec.y, 5, 5);
                                e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Yellow, playerVec.x, playerVec.y + 10);
                                string currentWeapon = playerFunctions.getItemName(hProcess, memoryFunctions.readInt(hProcess, foreignPlayerObj, 0xA14, 4));
                                if (currentWeapon != "-")
                                {
                                    //e.Graphics.DrawString(currentWeapon, font, Brushes.Yellow, playerVec.x, playerVec.y + 30);
                                }
                            }


                       
                    }


                    if (oldPlayerCount != _playerIDs.Count())
                    {
                        playerList.DataSource = null;
                        playerList.DataSource = _playerIDs;

                        playerComboBox.DataSource = null;
                        playerComboBox.DataSource = _playerIDsCombo;
                    }

                    playerCountTxt.Text = Convert.ToString(_playerIDs.Count);
                    
                }


                if (zombieESP == true)
                {
                    for (int i = 0; i < foreignPlayerCount; i++)
                    {
                        int foreignPlayerID, foreignPlayerObj, foreignPlayerLocation = 0;
                        float foreignX, foreignY, foreignZ = 0;
                        foreignPlayerObj = memoryFunctions.readInt(hProcess, memoryFunctions.readInt(hProcess, foreignPlayerTable, i * 0x2C, 4), 0x4, 4);
                        foreignPlayerID = memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x07E8, 4);
                        foreignPlayerLocation = memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x24, 4);
                        foreignX = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x28, 4);
                        foreignY = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x30, 4);
                        foreignZ = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x2C, 4);
                        VECTOR3 playerVec = new VECTOR3() { x = foreignX, y = foreignY, z = foreignZ };


                        float deltaX = foreignX - xPos;
                        float deltaY = foreignY - yPos;
                        float deltaZ = foreignZ - zPos;

                        string playerName = playerFunctions.getPlayerName(hProcess, foreignPlayerID);

                        double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));
                        playerVec = W2SN(playerVec, InvViewRight, InvViewUp, InvViewForward, InvViewTranslation, ViewPortMatrix, ProjD1, ProjD2);


                        int isDead = memoryFunctions.readByte(hProcess, foreignPlayerObj, 0x027C);

                        if (foreignPlayerID <= 1 && playerVec.z > 0.1 && foreignPlayerID != localPlayerID)
                        {

                           // e.Graphics.DrawString(Convert.ToString((int)foreignPlayerID), font, Brushes.Aqua, playerVec.x, playerVec.y + 50);
                            if (foreignPlayerID <= 1)
                            {
                                e.Graphics.FillRectangle(Brushes.Green, playerVec.x, playerVec.y, 5, 5);
                                e.Graphics.DrawString(playerName, font, Brushes.Lime, playerVec.x, playerVec.y + 10);
                                e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Lime, playerVec.x, playerVec.y + 20);
                            }
                            
                        }
                        


                    }
                }


                int nearItemSize = memoryFunctions.readInt(hProcess, baseAddress, 0x11B8, 4);
                int nearItemTable = memoryFunctions.readInt(hProcess, baseAddress, 0x11B4, 4);
                int droppedSize = memoryFunctions.readInt(hProcess, baseAddress, 0xFC0, 4);
                int dropepdTable = memoryFunctions.readInt(hProcess, baseAddress, 0x0FBC, 4);


                if (itemESP == true)
                {


                    for (int z = 0; z < nearItemSize; z++)
                    {

                        int itemObj, itemLocation = 0;
                        float itemX, itemY, itemZ = 0;
                        itemObj = memoryFunctions.readInt(hProcess, nearItemTable, z * 0x4, 4);
                        itemLocation = memoryFunctions.readInt(hProcess, itemObj, 0x24, 4);
                        itemX = memoryFunctions.readFloat(hProcess, itemLocation, 0x28, 4);
                        itemY = memoryFunctions.readFloat(hProcess, itemLocation, 0x30, 4);
                        itemZ = memoryFunctions.readFloat(hProcess, itemLocation, 0x2C, 4);
                        VECTOR3 playerVec = new VECTOR3() { x = itemX, y = itemY, z = itemZ };

                        float deltaX = itemX - xPos;
                        float deltaY = itemY - yPos;
                        float deltaZ = itemZ - zPos;

                        string itemName = playerFunctions.getItemName(hProcess, itemObj);
                        itemName = itemName.ToLower();

                        double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));
                        playerVec = W2SN(playerVec, InvViewRight, InvViewUp, InvViewForward, InvViewTranslation, ViewPortMatrix, ProjD1, ProjD2);

                        if (playerVec.z > 0.1 && distanceToPlayer < 1500)
                        {
                            if (itemName.Contains(filterBox.Text) && filterBox.Text != null)
                            {

                                if (weaponCheck(itemName) == true)
                                {
                                    e.Graphics.FillRectangle(Brushes.Lime, playerVec.x, playerVec.y, 5, 5);
                                    e.Graphics.DrawString(itemName, font, Brushes.Lime, playerVec.x, playerVec.y + 10);
                                    e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Pink, playerVec.x, playerVec.y + 20);
                                }
                                else if (weaponESP != true)
                                {
                                    e.Graphics.FillRectangle(Brushes.Yellow, playerVec.x, playerVec.y, 5, 5);
                                    e.Graphics.DrawString(itemName, font, Brushes.Yellow, playerVec.x, playerVec.y + 10);
                                    e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Pink, playerVec.x, playerVec.y + 20);
                                }
                            }



                        }



                    }

                    for (int z = 0; z < droppedSize; z++)
                    {

                        int itemObj, itemLocation = 0;
                        float itemX, itemY, itemZ = 0;
                        itemObj = memoryFunctions.readInt(hProcess, dropepdTable, z * 0x4, 4);
                        itemLocation = memoryFunctions.readInt(hProcess, itemObj, 0x24, 4);
                        itemX = memoryFunctions.readFloat(hProcess, itemLocation, 0x28, 4);
                        itemY = memoryFunctions.readFloat(hProcess, itemLocation, 0x30, 4);
                        itemZ = memoryFunctions.readFloat(hProcess, itemLocation, 0x2C, 4);
                        VECTOR3 playerVec = new VECTOR3() { x = itemX, y = itemY, z = itemZ };

                        float deltaX = itemX - xPos;
                        float deltaY = itemY - yPos;
                        float deltaZ = itemZ - zPos;

                        string itemName = playerFunctions.getItemName(hProcess, itemObj);
                        itemName = itemName.ToLower();

                        double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));
                        playerVec = W2SN(playerVec, InvViewRight, InvViewUp, InvViewForward, InvViewTranslation, ViewPortMatrix, ProjD1, ProjD2);

                        if (playerVec.z > 0.1 && distanceToPlayer < 1500)
                        {
                            if (weaponCheck(itemName) == true)
                            {
                                e.Graphics.FillRectangle(Brushes.Lime, playerVec.x, playerVec.y, 5, 5);
                                e.Graphics.DrawString(itemName, font, Brushes.Lime, playerVec.x, playerVec.y + 10);
                                e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Pink, playerVec.x, playerVec.y + 20);
                            }
                            else if (weaponESP != true)
                            {
                                e.Graphics.FillRectangle(Brushes.Yellow, playerVec.x, playerVec.y, 5, 5);
                                e.Graphics.DrawString(itemName, font, Brushes.Yellow, playerVec.x, playerVec.y + 10);
                                e.Graphics.DrawString(Convert.ToString((int)distanceToPlayer), font, Brushes.Pink, playerVec.x, playerVec.y + 20);
                            }




                        }



                    }
                }


                //KEY BINDINGS
                ////////////////////////////////////////////

                if (GetAsyncKeyState(Keys.F1) < 0)
                {
                    hoverTimer.Stop();
                    fastTravelTimer.Stop();
                    hoverChk.Checked = false;
                    double distance = (double)f1TeleValue.Value;
                    float newXpos = (float)(xPos + (distance * xDirc));
                    float newYpos = (float)(yPos + (distance * yDirc));
                    landContact = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0199);


                    if (landContact == 0)
                    {
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x48, 4);
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x4C, 4);
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x50, 4);

                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x54, 4);
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x58, 4);
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x5C, 4);

                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x2C, 4);

                    }
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newXpos, 0x28, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newYpos, 0x30, 4);

                }
                if (GetAsyncKeyState(Keys.F2) < 0)
                {
                    double distance = (double)f2TeleValue.Value;
                    float newXpos = (float)(xPos + (distance * xDirc));
                    float newYpos = (float)(yPos + (distance * yDirc));
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newXpos, 0x28, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newYpos, 0x30, 4);

                }
                if (GetAsyncKeyState(Keys.F3) < 0)
                {
                    double distance = (double)f3f4TeleValue.Value;
                    float newXpos = (float)(xPos + (distance * xDirc));
                    float newYpos = (float)(yPos + (distance * yDirc));
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newXpos, 0x28, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newYpos, 0x30, 4);

                }
                if (GetAsyncKeyState(Keys.F4) < 0)
                {
                    double distance = (double)f3f4TeleValue.Value;
                    float newXpos = (float)(xPos - (distance * xDirc));
                    float newYpos = (float)(yPos - (distance * yDirc));
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newXpos, 0x28, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newYpos, 0x30, 4);


                }

                //air time hotkeys
                if (GetAsyncKeyState(Keys.F5) < 0)
                {
                    hoverTimer.Stop();
                    fastTravelTimer.Stop();
                    hoverChk.Checked = false;
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x4C, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x2C, 4);



                }

                if (GetAsyncKeyState(Keys.F6) < 0)
                {
                    float newZpos = zPos + (float)vertTeleValue.Value;
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newZpos, 0x2C, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x48, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x4C, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x50, 4);

                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x54, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x58, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x5C, 4);




                }
                if (GetAsyncKeyState(Keys.F7) < 0)
                {
                    float newZpos = zPos - (float)vertTeleValue.Value/5;
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, newZpos, 0x2C, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x48, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x4C, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x50, 4);

                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x54, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x58, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x5C, 4);

                }


                if (GetAsyncKeyState(Keys.F8) < 0)
                {
                    hoverCheck = !hoverCheck;
                    Thread.Sleep(200);
                }

                if (GetAsyncKeyState(Keys.F9) < 0)
                {
                    hoverTimer.Stop();
                    Thread.Sleep(200);
                    String travelTo = locationComboBox.Text;

                    mapLocations endLocation = locations.FirstOrDefault(o => o.locationName == travelTo);
                    locationToTravel = endLocation;
                    fastTravelTimer.Start();
                }


                if (GetAsyncKeyState(Keys.F10) < 0)
                {

                    memoryFunctions.writeInt(hProcess, localPlayerPointer, 402, 0x0CE0, 4);


                    Thread.Sleep(200);
                }

            }

            

        }

        private void tmrGraphicsTimer_Tick(object sender, EventArgs e)
        {
            drawingBoard.Refresh();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void playerCountTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void hackCountTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private mapLocations locationToTravel;


        private void fastTravelTimer_Tick(object sender, EventArgs e)
        {
            int localX = (int)memoryFunctions.readFloat(handle, localPlayerPosition, 0x28, 4);
            int localY = (int)memoryFunctions.readFloat(handle, localPlayerPosition, 0x30, 4);
            int localZ = (int)memoryFunctions.readFloat(handle, localPlayerPosition, 0x2C, 4);
            double distance = (double)fastTeleValue.Value;
            if (localZ < 900)
            {
                memoryFunctions.writeFloat(handle, localPlayerPosition, 901, 0x2c, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x48, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x4C, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x50, 4);

                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x54, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x58, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x5C, 4);
            }
            else
            {
                if (futureX.Value < localX)
                {
                    memoryFunctions.writeFloat(handle, localPlayerPosition, (float)(localX - distance), 0x28, 4);
                }
                if (futureX.Value > localX)
                {
                    memoryFunctions.writeFloat(handle, localPlayerPosition, (float)(localX + distance), 0x28, 4);
                }
                if (futureY.Value < localY)
                {
                    memoryFunctions.writeFloat(handle, localPlayerPosition, (float)(localY - distance), 0x30, 4);
                }
                if (futureY.Value > localY)
                {
                    memoryFunctions.writeFloat(handle, localPlayerPosition, (float)(localY + distance), 0x30, 4);
                }
            }

            if (localX == futureX.Value && localY == futureY.Value)
            {
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x48, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x4C, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x50, 4);

                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x54, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x58, 4);
                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x5C, 4);

                memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x2C, 4);
                fastTravelTimer.Stop();

            }

        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            int foreignPlayerTable = memoryFunctions.readInt(handle, foreignPlayerPointer, 0xC, 4);
            int foreignPlayerCount = memoryFunctions.readInt(handle, foreignPlayerPointer, 0x4, 4);

            int oldPlayerCount = _playerIDs.Count();
            for (int i = 0; i < foreignPlayerCount; i++)
            {
                int foreignPlayerID, foreignPlayerObj = 0;
                foreignPlayerID = memoryFunctions.readInt(handle, foreignPlayerObj, 0x07E0, 4);
                foreignPlayerObj = memoryFunctions.readInt(handle, memoryFunctions.readInt(handle, foreignPlayerTable, i * 0x2C, 4), 0x4, 4);
                if (foreignPlayerID > 1 && foreignPlayerID != localPlayerID)
                {
                    //memoryFunctions.writeInt(handle, foreignPlayerObj, 256, 0x0CE0, 4);

                }

            }
        }


        public struct VECTOR3
        {
            public float x;
            public float y;
            public float z;

            public float dot(VECTOR3 dot)
            {
                return (x * dot.x + y * dot.y + z * dot.z);
            }
        }

        public static VECTOR3 W2SN(VECTOR3 _in, VECTOR3 InvViewRight, VECTOR3 InvViewUp, VECTOR3 InvViewForward, VECTOR3 InvViewTranslation, VECTOR3 ViewPortMatrix, VECTOR3 ProjD1, VECTOR3 ProjD2)
        {
            VECTOR3 _out, temp;
            temp = SubVectorDist(_in, InvViewTranslation);
            float x = temp.dot(InvViewRight);
            float y = temp.dot(InvViewUp);
            float z = temp.dot(InvViewForward);

            _out.x = ViewPortMatrix.x * (1 + (x / ProjD1.x / z));
            _out.y = ViewPortMatrix.z * (1 - (y / ProjD2.z / z));
            _out.z = z;
            return _out;
        }

        static VECTOR3 SubVectorDist(VECTOR3 playerFrom, VECTOR3 playerTo)
        {
            return new VECTOR3()
            {
                x = playerFrom.x - playerTo.x,
                y = playerFrom.y - playerTo.y,
                z = playerFrom.z - playerTo.z
            };
        }

        public static VECTOR3 ReadVECTOR3(int pOffset)
        {
            float _x = memoryFunctions.readFloat(hProcess,pOffset,4);
            float _z = memoryFunctions.readFloat(hProcess, pOffset,0x4, 4);
            float _y = memoryFunctions.readFloat(hProcess, pOffset,0x8, 4);
            return new VECTOR3
            {
                x = _x,
                y = _y,
                z = _z
            };
        }
        public static int isConnected = memoryFunctions.readByte(handle, localPlayerPointer, 0x019C);
        public static int isDead = memoryFunctions.readByte(handle, localPlayerPointer, 0x0274);
        private void disconnectTimer_Tick(object sender, EventArgs e)
        {
            int localPlayer = memoryFunctions.readInt(hProcess, baseAddress, 0x1694, 4);
            int localPlayerPointer = memoryFunctions.readInt(hProcess, localPlayer, 0x4, 4);
            int localPlayerPosition = memoryFunctions.readInt(hProcess, localPlayerPointer, 0x24, 4);
            int localPlayerID = memoryFunctions.readInt(hProcess, localPlayerPointer, 0x07E8, 4);

            isConnected = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x019C);
            isDead = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0274);

            if (isConnected == 0)
            {
               // stopRefresh = true;
            }
            else if (isDead == 1)
            {
               // stopRefresh = true;

            }
            else
            {
                stopRefresh = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gamePanel.BringToFront();
            gamePanel.Visible = !gamePanel.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enemyPanel.BringToFront();
            enemyPanel.Visible = !enemyPanel.Visible;
            localPanel.Visible = false;
            travelPanel.Visible = false;
            teleportPanel.Visible = false;
            espPanel.Visible = false;
            itemPanel.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            localPanel.BringToFront();
            localPanel.Visible = !localPanel.Visible;
            enemyPanel.Visible = false;
            travelPanel.Visible = false;
            teleportPanel.Visible = false;
            espPanel.Visible = false;
            itemPanel.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            travelPanel.BringToFront();
            travelPanel.Visible = !travelPanel.Visible;
            localPanel.Visible = false;
            enemyPanel.Visible = false;
            teleportPanel.Visible = false;
            espPanel.Visible = false;
            itemPanel.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            teleportPanel.BringToFront();
            teleportPanel.Visible = !teleportPanel.Visible;
            localPanel.Visible = false;
            enemyPanel.Visible = false;
            travelPanel.Visible = false;
            espPanel.Visible = false;
            itemPanel.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            espPanel.BringToFront();
            espPanel.Visible = !espPanel.Visible;
            localPanel.Visible = false;
            enemyPanel.Visible = false;
            travelPanel.Visible = false;
            teleportPanel.Visible = false;
            itemPanel.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            itemPanel.BringToFront();
            itemPanel.Visible = !itemPanel.Visible;
            localPanel.Visible = false;
            enemyPanel.Visible = false;
            travelPanel.Visible = false;
            teleportPanel.Visible = false;
            espPanel.Visible = false;
        }

        private void getItem_Click_1(object sender, EventArgs e)
        {
            String travelTo = itemListBox.Text;

            itemStruct item = itemStructList.FirstOrDefault(o => o.itemName == travelTo);
            int itemLocation = memoryFunctions.readInt(hProcess, item.itemID, 0x24, 4);

            float localX = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
            float localY = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
            float localZ = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

            memoryFunctions.writeFloat(hProcess, itemLocation, (float)(localX + 0.5), 0x28, 4);
            memoryFunctions.writeFloat(hProcess, itemLocation, (float)(localY + 0.5), 0x30, 4);
            memoryFunctions.writeFloat(hProcess, itemLocation, localZ + 1, 0x2C, 4);

        }

        private void gameOverlay_Deactivate(object sender, EventArgs e)
        {
           // gamePanel.Visible = false;
            //enemyPanel.Visible = false;
            //localPanel.Visible = false;
            //travelPanel.Visible = false;
            //teleportPanel.Visible = false;
            //espPanel.Visible = false;
            //itemPanel.Visible = false;

        }

        private void hoverTimer_Tick(object sender, EventArgs e)
        {
            memoryFunctions.writeByte(handle, localPlayerPointer, 1, 0x0199);
            //memoryFunctions.writeFloat(handle, localPlayerPosition, 1, 0x4c, 4);
            //consoleTxt.Text = (memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0199)).ToString();
        }

        private void travelBtn_Click_1(object sender, EventArgs e)
        {
            hoverTimer.Stop();
            String travelTo = locationComboBox.Text;

            mapLocations endLocation = locations.FirstOrDefault(o => o.locationName == travelTo);
            locationToTravel = endLocation;
            fastTravelTimer.Start();
        }

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String travelTo = locationComboBox.Text;

            mapLocations endLocation = locations.FirstOrDefault(o => o.locationName == travelTo);

            futureX.Value = endLocation.locationX;
            futureY.Value = endLocation.locationY;
        
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gamePanel_Click(object sender, EventArgs e)
        {
            gamePanel.BringToFront();
        }

        private void enemyPanel_Click(object sender, EventArgs e)
        {
            enemyPanel.BringToFront();
        }

        private void localPanel_Click(object sender, EventArgs e)
        {
            localPanel.BringToFront();
        }

        private void travelPanel_Click(object sender, EventArgs e)
        {
            travelPanel.BringToFront();
        }

        private void teleportPanel_Click(object sender, EventArgs e)
        {
            teleportPanel.BringToFront();
        }

        private void espPanel_Click(object sender, EventArgs e)
        {
            espPanel.BringToFront();
        }

        private void itemPanel_Click(object sender, EventArgs e)
        {
            itemPanel.BringToFront();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gameBox_Enter(object sender, EventArgs e)
        {
            gamePanel.BringToFront();
        }

        private void enemyBox_Enter(object sender, EventArgs e)
        {
            enemyBox.BringToFront();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            groupBox3.BringToFront();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            groupBox4.BringToFront();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            groupBox5.BringToFront();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
            groupBox6.BringToFront();
        }

        private void itemPanel_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {
            groupBox7.BringToFront();
        }

        private void gamePanel_Enter(object sender, EventArgs e)
        {
            gamePanel.BringToFront();
        }

        private void gamePanel_MouseEnter(object sender, EventArgs e)
        {

        }

        private void itemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void itemTimer_Tick(object sender, EventArgs e)
        {
            int nearItemSize = memoryFunctions.readInt(hProcess, baseAddress, 0x11B8, 4);
            int nearItemTable = memoryFunctions.readInt(hProcess, baseAddress, 0x11B4, 4);

            string itemSearch = itemSearchBox.Text;
            float xPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
            float yPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
            float zPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

            for (int z = 0; z < nearItemSize; z++)
            {

                int itemObj, itemLocation = 0;
                float itemX, itemY, itemZ = 0;
                itemObj = memoryFunctions.readInt(hProcess, nearItemTable, z * 0x4, 4);
                itemLocation = memoryFunctions.readInt(hProcess, itemObj, 0x20, 4);
                itemX = memoryFunctions.readFloat(hProcess, itemLocation, 0x28, 4);
                itemY = memoryFunctions.readFloat(hProcess, itemLocation, 0x30, 4);
                itemZ = memoryFunctions.readFloat(hProcess, itemLocation, 0x2C, 4);


                float localX = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
                float localY = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
                float localZ = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

                float deltaX = itemX - xPos;
                float deltaY = itemY - yPos;
                float deltaZ = itemZ - zPos;

                string itemName = playerFunctions.getItemName(hProcess, itemObj);
                itemName = itemName.ToLower();



                if (itemMagnet == true && itemName.Contains(itemSearch) && itemSearch != "")
                {

                    memoryFunctions.writeFloat(hProcess, itemLocation, localX + 1, 0x28, 4);
                    memoryFunctions.writeFloat(hProcess, itemLocation, localY + 1, 0x30, 4);
                    memoryFunctions.writeFloat(hProcess, itemLocation, localZ + 1, 0x2C, 4);
                }



            }

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
        


    }
}
