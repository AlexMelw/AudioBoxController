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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playToggleButton = new Syncfusion.Windows.Forms.Tools.ToggleButton();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.firstLoadAudioFileButtonAdv = new Syncfusion.Windows.Forms.ButtonAdv();
            this.firstAxWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.secondAxWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.secondLoadAudioFileButtonAdv = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.playToggleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstAxWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondAxWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // playToggleButton
            // 
            this.playToggleButton.ActiveState = activeStateCollection2;
            this.playToggleButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.playToggleButton.ForeColor = System.Drawing.Color.Black;
            inactiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.playToggleButton.InactiveState = inactiveStateCollection2;
            this.playToggleButton.Location = new System.Drawing.Point(87, 245);
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
            this.closePictureBox.Location = new System.Drawing.Point(365, 12);
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
            // firstAxWindowsMediaPlayer
            // 
            this.firstAxWindowsMediaPlayer.Enabled = true;
            this.firstAxWindowsMediaPlayer.Location = new System.Drawing.Point(12, 60);
            this.firstAxWindowsMediaPlayer.Name = "firstAxWindowsMediaPlayer";
            this.firstAxWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("firstAxWindowsMediaPlayer.OcxState")));
            this.firstAxWindowsMediaPlayer.Size = new System.Drawing.Size(385, 169);
            this.firstAxWindowsMediaPlayer.TabIndex = 3;
            // 
            // secondAxWindowsMediaPlayer
            // 
            this.secondAxWindowsMediaPlayer.Enabled = true;
            this.secondAxWindowsMediaPlayer.Location = new System.Drawing.Point(2, 359);
            this.secondAxWindowsMediaPlayer.Name = "secondAxWindowsMediaPlayer";
            this.secondAxWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("secondAxWindowsMediaPlayer.OcxState")));
            this.secondAxWindowsMediaPlayer.Size = new System.Drawing.Size(385, 164);
            this.secondAxWindowsMediaPlayer.TabIndex = 4;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 549);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.secondLoadAudioFileButtonAdv);
            this.Controls.Add(this.secondAxWindowsMediaPlayer);
            this.Controls.Add(this.firstAxWindowsMediaPlayer);
            this.Controls.Add(this.firstLoadAudioFileButtonAdv);
            this.Controls.Add(this.playToggleButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playToggleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstAxWindowsMediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondAxWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ToggleButton playToggleButton;
        private System.Windows.Forms.PictureBox closePictureBox;
        private Syncfusion.Windows.Forms.ButtonAdv firstLoadAudioFileButtonAdv;
        private AxWMPLib.AxWindowsMediaPlayer firstAxWindowsMediaPlayer;
        private AxWMPLib.AxWindowsMediaPlayer secondAxWindowsMediaPlayer;
        private Syncfusion.Windows.Forms.ButtonAdv secondLoadAudioFileButtonAdv;
    }
}

