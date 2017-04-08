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
            Syncfusion.Windows.Forms.Tools.ActiveStateCollection activeStateCollection1 = new Syncfusion.Windows.Forms.Tools.ActiveStateCollection();
            Syncfusion.Windows.Forms.Tools.InactiveStateCollection inactiveStateCollection1 = new Syncfusion.Windows.Forms.Tools.InactiveStateCollection();
            Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer toggleButtonRenderer1 = new Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer();
            Syncfusion.Windows.Forms.Tools.SliderCollection sliderCollection1 = new Syncfusion.Windows.Forms.Tools.SliderCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playToggleButton = new Syncfusion.Windows.Forms.Tools.ToggleButton();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.loadAudioFileButtonAdv = new Syncfusion.Windows.Forms.ButtonAdv();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.playToggleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // playToggleButton
            // 
            this.playToggleButton.ActiveState = activeStateCollection1;
            this.playToggleButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.playToggleButton.ForeColor = System.Drawing.Color.Black;
            inactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.playToggleButton.InactiveState = inactiveStateCollection1;
            this.playToggleButton.Location = new System.Drawing.Point(734, 12);
            this.playToggleButton.MinimumSize = new System.Drawing.Size(52, 20);
            this.playToggleButton.Name = "playToggleButton";
            this.playToggleButton.Renderer = toggleButtonRenderer1;
            this.playToggleButton.Size = new System.Drawing.Size(90, 40);
            this.playToggleButton.Slider = sliderCollection1;
            this.playToggleButton.TabIndex = 0;
            this.playToggleButton.Text = "toggleButton1";
            // 
            // closePictureBox
            // 
            this.closePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closePictureBox.Location = new System.Drawing.Point(850, 12);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(32, 32);
            this.closePictureBox.TabIndex = 1;
            this.closePictureBox.TabStop = false;
            // 
            // loadAudioFileButtonAdv
            // 
            this.loadAudioFileButtonAdv.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.loadAudioFileButtonAdv.IsBackStageButton = false;
            this.loadAudioFileButtonAdv.Location = new System.Drawing.Point(685, 333);
            this.loadAudioFileButtonAdv.Name = "loadAudioFileButtonAdv";
            this.loadAudioFileButtonAdv.Size = new System.Drawing.Size(75, 23);
            this.loadAudioFileButtonAdv.TabIndex = 2;
            this.loadAudioFileButtonAdv.Text = "buttonAdv1";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(385, 169);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 549);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.loadAudioFileButtonAdv);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.playToggleButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playToggleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ToggleButton playToggleButton;
        private System.Windows.Forms.PictureBox closePictureBox;
        private Syncfusion.Windows.Forms.ButtonAdv loadAudioFileButtonAdv;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

