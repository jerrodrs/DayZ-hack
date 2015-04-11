namespace dayz_toolkit
{
    partial class dayztk
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeOfDayBar = new System.Windows.Forms.HScrollBar();
            this.label16 = new System.Windows.Forms.Label();
            this.hackCountTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.playerCountTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.consoleTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.itemSearchBox = new System.Windows.Forms.TextBox();
            this.weatherChk = new System.Windows.Forms.CheckBox();
            this.antiFallChk = new System.Windows.Forms.CheckBox();
            this.hoverChk = new System.Windows.Forms.CheckBox();
            this.itemMagChk = new System.Windows.Forms.CheckBox();
            this.noRecoilChk = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.futureZ = new System.Windows.Forms.NumericUpDown();
            this.futureY = new System.Windows.Forms.NumericUpDown();
            this.futureX = new System.Windows.Forms.NumericUpDown();
            this.localZNum = new System.Windows.Forms.NumericUpDown();
            this.localYNum = new System.Windows.Forms.NumericUpDown();
            this.localXNum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.travelBtn = new System.Windows.Forms.Button();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fastTeleValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.vertTeleValue = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.f3f4TeleValue = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.f2TeleValue = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.f1TeleValue = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.playerList = new System.Windows.Forms.ListBox();
            this.weaponESPChk = new System.Windows.Forms.CheckBox();
            this.itemEspChk = new System.Windows.Forms.CheckBox();
            this.showZmbChk = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.playerESPChk = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.disconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.fastTravelTimer = new System.Windows.Forms.Timer(this.components);
            this.hoverTimer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.futureZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.futureY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.futureX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localZNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localYNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localXNum)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastTeleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertTeleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f3f4TeleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2TeleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1TeleValue)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeOfDayBar);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.hackCountTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.playerCountTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.consoleTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // timeOfDayBar
            // 
            this.timeOfDayBar.LargeChange = 1;
            this.timeOfDayBar.Location = new System.Drawing.Point(94, 108);
            this.timeOfDayBar.Maximum = 10;
            this.timeOfDayBar.Minimum = -10;
            this.timeOfDayBar.Name = "timeOfDayBar";
            this.timeOfDayBar.Size = new System.Drawing.Size(215, 17);
            this.timeOfDayBar.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 15);
            this.label16.TabIndex = 8;
            this.label16.Text = "Time of Day:";
            // 
            // hackCountTxt
            // 
            this.hackCountTxt.Location = new System.Drawing.Point(250, 74);
            this.hackCountTxt.Name = "hackCountTxt";
            this.hackCountTxt.ReadOnly = true;
            this.hackCountTxt.Size = new System.Drawing.Size(59, 22);
            this.hackCountTxt.TabIndex = 7;
            this.hackCountTxt.TextChanged += new System.EventHandler(this.hackCountTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hack Count:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // playerCountTxt
            // 
            this.playerCountTxt.Location = new System.Drawing.Point(94, 74);
            this.playerCountTxt.Name = "playerCountTxt";
            this.playerCountTxt.ReadOnly = true;
            this.playerCountTxt.Size = new System.Drawing.Size(62, 22);
            this.playerCountTxt.TabIndex = 5;
            this.playerCountTxt.TextChanged += new System.EventHandler(this.playerCountTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player Count:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // consoleTxt
            // 
            this.consoleTxt.Location = new System.Drawing.Point(62, 21);
            this.consoleTxt.Multiline = true;
            this.consoleTxt.Name = "consoleTxt";
            this.consoleTxt.ReadOnly = true;
            this.consoleTxt.Size = new System.Drawing.Size(247, 47);
            this.consoleTxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Debug:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.playerComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 102);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enemy Players";
            // 
            // playerComboBox
            // 
            this.playerComboBox.FormattingEnabled = true;
            this.playerComboBox.Location = new System.Drawing.Point(59, 19);
            this.playerComboBox.Name = "playerComboBox";
            this.playerComboBox.Size = new System.Drawing.Size(250, 23);
            this.playerComboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Player:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.itemSearchBox);
            this.groupBox3.Controls.Add(this.weatherChk);
            this.groupBox3.Controls.Add(this.antiFallChk);
            this.groupBox3.Controls.Add(this.hoverChk);
            this.groupBox3.Controls.Add(this.itemMagChk);
            this.groupBox3.Controls.Add(this.noRecoilChk);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 102);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local Player";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "Launch Item Browser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // itemSearchBox
            // 
            this.itemSearchBox.Location = new System.Drawing.Point(87, 21);
            this.itemSearchBox.Name = "itemSearchBox";
            this.itemSearchBox.Size = new System.Drawing.Size(119, 22);
            this.itemSearchBox.TabIndex = 8;
            // 
            // weatherChk
            // 
            this.weatherChk.AutoSize = true;
            this.weatherChk.Location = new System.Drawing.Point(191, 72);
            this.weatherChk.Name = "weatherChk";
            this.weatherChk.Size = new System.Drawing.Size(87, 19);
            this.weatherChk.TabIndex = 7;
            this.weatherChk.Text = "No Weather";
            this.weatherChk.UseVisualStyleBackColor = true;
            // 
            // antiFallChk
            // 
            this.antiFallChk.AutoSize = true;
            this.antiFallChk.Checked = true;
            this.antiFallChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antiFallChk.Location = new System.Drawing.Point(104, 72);
            this.antiFallChk.Name = "antiFallChk";
            this.antiFallChk.Size = new System.Drawing.Size(68, 19);
            this.antiFallChk.TabIndex = 6;
            this.antiFallChk.Text = "Anti Fall";
            this.antiFallChk.UseVisualStyleBackColor = true;
            // 
            // hoverChk
            // 
            this.hoverChk.AutoSize = true;
            this.hoverChk.Location = new System.Drawing.Point(17, 72);
            this.hoverChk.Name = "hoverChk";
            this.hoverChk.Size = new System.Drawing.Size(57, 19);
            this.hoverChk.TabIndex = 5;
            this.hoverChk.Text = "Hover";
            this.hoverChk.UseVisualStyleBackColor = true;
            // 
            // itemMagChk
            // 
            this.itemMagChk.AutoSize = true;
            this.itemMagChk.Location = new System.Drawing.Point(104, 47);
            this.itemMagChk.Name = "itemMagChk";
            this.itemMagChk.Size = new System.Drawing.Size(91, 19);
            this.itemMagChk.TabIndex = 4;
            this.itemMagChk.Text = "Item Magnet";
            this.itemMagChk.UseVisualStyleBackColor = true;
            this.itemMagChk.CheckedChanged += new System.EventHandler(this.itemMagChk_CheckedChanged);
            // 
            // noRecoilChk
            // 
            this.noRecoilChk.AutoSize = true;
            this.noRecoilChk.Checked = true;
            this.noRecoilChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noRecoilChk.Location = new System.Drawing.Point(17, 47);
            this.noRecoilChk.Name = "noRecoilChk";
            this.noRecoilChk.Size = new System.Drawing.Size(75, 19);
            this.noRecoilChk.TabIndex = 2;
            this.noRecoilChk.Text = "No Recoil";
            this.noRecoilChk.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Item Search:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.futureZ);
            this.groupBox4.Controls.Add(this.futureY);
            this.groupBox4.Controls.Add(this.futureX);
            this.groupBox4.Controls.Add(this.localZNum);
            this.groupBox4.Controls.Add(this.localYNum);
            this.groupBox4.Controls.Add(this.localXNum);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.travelBtn);
            this.groupBox4.Controls.Add(this.locationComboBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(6, 382);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 133);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fast Travel";
            // 
            // futureZ
            // 
            this.futureZ.Location = new System.Drawing.Point(237, 85);
            this.futureZ.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.futureZ.Name = "futureZ";
            this.futureZ.Size = new System.Drawing.Size(72, 22);
            this.futureZ.TabIndex = 10;
            // 
            // futureY
            // 
            this.futureY.Location = new System.Drawing.Point(162, 85);
            this.futureY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.futureY.Name = "futureY";
            this.futureY.Size = new System.Drawing.Size(69, 22);
            this.futureY.TabIndex = 9;
            // 
            // futureX
            // 
            this.futureX.Location = new System.Drawing.Point(87, 85);
            this.futureX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.futureX.Name = "futureX";
            this.futureX.Size = new System.Drawing.Size(69, 22);
            this.futureX.TabIndex = 8;
            // 
            // localZNum
            // 
            this.localZNum.Location = new System.Drawing.Point(237, 52);
            this.localZNum.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.localZNum.Name = "localZNum";
            this.localZNum.Size = new System.Drawing.Size(72, 22);
            this.localZNum.TabIndex = 7;
            // 
            // localYNum
            // 
            this.localYNum.Location = new System.Drawing.Point(162, 52);
            this.localYNum.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.localYNum.Name = "localYNum";
            this.localYNum.Size = new System.Drawing.Size(69, 22);
            this.localYNum.TabIndex = 6;
            // 
            // localXNum
            // 
            this.localXNum.Location = new System.Drawing.Point(87, 52);
            this.localXNum.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.localXNum.Name = "localXNum";
            this.localXNum.Size = new System.Drawing.Size(69, 22);
            this.localXNum.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Future XYZ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Current XYZ:";
            // 
            // travelBtn
            // 
            this.travelBtn.Location = new System.Drawing.Point(263, 18);
            this.travelBtn.Name = "travelBtn";
            this.travelBtn.Size = new System.Drawing.Size(46, 23);
            this.travelBtn.TabIndex = 2;
            this.travelBtn.Text = "Travel";
            this.travelBtn.UseVisualStyleBackColor = true;
            this.travelBtn.Click += new System.EventHandler(this.travelBtn_Click);
            // 
            // locationComboBox
            // 
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(76, 19);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(181, 23);
            this.locationComboBox.TabIndex = 1;
            this.locationComboBox.SelectedIndexChanged += new System.EventHandler(this.locationComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Location:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.fastTeleValue);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.vertTeleValue);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.f3f4TeleValue);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.f2TeleValue);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.f1TeleValue);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(338, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 178);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Teleporting";
            // 
            // fastTeleValue
            // 
            this.fastTeleValue.DecimalPlaces = 2;
            this.fastTeleValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.fastTeleValue.Location = new System.Drawing.Point(80, 130);
            this.fastTeleValue.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fastTeleValue.Name = "fastTeleValue";
            this.fastTeleValue.Size = new System.Drawing.Size(105, 22);
            this.fastTeleValue.TabIndex = 9;
            this.fastTeleValue.Value = new decimal(new int[] {
            170,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fast Travel:";
            // 
            // vertTeleValue
            // 
            this.vertTeleValue.DecimalPlaces = 2;
            this.vertTeleValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.vertTeleValue.Location = new System.Drawing.Point(80, 102);
            this.vertTeleValue.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.vertTeleValue.Name = "vertTeleValue";
            this.vertTeleValue.Size = new System.Drawing.Size(105, 22);
            this.vertTeleValue.TabIndex = 7;
            this.vertTeleValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "Vert Teli:";
            // 
            // f3f4TeleValue
            // 
            this.f3f4TeleValue.DecimalPlaces = 2;
            this.f3f4TeleValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.f3f4TeleValue.Location = new System.Drawing.Point(80, 74);
            this.f3f4TeleValue.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.f3f4TeleValue.Name = "f3f4TeleValue";
            this.f3f4TeleValue.Size = new System.Drawing.Size(105, 22);
            this.f3f4TeleValue.TabIndex = 5;
            this.f3f4TeleValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "F3/F4 Tele:";
            // 
            // f2TeleValue
            // 
            this.f2TeleValue.DecimalPlaces = 1;
            this.f2TeleValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.f2TeleValue.Location = new System.Drawing.Point(80, 46);
            this.f2TeleValue.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.f2TeleValue.Name = "f2TeleValue";
            this.f2TeleValue.Size = new System.Drawing.Size(105, 22);
            this.f2TeleValue.TabIndex = 3;
            this.f2TeleValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "F2 Tele:";
            // 
            // f1TeleValue
            // 
            this.f1TeleValue.DecimalPlaces = 1;
            this.f1TeleValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.f1TeleValue.Location = new System.Drawing.Point(80, 18);
            this.f1TeleValue.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.f1TeleValue.Name = "f1TeleValue";
            this.f1TeleValue.Size = new System.Drawing.Size(105, 22);
            this.f1TeleValue.TabIndex = 1;
            this.f1TeleValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.f1TeleValue.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "F1 Tele:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.playerList);
            this.groupBox6.Controls.Add(this.weaponESPChk);
            this.groupBox6.Controls.Add(this.itemEspChk);
            this.groupBox6.Controls.Add(this.showZmbChk);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.playerESPChk);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Location = new System.Drawing.Point(338, 210);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 355);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ESP";
            // 
            // playerList
            // 
            this.playerList.FormattingEnabled = true;
            this.playerList.ItemHeight = 15;
            this.playerList.Location = new System.Drawing.Point(15, 39);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(170, 229);
            this.playerList.TabIndex = 7;
            // 
            // weaponESPChk
            // 
            this.weaponESPChk.AutoSize = true;
            this.weaponESPChk.Location = new System.Drawing.Point(99, 325);
            this.weaponESPChk.Name = "weaponESPChk";
            this.weaponESPChk.Size = new System.Drawing.Size(74, 19);
            this.weaponESPChk.TabIndex = 6;
            this.weaponESPChk.Text = "Weapons";
            this.weaponESPChk.UseVisualStyleBackColor = true;
            // 
            // itemEspChk
            // 
            this.itemEspChk.AutoSize = true;
            this.itemEspChk.Location = new System.Drawing.Point(14, 325);
            this.itemEspChk.Name = "itemEspChk";
            this.itemEspChk.Size = new System.Drawing.Size(54, 19);
            this.itemEspChk.TabIndex = 5;
            this.itemEspChk.Text = "Items";
            this.itemEspChk.UseVisualStyleBackColor = true;
            // 
            // showZmbChk
            // 
            this.showZmbChk.AutoSize = true;
            this.showZmbChk.Location = new System.Drawing.Point(99, 300);
            this.showZmbChk.Name = "showZmbChk";
            this.showZmbChk.Size = new System.Drawing.Size(70, 19);
            this.showZmbChk.TabIndex = 4;
            this.showZmbChk.Text = "Zombies";
            this.showZmbChk.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 15);
            this.label14.TabIndex = 3;
            this.label14.Text = "3D ESP Settings:";
            // 
            // playerESPChk
            // 
            this.playerESPChk.AutoSize = true;
            this.playerESPChk.Checked = true;
            this.playerESPChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playerESPChk.Location = new System.Drawing.Point(15, 300);
            this.playerESPChk.Name = "playerESPChk";
            this.playerESPChk.Size = new System.Drawing.Size(63, 19);
            this.playerESPChk.TabIndex = 2;
            this.playerESPChk.Text = "Players";
            this.playerESPChk.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Players Near:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingsToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // bindingsToolStripMenuItem
            // 
            this.bindingsToolStripMenuItem.Name = "bindingsToolStripMenuItem";
            this.bindingsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.bindingsToolStripMenuItem.Text = "Bindings";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // disconnectTimer
            // 
            this.disconnectTimer.Enabled = true;
            this.disconnectTimer.Tick += new System.EventHandler(this.disconnectTimer_Tick);
            // 
            // fastTravelTimer
            // 
            this.fastTravelTimer.Interval = 10;
            this.fastTravelTimer.Tick += new System.EventHandler(this.fastTravelTimer_Tick);
            // 
            // hoverTimer
            // 
            this.hoverTimer.Interval = 1;
            this.hoverTimer.Tick += new System.EventHandler(this.hoverTimer_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // dayztk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 577);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dayztk";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dayz Toolkit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.futureZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.futureY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.futureX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localZNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localYNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localXNum)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastTeleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertTeleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f3f4TeleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f2TeleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f1TeleValue)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox consoleTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerCountTxt;
        private System.Windows.Forms.TextBox hackCountTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox weatherChk;
        private System.Windows.Forms.CheckBox antiFallChk;
        private System.Windows.Forms.CheckBox hoverChk;
        private System.Windows.Forms.CheckBox itemMagChk;
        private System.Windows.Forms.CheckBox noRecoilChk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown futureZ;
        private System.Windows.Forms.NumericUpDown futureY;
        private System.Windows.Forms.NumericUpDown futureX;
        private System.Windows.Forms.NumericUpDown localZNum;
        private System.Windows.Forms.NumericUpDown localYNum;
        private System.Windows.Forms.NumericUpDown localXNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button travelBtn;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown f3f4TeleValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown f2TeleValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown f1TeleValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox weaponESPChk;
        private System.Windows.Forms.CheckBox itemEspChk;
        private System.Windows.Forms.CheckBox showZmbChk;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox playerESPChk;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bindingsToolStripMenuItem;
        private System.Windows.Forms.ListBox playerList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown vertTeleValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.HScrollBar timeOfDayBar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox itemSearchBox;
        private System.Windows.Forms.Timer disconnectTimer;
        private System.Windows.Forms.Timer fastTravelTimer;
        private System.Windows.Forms.Timer hoverTimer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox playerComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown fastTeleValue;
        private System.Windows.Forms.Label label5;
    }
}

