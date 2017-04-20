using System;
using System.ComponentModel;
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
    public partial class SecondForm : Form
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
        public ZPlay Player;
        private ZPlay _metronomePlayer;
        private RadialMenu _radialMenu;
        private RadialMenuSlider _volumeRadialMenuSlider;
        private bool _isMetronomeSwitch = false;
        private bool _isReverseModeSwitch = false;
        private bool _isPaused = false;
        private bool _isPlaying = false;

        public void SetIsPaused(bool value) => _isPaused = value;
        public bool GetIsPaused(bool value) => _isPaused;
        public void SetIsPlaying(bool value) => _isPlaying = value;
        public bool GetIsPlaying(bool value) => _isPlaying;

        #region CONSTRUCTORS

        public SecondForm()
        {
            InitializeComponent();

            _volumeRadialMenuSlider = new RadialMenuSlider();

            // THIS IS System.Windows.Forms.Timers.Timer
            //_timer = new Timer();
            //_timer.Interval = 50;
            //_timer.Tick += (sender, args) =>
            //{
            //    if (FFTPictureBox.InvokeRequired)
            //        FFTPictureBox.Invoke((MethodInvoker) (() =>
            //            FFTPictureBox.Refresh()));
            //    else
            //        FFTPictureBox.Refresh();

            //    if (playbackProgressBarAdv.InvokeRequired)
            //        playbackProgressBarAdv.Invoke((MethodInvoker) (() =>
            //            UpdateProgressBar(ref player)));
            //    else
            //        UpdateProgressBar(ref player);
            //};

            // THIS IS System.Threading.Timer
            _timer = new Timer(
                callback: o =>
                {
                    if (FFTPictureBox.InvokeRequired)
                        FFTPictureBox.Invoke((MethodInvoker)(() =>
                        {
                            if (FFTPictureBox.InvokeRequired)
                                FFTPictureBox.Invoke((MethodInvoker)(() =>
                                   FFTPictureBox.Refresh()));
                            else
                                FFTPictureBox.Refresh();

                            if (playbackProgressBarAdv.InvokeRequired)
                                playbackProgressBarAdv.Invoke((MethodInvoker)(() =>
                                   UpdateProgressBar(ref Player)));
                            else
                                UpdateProgressBar(ref Player);
                        }));
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

        private void SecondForm_Load(object sender, EventArgs e)
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
                        player?.StopPlayback();
                        _isPaused = false;
                        _isPlaying = false;

                        if (player == null)
                            player = new ZPlay();

                        if (player.OpenFile(openFileDialog.FileName, TStreamFormat.sfAutodetect) == false)
                        {
                            MessageBox.Show($@"ERROR {this.Player.GetError()}");
                            return;
                        }

                        AdjustPlayerParams(ref player);
                        SetProgressBar(ref player);
                        ResetToggleButtons(ref player);
                    }
                    catch (IOException exception)
                    {
                        Console.WriteLine(exception.StackTrace);
                        throw;
                    }
                }
            }
        }

        public void ResetToggleButtons(ref ZPlay player)
        {
            if (reversePlaybackToggleButton.ToggleState == ToggleButtonState.Active)
                reversePlaybackToggleButton.SwitchState();
        }

        private TStreamInfo GetStreamInfo(ref ZPlay player)
        {
            TStreamInfo streamInfo = new TStreamInfo();
            player?.GetStreamInfo(ref streamInfo);

            return streamInfo;
        }

        private TStreamTime GetPosition(ref ZPlay player)
        {
            TStreamTime position = new TStreamTime();
            player?.GetPosition(ref position);

            return position;
        }

        public void SetProgressBar(ref ZPlay player)
        {
            playbackProgressBarAdv.Minimum = 0;
            playbackProgressBarAdv.Value = 0;

            TStreamInfo info = GetStreamInfo(ref player);
            playbackProgressBarAdv.Maximum = Convert.ToInt32(info.Length.ms);
        }

        private bool IsAudioTrackEndReached(ref ZPlay player)
        {
            int positionMilisec = Convert.ToInt32(GetPosition(ref player).ms);
            int audioTrackLengthMilisec = Convert.ToInt32(GetStreamInfo(ref player).Length.ms);

            return (positionMilisec + 1000) >= audioTrackLengthMilisec;
        }

        private bool IsAudioTrackBeginningReached(ref ZPlay player)
        {
            int positionMilisec = Convert.ToInt32(GetPosition(ref player).ms);
            using (StreamWriter writer = File.AppendText(@"C:\Users\slava\Desktop\log.txt"))
            {
                writer.WriteLine($"{playbackProgressBarAdv.Value} : {playbackProgressBarAdv.Value <= 1000}");
            }
            return playbackProgressBarAdv.Value <= 1000;
        }

        private void UpdateProgressBar(ref ZPlay player)
        {
            int positionMilisec = Convert.ToInt32(GetPosition(ref player).ms);

            if (playbackProgressBarAdv.Maximum >= positionMilisec)
                playbackProgressBarAdv.Value = positionMilisec;

            if (IsAudioTrackEndReached(ref player))
            {
                NormalizeMetronomeToggleButton(ref player);
                //NormalizeReversePlaybackToggleButton(ref player);

                //if (metronomeToggleButton.InvokeRequired)
                //    metronomeToggleButton.Invoke((MethodInvoker) (() =>
                //        _metronomePlayer?.StopPlayback()));
                //else
                //{
                //    _metronomePlayer?.StopPlayback();
                //}
                _metronomePlayer?.StopPlayback();
            }
        }

        //private void NormalizeReversePlaybackToggleButton(ref ZPlay player)
        //{
        //    if (IsAudioTrackBeginningReached(ref player) && _isReverseModeSwitch)
        //    {
        //        if (reversePlaybackToggleButton.InvokeRequired)
        //            reversePlaybackToggleButton.Invoke((MethodInvoker)(() =>
        //               reversePlaybackToggleButton.SwitchState()));
        //        else
        //            reversePlaybackToggleButton.SwitchState();

        //        _isReverseModeSwitch = false;
        //    }

        //}

        private void NormalizeMetronomeToggleButton(ref ZPlay player)
        {
            if (IsAudioTrackEndReached(ref player) && _isMetronomeSwitch)
            {
                if (metronomeToggleButton.InvokeRequired)
                    metronomeToggleButton.Invoke((MethodInvoker)(() =>
                       metronomeToggleButton.SwitchState()));
                else
                    metronomeToggleButton.SwitchState();

                _isMetronomeSwitch = false;
            }
        }

        public void AdjustPlayerParams(ref ZPlay player)
        {
            player.SetPlayerVolume(50, 50);
            player.SetMasterVolume(100, 100);

            playerVolumeTrackBarEx.Value = 50;
            masterVolumeTrackBarEx.Value = 100;
            pitchTrackBarEx.Value = 100;
            rateTrackBarEx.Value = 100;
        }

        private void RegisterControlsEvents()
        {
            #region Menu Buttons

            loadAudioFileButtonAdv.Click += (sender, args) => OpenAudioFile(ref Player);

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

            pitchTrackBarEx.MouseUp += (sender, args) =>
            {
                int pitchValue = ((TrackBarEx)sender).Value;
                pitchNumericUpDown.Value = pitchValue >= 10 ? pitchValue : 10;
            };

            pitchNumericUpDown.ValueChanged += (sender, args) =>
            {
                int pitchValue = (int)((NumericUpDown)sender).Value;
                pitchTrackBarEx.Value = pitchValue;

                Player?.SetPitch(pitchValue);
            };


            // freeeeeeeeeeeee

            frequencyTrackBarEx.MouseUp += (sender, args) =>
            {
                int pitchValue = ((TrackBarEx)sender).Value;
                frequencyNumericUpDown.Value = pitchValue >= 20 ? pitchValue : 20;
            };

            frequencyNumericUpDown.ValueChanged += (sender, args) =>
            {
                int pitchValue = (int)((NumericUpDown)sender).Value;
                frequencyTrackBarEx.Value = pitchValue;

                _metronomePlayer?.SetPitch(pitchValue);
            };

            // periooooooooooooooo

            periodicityTrackBarEx.MouseUp += (sender, args) =>
            {
                int tempoValue = ((TrackBarEx)sender).Value;
                //periodicityTextBox.Text = $@"{BpmToPeriodicity(tempoValue >= 20 ? tempoValue : 20)}";
                periodicityTextBox.Text =
                    $@"{BpmToPeriodicity(periodicityTrackBarEx.Maximum - tempoValue + periodicityTrackBarEx.Minimum)}";
            };

            periodicityTextBox.TextChanged += (sender, args) =>
            {
                decimal periodicityValue = decimal.Parse(periodicityTextBox.Text);
                periodicityTrackBarEx.Value = periodicityTrackBarEx.Maximum - PeriodicityToBPM(periodicityValue) +
                                              periodicityTrackBarEx.Minimum;

                _metronomePlayer?.SetTempo(periodicityTrackBarEx.Maximum - periodicityTrackBarEx.Value +
                                           periodicityTrackBarEx.Minimum);
            };


            //rateTrackBarEx.Click += (sender, args) =>
            //{
            //    int rateValue = ((TrackBarEx)sender).Value;
            //    Player?.SetTempo(rateValue);
            //};

            tempoTrackBarEx.MouseUp += (sender, args) =>
            {
                int tempoValue = ((TrackBarEx)sender).Value;
                tempoNumericUpDown.Value = tempoValue >= 10 ? tempoValue : 10;
            };

            tempoNumericUpDown.ValueChanged += (sender, args) =>
            {
                int tempoValue = (int)((NumericUpDown)sender).Value;
                tempoTrackBarEx.Value = tempoValue;

                Player?.SetTempo(tempoValue);
            };

            reversePlaybackToggleButton.ToggleStateChanged += (sender, args) =>
            {
                if (Player == null)
                    return;

                ToggleButton self = (ToggleButton)sender;

                if (self.ToggleState == ToggleButtonState.Active)
                {
                    Player?.ReverseMode(true);
                }
                else
                {
                    // ToggleButtonState.Inactive
                    Player?.ReverseMode(false);
                }
            };

            playbackProgressBarAdv.MouseDown += (sender, args) =>
            {
                //if (args.Button != MouseButtons.Left)
                //    return;

                TStreamTime newPosition = new TStreamTime();
                TStreamInfo info = GetStreamInfo(ref Player);

                newPosition.ms = Convert.ToUInt32(
                    args.X * info.Length.ms / Convert.ToDouble(((ProgressBarAdv)sender).Size.Width));


                Player?.Seek(TTimeFormat.tfMillisecond, ref newPosition, TSeekMethod.smFromBeginning);
            };

            _volumeRadialMenuSlider.SliderValueChanged += (sender, args) =>
            {
                int volumeLevel = (int)((RadialMenuSlider)sender).SliderValue;

                if (FFTPictureBox.InvokeRequired)
                    FFTPictureBox.Invoke((MethodInvoker)(() => { Player?.SetPlayerVolume(volumeLevel, volumeLevel); }));
                else
                    Player?.SetPlayerVolume(volumeLevel, volumeLevel);
            };

            volumePictureBox.Click += (sender, args) =>
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

                _radialMenu.MenuIcon =
                    Image.FromFile($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Icons\Volume-high-icon.png");

                _radialMenu.MenuVisibility = true;
                _radialMenu.PersistPreviousState = true;
                _radialMenu.UseIndexBasedOrder = true;

                _radialMenu.RadialMenuSliderDrillDown(_volumeRadialMenuSlider);

                #region TRASH

                //_radialMenu.Items.Add(_volumeRadialMenuSlider);
                //_radialMenu.Icon = Image
                //    .FromFile($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Icons\arrow-back-icon.png");


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
                LeftMouseClick(location.X - 40, location.Y + 15);
            };


            FFTPictureBox.Paint += (sender, args) =>
            {
                IntPtr MyDeviceContext = default(IntPtr);
                MyDeviceContext = args.Graphics.GetHdc();
                Player?.DrawFFTGraphOnHDC(MyDeviceContext, 0, 0, FFTPictureBox.Width, FFTPictureBox.Height);
                args.Graphics.ReleaseHdc(MyDeviceContext);
            };

            playToggleButton.ToggleStateChanged += (sender, args) =>
            {
                if (Player == null)
                    return;

                if (playToggleButton.ToggleState == ToggleButtonState.Active)
                {
                    Player.StartPlayback();
                    //_timer.Start();
                    return;
                }
                else
                {
                    Player.StopPlayback(); // ToggleButtonState.Inactive
                    //_timer.Stop();
                }
            };

            metronomeToggleButton.ToggleStateChanged += (sender, args) =>
            {
                if (metronomeToggleButton.ToggleState == ToggleButtonState.Active)
                {
                    if (_metronomePlayer == null)
                        _metronomePlayer = new ZPlay();

                    if (_metronomePlayer.OpenFile(@"Resources\metronom.mp3", TStreamFormat.sfAutodetect) == false)
                    {
                        MessageBox.Show($@"ERROR {_metronomePlayer.GetError()}");
                        return;
                    }

                    _metronomePlayer.StartPlayback();

                    _metronomePlayer.SetMasterVolume(100, 100);
                    _metronomePlayer.SetPlayerVolume(100, 100);

                    _isMetronomeSwitch = true;
                }
                else
                {
                    _metronomePlayer.StopPlayback(); // ToggleButtonState.Inactive
                    _isMetronomeSwitch = false;
                }
            };

            playerVolumeTrackBarEx.Scroll += (sender, args) =>
            {
                int volumeLevel = ((TrackBarEx)sender).Value;
                Player?.SetPlayerVolume(volumeLevel, volumeLevel);
            };

            masterVolumeTrackBarEx.Scroll += (sender, args) =>
            {
                int volumeLevel = ((TrackBarEx)sender).Value;
                Player?.SetMasterVolume(volumeLevel, volumeLevel);
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

            #region SecondForm Control Buttons

            ReplayPictureBox.Click += OnReplayPictureBoxOnClick;
            PlayResumePictureBox.Click += OnPlayResumePictureBoxOnClick;
            PausePictureBox.Click += OnPausePictureBoxOnClick;
            StopPictureBox.Click += OnStopPictureBoxOnClick;
            RewindPictureBox.Click += OnRewindPictureBoxOnClick;
            FastForwardPictureBox.Click += OnFastForwardPictureBoxOnClick;

            #endregion
        }

        #region SecondForm Control Buttons Named Methods

        public void OnFastForwardPictureBoxOnClick(object sender, EventArgs args)
        {
            if (Player == null)
                return;

            TStreamTime position = new TStreamTime();
            TStreamInfo info = GetStreamInfo(ref Player);
            position.sec = Convert.ToUInt32(0.05 * info.Length.sec); // 5%
            Player?.Seek(TTimeFormat.tfSecond, ref position, TSeekMethod.smFromCurrentForward);
        }

        public void OnRewindPictureBoxOnClick(object sender, EventArgs args)
        {
            if (Player == null)
                return;

            TStreamTime position = new TStreamTime();
            TStreamInfo info = GetStreamInfo(ref Player);
            position.sec = Convert.ToUInt32(0.05 * info.Length.sec); // 5%
            Player?.Seek(TTimeFormat.tfSecond, ref position, TSeekMethod.smFromCurrentBackward);
        }

        public void OnStopPictureBoxOnClick(object sender, EventArgs args)
        {
            if (Player == null)
                return;

            Player.StopPlayback();

            _isPaused = false;
            _isPlaying = false;
        }

        public void OnPausePictureBoxOnClick(object sender, EventArgs args)
        {
            if (Player == null)
                return;

            _isPaused = Player.PausePlayback();
            _isPlaying = !_isPaused;
        }

        public void OnPlayResumePictureBoxOnClick(object sender, EventArgs args)
        {
            if (Player == null || _isPlaying)
                return;

            if (_isPaused)
            {
                _isPlaying = Player.ResumePlayback();
                _isPaused = !_isPlaying;
                return;
            }

            // It was not playing at all or even stopped
            _isPlaying = Player.StartPlayback();
            _isPaused = !_isPlaying;
        }

        public void OnReplayPictureBoxOnClick(object sender, EventArgs args)
        {
            if (Player == null)
                return;

            Player.StopPlayback();
            _isPlaying = Player.StartPlayback();
            _isPaused = false;
        }

        #endregion

        private void SetControlsProperties()
        {
            #region Metronome Toggle Button

            metronomeToggleButton.ActiveState.BackColor = playToggleButton.InactiveState.BackColor;
            metronomeToggleButton.ActiveState.HoverColor = playToggleButton.InactiveState.HoverColor;
            metronomeToggleButton.ActiveState.ForeColor = playToggleButton.InactiveState.ForeColor;

            metronomeToggleButton.ActiveState.Text = @"OFF   ";
            metronomeToggleButton.InactiveState.Text = @"ON   ";

            #endregion

            #region Play Toggle Button

            playToggleButton.ActiveState.BackColor = playToggleButton.InactiveState.BackColor;
            playToggleButton.ActiveState.HoverColor = playToggleButton.InactiveState.HoverColor;
            playToggleButton.ActiveState.ForeColor = playToggleButton.InactiveState.ForeColor;

            playToggleButton.ActiveState.Text = @"STOP   ";
            playToggleButton.InactiveState.Text = @"PLAY   ";

            #endregion

            #region Reverse Playback Toggle Button

            reversePlaybackToggleButton.ActiveState.BackColor = playToggleButton.InactiveState.BackColor;
            reversePlaybackToggleButton.ActiveState.HoverColor = playToggleButton.InactiveState.HoverColor;
            reversePlaybackToggleButton.ActiveState.ForeColor = playToggleButton.InactiveState.ForeColor;

            reversePlaybackToggleButton.ActiveState.Text = @"DEACTIVATE   ";
            reversePlaybackToggleButton.InactiveState.Text = @"ACTIVATE   ";

            #endregion

            #region SecondForm

            this.BackColor = Color.FromArgb(226, 226, 226);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = Image.FromFile(@"Resources\stripes.png");
            this.Text = "AudioBox";

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

            loadAudioFileButtonAdv.Text = @"LOAD AN AUDIO TRACK";
            //secondLoadAudioFileButtonAdv.Text = @"Load Second Track";

            #endregion

            #region Volume TrackBars

            masterVolumeTrackBarEx.Maximum = 100;
            masterVolumeTrackBarEx.Minimum = 0;
            masterVolumeTrackBarEx.Value = 100;

            playerVolumeTrackBarEx.Maximum = 100;
            playerVolumeTrackBarEx.Minimum = 1;
            playerVolumeTrackBarEx.Value = 50;

            #endregion

            #region Pitch TrackBar

            pitchTrackBarEx.Minimum = 10;
            pitchTrackBarEx.Maximum = 200;
            pitchTrackBarEx.Value = 100;

            #endregion

            #region Pitch NumericUpDown

            pitchNumericUpDown.Minimum = 10;
            pitchNumericUpDown.Maximum = 200;
            pitchNumericUpDown.Value = 100;

            #endregion

            #region Rate TrackBar

            rateTrackBarEx.Minimum = 10;
            rateTrackBarEx.Maximum = 200;
            rateTrackBarEx.Value = 100;

            #endregion

            #region Tempo TrackBar

            tempoTrackBarEx.Minimum = 10;
            tempoTrackBarEx.Maximum = 200;
            tempoTrackBarEx.Value = 100;

            #endregion

            #region Tempo NumericUpDown

            tempoNumericUpDown.Minimum = 10;
            tempoNumericUpDown.Maximum = 200;
            tempoNumericUpDown.Value = 100;
            tempoNumericUpDown.TextAlign = HorizontalAlignment.Center;

            #endregion

            #region Reverse GroupBox

            reverseGroupBox.BackColor = Color.Transparent;
            reverseGroupBox.ForeColor = Color.White;

            #endregion

            #region Volume GroupBox

            volumeGroupBox.BackColor = Color.Transparent;
            volumeGroupBox.ForeColor = Color.White;
            volumePictureBox.Image = Image.FromFile(@"Icons\Status-audio-volume-high-icon.png");
            volumePictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            #endregion

            #region Audio Pitch GroupBox

            audioPitchGroupBox.BackColor = Color.Transparent;
            audioPitchGroupBox.ForeColor = Color.White;

            #endregion

            #region Pitch NumericUpDown

            pitchNumericUpDown.TextAlign = HorizontalAlignment.Center;

            #endregion

            #region AudioSpeed GroupBox

            audioSpeedGroupBox.BackColor = Color.Transparent;
            audioSpeedGroupBox.ForeColor = Color.White;

            #endregion

            #region FFTGroupBox

            FFTGroupBox.BackColor = Color.Transparent;
            FFTGroupBox.ForeColor = Color.White;

            #endregion

            #region Metronome GroupBox

            metronomeGroupBox.BackColor = Color.Transparent;
            metronomeGroupBox.ForeColor = Color.White;

            frequencyLabel.Text = $"Frequency{Environment.NewLine}Hz";
            periodicityLabel.Text = $"Periodicity{Environment.NewLine}1/BPM";

            frequencyTrackBarEx.Minimum = 20;
            frequencyTrackBarEx.Maximum = 2500;
            frequencyTrackBarEx.Value = 100;

            frequencyNumericUpDown.Minimum = 20;
            frequencyNumericUpDown.Maximum = 2500;
            frequencyNumericUpDown.Value = 100;

            periodicityTrackBarEx.Minimum = 20;
            periodicityTrackBarEx.Maximum = 350;
            periodicityTrackBarEx.Value = 270; // 350 (MAXIMUM) - 100 (NORMAL STATE) + 20 (MINIMUM)

            periodicityTextBox.Text = @"0.01";

            #endregion

            #region Player Control Buttons (PictureBoxes)

            ReplayPictureBox.Image = Image.FromFile(@"Icons\replay-icon.png");
            PlayResumePictureBox.Image = Image.FromFile(@"Icons\play-icon.png");
            PausePictureBox.Image = Image.FromFile(@"Icons\pause-icon.png");
            StopPictureBox.Image = Image.FromFile(@"Icons\stop-icon.png");
            RewindPictureBox.Image = Image.FromFile(@"Icons\rewind-icon.png");
            FastForwardPictureBox.Image = Image.FromFile(@"Icons\forward-icon.png");

            ReplayPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PlayResumePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PausePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            StopPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            RewindPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            FastForwardPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            ReplayPictureBox.BackColor = Color.Transparent;
            PlayResumePictureBox.BackColor = Color.Transparent;
            PausePictureBox.BackColor = Color.Transparent;
            StopPictureBox.BackColor = Color.Transparent;
            RewindPictureBox.BackColor = Color.Transparent;
            FastForwardPictureBox.BackColor = Color.Transparent;

            #endregion

            #region numberPictureBox

            numberPictureBox.Image = Image.FromFile(@"Icons\two.png");
            numberPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            numberPictureBox.BackColor = Color.Transparent;

            #endregion

            #region nicePictureBox

            nicePictureBox.Image = Image.FromFile(@"Resources\File-Music-icon.png");
            nicePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            nicePictureBox.BackColor = Color.Transparent;

            #endregion
        }

        private decimal BpmToPeriodicity(int bpm) => (decimal)1 / bpm;
        private int PeriodicityToBPM(decimal periodicity) => (int)(1 / periodicity);

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _timer?.Dispose();
            Player?.StopPlayback();
        }
    }
}