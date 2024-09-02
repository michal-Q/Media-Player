namespace Media_Player
{
    partial class Form1
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.PlaylistTitleTextBox = new System.Windows.Forms.TextBox();
            this.PlaylistTitle = new System.Windows.Forms.Label();
            this.FullPlaylistIcon = new System.Windows.Forms.PictureBox();
            this.SidePanel2 = new System.Windows.Forms.Panel();
            this.SidePanelForButtons = new System.Windows.Forms.Panel();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SidePanel2Title = new System.Windows.Forms.Label();
            this.SidePanel1 = new System.Windows.Forms.Panel();
            this.ImportPlaylistButton = new System.Windows.Forms.Button();
            this.CreatePlaylistButton = new System.Windows.Forms.Button();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SidePlayButton = new System.Windows.Forms.Button();
            this.TimeOfWholeSong = new System.Windows.Forms.Label();
            this.CurrentSongTime = new System.Windows.Forms.Label();
            this.VolumeSlider = new CustomSlider();
            this.SongSlider = new CustomSlider();
            this.RedDeleteButton = new ePOSOne.btnProduct.Button_WOC();
            this.DeleteButton = new ePOSOne.btnProduct.Button_WOC();
            this.AddSongButton = new ePOSOne.btnProduct.Button_WOC();
            this.RandomButton = new ePOSOne.btnProduct.Button_WOC();
            this.PlayButton = new ePOSOne.btnProduct.Button_WOC();
            this.TopPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullPlaylistIcon)).BeginInit();
            this.SidePanel2.SuspendLayout();
            this.SidePanel1.SuspendLayout();
            this.BackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Black;
            this.TopPanel.Controls.Add(this.ExitButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1017, 34);
            this.TopPanel.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Yi Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Gray;
            this.ExitButton.Location = new System.Drawing.Point(978, -5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(40, 40);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CenterPanel
            // 
            this.CenterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CenterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CenterPanel.Controls.Add(this.RedDeleteButton);
            this.CenterPanel.Controls.Add(this.PlaylistTitleTextBox);
            this.CenterPanel.Controls.Add(this.DeleteButton);
            this.CenterPanel.Controls.Add(this.AddSongButton);
            this.CenterPanel.Controls.Add(this.RandomButton);
            this.CenterPanel.Controls.Add(this.PlayButton);
            this.CenterPanel.Controls.Add(this.PlaylistTitle);
            this.CenterPanel.Controls.Add(this.FullPlaylistIcon);
            this.CenterPanel.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CenterPanel.Location = new System.Drawing.Point(264, 34);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(741, 473);
            this.CenterPanel.TabIndex = 2;
            // 
            // PlaylistTitleTextBox
            // 
            this.PlaylistTitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PlaylistTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlaylistTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.PlaylistTitleTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.PlaylistTitleTextBox.Location = new System.Drawing.Point(165, 57);
            this.PlaylistTitleTextBox.MaximumSize = new System.Drawing.Size(573, 0);
            this.PlaylistTitleTextBox.MaxLength = 19;
            this.PlaylistTitleTextBox.Name = "PlaylistTitleTextBox";
            this.PlaylistTitleTextBox.Size = new System.Drawing.Size(573, 55);
            this.PlaylistTitleTextBox.TabIndex = 9;
            this.PlaylistTitleTextBox.TabStop = false;
            this.PlaylistTitleTextBox.Text = "Platlist Name";
            this.PlaylistTitleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlaylistTitleTextBox_KeyDown);
            this.PlaylistTitleTextBox.MouseLeave += new System.EventHandler(this.PlaylistTitleTextBox_MouseLeave);
            // 
            // PlaylistTitle
            // 
            this.PlaylistTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaylistTitle.ForeColor = System.Drawing.Color.LightGray;
            this.PlaylistTitle.Location = new System.Drawing.Point(155, 57);
            this.PlaylistTitle.Name = "PlaylistTitle";
            this.PlaylistTitle.Size = new System.Drawing.Size(545, 68);
            this.PlaylistTitle.TabIndex = 1;
            this.PlaylistTitle.Text = "Playlist Name";
            this.PlaylistTitle.Click += new System.EventHandler(this.PlaylistTitle_Click);
            // 
            // FullPlaylistIcon
            // 
            this.FullPlaylistIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.FullPlaylistIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FullPlaylistIcon.Location = new System.Drawing.Point(37, 33);
            this.FullPlaylistIcon.Name = "FullPlaylistIcon";
            this.FullPlaylistIcon.Size = new System.Drawing.Size(100, 100);
            this.FullPlaylistIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FullPlaylistIcon.TabIndex = 0;
            this.FullPlaylistIcon.TabStop = false;
            this.FullPlaylistIcon.Click += new System.EventHandler(this.FullPlaylistIcon_Click);
            // 
            // SidePanel2
            // 
            this.SidePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SidePanel2.AutoScroll = true;
            this.SidePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.SidePanel2.Controls.Add(this.SidePanelForButtons);
            this.SidePanel2.Controls.Add(this.RefreshButton);
            this.SidePanel2.Controls.Add(this.SidePanel2Title);
            this.SidePanel2.Location = new System.Drawing.Point(12, 128);
            this.SidePanel2.Name = "SidePanel2";
            this.SidePanel2.Size = new System.Drawing.Size(241, 379);
            this.SidePanel2.TabIndex = 3;
            // 
            // SidePanelForButtons
            // 
            this.SidePanelForButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SidePanelForButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.SidePanelForButtons.Location = new System.Drawing.Point(0, 37);
            this.SidePanelForButtons.Name = "SidePanelForButtons";
            this.SidePanelForButtons.Size = new System.Drawing.Size(241, 339);
            this.SidePanelForButtons.TabIndex = 4;
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.RefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.RefreshButton.Location = new System.Drawing.Point(201, 13);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(1, 1);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.TabStop = false;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SidePanel2Title
            // 
            this.SidePanel2Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SidePanel2Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SidePanel2Title.ForeColor = System.Drawing.Color.LightGray;
            this.SidePanel2Title.Location = new System.Drawing.Point(3, 8);
            this.SidePanel2Title.Name = "SidePanel2Title";
            this.SidePanel2Title.Size = new System.Drawing.Size(238, 25);
            this.SidePanel2Title.TabIndex = 0;
            this.SidePanel2Title.Text = "Your Playlists";
            this.SidePanel2Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SidePanel1
            // 
            this.SidePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SidePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.SidePanel1.Controls.Add(this.ImportPlaylistButton);
            this.SidePanel1.Controls.Add(this.CreatePlaylistButton);
            this.SidePanel1.Location = new System.Drawing.Point(12, 34);
            this.SidePanel1.Name = "SidePanel1";
            this.SidePanel1.Size = new System.Drawing.Size(241, 83);
            this.SidePanel1.TabIndex = 4;
            // 
            // ImportPlaylistButton
            // 
            this.ImportPlaylistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ImportPlaylistButton.FlatAppearance.BorderSize = 0;
            this.ImportPlaylistButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ImportPlaylistButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ImportPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportPlaylistButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportPlaylistButton.ForeColor = System.Drawing.Color.LightGray;
            this.ImportPlaylistButton.Location = new System.Drawing.Point(0, 43);
            this.ImportPlaylistButton.Name = "ImportPlaylistButton";
            this.ImportPlaylistButton.Size = new System.Drawing.Size(241, 37);
            this.ImportPlaylistButton.TabIndex = 1;
            this.ImportPlaylistButton.TabStop = false;
            this.ImportPlaylistButton.Text = "Import Playlist";
            this.ImportPlaylistButton.UseVisualStyleBackColor = false;
            this.ImportPlaylistButton.Click += new System.EventHandler(this.ImportPlaylistButton_Click);
            this.ImportPlaylistButton.MouseEnter += new System.EventHandler(this.OnButtonHoverEnter);
            this.ImportPlaylistButton.MouseLeave += new System.EventHandler(this.OnButtonHoverLeave);
            // 
            // CreatePlaylistButton
            // 
            this.CreatePlaylistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreatePlaylistButton.FlatAppearance.BorderSize = 0;
            this.CreatePlaylistButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreatePlaylistButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CreatePlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreatePlaylistButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePlaylistButton.ForeColor = System.Drawing.Color.LightGray;
            this.CreatePlaylistButton.Location = new System.Drawing.Point(0, 3);
            this.CreatePlaylistButton.Name = "CreatePlaylistButton";
            this.CreatePlaylistButton.Size = new System.Drawing.Size(241, 37);
            this.CreatePlaylistButton.TabIndex = 0;
            this.CreatePlaylistButton.TabStop = false;
            this.CreatePlaylistButton.Text = "Create Playlist";
            this.CreatePlaylistButton.UseVisualStyleBackColor = false;
            this.CreatePlaylistButton.Click += new System.EventHandler(this.CreatePlaylistButton_Click);
            this.CreatePlaylistButton.MouseEnter += new System.EventHandler(this.OnButtonHoverEnter);
            this.CreatePlaylistButton.MouseLeave += new System.EventHandler(this.OnButtonHoverLeave);
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.Black;
            this.BackPanel.Controls.Add(this.PreviousButton);
            this.BackPanel.Controls.Add(this.NextButton);
            this.BackPanel.Controls.Add(this.button1);
            this.BackPanel.Controls.Add(this.SidePlayButton);
            this.BackPanel.Controls.Add(this.TimeOfWholeSong);
            this.BackPanel.Controls.Add(this.VolumeSlider);
            this.BackPanel.Controls.Add(this.CurrentSongTime);
            this.BackPanel.Controls.Add(this.SongSlider);
            this.BackPanel.Controls.Add(this.TopPanel);
            this.BackPanel.Controls.Add(this.SidePanel1);
            this.BackPanel.Controls.Add(this.CenterPanel);
            this.BackPanel.Controls.Add(this.SidePanel2);
            this.BackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPanel.Location = new System.Drawing.Point(0, 0);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(1017, 582);
            this.BackPanel.TabIndex = 5;
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackgroundImage = global::Media_Player.Properties.Resources.previous_icon;
            this.PreviousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PreviousButton.FlatAppearance.BorderSize = 0;
            this.PreviousButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousButton.Location = new System.Drawing.Point(40, 525);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(40, 40);
            this.PreviousButton.TabIndex = 12;
            this.PreviousButton.TabStop = false;
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            this.PreviousButton.MouseEnter += new System.EventHandler(this.BiggerWhen_MouseEnter);
            this.PreviousButton.MouseLeave += new System.EventHandler(this.SmallerWhen_MouseLeave);
            // 
            // NextButton
            // 
            this.NextButton.BackgroundImage = global::Media_Player.Properties.Resources.next_icon;
            this.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Location = new System.Drawing.Point(180, 525);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(40, 40);
            this.NextButton.TabIndex = 11;
            this.NextButton.TabStop = false;
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            this.NextButton.MouseEnter += new System.EventHandler(this.BiggerWhen_MouseEnter);
            this.NextButton.MouseLeave += new System.EventHandler(this.SmallerWhen_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Media_Player.Properties.Resources.volume_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(829, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 18);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SidePlayButton
            // 
            this.SidePlayButton.BackgroundImage = global::Media_Player.Properties.Resources.play_icon;
            this.SidePlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SidePlayButton.FlatAppearance.BorderSize = 0;
            this.SidePlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.SidePlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SidePlayButton.Location = new System.Drawing.Point(106, 521);
            this.SidePlayButton.Name = "SidePlayButton";
            this.SidePlayButton.Size = new System.Drawing.Size(48, 48);
            this.SidePlayButton.TabIndex = 9;
            this.SidePlayButton.TabStop = false;
            this.SidePlayButton.UseVisualStyleBackColor = true;
            this.SidePlayButton.Click += new System.EventHandler(this.SidePlayButton_Click);
            this.SidePlayButton.MouseEnter += new System.EventHandler(this.BiggerWhen_MouseEnter);
            this.SidePlayButton.MouseLeave += new System.EventHandler(this.SmallerWhen_MouseLeave);
            // 
            // TimeOfWholeSong
            // 
            this.TimeOfWholeSong.AutoSize = true;
            this.TimeOfWholeSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeOfWholeSong.ForeColor = System.Drawing.Color.Silver;
            this.TimeOfWholeSong.Location = new System.Drawing.Point(752, 539);
            this.TimeOfWholeSong.Name = "TimeOfWholeSong";
            this.TimeOfWholeSong.Size = new System.Drawing.Size(32, 13);
            this.TimeOfWholeSong.TabIndex = 8;
            this.TimeOfWholeSong.Text = "0:00";
            // 
            // CurrentSongTime
            // 
            this.CurrentSongTime.AutoSize = true;
            this.CurrentSongTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSongTime.ForeColor = System.Drawing.Color.Silver;
            this.CurrentSongTime.Location = new System.Drawing.Point(261, 539);
            this.CurrentSongTime.Name = "CurrentSongTime";
            this.CurrentSongTime.Size = new System.Drawing.Size(32, 13);
            this.CurrentSongTime.TabIndex = 6;
            this.CurrentSongTime.Text = "0:00";
            // 
            // VolumeSlider
            // 
            this.VolumeSlider.Location = new System.Drawing.Point(853, 530);
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.Size = new System.Drawing.Size(152, 30);
            this.VolumeSlider.TabIndex = 7;
            this.VolumeSlider.TabStop = false;
            this.VolumeSlider.Text = "customSlider2";
            this.VolumeSlider.Value = 1;
            this.VolumeSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VolumeChanged);
            // 
            // SongSlider
            // 
            this.SongSlider.Location = new System.Drawing.Point(296, 530);
            this.SongSlider.Name = "SongSlider";
            this.SongSlider.Size = new System.Drawing.Size(454, 30);
            this.SongSlider.TabIndex = 5;
            this.SongSlider.TabStop = false;
            this.SongSlider.Text = "customSlider1";
            this.SongSlider.Value = 0;
            this.SongSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CurrentSongTimeChanged);
            // 
            // RedDeleteButton
            // 
            this.RedDeleteButton.BorderColor = System.Drawing.Color.Crimson;
            this.RedDeleteButton.ButtonColor = System.Drawing.Color.Crimson;
            this.RedDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RedDeleteButton.FlatAppearance.BorderSize = 0;
            this.RedDeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RedDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedDeleteButton.ForeColor = System.Drawing.Color.LightGray;
            this.RedDeleteButton.Location = new System.Drawing.Point(277, 161);
            this.RedDeleteButton.Name = "RedDeleteButton";
            this.RedDeleteButton.OnHoverBorderColor = System.Drawing.Color.Crimson;
            this.RedDeleteButton.OnHoverButtonColor = System.Drawing.Color.Crimson;
            this.RedDeleteButton.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.RedDeleteButton.Size = new System.Drawing.Size(105, 32);
            this.RedDeleteButton.TabIndex = 10;
            this.RedDeleteButton.TabStop = false;
            this.RedDeleteButton.Text = "Delete";
            this.RedDeleteButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.RedDeleteButton.UseVisualStyleBackColor = false;
            this.RedDeleteButton.Click += new System.EventHandler(this.RedDeleteButton_Click);
            this.RedDeleteButton.MouseLeave += new System.EventHandler(this.RedDeleteButton_MouseLeave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DeleteButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.LightGray;
            this.DeleteButton.Location = new System.Drawing.Point(277, 161);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DeleteButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DeleteButton.OnHoverTextColor = System.Drawing.Color.LightGray;
            this.DeleteButton.Size = new System.Drawing.Size(105, 32);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.TabStop = false;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextColor = System.Drawing.Color.LightGray;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddSongButton
            // 
            this.AddSongButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AddSongButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AddSongButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.AddSongButton.FlatAppearance.BorderSize = 0;
            this.AddSongButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.AddSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSongButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSongButton.ForeColor = System.Drawing.Color.LightGray;
            this.AddSongButton.Location = new System.Drawing.Point(397, 161);
            this.AddSongButton.Name = "AddSongButton";
            this.AddSongButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AddSongButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AddSongButton.OnHoverTextColor = System.Drawing.Color.LightGray;
            this.AddSongButton.Size = new System.Drawing.Size(105, 32);
            this.AddSongButton.TabIndex = 7;
            this.AddSongButton.TabStop = false;
            this.AddSongButton.Text = "Add";
            this.AddSongButton.TextColor = System.Drawing.Color.LightGray;
            this.AddSongButton.UseVisualStyleBackColor = false;
            this.AddSongButton.Click += new System.EventHandler(this.AddSongButton_Click);
            this.AddSongButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Add_Button_MouseDown);
            this.AddSongButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Add_Button_MouseUp);
            // 
            // RandomButton
            // 
            this.RandomButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RandomButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RandomButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RandomButton.FlatAppearance.BorderSize = 0;
            this.RandomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RandomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RandomButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomButton.ForeColor = System.Drawing.Color.LightGray;
            this.RandomButton.Location = new System.Drawing.Point(157, 161);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.RandomButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.RandomButton.OnHoverTextColor = System.Drawing.Color.LightGray;
            this.RandomButton.Size = new System.Drawing.Size(105, 32);
            this.RandomButton.TabIndex = 6;
            this.RandomButton.TabStop = false;
            this.RandomButton.Text = "Random";
            this.RandomButton.TextColor = System.Drawing.Color.LightGray;
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Random_Button_MouseDown);
            // 
            // PlayButton
            // 
            this.PlayButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PlayButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PlayButton.FlatAppearance.BorderSize = 0;
            this.PlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.ForeColor = System.Drawing.Color.LightGray;
            this.PlayButton.Location = new System.Drawing.Point(37, 161);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.PlayButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.PlayButton.OnHoverTextColor = System.Drawing.Color.LightGray;
            this.PlayButton.Size = new System.Drawing.Size(105, 32);
            this.PlayButton.TabIndex = 5;
            this.PlayButton.TabStop = false;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextColor = System.Drawing.Color.LightGray;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Play_Button_MouseDown);
            this.PlayButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Play_Button_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1017, 582);
            this.Controls.Add(this.BackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.TopPanel.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullPlaylistIcon)).EndInit();
            this.SidePanel2.ResumeLayout(false);
            this.SidePanel1.ResumeLayout(false);
            this.BackPanel.ResumeLayout(false);
            this.BackPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel SidePanel2;
        private System.Windows.Forms.Panel SidePanel1;
        private System.Windows.Forms.Button CreatePlaylistButton;
        private System.Windows.Forms.Button ImportPlaylistButton;
        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.Label SidePanel2Title;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.PictureBox FullPlaylistIcon;
        private System.Windows.Forms.Label PlaylistTitle;
        private ePOSOne.btnProduct.Button_WOC PlayButton;
        private ePOSOne.btnProduct.Button_WOC AddSongButton;
        private ePOSOne.btnProduct.Button_WOC RandomButton;
        private CustomSlider SongSlider;
        private CustomSlider VolumeSlider;
        private System.Windows.Forms.Label CurrentSongTime;
        private System.Windows.Forms.Label TimeOfWholeSong;
        private System.Windows.Forms.Button SidePlayButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Panel SidePanelForButtons;
        private ePOSOne.btnProduct.Button_WOC DeleteButton;
        private System.Windows.Forms.TextBox PlaylistTitleTextBox;
        private ePOSOne.btnProduct.Button_WOC RedDeleteButton;
    }
}

