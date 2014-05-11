namespace CryptoTriangular
{
    partial class OptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsWindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_hide_balloon = new System.Windows.Forms.CheckBox();
            this.cb_DisplayBaloonWhenPercentChanges = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerInterval = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_complexAnalysis = new System.Windows.Forms.CheckBox();
            this.cb_displayAllpaths = new System.Windows.Forms.CheckBox();
            this.panelArbitrage = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minPercentBenefit = new System.Windows.Forms.NumericUpDown();
            this.cb_sound = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel_favorite = new System.Windows.Forms.Panel();
            this.btc_remove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addPath = new System.Windows.Forms.Button();
            this.textBox_track = new System.Windows.Forms.TextBox();
            this.richTextBox_tracks = new System.Windows.Forms.RichTextBox();
            this.cb_favouritePaths = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerInterval)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panelArbitrage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minPercentBenefit)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel_favorite.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 267);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(357, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Advanced";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 52);
            this.label4.TabIndex = 20;
            this.label4.Text = "Important: Remember that \r\ncalculations are based on two \r\nfactors - your compute" +
    "r and\r\nInternet connection";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_hide_balloon);
            this.groupBox5.Controls.Add(this.cb_DisplayBaloonWhenPercentChanges);
            this.groupBox5.Location = new System.Drawing.Point(13, 94);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 81);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Advanced :";
            // 
            // cb_hide_balloon
            // 
            this.cb_hide_balloon.AutoSize = true;
            this.cb_hide_balloon.Location = new System.Drawing.Point(6, 21);
            this.cb_hide_balloon.Name = "cb_hide_balloon";
            this.cb_hide_balloon.Size = new System.Drawing.Size(178, 17);
            this.cb_hide_balloon.TabIndex = 0;
            this.cb_hide_balloon.Text = "Hide BalloonTip after 5th display";
            this.cb_hide_balloon.UseVisualStyleBackColor = true;
            // 
            // cb_DisplayBaloonWhenPercentChanges
            // 
            this.cb_DisplayBaloonWhenPercentChanges.AutoSize = true;
            this.cb_DisplayBaloonWhenPercentChanges.Location = new System.Drawing.Point(6, 40);
            this.cb_DisplayBaloonWhenPercentChanges.Name = "cb_DisplayBaloonWhenPercentChanges";
            this.cb_DisplayBaloonWhenPercentChanges.Size = new System.Drawing.Size(264, 30);
            this.cb_DisplayBaloonWhenPercentChanges.TabIndex = 1;
            this.cb_DisplayBaloonWhenPercentChanges.Text = "Show BalloonTip only when Arbitrage percent has \r\nbeen changed since last time";
            this.cb_DisplayBaloonWhenPercentChanges.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.timerInterval);
            this.groupBox3.Location = new System.Drawing.Point(13, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 56);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Refreshing loop each :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "seconds";
            // 
            // timerInterval
            // 
            this.timerInterval.Location = new System.Drawing.Point(19, 19);
            this.timerInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.timerInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timerInterval.Name = "timerInterval";
            this.timerInterval.Size = new System.Drawing.Size(58, 20);
            this.timerInterval.TabIndex = 0;
            this.timerInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cb_complexAnalysis);
            this.tabPage2.Controls.Add(this.cb_displayAllpaths);
            this.tabPage2.Controls.Add(this.panelArbitrage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(357, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Arbitrage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 52);
            this.label5.TabIndex = 23;
            this.label5.Text = resources.GetString("label5.Text");
            this.label5.Visible = false;
            // 
            // cb_complexAnalysis
            // 
            this.cb_complexAnalysis.AutoSize = true;
            this.cb_complexAnalysis.Location = new System.Drawing.Point(18, 155);
            this.cb_complexAnalysis.Name = "cb_complexAnalysis";
            this.cb_complexAnalysis.Size = new System.Drawing.Size(285, 17);
            this.cb_complexAnalysis.TabIndex = 22;
            this.cb_complexAnalysis.Text = "Complex Analysis - Takes up to 3 offers from orderbook";
            this.cb_complexAnalysis.UseVisualStyleBackColor = true;
            this.cb_complexAnalysis.Visible = false;
            // 
            // cb_displayAllpaths
            // 
            this.cb_displayAllpaths.AutoSize = true;
            this.cb_displayAllpaths.Location = new System.Drawing.Point(18, 19);
            this.cb_displayAllpaths.Name = "cb_displayAllpaths";
            this.cb_displayAllpaths.Size = new System.Drawing.Size(152, 17);
            this.cb_displayAllpaths.TabIndex = 21;
            this.cb_displayAllpaths.Text = "Display all computed paths";
            this.cb_displayAllpaths.UseVisualStyleBackColor = true;
            this.cb_displayAllpaths.CheckedChanged += new System.EventHandler(this.cb_displayAllpaths_CheckedChanged);
            // 
            // panelArbitrage
            // 
            this.panelArbitrage.Controls.Add(this.groupBox1);
            this.panelArbitrage.Controls.Add(this.cb_sound);
            this.panelArbitrage.Location = new System.Drawing.Point(18, 42);
            this.panelArbitrage.Name = "panelArbitrage";
            this.panelArbitrage.Size = new System.Drawing.Size(317, 95);
            this.panelArbitrage.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.minPercentBenefit);
            this.groupBox1.Location = new System.Drawing.Point(18, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 56);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Minimum Percent Benefit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "%";
            // 
            // minPercentBenefit
            // 
            this.minPercentBenefit.DecimalPlaces = 2;
            this.minPercentBenefit.Location = new System.Drawing.Point(19, 19);
            this.minPercentBenefit.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.minPercentBenefit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.minPercentBenefit.Name = "minPercentBenefit";
            this.minPercentBenefit.Size = new System.Drawing.Size(58, 20);
            this.minPercentBenefit.TabIndex = 0;
            this.minPercentBenefit.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // cb_sound
            // 
            this.cb_sound.AutoSize = true;
            this.cb_sound.Location = new System.Drawing.Point(18, 65);
            this.cb_sound.Name = "cb_sound";
            this.cb_sound.Size = new System.Drawing.Size(277, 17);
            this.cb_sound.TabIndex = 19;
            this.cb_sound.Text = "Sound notification when arbitrage ocassion appeared\r\n";
            this.cb_sound.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel_favorite);
            this.tabPage3.Controls.Add(this.cb_favouritePaths);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(357, 241);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Favorite Routes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel_favorite
            // 
            this.panel_favorite.Controls.Add(this.btc_remove);
            this.panel_favorite.Controls.Add(this.label3);
            this.panel_favorite.Controls.Add(this.addPath);
            this.panel_favorite.Controls.Add(this.textBox_track);
            this.panel_favorite.Controls.Add(this.richTextBox_tracks);
            this.panel_favorite.Enabled = false;
            this.panel_favorite.Location = new System.Drawing.Point(20, 35);
            this.panel_favorite.Name = "panel_favorite";
            this.panel_favorite.Size = new System.Drawing.Size(314, 198);
            this.panel_favorite.TabIndex = 2;
            // 
            // btc_remove
            // 
            this.btc_remove.Location = new System.Drawing.Point(233, 40);
            this.btc_remove.Name = "btc_remove";
            this.btc_remove.Size = new System.Drawing.Size(61, 21);
            this.btc_remove.TabIndex = 5;
            this.btc_remove.Text = "Remove";
            this.btc_remove.UseVisualStyleBackColor = true;
            this.btc_remove.Click += new System.EventHandler(this.btc_remove_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "i.e : BTC-LTC-PPC-BTC";
            // 
            // addPath
            // 
            this.addPath.Location = new System.Drawing.Point(183, 40);
            this.addPath.Name = "addPath";
            this.addPath.Size = new System.Drawing.Size(44, 21);
            this.addPath.TabIndex = 3;
            this.addPath.Text = "Add";
            this.addPath.UseVisualStyleBackColor = true;
            this.addPath.Click += new System.EventHandler(this.addPath_Click);
            // 
            // textBox_track
            // 
            this.textBox_track.Location = new System.Drawing.Point(17, 40);
            this.textBox_track.Name = "textBox_track";
            this.textBox_track.Size = new System.Drawing.Size(160, 20);
            this.textBox_track.TabIndex = 2;
            // 
            // richTextBox_tracks
            // 
            this.richTextBox_tracks.Enabled = false;
            this.richTextBox_tracks.Location = new System.Drawing.Point(17, 66);
            this.richTextBox_tracks.Name = "richTextBox_tracks";
            this.richTextBox_tracks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_tracks.Size = new System.Drawing.Size(277, 125);
            this.richTextBox_tracks.TabIndex = 1;
            this.richTextBox_tracks.Text = "";
            // 
            // cb_favouritePaths
            // 
            this.cb_favouritePaths.AutoSize = true;
            this.cb_favouritePaths.Location = new System.Drawing.Point(20, 17);
            this.cb_favouritePaths.Name = "cb_favouritePaths";
            this.cb_favouritePaths.Size = new System.Drawing.Size(217, 17);
            this.cb_favouritePaths.TabIndex = 0;
            this.cb_favouritePaths.Text = "Show only my favourite predefined paths";
            this.cb_favouritePaths.UseVisualStyleBackColor = true;
            this.cb_favouritePaths.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 267);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsWindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerInterval)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelArbitrage.ResumeLayout(false);
            this.panelArbitrage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minPercentBenefit)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel_favorite.ResumeLayout(false);
            this.panel_favorite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cb_hide_balloon;
        private System.Windows.Forms.CheckBox cb_DisplayBaloonWhenPercentChanges;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown timerInterval;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cb_sound;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minPercentBenefit;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox_tracks;
        private System.Windows.Forms.CheckBox cb_favouritePaths;
        private System.Windows.Forms.Panel panel_favorite;
        private System.Windows.Forms.Button addPath;
        private System.Windows.Forms.TextBox textBox_track;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_displayAllpaths;
        private System.Windows.Forms.Panel panelArbitrage;
        private System.Windows.Forms.Button btc_remove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_complexAnalysis;

    }
}