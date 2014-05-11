namespace CryptoTriangular
{
    partial class CurrenciesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrenciesWindow));
            this.cb_Bitcoin = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NXT = new System.Windows.Forms.CheckBox();
            this.QRK = new System.Windows.Forms.CheckBox();
            this.WDC = new System.Windows.Forms.CheckBox();
            this.PPC = new System.Windows.Forms.CheckBox();
            this.AUR = new System.Windows.Forms.CheckBox();
            this.DOGE = new System.Windows.Forms.CheckBox();
            this.cb_Litecoin = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IFC = new System.Windows.Forms.CheckBox();
            this.XPM = new System.Windows.Forms.CheckBox();
            this.DGC = new System.Windows.Forms.CheckBox();
            this.FRK = new System.Windows.Forms.CheckBox();
            this.BC = new System.Windows.Forms.CheckBox();
            this.ZET = new System.Windows.Forms.CheckBox();
            this.NET = new System.Windows.Forms.CheckBox();
            this.PXC = new System.Windows.Forms.CheckBox();
            this.SBC = new System.Windows.Forms.CheckBox();
            this.GLD = new System.Windows.Forms.CheckBox();
            this.YAC = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_Bitcoin
            // 
            this.cb_Bitcoin.AutoSize = true;
            this.cb_Bitcoin.Checked = true;
            this.cb_Bitcoin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Bitcoin.Enabled = false;
            this.cb_Bitcoin.Location = new System.Drawing.Point(6, 25);
            this.cb_Bitcoin.Name = "cb_Bitcoin";
            this.cb_Bitcoin.Size = new System.Drawing.Size(82, 17);
            this.cb_Bitcoin.TabIndex = 0;
            this.cb_Bitcoin.Text = "Bitcoin BTC";
            this.cb_Bitcoin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YAC);
            this.groupBox1.Controls.Add(this.NET);
            this.groupBox1.Controls.Add(this.PXC);
            this.groupBox1.Controls.Add(this.SBC);
            this.groupBox1.Controls.Add(this.GLD);
            this.groupBox1.Controls.Add(this.IFC);
            this.groupBox1.Controls.Add(this.XPM);
            this.groupBox1.Controls.Add(this.DGC);
            this.groupBox1.Controls.Add(this.FRK);
            this.groupBox1.Controls.Add(this.BC);
            this.groupBox1.Controls.Add(this.ZET);
            this.groupBox1.Controls.Add(this.NXT);
            this.groupBox1.Controls.Add(this.QRK);
            this.groupBox1.Controls.Add(this.WDC);
            this.groupBox1.Controls.Add(this.PPC);
            this.groupBox1.Controls.Add(this.AUR);
            this.groupBox1.Controls.Add(this.DOGE);
            this.groupBox1.Location = new System.Drawing.Point(127, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optional currencies (chose at least 1) :";
            // 
            // NXT
            // 
            this.NXT.AutoSize = true;
            this.NXT.Checked = true;
            this.NXT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NXT.Location = new System.Drawing.Point(6, 71);
            this.NXT.Name = "NXT";
            this.NXT.Size = new System.Drawing.Size(88, 17);
            this.NXT.TabIndex = 7;
            this.NXT.Text = "NxtCoin NXT";
            this.NXT.UseVisualStyleBackColor = true;
            this.NXT.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // QRK
            // 
            this.QRK.AutoSize = true;
            this.QRK.Checked = true;
            this.QRK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.QRK.Location = new System.Drawing.Point(118, 25);
            this.QRK.Name = "QRK";
            this.QRK.Size = new System.Drawing.Size(102, 17);
            this.QRK.TabIndex = 6;
            this.QRK.Text = "QuarkCoin QRK";
            this.QRK.UseVisualStyleBackColor = true;
            this.QRK.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // WDC
            // 
            this.WDC.AutoSize = true;
            this.WDC.Checked = true;
            this.WDC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WDC.Location = new System.Drawing.Point(118, 48);
            this.WDC.Name = "WDC";
            this.WDC.Size = new System.Drawing.Size(104, 17);
            this.WDC.TabIndex = 5;
            this.WDC.Text = "WorldCoin WDC";
            this.WDC.UseVisualStyleBackColor = true;
            this.WDC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // PPC
            // 
            this.PPC.AutoSize = true;
            this.PPC.Checked = true;
            this.PPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PPC.Location = new System.Drawing.Point(118, 71);
            this.PPC.Name = "PPC";
            this.PPC.Size = new System.Drawing.Size(93, 17);
            this.PPC.TabIndex = 4;
            this.PPC.Text = "PeerCoin PPC";
            this.PPC.UseVisualStyleBackColor = true;
            this.PPC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // AUR
            // 
            this.AUR.AutoSize = true;
            this.AUR.Checked = true;
            this.AUR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AUR.Location = new System.Drawing.Point(6, 48);
            this.AUR.Name = "AUR";
            this.AUR.Size = new System.Drawing.Size(104, 17);
            this.AUR.TabIndex = 3;
            this.AUR.Text = "AuroraCoin AUR";
            this.AUR.UseVisualStyleBackColor = true;
            this.AUR.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // DOGE
            // 
            this.DOGE.AutoSize = true;
            this.DOGE.Checked = true;
            this.DOGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DOGE.Location = new System.Drawing.Point(6, 25);
            this.DOGE.Name = "DOGE";
            this.DOGE.Size = new System.Drawing.Size(107, 17);
            this.DOGE.TabIndex = 2;
            this.DOGE.Text = "DogeCoin DOGE";
            this.DOGE.UseVisualStyleBackColor = true;
            this.DOGE.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // cb_Litecoin
            // 
            this.cb_Litecoin.AutoSize = true;
            this.cb_Litecoin.Checked = true;
            this.cb_Litecoin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Litecoin.Enabled = false;
            this.cb_Litecoin.Location = new System.Drawing.Point(6, 48);
            this.cb_Litecoin.Name = "cb_Litecoin";
            this.cb_Litecoin.Size = new System.Drawing.Size(86, 17);
            this.cb_Litecoin.TabIndex = 1;
            this.cb_Litecoin.Text = "Litecoin LTC";
            this.cb_Litecoin.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_Litecoin);
            this.groupBox2.Controls.Add(this.cb_Bitcoin);
            this.groupBox2.Location = new System.Drawing.Point(9, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base currencies :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chose currencies which will be taken into consideration during computing\r\nArbitra" +
    "ge :\r\n";
            // 
            // IFC
            // 
            this.IFC.AutoSize = true;
            this.IFC.Checked = true;
            this.IFC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IFC.Location = new System.Drawing.Point(6, 140);
            this.IFC.Name = "IFC";
            this.IFC.Size = new System.Drawing.Size(97, 17);
            this.IFC.TabIndex = 13;
            this.IFC.Text = "InfiniteCoin IFC";
            this.IFC.UseVisualStyleBackColor = true;
            this.IFC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // XPM
            // 
            this.XPM.AutoSize = true;
            this.XPM.Checked = true;
            this.XPM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.XPM.Location = new System.Drawing.Point(118, 94);
            this.XPM.Name = "XPM";
            this.XPM.Size = new System.Drawing.Size(99, 17);
            this.XPM.TabIndex = 12;
            this.XPM.Text = "PrimeCoin XPM";
            this.XPM.UseVisualStyleBackColor = true;
            this.XPM.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // DGC
            // 
            this.DGC.AutoSize = true;
            this.DGC.Checked = true;
            this.DGC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DGC.Location = new System.Drawing.Point(118, 117);
            this.DGC.Name = "DGC";
            this.DGC.Size = new System.Drawing.Size(102, 17);
            this.DGC.TabIndex = 11;
            this.DGC.Text = "DigitalCoin DGC";
            this.DGC.UseVisualStyleBackColor = true;
            this.DGC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // FRK
            // 
            this.FRK.AutoSize = true;
            this.FRK.Checked = true;
            this.FRK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FRK.Location = new System.Drawing.Point(118, 140);
            this.FRK.Name = "FRK";
            this.FRK.Size = new System.Drawing.Size(83, 17);
            this.FRK.TabIndex = 10;
            this.FRK.Text = "Franco FRK";
            this.FRK.UseVisualStyleBackColor = true;
            this.FRK.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // BC
            // 
            this.BC.AutoSize = true;
            this.BC.Checked = true;
            this.BC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BC.Location = new System.Drawing.Point(6, 117);
            this.BC.Name = "BC";
            this.BC.Size = new System.Drawing.Size(91, 17);
            this.BC.TabIndex = 9;
            this.BC.Text = "BlackCoin BC";
            this.BC.UseVisualStyleBackColor = true;
            this.BC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // ZET
            // 
            this.ZET.AutoSize = true;
            this.ZET.Checked = true;
            this.ZET.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ZET.Location = new System.Drawing.Point(6, 94);
            this.ZET.Name = "ZET";
            this.ZET.Size = new System.Drawing.Size(93, 17);
            this.ZET.TabIndex = 8;
            this.ZET.Text = "ZetaCoin ZET";
            this.ZET.UseVisualStyleBackColor = true;
            this.ZET.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // NET
            // 
            this.NET.AutoSize = true;
            this.NET.Checked = true;
            this.NET.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NET.Location = new System.Drawing.Point(6, 186);
            this.NET.Name = "NET";
            this.NET.Size = new System.Drawing.Size(89, 17);
            this.NET.TabIndex = 17;
            this.NET.Text = "NetCoin NET";
            this.NET.UseVisualStyleBackColor = true;
            this.NET.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // PXC
            // 
            this.PXC.AutoSize = true;
            this.PXC.Checked = true;
            this.PXC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PXC.Location = new System.Drawing.Point(118, 163);
            this.PXC.Name = "PXC";
            this.PXC.Size = new System.Drawing.Size(109, 17);
            this.PXC.TabIndex = 16;
            this.PXC.Text = "PhoenixCoin PXC";
            this.PXC.UseVisualStyleBackColor = true;
            this.PXC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // SBC
            // 
            this.SBC.AutoSize = true;
            this.SBC.Checked = true;
            this.SBC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SBC.Location = new System.Drawing.Point(118, 186);
            this.SBC.Name = "SBC";
            this.SBC.Size = new System.Drawing.Size(101, 17);
            this.SBC.TabIndex = 15;
            this.SBC.Text = "StableCoin SBC";
            this.SBC.UseVisualStyleBackColor = true;
            this.SBC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // GLD
            // 
            this.GLD.AutoSize = true;
            this.GLD.Checked = true;
            this.GLD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GLD.Location = new System.Drawing.Point(6, 163);
            this.GLD.Name = "GLD";
            this.GLD.Size = new System.Drawing.Size(94, 17);
            this.GLD.TabIndex = 14;
            this.GLD.Text = "GoldCoin GLD";
            this.GLD.UseVisualStyleBackColor = true;
            this.GLD.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // YAC
            // 
            this.YAC.AutoSize = true;
            this.YAC.Checked = true;
            this.YAC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.YAC.Location = new System.Drawing.Point(6, 209);
            this.YAC.Name = "YAC";
            this.YAC.Size = new System.Drawing.Size(84, 17);
            this.YAC.TabIndex = 18;
            this.YAC.Text = "YaCoin YAC";
            this.YAC.UseVisualStyleBackColor = true;
            this.YAC.CheckedChanged += new System.EventHandler(this.SelectCurrency);
            // 
            // CurrenciesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 302);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CurrenciesWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CurrenciesWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrenciesWindow_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_Bitcoin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox NXT;
        private System.Windows.Forms.CheckBox QRK;
        private System.Windows.Forms.CheckBox WDC;
        private System.Windows.Forms.CheckBox PPC;
        private System.Windows.Forms.CheckBox AUR;
        private System.Windows.Forms.CheckBox DOGE;
        private System.Windows.Forms.CheckBox cb_Litecoin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox YAC;
        private System.Windows.Forms.CheckBox NET;
        private System.Windows.Forms.CheckBox PXC;
        private System.Windows.Forms.CheckBox SBC;
        private System.Windows.Forms.CheckBox GLD;
        private System.Windows.Forms.CheckBox IFC;
        private System.Windows.Forms.CheckBox XPM;
        private System.Windows.Forms.CheckBox DGC;
        private System.Windows.Forms.CheckBox FRK;
        private System.Windows.Forms.CheckBox BC;
        private System.Windows.Forms.CheckBox ZET;
    }
}