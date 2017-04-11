using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AxWMPLib;
using libZPlay;
using Presentation.Desktop.Properties;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Timer = System.Threading.Timer;

namespace Presentation.Desktop
{
    public partial class MainForm : Form
    {
        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private string _firstAudioFilePath;
        private string _secondAudioFilePath;
        private Timer _timer;
        private ZPlay _player;
        private RadialMenu _radialMenu;
        private RadialMenuSlider _volumeRadialMenuSlider;

        #region CONSTRUCTORS

        public MainForm()
        {
            InitializeComponent();

            _volumeRadialMenuSlider = new RadialMenuSlider();

            _timer = new Timer(
                callback: o =>
                {
                    if (FFTPictureBox.InvokeRequired)
                    {
                        FFTPictureBox.Invoke((MethodInvoker) delegate { FFTPictureBox.Refresh(); });
                    }
                },
                state: null,
                dueTime: 0,
                period: 50);
        }

        #endregion

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetControlsProperties();
            RegisterControlsEvents();
        }

        private void OpenAudioFile(ref ZPlay player)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resources.FileFilters;

                if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
                {
                    try
                    {
                        player = new ZPlay();

                        if (player.OpenFile(openFileDialog.FileName, TStreamFormat.sfAutodetect) == false)
                        {
                            MessageBox.Show($@"ERROR {_player.GetError()}");
                            return;
                        }

                        AdjustPlayerParams(ref player);
                    }
                    catch (IOException exception)
                    {
                        Console.WriteLine(exception.StackTrace);
                        throw;
                    }
                }
            }
        }

        private void AdjustPlayerParams(ref ZPlay player)
        {
            player.SetPlayerVolume(50, 50);
            player.SetMasterVolume(100, 100);

            playerVolumeTrackBarEx.Value = 50;
            masterVolumeTrackBarEx.Value = 100;
        }

        private void RegisterControlsEvents()
        {
            #region Menu Buttons

            firstLoadAudioFileButtonAdv.Click += (sender, args) => OpenAudioFile(ref _player);

            //secondLoadAudioFileButtonAdv.Click +=
            //    (sender, args) =>
            //    {
            //        OpenAudioFile(secondAxWindowsMediaPlayer, ref _secondAudioFilePath);
            //        this.Height = 600;
            //        secondAxWindowsMediaPlayer.Location = new Point(
            //            firstAxWindowsMediaPlayer.Left,
            //            secondAxWindowsMediaPlayer.Top
            //        );
            //    };

            #endregion

            _volumeRadialMenuSlider.SliderValueChanged += (sender, args) =>
            {
                int volumeLevel = (int) ((RadialMenuSlider)sender).SliderValue;
                _player?.SetPlayerVolume(volumeLevel, volumeLevel);
            };

            radButton.Click += (sender, args) =>
            {
                _radialMenu = new RadialMenu();

                #region Volume Radial Menu Slider

                _volumeRadialMenuSlider.MinimumValue = 0;
                _volumeRadialMenuSlider.MaximumValue = 100;
                _volumeRadialMenuSlider.SliderValue = 50;
                _volumeRadialMenuSlider.Text = "VOLUME";

                #endregion

                #region Radial Menu Properties Settings

                _radialMenu.WedgeCount = 1;

                _radialMenu.Icon = Image
                    .FromFile($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Icons\arrow-back-icon.png");
                _radialMenu.MenuIcon =
                    Image.FromFile($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Icons\Volume-high-icon.png");

                _radialMenu.MenuVisibility = true;
                _radialMenu.PersistPreviousState = true;
                _radialMenu.UseIndexBasedOrder = true;

                _radialMenu.RadialMenuSliderDrillDown(_volumeRadialMenuSlider);

                #region TRASH

                //_radialMenu.Items.Add(_volumeRadialMenuSlider);

                //ImageCollection ic = new ImageCollection();
                //ic.Add(Image.FromFile($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Icons\arrow-back-icon.png"));

                //_radialMenu.ImageCollection = ic;

                //_radialMenu.DisplayStyle = DisplayStyle.TextAboveImage;
                //ImageList imageList = new ImageList();
                //string[] files = Directory.GetFiles($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Icons");

                //foreach (string file in files)
                //{
                //    imageList.Images.Add("volume", Image.FromFile(file));
                //}

                //_radialMenu.ImageList = ImageListAdv.FromImageList(imageList);

                #endregion

                #endregion

                #region Show Radial Menu

                this.Controls.Add(_radialMenu);
                _radialMenu.ShowRadialMenu();
                //_radialMenu.HidePopup();
                //_radialMenu.ShowPopup(new Point());
                #endregion
                
                _radialMenu.PreviousLevelOpened += (radialMenuSender, opening) => _radialMenu.Dispose();

                // Emulate mouse click on 50% Volume on _volumeRadialMenuSlider
                // because there's a library bug that cannot update value
                // by .SliderValue property as it's meant to be updated.
                Point location = MousePosition;
                LeftMouseClick(location.X-40, location.Y+15);
            };


            FFTPictureBox.Paint += (object sender, PaintEventArgs args) =>
            {
                IntPtr MyDeviceContext = default(IntPtr);
                MyDeviceContext = args.Graphics.GetHdc();
                _player?.DrawFFTGraphOnHDC(MyDeviceContext, 0, 0, FFTPictureBox.Width, FFTPictureBox.Height);
                args.Graphics.ReleaseHdc(MyDeviceContext);
            };

            playToggleButton.ToggleStateChanged += (sender, args) =>
            {
                if (_player == null)
                    return;

                if (playToggleButton.ToggleState == ToggleButtonState.Active)
                {
                    _player.StartPlayback();
                    FFTPictureBox.Refresh();
                    return;
                }
                else
                    _player.StopPlayback(); // ToggleButtonState.Inactive
            };

            playerVolumeTrackBarEx.Scroll += (sender, args) =>
            {
                int volumeLevel = ((TrackBarEx) sender).Value;
                _player?.SetPlayerVolume(volumeLevel, volumeLevel);
            };

            masterVolumeTrackBarEx.Scroll += (sender, args) =>
            {
                int volumeLevel = ((TrackBarEx) sender).Value;
                _player?.SetMasterVolume(volumeLevel, volumeLevel);
            };

            this.MouseDown += (sender, mouseEventArgs) =>
            {
                if (mouseEventArgs.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

            closePictureBox.Click += (sender, args) => this.Close();
        }

        private void SetControlsProperties()
        {
            #region Play Toggle Button

            playToggleButton.ActiveState.BackColor = playToggleButton.InactiveState.BackColor;
            playToggleButton.ActiveState.HoverColor = playToggleButton.InactiveState.HoverColor;
            playToggleButton.ActiveState.ForeColor = playToggleButton.InactiveState.ForeColor;

            playToggleButton.ActiveState.Text = @"STOP   ";
            playToggleButton.InactiveState.Text = @"PLAY   ";

            #endregion

            #region MainForm

            this.BackColor = Color.FromArgb(226, 226, 226);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = Image.FromFile(@"Resources\stripes.png");

            //this.Height = 300;

            #endregion

            #region Close Button

            closePictureBox.BackgroundImage = Image.FromFile(@"Resources\close-icon.png");
            closePictureBox.BackColor = Color.Transparent;
            closePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            closePictureBox.Size = new Size(32, 32);
            closePictureBox.Margin = new Padding(0, 0, 0, 0);

            #endregion

            #region Load Audio File

            firstLoadAudioFileButtonAdv.Text = @"Load First Track";
            secondLoadAudioFileButtonAdv.Text = @"Load Second Track";

            #endregion

            #region Volume TrackBars

            masterVolumeTrackBarEx.Maximum = 100;
            masterVolumeTrackBarEx.Minimum = 0;
            masterVolumeTrackBarEx.Value = 50;

            playerVolumeTrackBarEx.Maximum = 100;
            playerVolumeTrackBarEx.Minimum = 1;
            playerVolumeTrackBarEx.Value = 50;

            #endregion
        }

        private int FlipValue100(double value) => (int) (100 - value);
        private int FlipValue200(double value) => (int) (200 - value);
    }
}