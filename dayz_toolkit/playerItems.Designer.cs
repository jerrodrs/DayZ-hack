namespace dayz_toolkit
{
    partial class playerItems
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
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.itemRefresh = new System.Windows.Forms.Timer(this.components);
            this.getItem = new System.Windows.Forms.Button();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.itemListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // itemListBox
            // 
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.ItemHeight = 15;
            this.itemListBox.Location = new System.Drawing.Point(6, 21);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(357, 259);
            this.itemListBox.TabIndex = 0;
            // 
            // itemRefresh
            // 
            this.itemRefresh.Enabled = true;
            this.itemRefresh.Tick += new System.EventHandler(this.itemRefresh_Tick);
            // 
            // getItem
            // 
            this.getItem.Location = new System.Drawing.Point(12, 334);
            this.getItem.Name = "getItem";
            this.getItem.Size = new System.Drawing.Size(369, 23);
            this.getItem.TabIndex = 1;
            this.getItem.Text = "Teleport to Local";
            this.getItem.UseVisualStyleBackColor = true;
            this.getItem.Click += new System.EventHandler(this.getItem_Click);
            // 
            // filterBox
            // 
            this.filterBox.Location = new System.Drawing.Point(54, 307);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(327, 22);
            this.filterBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter:";
            // 
            // playerItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.getItem);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "playerItems";
            this.Text = "playerItems";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox itemListBox;
        private System.Windows.Forms.Timer itemRefresh;
        private System.Windows.Forms.Button getItem;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.Label label1;
    }
}