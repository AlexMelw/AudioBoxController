#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Presentation.Desktop
{
    partial class MainForm
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
            Syncfusion.Windows.Forms.Tools.ActiveStateCollection activeStateCollection2 = new Syncfusion.Windows.Forms.Tools.ActiveStateCollection();
            Syncfusion.Windows.Forms.Tools.InactiveStateCollection inactiveStateCollection2 = new Syncfusion.Windows.Forms.Tools.InactiveStateCollection();
            Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer toggleButtonRenderer2 = new Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer();
            Syncfusion.Windows.Forms.Tools.SliderCollection sliderCollection2 = new Syncfusion.Windows.Forms.Tools.SliderCollection();
            this.playToggleButton = new Syncfusion.Windows.Forms.Tools.ToggleButton();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.firstLoadAudioFileButtonAdv = new Syncfusion.Windows.Forms.ButtonAdv();
            this.secondLoadAudioFileButtonAdv = new Syncfusion.Windows.Forms.ButtonAdv();
            this.playerVolumeTrackBarEx = new Syncfusion.Windows.Forms.Tools.TrackBarEx(0, 10);
            this.masterVolumeTrackBarEx = new Syncfusion.Windows.Forms.Tools.TrackBarEx(0, 10);
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.ComboBox3 = new System.Windows.Forms.ComboBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.FFTLinear = new System.Windows.Forms.CheckBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.FFTEnabled = new System.Windows.Forms.CheckBox();
            this.FFTPictureBox = new System.Windows.Forms.PictureBox();
            this.radButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playToggleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            this.GroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FFTPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playToggleButton
            // 
            this.playToggleButton.ActiveState = activeStateCollection2;
            this.playToggleButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.playToggleButton.ForeColor = System.Drawing.Color.Black;
            inactiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.playToggleButton.InactiveState = inactiveStateCollection2;
            this.playToggleButton.Location = new System.Drawing.Point(258, 1);
            this.playToggleButton.MinimumSize = new System.Drawing.Size(52, 20);
            this.playToggleButton.Name = "playToggleButton";
            this.playToggleButton.Renderer = toggleButtonRenderer2;
            this.playToggleButton.Size = new System.Drawing.Size(90, 40);
            this.playToggleButton.Slider = sliderCollection2;
            this.playToggleButton.TabIndex = 0;
            this.playToggleButton.Text = "toggleButton1";
            // 
            // closePictureBox
            // 
            this.closePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closePictureBox.Location = new System.Drawing.Point(656, 9);
            this.closePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(32, 32);
            this.closePictureBox.TabIndex = 1;
            this.closePictureBox.TabStop = false;
            // 
            // firstLoadAudioFileButtonAdv
            // 
            this.firstLoadAudioFileButtonAdv.BeforeTouchSize = new System.Drawing.Size(112, 23);
            this.firstLoadAudioFileButtonAdv.IsBackStageButton = false;
            this.firstLoadAudioFileButtonAdv.Location = new System.Drawing.Point(12, 16);
            this.firstLoadAudioFileButtonAdv.Name = "firstLoadAudioFileButtonAdv";
            this.firstLoadAudioFileButtonAdv.Size = new System.Drawing.Size(112, 23);
            this.firstLoadAudioFileButtonAdv.TabIndex = 2;
            this.firstLoadAudioFileButtonAdv.Text = "first load";
            // 
            // secondLoadAudioFileButtonAdv
            // 
            this.secondLoadAudioFileButtonAdv.BeforeTouchSize = new System.Drawing.Size(112, 23);
            this.secondLoadAudioFileButtonAdv.IsBackStageButton = false;
            this.secondLoadAudioFileButtonAdv.Location = new System.Drawing.Point(140, 16);
            this.secondLoadAudioFileButtonAdv.Name = "secondLoadAudioFileButtonAdv";
            this.secondLoadAudioFileButtonAdv.Size = new System.Drawing.Size(112, 23);
            this.secondLoadAudioFileButtonAdv.TabIndex = 5;
            this.secondLoadAudioFileButtonAdv.Text = "second load";
            // 
            // playerVolumeTrackBarEx
            // 
            this.playerVolumeTrackBarEx.BackColor = System.Drawing.Color.Transparent;
            this.playerVolumeTrackBarEx.BeforeTouchSize = new System.Drawing.Size(20, 250);
            this.playerVolumeTrackBarEx.Location = new System.Drawing.Point(665, 68);
            this.playerVolumeTrackBarEx.Name = "playerVolumeTrackBarEx";
            this.playerVolumeTrackBarEx.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.playerVolumeTrackBarEx.Size = new System.Drawing.Size(20, 250);
            this.playerVolumeTrackBarEx.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Default;
            this.playerVolumeTrackBarEx.TabIndex = 6;
            this.playerVolumeTrackBarEx.Text = "trackBarEx1";
            this.playerVolumeTrackBarEx.TimerInterval = 100;
            this.playerVolumeTrackBarEx.TrackBarGradientEnd = System.Drawing.Color.DimGray;
            this.playerVolumeTrackBarEx.TrackBarGradientStart = System.Drawing.Color.DarkGray;
            this.playerVolumeTrackBarEx.Value = 5;
            // 
            // masterVolumeTrackBarEx
            // 
            this.masterVolumeTrackBarEx.BackColor = System.Drawing.Color.Transparent;
            this.masterVolumeTrackBarEx.BeforeTouchSize = new System.Drawing.Size(20, 250);
            this.masterVolumeTrackBarEx.Location = new System.Drawing.Point(665, 337);
            this.masterVolumeTrackBarEx.Name = "masterVolumeTrackBarEx";
            this.masterVolumeTrackBarEx.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.masterVolumeTrackBarEx.Size = new System.Drawing.Size(20, 250);
            this.masterVolumeTrackBarEx.Style = Syncfusion.Windows.Forms.Tools.TrackBarEx.Theme.Default;
            this.masterVolumeTrackBarEx.TabIndex = 10;
            this.masterVolumeTrackBarEx.Text = "trackBarEx1";
            this.masterVolumeTrackBarEx.TimerInterval = 100;
            this.masterVolumeTrackBarEx.TrackBarGradientEnd = System.Drawing.Color.DimGray;
            this.masterVolumeTrackBarEx.TrackBarGradientStart = System.Drawing.Color.DarkGray;
            this.masterVolumeTrackBarEx.Value = 5;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.checkBox3);
            this.GroupBox8.Controls.Add(this.CheckBox2);
            this.GroupBox8.Controls.Add(this.ComboBox3);
            this.GroupBox8.Controls.Add(this.ComboBox2);
            this.GroupBox8.Controls.Add(this.FFTLinear);
            this.GroupBox8.Controls.Add(this.ComboBox1);
            this.GroupBox8.Controls.Add(this.FFTEnabled);
            this.GroupBox8.Controls.Add(this.FFTPictureBox);
            this.GroupBox8.Location = new System.Drawing.Point(12, 45);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(578, 316);
            this.GroupBox8.TabIndex = 28;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "FFT";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(180, 290);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 17);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "Scale";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Checked = true;
            this.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox2.Location = new System.Drawing.Point(129, 290);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(45, 17);
            this.CheckBox2.TabIndex = 6;
            this.CheckBox2.Text = "Grid";
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // ComboBox3
            // 
            this.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox3.FormattingEnabled = true;
            this.ComboBox3.Items.AddRange(new object[] {
            "Rectangular",
            "Hamming",
            "Hann",
            "Cosine",
            "Lanczos",
            "Bartlett",
            "Triangular",
            "Gauss",
            "Bartlett-Hann",
            "Blackman",
            "Nuttall",
            "Blackman-Harris",
            "Blackman-Nuttall",
            "Flat-Top"});
            this.ComboBox3.Location = new System.Drawing.Point(397, 288);
            this.ComboBox3.Name = "ComboBox3";
            this.ComboBox3.Size = new System.Drawing.Size(107, 21);
            this.ComboBox3.TabIndex = 5;
            // 
            // ComboBox2
            // 
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1204",
            "2048",
            "4096"});
            this.ComboBox2.Location = new System.Drawing.Point(511, 288);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(59, 21);
            this.ComboBox2.TabIndex = 4;
            // 
            // FFTLinear
            // 
            this.FFTLinear.AutoSize = true;
            this.FFTLinear.Location = new System.Drawing.Point(69, 290);
            this.FFTLinear.Name = "FFTLinear";
            this.FFTLinear.Size = new System.Drawing.Size(55, 17);
            this.FFTLinear.TabIndex = 3;
            this.FFTLinear.Text = "Linear";
            this.FFTLinear.UseVisualStyleBackColor = true;
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "Lines (Left On Top)",
            "Lines (Right On Top)",
            "Area (Left On Top)",
            "Area (Right On Top)",
            "Bars (Left On Top)",
            "Bars (Right OnTop)",
            "Spectrum"});
            this.ComboBox1.Location = new System.Drawing.Point(271, 288);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(116, 21);
            this.ComboBox1.TabIndex = 2;
            // 
            // FFTEnabled
            // 
            this.FFTEnabled.AutoSize = true;
            this.FFTEnabled.Checked = true;
            this.FFTEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FFTEnabled.Location = new System.Drawing.Point(8, 290);
            this.FFTEnabled.Name = "FFTEnabled";
            this.FFTEnabled.Size = new System.Drawing.Size(59, 17);
            this.FFTEnabled.TabIndex = 1;
            this.FFTEnabled.Text = "Enable";
            this.FFTEnabled.UseVisualStyleBackColor = true;
            // 
            // FFTPictureBox
            // 
            this.FFTPictureBox.BackColor = System.Drawing.Color.Black;
            this.FFTPictureBox.Location = new System.Drawing.Point(6, 16);
            this.FFTPictureBox.Name = "FFTPictureBox";
            this.FFTPictureBox.Size = new System.Drawing.Size(566, 265);
            this.FFTPictureBox.TabIndex = 0;
            this.FFTPictureBox.TabStop = false;
            // 
            // radButton
            // 
            this.radButton.Location = new System.Drawing.Point(499, 462);
            this.radButton.Name = "radButton";
            this.radButton.Size = new System.Drawing.Size(124, 23);
            this.radButton.TabIndex = 29;
            this.radButton.Text = "Invoke Radial Menu";
            this.radButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 620);
            this.Controls.Add(this.radButton);
            this.Controls.Add(this.GroupBox8);
            this.Controls.Add(this.masterVolumeTrackBarEx);
            this.Controls.Add(this.playerVolumeTrackBarEx);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.secondLoadAudioFileButtonAdv);
            this.Controls.Add(this.firstLoadAudioFileButtonAdv);
            this.Controls.Add(this.playToggleButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playToggleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FFTPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ToggleButton playToggleButton;
        private System.Windows.Forms.PictureBox closePictureBox;
        private Syncfusion.Windows.Forms.ButtonAdv firstLoadAudioFileButtonAdv;
        private Syncfusion.Windows.Forms.ButtonAdv secondLoadAudioFileButtonAdv;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx playerVolumeTrackBarEx;
        private Syncfusion.Windows.Forms.Tools.TrackBarEx masterVolumeTrackBarEx;
        internal System.Windows.Forms.GroupBox GroupBox8;
        private System.Windows.Forms.CheckBox checkBox3;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.ComboBox ComboBox3;
        internal System.Windows.Forms.ComboBox ComboBox2;
        internal System.Windows.Forms.CheckBox FFTLinear;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.CheckBox FFTEnabled;
        internal System.Windows.Forms.PictureBox FFTPictureBox;
        private System.Windows.Forms.Button radButton;
    }
}

