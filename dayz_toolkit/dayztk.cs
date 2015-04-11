using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;


namespace dayz_toolkit
{
    public partial class dayztk : Form
    {

        public dayztk()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void setConsoleText(string message)
        {

            this.consoleTxt.Text = message;

        }


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




        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        public static IntPtr handle = memoryFunctions.findDayzProcess();

        static int baseAddress = memoryFunctions.readInt(handle, 0x010810D0, 4);

        //local players
        static int localPlayer = memoryFunctions.readInt(handle, baseAddress, 0x15C4, 4);
        static int localPlayerPointer = memoryFunctions.readInt(handle, localPlayer, 0x4, 4);
        static int localPlayerPosition = memoryFunctions.readInt(handle, localPlayerPointer, 0x20, 4);
        static int localPlayerID = memoryFunctions.readInt(handle, localPlayerPointer, 0x07E0, 4);

        //foreign players
        static int foreignPlayerPointer = memoryFunctions.readInt(handle, baseAddress, 0x778, 4);

        static bool fallCheck = false;
        static bool recoilCheck = false;
        static bool zombieESP = false;
        static bool itemESP = false;
        static bool playerESP = false;
        static bool itemMagnet = false;
        static bool weaponESP = false;
        static bool disarmCheck = false;
        static bool weatherCheck = false;
        static bool f6ON = false;
        static bool hoverBool = false;
        static bool hoverCheck = false;

        float oldZ;

        int landContact;

        public static int isConnected = memoryFunctions.readByte(handle, localPlayerPointer, 0x019C);
        public static int isDead = memoryFunctions.readByte(handle, localPlayerPointer, 0x027C);

        static List<string> _playerIDs = new List<string>();
        static List<string> _playerIDsCombo = new List<string>();
        static List<string> _playerIDCompare = new List<string>();


        public void getVariables()
        {
            //local players
            localPlayer = memoryFunctions.readInt(handle, baseAddress, 0x15C4, 4);
            localPlayerPointer = memoryFunctions.readInt(handle, localPlayer, 0x4, 4);
            localPlayerPosition = memoryFunctions.readInt(handle, localPlayerPointer, 0x20, 4);
            localPlayerID = memoryFunctions.readInt(handle, localPlayerPointer, 0x07E0, 4);

            //foreign players
            foreignPlayerPointer = memoryFunctions.readInt(handle, baseAddress, 0x778, 4);
        }


        public static bool getZombieESP()
        {
            return zombieESP;
        }
        public static bool getItemESP()
        {
            return itemESP;
        }
        public static bool getPlayerESP()
        {
            return playerESP;
        }
        public static bool getWeaponESP()
        {
            return weaponESP;
        }

        List<mapLocations> locations = new List<mapLocations>();
        List<String> locationNames = new List<string>();

        private void doWork()
        {
            IntPtr hProcess = handle;
            int[] playerlist = new int[100];
            List<player> _playerComboBox = new List<player>();


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
            else
            {
                consoleTxt.Text = "Local Player Connected";






                //anti fall
                fallCheck = this.antiFallChk.Checked;
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
                //disarmCheck
                // disarmCheck = disarmChk.Checked;
                //weatherCheck
                weatherCheck = weatherChk.Checked;
                //hoverCheck
                hoverCheck = hoverChk.Checked;

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
                //time of day
                if (weatherCheck == true)
                {
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x1608, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x160C, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x1620, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x1624, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x1614, 4);
                    memoryFunctions.writeFloat(hProcess, baseAddress, (float)0, 0x1618, 4);
                }


                float timeOfDay = (this.timeOfDayBar.Value) / 10;

                memoryFunctions.writeFloat(hProcess, baseAddress, (float)timeOfDay, 0x163C, 4);


                //local positions
                float xPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x28, 4);
                float yPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x30, 4);
                float zPos = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x2C, 4);

                oldZ = zPos;




                landContact = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0199);

                if (fallCheck == true && hoverCheck == false)
                {
                    landContact = memoryFunctions.readByte(hProcess, localPlayerPointer, 0x0199);


                    if (landContact == 0 && hoverCheck == false)
                    {
                        //memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x48, 4);
                        memoryFunctions.writeFloat(hProcess, localPlayerPosition, -2, 0x4C, 4);
                        //memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x50, 4);

                        //memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x54, 4);
                        //memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x58, 4);
                        //memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x5C, 4);

                        //memoryFunctions.writeFloat(hProcess, localPlayerPosition, 0, 0x2C, 4);

                    }

                }
                f6ON = false;

                if (recoilCheck == true)
                {
                    memoryFunctions.writeFloat(hProcess, localPlayerPointer, 0, 0x0C34, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPointer, 0, 0x0C50, 4);
                    memoryFunctions.writeFloat(hProcess, localPlayerPointer, 1, 0x0C54, 4);
                }



                float xDirc = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x1C, 4);
                float yDirc = memoryFunctions.readFloat(hProcess, localPlayerPosition, 0x24, 4);

                this.localXNum.Value = (decimal)xPos;
                this.localYNum.Value = (decimal)yPos;
                this.localZNum.Value = (decimal)zPos;

                //Debug.WriteLine(playerFunctions.getItemName(hProcess, memoryFunctions.readInt(hProcess, localPlayerPointer, 0xA44, 4)));



                //foreign values for this table
                int foreignPlayerTable = memoryFunctions.readInt(hProcess, foreignPlayerPointer, 0xC, 4);
                int foreignPlayerCount = memoryFunctions.readInt(hProcess, foreignPlayerPointer, 0x4, 4);

                int oldPlayerCount = _playerIDs.Count();
                _playerIDs.Clear();
                _playerIDsCombo.Clear();
                for (int i = 0; i < foreignPlayerCount; i++)
                {
                    int foreignPlayerID, foreignPlayerObj, foreignPlayerLocation = 0;
                    float foreignX, foreignY, foreignZ = 0;
                    foreignPlayerObj = memoryFunctions.readInt(hProcess, memoryFunctions.readInt(hProcess, foreignPlayerTable, i * 0x2C, 4), 0x4, 4);
                    foreignPlayerID = memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x07E0, 4);
                    foreignPlayerLocation = memoryFunctions.readInt(hProcess, foreignPlayerObj, 0x20, 4);
                    foreignX = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x28, 4);
                    foreignY = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x30, 4);
                    foreignZ = memoryFunctions.readFloat(hProcess, foreignPlayerLocation, 0x2C, 4);
                    //string playerName = "-";
                    string playerName = playerFunctions.getPlayerName(hProcess, foreignPlayerID);

                    //calculate distances to foreignplayers
                    float deltaX = foreignX - xPos;
                    float deltaY = foreignY - yPos;
                    float deltaZ = foreignZ - zPos;

                    double distanceToPlayer = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2) + Math.Pow((deltaZ), 2));

                    double foreignAngleX = (distanceToPlayer * Math.Cos(deltaX));
                    double foreignAngleY = (distanceToPlayer * Math.Sin(deltaY));

                    double crosshairX = (distanceToPlayer * xDirc);
                    double crosshairY = (distanceToPlayer * yDirc);

                    double angle = Math.Abs(Math.Atan2((foreignAngleY - crosshairY), (foreignAngleX - crosshairX)) * 180 / Math.PI);

                    if (foreignPlayerID > 1 && distanceToPlayer > 0 && distanceToPlayer < 5000 && foreignPlayerID != localPlayerID)
                    {


                        player currentPlayer = new player(foreignPlayerID, playerName, i, foreignPlayerObj, foreignX, foreignY, foreignZ, 0, 0);
                        //_playerComboBox.Add(currentPlayer);
                        playerlist[i] = foreignPlayerObj;
                        String nameId = playerName;
                        _playerIDsCombo.Add(nameId);
                        nameId = playerName;
                        _playerIDs.Add(nameId);



                        if (disarmCheck == true)
                        {
                            //memoryFunctions.writeInt(hProcess, foreignPlayerObj,197, 0x0CE0, 4);
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


                int nearItemSize = memoryFunctions.readInt(hProcess, baseAddress, 0x11B8, 4);
                int nearItemTable = memoryFunctions.readInt(hProcess, baseAddress, 0x11B4, 4);

                string itemSearch = itemSearchBox.Text;

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
                    float newZpos = zPos - (float)vertTeleValue.Value;
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
                    hoverChk.Checked = !hoverCheck;
                    Thread.Sleep(500);
                    /*hoverBool = !hoverBool;
                    if (hoverBool == true)
                    {
                        hoverTimer.Start();
                    }
                    if (hoverBool == false)
                    {
                        hoverTimer.Stop();
                    }
                    Thread.Sleep(200);*/

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


                //memoryFunctions.writeInt(hProcess, localPlayerPointer, 265, 0x0CE0, 4);
                if (GetAsyncKeyState(Keys.F10) < 0)
                {

                    memoryFunctions.writeInt(hProcess, localPlayerPointer, 402, 0x0CE0, 4);


                    Thread.Sleep(200);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.doWork();   
        }

        private void disconnectTimer_Tick(object sender, EventArgs e)
        {
            getVariables();
            isConnected = memoryFunctions.readByte(handle, localPlayerPointer, 0x019C);
            isDead = memoryFunctions.readByte(handle, localPlayerPointer, 0x027C);
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

        private void travelBtn_Click(object sender, EventArgs e)
        {
            hoverTimer.Stop();
            String travelTo = locationComboBox.Text;

            mapLocations endLocation = locations.FirstOrDefault(o => o.locationName == travelTo);
            locationToTravel = endLocation;
            fastTravelTimer.Start();
        }

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

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String travelTo = locationComboBox.Text;

            mapLocations endLocation = locations.FirstOrDefault(o => o.locationName == travelTo);

            futureX.Value = endLocation.locationX;
            futureY.Value = endLocation.locationY;
        }

        private void hoverTimer_Tick(object sender, EventArgs e)
        {
            memoryFunctions.writeByte(handle, localPlayerPointer, 1, 0x0199);

            //memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x48, 4);
            //memoryFunctions.writeFloat(handle, localPlayerPosition, 3, 0x4C, 4);
            //memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x50, 4);
            //memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x54, 4);
            //memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x58, 4);
            //memoryFunctions.writeFloat(handle, localPlayerPosition, 0, 0x5C, 4);


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

        private void button1_Click_1(object sender, EventArgs e)
        {
            playerItems form = new playerItems();
            form.TopMost = true;
            form.Show();
        }

        private void itemMagChk_CheckedChanged(object sender, EventArgs e)
        {

        }



    }
}
