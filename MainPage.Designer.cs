namespace catwiftools
{
    partial class CatWifTools
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
            components = new System.ComponentModel.Container();
            pbxLogo = new PictureBox();
            lblAuthor = new Label();
            lblTitle = new Label();
            gbxWalletNav = new BorderlessGroupBox();
            btnWalletsVolume = new Button();
            btnWalletsBundler = new Button();
            btnWalletsBumpIt = new Button();
            label1 = new Label();
            bundlerMainPage1 = new bundler.bundlerMainPage();
            gbxBackground = new BorderlessGroupBox();
            pictureBox1 = new PictureBox();
            lblBackground = new Label();
            tmrClock = new System.Windows.Forms.Timer(components);
            lblClock = new Label();
            btnCloseApp = new Button();
            btnMinimise = new Button();
            tasksMainPage1 = new tasks.tasksMainPage();
            proxiesMainPage1 = new proxies.proxiesMainPage();
            walletVolume1 = new wallet.walletVolume();
            lblSettings = new Label();
            btnSettingsBundler = new Button();
            btnSettingsVolume = new Button();
            btnSettingsGeneral = new Button();
            btnSettingsBumpIt = new Button();
            gbxSettingsNav = new BorderlessGroupBox();
            mainNav1 = new mainNav();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            gbxWalletNav.SuspendLayout();
            gbxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxSettingsNav.SuspendLayout();
            SuspendLayout();
            // 
            // pbxLogo
            // 
            pbxLogo.BackColor = Color.FromArgb(25, 25, 25);
            pbxLogo.Image = Properties.Resources._21;
            pbxLogo.ImeMode = ImeMode.NoControl;
            pbxLogo.Location = new Point(15, 15);
            pbxLogo.Name = "pbxLogo";
            pbxLogo.Size = new Size(54, 54);
            pbxLogo.TabIndex = 10;
            pbxLogo.TabStop = false;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.ForeColor = Color.FromArgb(153, 153, 153);
            lblAuthor.ImeMode = ImeMode.NoControl;
            lblAuthor.Location = new Point(79, 53);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(74, 15);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "@water.1213";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F);
            lblTitle.ForeColor = Color.White;
            lblTitle.ImeMode = ImeMode.NoControl;
            lblTitle.Location = new Point(79, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(116, 28);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "CatWifTools";
            // 
            // gbxWalletNav
            // 
            gbxWalletNav.Controls.Add(btnWalletsVolume);
            gbxWalletNav.Controls.Add(btnWalletsBundler);
            gbxWalletNav.Controls.Add(btnWalletsBumpIt);
            gbxWalletNav.Controls.Add(label1);
            gbxWalletNav.Location = new Point(225, 43);
            gbxWalletNav.Name = "gbxWalletNav";
            gbxWalletNav.Size = new Size(200, 762);
            gbxWalletNav.TabIndex = 18;
            gbxWalletNav.TabStop = false;
            gbxWalletNav.VisibleChanged += gbxWalletNav_VisibleChanged;
            // 
            // btnWalletsVolume
            // 
            btnWalletsVolume.BackColor = Color.Transparent;
            btnWalletsVolume.BackgroundImageLayout = ImageLayout.None;
            btnWalletsVolume.FlatAppearance.BorderSize = 0;
            btnWalletsVolume.FlatStyle = FlatStyle.Flat;
            btnWalletsVolume.Font = new Font("Segoe UI", 12F);
            btnWalletsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            btnWalletsVolume.ImageAlign = ContentAlignment.MiddleLeft;
            btnWalletsVolume.ImeMode = ImeMode.NoControl;
            btnWalletsVolume.Location = new Point(10, 71);
            btnWalletsVolume.Name = "btnWalletsVolume";
            btnWalletsVolume.Padding = new Padding(5, 0, 5, 0);
            btnWalletsVolume.Size = new Size(180, 40);
            btnWalletsVolume.TabIndex = 10;
            btnWalletsVolume.Text = "Volume";
            btnWalletsVolume.UseMnemonic = false;
            btnWalletsVolume.UseVisualStyleBackColor = false;
            btnWalletsVolume.Click += Button_Click;
            // 
            // btnWalletsBundler
            // 
            btnWalletsBundler.BackColor = Color.Transparent;
            btnWalletsBundler.BackgroundImageLayout = ImageLayout.None;
            btnWalletsBundler.FlatAppearance.BorderSize = 0;
            btnWalletsBundler.FlatStyle = FlatStyle.Flat;
            btnWalletsBundler.Font = new Font("Segoe UI", 12F);
            btnWalletsBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnWalletsBundler.ImageAlign = ContentAlignment.MiddleLeft;
            btnWalletsBundler.ImeMode = ImeMode.NoControl;
            btnWalletsBundler.Location = new Point(10, 136);
            btnWalletsBundler.Name = "btnWalletsBundler";
            btnWalletsBundler.Padding = new Padding(5, 0, 5, 0);
            btnWalletsBundler.Size = new Size(180, 40);
            btnWalletsBundler.TabIndex = 9;
            btnWalletsBundler.Text = "Bundler";
            btnWalletsBundler.UseMnemonic = false;
            btnWalletsBundler.UseVisualStyleBackColor = false;
            // 
            // btnWalletsBumpIt
            // 
            btnWalletsBumpIt.BackColor = Color.Transparent;
            btnWalletsBumpIt.BackgroundImageLayout = ImageLayout.None;
            btnWalletsBumpIt.FlatAppearance.BorderSize = 0;
            btnWalletsBumpIt.FlatStyle = FlatStyle.Flat;
            btnWalletsBumpIt.Font = new Font("Segoe UI", 12F);
            btnWalletsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            btnWalletsBumpIt.ImageAlign = ContentAlignment.MiddleLeft;
            btnWalletsBumpIt.ImeMode = ImeMode.NoControl;
            btnWalletsBumpIt.Location = new Point(10, 201);
            btnWalletsBumpIt.Name = "btnWalletsBumpIt";
            btnWalletsBumpIt.Padding = new Padding(5, 0, 5, 0);
            btnWalletsBumpIt.Size = new Size(180, 40);
            btnWalletsBumpIt.TabIndex = 8;
            btnWalletsBumpIt.Text = "Bump it";
            btnWalletsBumpIt.UseMnemonic = false;
            btnWalletsBumpIt.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = Color.White;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(10, 5);
            label1.Name = "label1";
            label1.Size = new Size(75, 28);
            label1.TabIndex = 7;
            label1.Text = "Wallets";
            // 
            // bundlerMainPage1
            // 
            bundlerMainPage1.BackColor = Color.Transparent;
            bundlerMainPage1.Location = new Point(225, 43);
            bundlerMainPage1.Name = "bundlerMainPage1";
            bundlerMainPage1.Size = new Size(1210, 762);
            bundlerMainPage1.TabIndex = 27;
            // 
            // gbxBackground
            // 
            gbxBackground.BackColor = Color.FromArgb(25, 25, 25);
            gbxBackground.Controls.Add(pictureBox1);
            gbxBackground.Controls.Add(lblBackground);
            gbxBackground.Location = new Point(700, 350);
            gbxBackground.Name = "gbxBackground";
            gbxBackground.Size = new Size(462, 85);
            gbxBackground.TabIndex = 23;
            gbxBackground.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(25, 25, 25);
            pictureBox1.Image = Properties.Resources._21;
            pictureBox1.ImeMode = ImeMode.NoControl;
            pictureBox1.Location = new Point(0, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 54);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // lblBackground
            // 
            lblBackground.AutoSize = true;
            lblBackground.Font = new Font("Segoe UI", 45F);
            lblBackground.ForeColor = Color.White;
            lblBackground.ImeMode = ImeMode.NoControl;
            lblBackground.Location = new Point(84, 2);
            lblBackground.Name = "lblBackground";
            lblBackground.Size = new Size(348, 81);
            lblBackground.TabIndex = 0;
            lblBackground.Text = "CatWifTools";
            // 
            // tmrClock
            // 
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.ForeColor = Color.FromArgb(153, 153, 153);
            lblClock.ImeMode = ImeMode.NoControl;
            lblClock.Location = new Point(1250, 14);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(0, 15);
            lblClock.TabIndex = 24;
            // 
            // btnCloseApp
            // 
            btnCloseApp.BackColor = Color.FromArgb(192, 0, 0);
            btnCloseApp.FlatStyle = FlatStyle.Flat;
            btnCloseApp.ImeMode = ImeMode.NoControl;
            btnCloseApp.Location = new Point(1406, 10);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(22, 22);
            btnCloseApp.TabIndex = 25;
            btnCloseApp.Text = "X";
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // btnMinimise
            // 
            btnMinimise.BackColor = Color.DimGray;
            btnMinimise.FlatStyle = FlatStyle.Flat;
            btnMinimise.ImeMode = ImeMode.NoControl;
            btnMinimise.Location = new Point(1378, 10);
            btnMinimise.Name = "btnMinimise";
            btnMinimise.Size = new Size(22, 22);
            btnMinimise.TabIndex = 26;
            btnMinimise.Text = "-";
            btnMinimise.UseVisualStyleBackColor = false;
            btnMinimise.Click += btnMinimise_Click;
            // 
            // tasksMainPage1
            // 
            tasksMainPage1.BackColor = Color.Transparent;
            tasksMainPage1.Location = new Point(225, 43);
            tasksMainPage1.Name = "tasksMainPage1";
            tasksMainPage1.Size = new Size(1210, 762);
            tasksMainPage1.TabIndex = 28;
            // 
            // proxiesMainPage1
            // 
            proxiesMainPage1.BackColor = Color.Transparent;
            proxiesMainPage1.Location = new Point(225, 43);
            proxiesMainPage1.Name = "proxiesMainPage1";
            proxiesMainPage1.Size = new Size(1210, 762);
            proxiesMainPage1.TabIndex = 29;
            // 
            // walletVolume1
            // 
            walletVolume1.BackColor = Color.Transparent;
            walletVolume1.Location = new Point(450, 43);
            walletVolume1.Name = "walletVolume1";
            walletVolume1.Size = new Size(990, 762);
            walletVolume1.TabIndex = 30;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Font = new Font("Segoe UI", 15F);
            lblSettings.ForeColor = Color.White;
            lblSettings.ImeMode = ImeMode.NoControl;
            lblSettings.Location = new Point(10, 5);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(83, 28);
            lblSettings.TabIndex = 11;
            lblSettings.Text = "Settings";
            // 
            // btnSettingsBundler
            // 
            btnSettingsBundler.BackColor = Color.Transparent;
            btnSettingsBundler.BackgroundImageLayout = ImageLayout.None;
            btnSettingsBundler.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsBundler.FlatStyle = FlatStyle.Flat;
            btnSettingsBundler.Font = new Font("Segoe UI", 12F);
            btnSettingsBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBundler.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsBundler.ImeMode = ImeMode.NoControl;
            btnSettingsBundler.Location = new Point(10, 201);
            btnSettingsBundler.Name = "btnSettingsBundler";
            btnSettingsBundler.Padding = new Padding(5, 0, 5, 0);
            btnSettingsBundler.Size = new Size(180, 40);
            btnSettingsBundler.TabIndex = 12;
            btnSettingsBundler.Text = "Bundler";
            btnSettingsBundler.UseMnemonic = false;
            btnSettingsBundler.UseVisualStyleBackColor = false;
            // 
            // btnSettingsVolume
            // 
            btnSettingsVolume.BackColor = Color.Transparent;
            btnSettingsVolume.BackgroundImageLayout = ImageLayout.None;
            btnSettingsVolume.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsVolume.FlatStyle = FlatStyle.Flat;
            btnSettingsVolume.Font = new Font("Segoe UI", 12F);
            btnSettingsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsVolume.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsVolume.ImeMode = ImeMode.NoControl;
            btnSettingsVolume.Location = new Point(10, 136);
            btnSettingsVolume.Name = "btnSettingsVolume";
            btnSettingsVolume.Padding = new Padding(5, 0, 5, 0);
            btnSettingsVolume.Size = new Size(180, 40);
            btnSettingsVolume.TabIndex = 13;
            btnSettingsVolume.Text = "Volume";
            btnSettingsVolume.UseMnemonic = false;
            btnSettingsVolume.UseVisualStyleBackColor = false;
            // 
            // btnSettingsGeneral
            // 
            btnSettingsGeneral.BackColor = Color.Transparent;
            btnSettingsGeneral.BackgroundImageLayout = ImageLayout.None;
            btnSettingsGeneral.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsGeneral.FlatStyle = FlatStyle.Flat;
            btnSettingsGeneral.Font = new Font("Segoe UI", 12F);
            btnSettingsGeneral.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsGeneral.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsGeneral.ImeMode = ImeMode.NoControl;
            btnSettingsGeneral.Location = new Point(10, 71);
            btnSettingsGeneral.Name = "btnSettingsGeneral";
            btnSettingsGeneral.Padding = new Padding(5, 0, 5, 0);
            btnSettingsGeneral.Size = new Size(180, 40);
            btnSettingsGeneral.TabIndex = 14;
            btnSettingsGeneral.Text = "General";
            btnSettingsGeneral.UseMnemonic = false;
            btnSettingsGeneral.UseVisualStyleBackColor = false;
            // 
            // btnSettingsBumpIt
            // 
            btnSettingsBumpIt.BackColor = Color.Transparent;
            btnSettingsBumpIt.BackgroundImageLayout = ImageLayout.None;
            btnSettingsBumpIt.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsBumpIt.FlatStyle = FlatStyle.Flat;
            btnSettingsBumpIt.Font = new Font("Segoe UI", 12F);
            btnSettingsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBumpIt.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsBumpIt.ImeMode = ImeMode.NoControl;
            btnSettingsBumpIt.Location = new Point(10, 266);
            btnSettingsBumpIt.Name = "btnSettingsBumpIt";
            btnSettingsBumpIt.Padding = new Padding(5, 0, 5, 0);
            btnSettingsBumpIt.Size = new Size(180, 40);
            btnSettingsBumpIt.TabIndex = 16;
            btnSettingsBumpIt.Text = "Bump It";
            btnSettingsBumpIt.UseMnemonic = false;
            btnSettingsBumpIt.UseVisualStyleBackColor = false;
            // 
            // gbxSettingsNav
            // 
            gbxSettingsNav.Controls.Add(btnSettingsBumpIt);
            gbxSettingsNav.Controls.Add(btnSettingsGeneral);
            gbxSettingsNav.Controls.Add(btnSettingsVolume);
            gbxSettingsNav.Controls.Add(btnSettingsBundler);
            gbxSettingsNav.Controls.Add(lblSettings);
            gbxSettingsNav.Location = new Point(225, 43);
            gbxSettingsNav.Name = "gbxSettingsNav";
            gbxSettingsNav.Size = new Size(200, 762);
            gbxSettingsNav.TabIndex = 22;
            gbxSettingsNav.TabStop = false;
            gbxSettingsNav.VisibleChanged += gbxSettingsNav_VisibleChanged;
            // 
            // mainNav1
            // 
            mainNav1.BackColor = Color.Transparent;
            mainNav1.Location = new Point(5, 100);
            mainNav1.Name = "mainNav1";
            mainNav1.Size = new Size(200, 762);
            mainNav1.TabIndex = 31;
            // 
            // CatWifTools
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1440, 810);
            ControlBox = false;
            Controls.Add(mainNav1);
            Controls.Add(pbxLogo);
            Controls.Add(btnMinimise);
            Controls.Add(lblTitle);
            Controls.Add(btnCloseApp);
            Controls.Add(lblClock);
            Controls.Add(lblAuthor);
            Controls.Add(gbxSettingsNav);
            Controls.Add(walletVolume1);
            Controls.Add(gbxWalletNav);
            Controls.Add(bundlerMainPage1);
            Controls.Add(tasksMainPage1);
            Controls.Add(proxiesMainPage1);
            Controls.Add(gbxBackground);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CatWifTools";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainPage";
            Load += CatWifTools_Load;
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            gbxWalletNav.ResumeLayout(false);
            gbxWalletNav.PerformLayout();
            gbxBackground.ResumeLayout(false);
            gbxBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxSettingsNav.ResumeLayout(false);
            gbxSettingsNav.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbxLogo;
        private Label lblAuthor;
        private Label lblTitle;
        private BorderlessGroupBox gbxWalletNav;
        public Button btnWalletsVolume;
        public Button btnWalletsBundler;
        public Button btnWalletsBumpIt;
        private Label label1;
        private BorderlessGroupBox gbxBackground;
        private PictureBox pictureBox1;
        private Label lblBackground;
        private System.Windows.Forms.Timer tmrClock;
        private Label lblClock;
        private Button btnCloseApp;
        private Button btnMinimise;
        private bundler.bundlerMainPage bundlerMainPage1;
        private tasks.tasksMainPage tasksMainPage1;
        private proxies.proxiesMainPage proxiesMainPage1;
        private wallet.walletVolume walletVolume1;
        private Label lblSettings;
        public Button btnSettingsBundler;
        public Button btnSettingsVolume;
        public Button btnSettingsGeneral;
        public Button btnSettingsBumpIt;
        private BorderlessGroupBox gbxSettingsNav;
        private mainNav mainNav1;
    }
}