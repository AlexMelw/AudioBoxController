using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AxWMPLib;
using Presentation.Desktop.Properties;
using Syncfusion.Windows.Forms.Tools;

namespace Presentation.Desktop
{
    public partial class MainForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private SoundPlayer _soundPlayer;
        private string _firstAudioFilePath;
        private string _secondAudioFilePath;

        #region CONSTRUCTORS

        public MainForm()
        {
            InitializeComponent();
            _soundPlayer = new SoundPlayer();
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

        private void OpenAudioFile(AxWindowsMediaPlayer player, ref string audioFilePath)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Resources.FileFilters;

                if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
                {
                    audioFilePath = openFileDialog.FileName;
                    try
                    {
                        if (!audioFilePath.EndsWith(@".wav", StringComparison.OrdinalIgnoreCase)) { }
                        else
                        {
                            //_soundPlayer = new SoundPlayer(_firstAudioFilePath);

                            player.URL = audioFilePath;
                        }
                    }
                    catch (IOException exception)
                    {
                        Console.WriteLine(exception.StackTrace);
                        throw;
                    }
                }
            }
        }

        private void RegisterControlsEvents()
        {
            #region Menu Buttons

            firstLoadAudioFileButtonAdv.Click +=
                (sender, args) => OpenAudioFile(firstAxWindowsMediaPlayer, ref _firstAudioFilePath);

            secondLoadAudioFileButtonAdv.Click +=
                (sender, args) =>
                {
                    OpenAudioFile(secondAxWindowsMediaPlayer, ref _secondAudioFilePath);
                    this.Height = 600;
                    secondAxWindowsMediaPlayer.Location = new Point(
                        firstAxWindowsMediaPlayer.Left,
                        secondAxWindowsMediaPlayer.Top
                    );
                };

            #endregion

            playToggleButton.ToggleStateChanged += (sender, args) =>
            {
                if (_soundPlayer == null)
                    return;

                if (playToggleButton.ToggleState == ToggleButtonState.Active)
                {
                    _soundPlayer.Play();
                    return;
                }
                else
                    _soundPlayer.Stop(); // ToggleButtonState.Inactive
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
            this.Height = 300;

            #endregion

            #region Close Button

            closePictureBox.BackgroundImage = Image.FromFile(@"Resources\close-icon.png");
            closePictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            closePictureBox.Size = new Size(32, 32);
            closePictureBox.Margin = new Padding(0, 0, 0, 0);

            #endregion

            #region Load Audio File

            firstLoadAudioFileButtonAdv.Text = @"Load First Track";
            secondLoadAudioFileButtonAdv.Text = @"Load Second Track";

            #endregion
        }
    }
}