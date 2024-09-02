using ePOSOne.btnProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using NAudio.Wave;
using NAudio.Gui;
using Media_Player.Properties;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace Media_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCustomizations();
            LoadPlaylistFromFolder();
            watchFile();
            FirstPlaylistToLoad();
            SetSlider();
            SidePanelForButtons.MouseWheel += SidePanelForButtons_Scroll;
            CenterPanel.MouseWheel += CenterPanel_Scroll;
        }
        

        #region Variables

        string PlaylistsPaths = AppDomain.CurrentDomain.BaseDirectory + "Playlists";
        List <string> FoldersList = new List<string>();
        List <Button> PlaylistList = new List<Button>();
        List<string> PlaylistPathList = new List<string>();
        string CurrentPlaylistPath = "none";

        bool clicked = false;

        List<string> SongsListToLoad = new List<string>();
        List<string> SongsList = new List<string>();
        List<Button> SongsButtonList = new List<Button>();
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;
        private bool isPlaying = false;
        private string lastPlayedSongPath = "none";
        bool AnotherPlaylist = false;
        string LastPlayPlaylist = "none";
        private Timer positionUpdateTimer;
        List<string> NotPlayedSongs = new List<string>();
        bool PlayRandomSong = false;
        List<string> PlayedSongs = new List<string>();
        Button LastButton;

        #endregion

        #region Load Customizations

        private void InitializeCustomizations()
        {
            PlaylistTitleTextBox.Hide();
            RedDeleteButton.Hide();
            TopPanel.MouseDown += new MouseEventHandler(TopPanel_MouseDown);

            SetRoundedCorners(CenterPanel, 10);
            SetRoundedCorners(SidePanel1, 10);
            SetRoundedCorners(SidePanel2, 10);
            SetRoundedCorners(FullPlaylistIcon, 10);
            SetFormRoundedCorners(10);

            SetRoundedCorners(PlayButton, 20);
            SetRoundedCorners(RandomButton, 20);
            SetRoundedCorners(AddSongButton, 20);
        }

        //umożliwia przesuwanie okna
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //zaokrągla rogi
        private void SetRoundedCorners(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius - 1, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius - 1, control.Height - radius - 1, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius - 1, radius, radius), 90, 90);

            path.CloseFigure();
            control.Region = new Region(path);
        }
        private void SetFormRoundedCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius - 1, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius - 1, this.Height - radius - 1, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius - 1, radius, radius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
        
        //sygnalizuje najechanie na przycisk
        private void OnButtonHoverEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }
        private void OnButtonHoverLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.LightGray;
        }

        //odpowiada za działanie scrolla 
        private void SidePanelForButtons_Scroll(object sender, MouseEventArgs e)
        {
            ScrollForPanel(sender, e, SidePanelForButtons, 0 , 330);
        }
        private void CenterPanel_Scroll(object sender, MouseEventArgs e)
        {
            //57, 455 or 161, 455 (idk)
            ScrollForPanel(sender, e, CenterPanel, 161, 455);
        }
        private void ScrollForPanel(object sender, MouseEventArgs e, Panel Panel, int minY, int maxY)
        {

            Control firstControl = Panel.Controls[0];
            Control lastControl = Panel.Controls[Panel.Controls.Count - 1];

            int totalHeight = lastControl.Location.Y + lastControl.Height - firstControl.Location.Y;
            int availableHeight = Panel.ClientSize.Height;

            //if (totalHeight > availableHeight)
            {
                if (e.Delta > 0)
                {
                    //Scroll Up
                    int scrollAmount = Math.Min(e.Delta, minY - firstControl.Location.Y);

                    foreach (Control control in Panel.Controls)
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y + scrollAmount);
                    }
                }
                else if (e.Delta < 0)
                {
                    //Scroll Down
                    if (lastControl.Location.Y > maxY)
                    {
                        int scrollAmount = Math.Max(e.Delta, maxY - (lastControl.Location.Y + lastControl.Height));

                        foreach (Control control in Panel.Controls)
                        {
                            control.Location = new Point(control.Location.X, control.Location.Y + scrollAmount);
                        }
                    }
                }
            }
        }
        private void ResetAfterScroll()
        {
            FullPlaylistIcon.Location = new Point(37, 33);
            PlaylistTitle.Location = new Point(155, 57);
            PlaylistTitleTextBox.Location = new Point(165, 57);
            PlayButton.Location = new Point(37, 161);
            RandomButton.Location = new Point(157, 161);
            DeleteButton.Location = new Point(277, 161);
            RedDeleteButton.Location = new Point(277, 161);
            AddSongButton.Location = new Point(397, 161);
        }

        //sygnalizuje najechanie na przycisk poprzez jego powiększenie
        private void BiggerWhen_MouseEnter(object sender, EventArgs e)
        {
            Control ThisButton = sender as Control;
            //Button ThisButton = sender as Button;
            int newWidth = ThisButton.Width + 2;
            int newHeight = ThisButton.Height + 2;

            int offsetX = (newWidth - ThisButton.Width) / 2;
            int offsetY = (newHeight - ThisButton.Height) / 2;

            ThisButton.Location = new Point(ThisButton.Location.X - offsetX, ThisButton.Location.Y - offsetY);
            ThisButton.Size = new Size(newWidth, newHeight);
        }
        private void SmallerWhen_MouseLeave(object sender, EventArgs e)
        {
            Control ThisButton = sender as Control;
            //Button ThisButton = sender as Button;
            int newWidth = ThisButton.Width - 2;
            int newHeight = ThisButton.Height - 2;

            int offsetX = (newWidth - ThisButton.Width) / 2;
            int offsetY = (newHeight - ThisButton.Height) / 2;

            ThisButton.Location = new Point(ThisButton.Location.X - offsetX, ThisButton.Location.Y - offsetY);
            ThisButton.Size = new Size(newWidth, newHeight);
        }

        #endregion

        #region SidePanel
        
        //rozpoczyna ładowanie bocznego panelu z playlistami
        public void LoadPlaylistFromFolder()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(LoadPlaylistFromFolder));
                return;
            }
            foreach (Button button in PlaylistList)
            {
                SidePanelForButtons.Controls.Remove(button);
            }
            PlaylistList.Clear();
            if (Directory.Exists(PlaylistsPaths))
            {
                CreatePlaylistsButton();
            }
            else
            {
                CheckIfPlaylistsFolderExists();
                LoadPlaylistFromFolder();
            }
        }

        //tworzy przyciski odpowiadające za playlisty w bocznym panelu
        private void CreatePlaylistsButton()
        {
            PlaylistPathList.Clear();
            FoldersList = Directory.GetDirectories(PlaylistsPaths).ToList();
            int x = 0;
            int y = 0;
            int margin = 0;

            if (!FoldersList.Any()) 
            {
                lastPlayedSongPath = "none";
                AnotherPlaylist = false;
                LastPlayPlaylist = "none";
                Directory.CreateDirectory(PlaylistsPaths +"/0");
                CopyFolder(AppDomain.CurrentDomain.BaseDirectory + "/Demo", PlaylistsPaths + "/0");
                FoldersList.Add(PlaylistsPaths + "/0");
                CreatePlaylistsButton();
            }
            foreach (string PlaylistPath in FoldersList)
            {
                PlaylistPathList.Add(PlaylistPath);

                string TxtPath = "none";
                string[] Extensions = { ".txt" };
                var TxtFiles = Directory.GetFiles(PlaylistPath).Where(file => Extensions.Contains(Path.GetExtension(file).ToLower())).ToList();
                if (TxtFiles.Any())
                {
                    TxtPath = Path.GetFullPath(TxtFiles.First());
                }
                else
                {
                    string NewTxtPath = PlaylistPath + "/New Playlist.txt";
                    using (FileStream fs = File.Create(NewTxtPath))
                    {

                    }
                    TxtPath = NewTxtPath;
                }
                string PlaylistName = Path.GetFileNameWithoutExtension(TxtPath);
                string ShorterPlaylistName = PlaylistName.Length <= 17 ? PlaylistName : PlaylistName.Substring(0, 17);

                Button PlaylistButton = new Button();
                PlaylistButton.Size = new Size(215, 50);
                PlaylistButton.Location = new Point(x, y);
                PlaylistButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                PlaylistButton.Left = (SidePanelForButtons.ClientSize.Width - PlaylistButton.Width) / 2;
                PlaylistButton.FlatStyle = FlatStyle.Flat;
                PlaylistButton.FlatAppearance.BorderSize = 0;
                PlaylistButton.Font = new Font(PlaylistButton.Font.Name, 11, FontStyle.Bold);
                PlaylistButton.ForeColor = Color.White;
                PlaylistButton.Text = "        " + ShorterPlaylistName;
                PlaylistButton.TextAlign = ContentAlignment.MiddleLeft;
                PlaylistButton.TabStop = false;
                PlaylistButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 25, 25);


                PictureBox PlaylistIcon = new PictureBox();
                PlaylistIcon.Size = new Size(40, 40);
                PlaylistIcon.Location = new Point(5, 5);
                PlaylistIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                PlaylistButton.Controls.Add(PlaylistIcon);
                SetRoundedCorners(PlaylistIcon, 10);

                AddPlaylistIcon(PlaylistPath, PlaylistIcon);

                SetRoundedCorners(PlaylistButton, 10);
                SidePanelForButtons.Controls.Add(PlaylistButton);
                PlaylistList.Add(PlaylistButton);
                y += PlaylistButton.Height + margin;

                PlaylistButton.Click += (sender, e) => OpenPlaylist(sender, e, PlaylistPath, PlaylistName);
            }
        }

        //sprawdza czy istnieje folder
        public void CheckIfPlaylistsFolderExists()
        {
            if (!Directory.Exists(PlaylistsPaths))
            {
                Directory.CreateDirectory(PlaylistsPaths);
            }
        }

        //dodaje wybrany obraz z wybranej playlisty
        private void AddPlaylistIcon(string PlaylistPath, PictureBox PlaylistIcon)
        {
            string[] imageExtensions = { ".jpg", ".png", ".gif"};

            var imageFiles = Directory.GetFiles(PlaylistPath).Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
            if (imageFiles.Any())
            {
                //PlaylistIcon.Image = Image.FromFile(imageFiles.First());
                using (var stream = new FileStream(imageFiles.First(), FileMode.Open, FileAccess.Read))
                {
                    var bitmap = new Bitmap(stream);
                    PlaylistIcon.Image = new Bitmap(bitmap);
                }
            }
            else
            {
                try
                {
                    //PlaylistIcon.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "Default_Playlist_Icon.png");
                    using (var stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Default_Playlist_Icon.png", FileMode.Open, FileAccess.Read))
                    {
                        var bitmap = new Bitmap(stream);
                        PlaylistIcon.Image = new Bitmap(bitmap);
                    }
                }
                catch
                {
                    PlaylistIcon.BackColor = Color.Fuchsia;
                }
            }
        }

        //sprawdza czy foldery playlist uległy zmianie i aktywuje LoadPlaylistFromFolder()
        private void watchFile()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = PlaylistsPaths;
            watcher.NotifyFilter = NotifyFilters.DirectoryName;
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;
            watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => LoadPlaylistFromFolder()));
            }
            else
            {
                LoadPlaylistFromFolder();
            }
        }
        
        //otwiera wybraną playliste
        private void OpenPlaylist(object sender, EventArgs e, string PlaylistPath, string PlaylistName)
        {
            ResetAfterScroll();
            CurrentPlaylistPath = PlaylistPath;
            LoadPlaylist(PlaylistPath, PlaylistName, false);
        }

        //kopiuje wybrany folder wraz z jego zawartością (.mp3, .wav, .png, .jpg, .gif, .txt) do przekazanej ścieżki
        private void CopyFolder(string sourceDir, string destinationDir)
        {
            Directory.CreateDirectory(destinationDir);

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string extension = Path.GetExtension(file).ToLower();
                if (extension == ".mp3" || extension == ".png" || extension == ".jpg" || extension == ".gif" || extension == ".txt")
                {
                    string destFileName = Path.Combine(destinationDir, Path.GetFileName(file));

                    int counter = 1;
                    string originalFileName = destFileName;
                    while (File.Exists(destFileName))
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
                        destFileName = Path.Combine(destinationDir, $"{fileNameWithoutExtension} ({counter}){extension}");
                        counter++;
                    }

                    File.Copy(file, destFileName, overwrite: false);
                }
            }

            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string destDirName = Path.Combine(destinationDir, Path.GetFileName(directory));
                CopyFolder(directory, destDirName);
            }
        }

        #region SidePanel_Buttons

        //ponownie ładuje playlisty poprzez aktywacje LoadPlaylistFromFolder()
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadPlaylistFromFolder();
        }
        
        //ładuje następną utwór
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (lastPlayedSongPath != "none" && SongsList.Count > 1){
                if (!PlayRandomSong)
                {
                    int CurrentSongIndex = SongsList.IndexOf(lastPlayedSongPath);
                    int NextSongIndex;
                    if (CurrentSongIndex >= SongsList.Count - 1)
                    {
                        NextSongIndex = 0;
                    }
                    else
                    {
                        NextSongIndex = CurrentSongIndex + 1;
                    }

                    PlayButton_Click(sender, e, SongsList[NextSongIndex]);
                }
                else
                {
                    Random random = new Random();
                    int RandomNumber = random.Next(0, NotPlayedSongs.Count);
                    string RandomSongPath = NotPlayedSongs[RandomNumber];
                    PlayButton_Click(sender, e, RandomSongPath);
                }
            }
        }

        //ładuje poprzedni utwór
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (lastPlayedSongPath != "none" && SongsList.Count > 1)
            {
                if (PlayRandomSong)
                {
                    int CurrentSongIndex = PlayedSongs.IndexOf(lastPlayedSongPath);
                    int PreviousSongIndex = CurrentSongIndex - 1;
                    if (PreviousSongIndex > -1)
                    {
                        PlayButton_Click(sender, e, PlayedSongs[PreviousSongIndex]);
                    }
                }
                else
                {
                    int CurrentSongIndex = SongsList.IndexOf(lastPlayedSongPath);
                    int PreviousSongIndex = CurrentSongIndex - 1;
                    if (PreviousSongIndex > -1)
                    {
                        PlayButton_Click(sender, e, SongsList[PreviousSongIndex]);
                    }
                }
            }
        }

        //pauzuje utwór lub ponawia odtwarzanie 
        private void SidePlayButton_Click(object sender, EventArgs e)
        {
            if (lastPlayedSongPath != "none" && SongsList.Count > 0)
            {
                string SongPath = lastPlayedSongPath;
                Button_WOC button = PlayButton;

                Bitmap PauseIcon = Properties.Resources.pause_icon;
                Bitmap PlayIcon = Properties.Resources.play_icon;

                if (!isPlaying)
                {
                    outputDevice.Play();
                    isPlaying = true;
                    if (LastPlayPlaylist == CurrentPlaylistPath)
                    {
                        button.Text = "Pause";
                    }
                    SidePlayButton.BackgroundImage = PauseIcon;
                }
                else if (isPlaying)
                {
                    if (LastPlayPlaylist == CurrentPlaylistPath)
                    {
                        button.Text = "Play";
                    }
                    outputDevice.Pause();
                    isPlaying = false;
                    SidePlayButton.BackgroundImage = PlayIcon;
                }
            }
        }

        //odpowiada za importowanie folderu
        private void ImportPlaylistButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFolderPath = folderDialog.SelectedPath;
                    string NewFolderPath = Path.Combine(PlaylistsPaths, Path.GetFileName(sourceFolderPath));

                    int counter = 1;
                    string originalFolderPath = NewFolderPath;
                    while (Directory.Exists(NewFolderPath))
                    {
                        NewFolderPath = originalFolderPath + $" ({counter})";
                        counter++;
                    }

                    CopyFolder(sourceFolderPath, NewFolderPath);
                }
            }
        }

        //tworzy nową playlistę
        private void CreatePlaylistButton_Click(object sender, EventArgs e)
        {
            int counter = 1;
            string NewPlaylistPath = PlaylistsPaths + "/0";
            while (Directory.Exists(NewPlaylistPath))
            {
                NewPlaylistPath = PlaylistsPaths + $"/{counter}";
                counter++;
            }
            Directory.CreateDirectory(NewPlaylistPath);
        }

        #endregion


        #endregion

        #region CenterPanel

        //odpowiada za zmiane głośności 
        private void VolumeChanged(object sender, MouseEventArgs e)
        {
            if (audioFile != null)
            {
                audioFile.Volume = VolumeSlider.Value / 50f;
            }
        }

        //odpowiada za kontrolowanie momentu odtwarzanego utworu
        private void CurrentSongTimeChanged(object sender, MouseEventArgs e)
        {
            if (SongSlider.isDragging)
            {
                if (audioFile != null && (int)audioFile.CurrentTime.TotalSeconds != SongSlider.Value)
                {
                    audioFile.CurrentTime = TimeSpan.FromSeconds(SongSlider.Value);
                }
            }
        }

        //odpowiada za pokazywanie aktualnego momentu utworu i odtwarzanie nowego w momencie zakończenia poprzedniego
        private void PositionUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile != null && !SongSlider.isDragging)
            {
                SongSlider.Value = (int)audioFile.CurrentTime.TotalSeconds;
                int TimeToMinute = (int)audioFile.CurrentTime.TotalSeconds / 60;
                int _TimeToSecond = TimeToMinute * 60;
                int TimeToSecond = (int)audioFile.CurrentTime.TotalSeconds - _TimeToSecond;
                if (TimeToSecond < 10)
                {
                    CurrentSongTime.Text = TimeToMinute + ":0" + TimeToSecond;
                }
                else
                {
                    CurrentSongTime.Text = TimeToMinute + ":" + TimeToSecond;
                }
                if ((int)audioFile.CurrentTime.TotalSeconds == (int)audioFile.TotalTime.TotalSeconds)
                {
                    if(!PlayRandomSong)
                    {
                        int CurrentSongIndex = SongsList.IndexOf(lastPlayedSongPath);
                        int NextSongIndex;
                        if (CurrentSongIndex >= SongsList.Count - 1)
                        {
                            NextSongIndex = 0;
                        }
                        else
                        {
                            NextSongIndex = CurrentSongIndex + 1;
                        }
                        
                        PlayButton_Click(sender, e, SongsList[NextSongIndex]);
                    }
                    else
                    {
                        Random random = new Random();
                        int RandomNumber = random.Next(0, NotPlayedSongs.Count);
                        string RandomSongPath = NotPlayedSongs[RandomNumber];
                        PlayButton_Click(sender, e, RandomSongPath);
                    }
                        
                }
            }
        }

        //informuje który utwór jest odtwarzany poprzez zmiene jego czćionki
        private void ChangeSongFont()
        {
            Console.WriteLine(lastPlayedSongPath);
            Button ThisButton = FindButtonBySongPath(lastPlayedSongPath);
            if (LastPlayPlaylist == "none" || LastPlayPlaylist == CurrentPlaylistPath)
            {
                if (LastButton != null && LastButton != ThisButton)
                {
                    LastButton.Font = new Font(LastButton.Font.Name, 12, FontStyle.Bold);
                    LastButton.ForeColor = Color.LightGray;
                }

                try{
                    ThisButton.Font = new Font(ThisButton.Font.Name, 14, FontStyle.Bold);
                    ThisButton.ForeColor = Color.White;
                }
                catch
                {

                }

                LastButton = ThisButton;
            }
            else
            {
                Console.WriteLine(LastPlayPlaylist);
                Console.WriteLine(CurrentPlaylistPath);
            }
        }

        #region Creating Panel

        //ustawia początkowo Slidery
        private void SetSlider()
        {
            VolumeSlider.MaxValue = 100;
            VolumeSlider.Value = 60;
            positionUpdateTimer = new Timer();
            positionUpdateTimer.Interval = 500;
            positionUpdateTimer.Tick += PositionUpdateTimer_Tick;
        }

        //startuje ładowanie pierwszej playlisty
        private void FirstPlaylistToLoad()
        {
            string ThisPlaylistPath = PlaylistPathList.First();
            string[] Extensions = { ".txt" };
            var TxtFiles = Directory.GetFiles(ThisPlaylistPath).Where(file => Extensions.Contains(Path.GetExtension(file).ToLower())).ToList();
            string TxtPath = Path.GetFullPath(TxtFiles.First());
            string PlaylistName = Path.GetFileNameWithoutExtension(TxtPath);
            CurrentPlaylistPath = ThisPlaylistPath;
            LoadPlaylist(ThisPlaylistPath, PlaylistName, false);
        }

        //ładuję wybraną playlistę
        public void LoadPlaylist(string PlaylistPath, string PlaylistName, bool reset)
        {
            AddPlaylistIcon(PlaylistPath, FullPlaylistIcon);
            PlaylistTitle.Text = PlaylistName;

            foreach (Button button in SongsButtonList)
            {
                CenterPanel.Controls.Remove(button);
            }
            SongsButtonList.Clear();
            SongsListToLoad.Clear();

            string[] mp3Files = Directory.GetFiles(PlaylistPath, "*.mp3", SearchOption.AllDirectories);

            SongsListToLoad.AddRange(mp3Files);
            

            CreateSongButton(SongsListToLoad);
            PlayPause(PlaylistPath);
            
            if(lastPlayedSongPath == "none" || reset)
            {
                SongsList.Clear();
                SongsList = SongsListToLoad.ToList();
                NotPlayedSongs = SongsList.ToList();
            }
            
        }

        //tworzy przyciski odpowiadające za utwory 
        private void CreateSongButton(List<string> SongsToLoad)
        {
            int x = 30;
            int y = 220;
            int margin = 0;

            foreach (string SongPath in SongsToLoad)
            {
                string SongName = Path.GetFileNameWithoutExtension(SongPath);

                Button SongButton = new Button();
                SongButton.Size = new Size(680, 60);
                SongButton.Location = new Point(x, y);
                SongButton.FlatStyle = FlatStyle.Flat;
                SongButton.FlatAppearance.BorderSize = 0;
                SongButton.Font = new Font(SongButton.Font.Name, 12, FontStyle.Bold);
                SongButton.ForeColor = Color.LightGray;
                SongButton.TabStop = false;
                SongButton.TextAlign = ContentAlignment.MiddleLeft;
                SongButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 30, 30);
                SongButton.Click += (sender, e) => SongButton_Click(sender, e, SongPath);

                SongButton.Tag = SongPath;

                SetRoundedCorners(SongButton, 10);
                CenterPanel.Controls.Add(SongButton);
                SongsButtonList.Add(SongButton);
                y += SongButton.Height + margin;

                AudioFileReader _audioFile = new AudioFileReader(SongPath);
                int TimeToMinute = (int)_audioFile.TotalTime.TotalSeconds / 60;
                int _TimeToSecond = TimeToMinute * 60;
                int TimeToSecond = (int)_audioFile.TotalTime.TotalSeconds - _TimeToSecond;
                String SongTotalTime = TimeToMinute + ":" + TimeToSecond;

                SongButton.Paint += (s, pe) =>
                {
                    Graphics g = pe.Graphics;

                    int nameWidth = 550;
                    g.DrawString(SongName, SongButton.Font, new SolidBrush(SongButton.ForeColor), new PointF(10, 15));

                    SizeF timeSize = g.MeasureString(SongTotalTime, SongButton.Font);
                    g.DrawString(SongTotalTime, SongButton.Font, new SolidBrush(SongButton.ForeColor), new PointF(nameWidth + 30, 18));
                };

                PictureBox TrashButton = new PictureBox();
                TrashButton.Size = new Size(25, 25);
                TrashButton.Location = new Point(SongButton.Width - TrashButton.Width - 15, 15);
                TrashButton.Image = Properties.Resources.trash_icon;
                TrashButton.SizeMode = PictureBoxSizeMode.StretchImage;
                TrashButton.MouseEnter += BiggerWhen_MouseEnter;
                TrashButton.MouseLeave += SmallerWhen_MouseLeave;
                TrashButton.MouseClick += (sender, e) => DeleteSong_Click(sender, e, SongPath, SongButton);
                SongButton.Controls.Add(TrashButton);
            }
        }

        #endregion

        #region NeedToPlay

        //odtwarza wybrany utwór
        private void PlayThisSong(object sender, EventArgs e, string SongPath)
        {
            Button_WOC button = PlayButton;

            DeletePlayback();
            lastPlayedSongPath = SongPath;

            audioFile = new AudioFileReader(SongPath);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            audioFile.CurrentTime = TimeSpan.FromSeconds(0);

            isPlaying = true;
            if (LastPlayPlaylist == CurrentPlaylistPath)
            {
                button.Text = "Pause";
            }
            positionUpdateTimer.Start();

            SongSlider.MaxValue = (int)audioFile.TotalTime.TotalSeconds;
            int TimeToMinute = (int)audioFile.TotalTime.TotalSeconds / 60;
            int _TimeToSecond = TimeToMinute * 60;
            int TimeToSecond = (int)audioFile.TotalTime.TotalSeconds - _TimeToSecond;
            TimeOfWholeSong.Text = TimeToMinute + ":" + TimeToSecond;

            NotPlayedSongs.Remove(SongPath);
            PlayedSongs.Add(SongPath);
            if (NotPlayedSongs.Count == 0)
            {
                NotPlayedSongs = SongsList.ToList();
            }
        }

        //niszczy odtwarzany aktualnie utwór
        private void DeletePlayback()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }

        //pomaga w rozpoznawianiu czy w podanej playliście jest odtwarzany utwór
        private void PlayPause(string ThisPlaylist)
        {
            if (LastPlayPlaylist != ThisPlaylist)
            {
                PlayButton.Text = "Play";
                AnotherPlaylist = true;
            }
            else
            {
                if (isPlaying)
                {
                    PlayButton.Text = "Pause";
                }
                AnotherPlaylist = false;

                if (LastButton != null && SongsList.Count > 0)
                {
                    ChangeSongFont();
                }
                
            }
        }

        //odnajduję on przycisk po ścieżce utworu
        private Button FindButtonBySongPath(string songPath)
        {
            foreach (Button button in SongsButtonList)
            {
                if (button.Tag != null && button.Tag.ToString() == songPath)
                {
                    return button;
                }
            }
            return null;
        }

        #endregion

        #region CenterPanel_Buttons

        //wyłącza aplikacje
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //zaczyna odtwarzać utwory z playlisty
        private void Play_Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (SongsListToLoad.Any())
            {
                if (LastPlayPlaylist != CurrentPlaylistPath)
                {
                    LastPlayPlaylist = CurrentPlaylistPath;
                    SongsList.Clear();
                    SongsList = SongsListToLoad.ToList();
                    NotPlayedSongs = SongsList.ToList();
                    AnotherPlaylist = true;
                }

                PlayButton._isHovering = false;
                PlayButton._buttonColor = Color.LightGray;
                PlayButton._borderColor = Color.LightGray;
                PlayButton.TextColor = Color.Black;
                if (lastPlayedSongPath == "none" || AnotherPlaylist)
                {
                    if (PlayRandomSong)
                    {
                        Random random = new Random();
                        int RandomNumber = random.Next(0, NotPlayedSongs.Count);
                        string RandomSongPath = NotPlayedSongs[RandomNumber];
                        PlayButton_Click(sender, e, RandomSongPath);
                    }
                    else
                    {
                        string SongPath = SongsList.First();
                        PlayButton_Click(sender, e, SongPath);
                    }

                }
                else
                {
                    PlayButton_Click(sender, e, lastPlayedSongPath);
                }
            }
        }
        private void Play_Button_MouseUp(object sender, MouseEventArgs e)
        {
            PlayButton._buttonColor = Color.FromArgb(40, 40, 40);
            PlayButton._borderColor = Color.FromArgb(40, 40, 40);
            PlayButton.TextColor = Color.LightGray;
        }

        //aktywuje oraz dezaktywuje randomowe odtwarzanie utworów
        private void Random_Button_MouseDown(object sender, MouseEventArgs e)
        {
            NotPlayedSongs = SongsList.ToList();
            Button_WOC button = sender as Button_WOC;
            
            if (!clicked)
            {
                button._onHoverButtonColor = Color.White;
                button._onHoverBorderColor = Color.White;
                button._onHoverTextColor = Color.Black;
                button._isHovering = false;

                button._buttonColor = Color.LightGray;
                button._borderColor = Color.LightGray;
                button.TextColor = Color.Black;

                clicked = true;
                PlayRandomSong = true;
            }
            else
            {
                button._onHoverButtonColor = Color.FromArgb(45, 45, 45);
                button._onHoverBorderColor = Color.FromArgb(45, 45, 45);
                button._onHoverTextColor = Color.LightGray;
                button._isHovering = false;

                button._buttonColor = Color.FromArgb(40, 40, 40);
                button._borderColor = Color.FromArgb(40, 40, 40);
                button.TextColor = Color.LightGray;

                clicked = false;
                PlayRandomSong = false;
            }
        }

        //dodawanie nowych utworów do aktualnej playlisty
        private void Add_Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button_WOC button = sender as Button_WOC;
            button._isHovering = false;
            button._buttonColor = Color.LightGray;
            button._borderColor = Color.LightGray;
            button.TextColor = Color.Black;
        }
        private void Add_Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button_WOC button = sender as Button_WOC;
            button._buttonColor = Color.FromArgb(40, 40, 40);
            button._borderColor = Color.FromArgb(40, 40, 40);
            button.TextColor = Color.LightGray;
        }
        private void AddSongButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files(*.MP3)|*.MP3";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> fileNamesList = new List<string>(openFileDialog.FileNames);

                foreach (string filePath in openFileDialog.FileNames)
                {
                    try
                    {
                        string fileName = Path.GetFileName(filePath);
                        string NewSongPath = Path.Combine(CurrentPlaylistPath, fileName);

                        File.Copy(filePath, NewSongPath, overwrite: true);
                        SongsListToLoad.Add(NewSongPath);
                    }
                    catch{}
                }
                string PlaylistName = PlaylistTitle.Text;
                if (CurrentPlaylistPath == LastPlayPlaylist)
                {
                    LoadPlaylist(CurrentPlaylistPath, PlaylistName, true);
                }
                else
                {
                    LoadPlaylist(CurrentPlaylistPath, PlaylistName, false);
                }
            }
        }

        //odpowiada za włączenie klikniętego utworu
        private void SongButton_Click(object sender, EventArgs e, string SongPath)
        {
            if (LastPlayPlaylist != CurrentPlaylistPath)
            {
                LastPlayPlaylist = CurrentPlaylistPath;
                SongsList.Clear();
                SongsList = SongsListToLoad.ToList();
                NotPlayedSongs = SongsList.ToList();
            }
            PlayButton_Click(sender, e, SongPath);
        }

        //pomaga w zarządzaniu odtwarzania i pauzowania utworu
        private void PlayButton_Click(object sender, EventArgs e, string SongPath)
        {
            AnotherPlaylist = false;
            Button_WOC button = PlayButton;

            Bitmap PauseIcon = Properties.Resources.pause_icon;
            Bitmap PlayIcon = Properties.Resources.play_icon;

            if (!isPlaying)
            {
                if (lastPlayedSongPath != SongPath)
                {
                    PlayThisSong(sender, e, SongPath);
                    ChangeSongFont();
                    SidePlayButton.BackgroundImage = PauseIcon;
                }
                else
                {
                    outputDevice.Play();
                    isPlaying = true;
                    button.Text = "Pause";
                    SidePlayButton.BackgroundImage = PauseIcon;
                }
            }
            else if(isPlaying && lastPlayedSongPath == SongPath)
            {
                button.Text = "Play";
                outputDevice.Pause();
                isPlaying = false;
                SidePlayButton.BackgroundImage = PlayIcon;
            }
            else if (isPlaying && lastPlayedSongPath != SongPath)
            {
                PlayThisSong(sender, e, SongPath);
                ChangeSongFont();
                SidePlayButton.BackgroundImage = PauseIcon;
            }
        }

        //usuwa wybrany utwór z playlisty
        private void DeleteSong_Click(object sender, EventArgs e, string ThisSongPath, Button ThisSongButton)
        {
            if(lastPlayedSongPath == ThisSongPath)
            {
                DeletePlayback();
                if (SongsList.Count > 1)
                {
                    NextButton_Click(sender, e);
                }
                else
                {
                    isPlaying = false;
                    SidePlayButton.BackgroundImage = Properties.Resources.play_icon;
                    PlayButton.Text = "Play";
                }
                SongsList.Remove(ThisSongPath);
                SongsListToLoad.Remove(ThisSongPath);
                NotPlayedSongs.Remove(ThisSongPath);
                CenterPanel.Controls.Remove(ThisSongButton);
                SongsButtonList.Remove(ThisSongButton);
                File.Delete(ThisSongPath);
                string PlaylistName = PlaylistTitle.Text;
                LoadPlaylist(CurrentPlaylistPath, PlaylistName, false);
                ResetAfterScroll();
            }
            else if(LastPlayPlaylist == CurrentPlaylistPath)
            {
                SongsList.Remove(ThisSongPath);
                SongsListToLoad.Remove(ThisSongPath);
                NotPlayedSongs.Remove(ThisSongPath);
                CenterPanel.Controls.Remove(ThisSongButton);
                SongsButtonList.Remove(ThisSongButton);
                File.Delete(ThisSongPath);
                string PlaylistName = PlaylistTitle.Text;
                LoadPlaylist(CurrentPlaylistPath, PlaylistName, false);
                ResetAfterScroll();
            }
            else
            {
                SongsListToLoad.Remove(ThisSongPath);
                CenterPanel.Controls.Remove(ThisSongButton);
                SongsButtonList.Remove(ThisSongButton);
                File.Delete(ThisSongPath);
                string PlaylistName = PlaylistTitle.Text;
                LoadPlaylist(CurrentPlaylistPath, PlaylistName, false);
                ResetAfterScroll();
            }
        }

        #endregion

        #region EditPlaylist
        
        //edycja tytułu playlisty
        private void PlaylistTitle_Click(object sender, EventArgs e)
        {
            PlaylistTitleTextBox.Show();
            PlaylistTitleTextBox.Text = PlaylistTitle.Text;
        }
        private void PlaylistTitleTextBox_MouseLeave(object sender, EventArgs e)
        {
            PlaylistTitleTextBox.Hide();
        }
        private void PlaylistTitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PlaylistTitle.Text = PlaylistTitleTextBox.Text;
                PlaylistTitleTextBox.Hide();

                string[] Extensions = { ".txt" };
                var oldTxtFiles = Directory.GetFiles(CurrentPlaylistPath).Where(file => Extensions.Contains(Path.GetExtension(file).ToLower())).ToList();
                string oldTxtPath = Path.GetFullPath(oldTxtFiles.First());

                Directory.Move(oldTxtPath, CurrentPlaylistPath + "/" + PlaylistTitleTextBox.Text + ".txt");
                LoadPlaylistFromFolder();
            }
        }

        //edycja ikony playlisty
        private void FullPlaylistIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                string ToPath = CurrentPlaylistPath;

                string[] imageExtensions = { ".jpg", ".png", ".gif" };
                var imageFiles = Directory.GetFiles(CurrentPlaylistPath).Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();
                if (imageFiles.Any())
                {
                    ToPath = Path.GetFullPath(imageFiles.First());
                    File.Copy(FilePath, ToPath, overwrite: true);
                    LoadPlaylistFromFolder();
                }
                else
                {
                    string savePath = Path.Combine(ToPath, Path.GetFileName(FilePath));
                    Image img = Image.FromFile(FilePath);
                    img.Save(savePath);
                    LoadPlaylistFromFolder();
                }
                
                AddPlaylistIcon(CurrentPlaylistPath, FullPlaylistIcon);
            }
        }

        //usuwanie aktualnej playlisty
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            RedDeleteButton.Show();
        }
        private void RedDeleteButton_MouseLeave(object sender, EventArgs e)
        {
            RedDeleteButton.Hide();
        }
        private void RedDeleteButton_Click(object sender, EventArgs e)
        {
            if(CurrentPlaylistPath == LastPlayPlaylist)
            {
                DeletePlayback();
                lastPlayedSongPath = "none";
                SidePlayButton.BackgroundImage = Properties.Resources.play_icon;
                SongsList.Clear();
            }
            RedDeleteButton.Hide();
            Directory.Delete(CurrentPlaylistPath, true);

            LoadPlaylistFromFolder();
            FirstPlaylistToLoad();
        }

        #endregion

        #endregion
        
    }
}
