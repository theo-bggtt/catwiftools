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
            bundlerMainPage1 = new catwiftools.bundler.bundlerMainPage();
            gbxBackground = new BorderlessGroupBox();
            pictureBox1 = new PictureBox();
            lblBackground = new Label();
            tmrClock = new System.Windows.Forms.Timer(components);
            lblClock = new Label();
            btnCloseApp = new Button();
            btnMinimise = new Button();
            tasksMainPage1 = new catwiftools.tasks.tasksMainPage();
            proxiesMainPage1 = new catwiftools.proxies.proxiesMainPage();
            lblSettings = new Label();
            gbxSettingsNav = new BorderlessGroupBox();
            btnSettingsGeneral = new Button();
            btnSettingsVolume = new Button();
            btnSettingsBundler = new Button();
            btnSettingsBumpIt = new Button();
            gbxMainNav = new BorderlessGroupBox();
            btnSettings = new Button();
            btnProxies = new Button();
            btnTasks = new Button();
            btnBundler = new Button();
            btnWallets = new Button();
            settingsVolume1 = new catwiftools.settings.settingsVolume();
            settingsBundler1 = new catwiftools.settings.settingsBundler();
            settingsBumpIt1 = new catwiftools.settings.settingsBumpIt();
            walletVolume1 = new catwiftools.wallet.walletGroup();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            gbxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxSettingsNav.SuspendLayout();
            gbxMainNav.SuspendLayout();
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
            // gbxSettingsNav
            // 
            gbxSettingsNav.Controls.Add(btnSettingsGeneral);
            gbxSettingsNav.Controls.Add(btnSettingsVolume);
            gbxSettingsNav.Controls.Add(btnSettingsBundler);
            gbxSettingsNav.Controls.Add(btnSettingsBumpIt);
            gbxSettingsNav.Controls.Add(lblSettings);
            gbxSettingsNav.Location = new Point(225, 43);
            gbxSettingsNav.Name = "gbxSettingsNav";
            gbxSettingsNav.Size = new Size(200, 762);
            gbxSettingsNav.TabIndex = 22;
            gbxSettingsNav.TabStop = false;
            gbxSettingsNav.VisibleChanged += gbxSettingsNav_VisibleChanged;
            // 
            // btnSettingsGeneral
            // 
            btnSettingsGeneral.BackColor = Color.Transparent;
            btnSettingsGeneral.BackgroundImageLayout = ImageLayout.None;
            btnSettingsGeneral.FlatAppearance.BorderSize = 0;
            btnSettingsGeneral.FlatStyle = FlatStyle.Flat;
            btnSettingsGeneral.Font = new Font("Segoe UI", 12F);
            btnSettingsGeneral.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsGeneral.Image = Properties.Resources.settings;
            btnSettingsGeneral.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsGeneral.ImeMode = ImeMode.NoControl;
            btnSettingsGeneral.Location = new Point(14, 71);
            btnSettingsGeneral.Name = "btnSettingsGeneral";
            btnSettingsGeneral.Padding = new Padding(5, 0, 5, 0);
            btnSettingsGeneral.Size = new Size(180, 40);
            btnSettingsGeneral.TabIndex = 20;
            btnSettingsGeneral.Tag = "settings";
            btnSettingsGeneral.Text = "General";
            btnSettingsGeneral.UseMnemonic = false;
            btnSettingsGeneral.UseVisualStyleBackColor = false;
            btnSettingsGeneral.Click += Button_Click;
            // 
            // btnSettingsVolume
            // 
            btnSettingsVolume.BackColor = Color.Transparent;
            btnSettingsVolume.BackgroundImageLayout = ImageLayout.None;
            btnSettingsVolume.FlatAppearance.BorderSize = 0;
            btnSettingsVolume.FlatStyle = FlatStyle.Flat;
            btnSettingsVolume.Font = new Font("Segoe UI", 12F);
            btnSettingsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsVolume.Image = Properties.Resources.volume;
            btnSettingsVolume.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsVolume.ImeMode = ImeMode.NoControl;
            btnSettingsVolume.Location = new Point(14, 136);
            btnSettingsVolume.Name = "btnSettingsVolume";
            btnSettingsVolume.Padding = new Padding(5, 0, 5, 0);
            btnSettingsVolume.Size = new Size(180, 40);
            btnSettingsVolume.TabIndex = 19;
            btnSettingsVolume.Tag = "volume";
            btnSettingsVolume.Text = "Volume";
            btnSettingsVolume.UseMnemonic = false;
            btnSettingsVolume.UseVisualStyleBackColor = false;
            btnSettingsVolume.Click += Button_Click;
            // 
            // btnSettingsBundler
            // 
            btnSettingsBundler.BackColor = Color.Transparent;
            btnSettingsBundler.BackgroundImageLayout = ImageLayout.None;
            btnSettingsBundler.FlatAppearance.BorderSize = 0;
            btnSettingsBundler.FlatStyle = FlatStyle.Flat;
            btnSettingsBundler.Font = new Font("Segoe UI", 12F);
            btnSettingsBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBundler.Image = Properties.Resources.bundler;
            btnSettingsBundler.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsBundler.ImeMode = ImeMode.NoControl;
            btnSettingsBundler.Location = new Point(14, 201);
            btnSettingsBundler.Name = "btnSettingsBundler";
            btnSettingsBundler.Padding = new Padding(5, 0, 5, 0);
            btnSettingsBundler.Size = new Size(180, 40);
            btnSettingsBundler.TabIndex = 18;
            btnSettingsBundler.Tag = "bundler";
            btnSettingsBundler.Text = "Bundler";
            btnSettingsBundler.UseMnemonic = false;
            btnSettingsBundler.UseVisualStyleBackColor = false;
            btnSettingsBundler.Click += Button_Click;
            // 
            // btnSettingsBumpIt
            // 
            btnSettingsBumpIt.BackColor = Color.Transparent;
            btnSettingsBumpIt.BackgroundImageLayout = ImageLayout.None;
            btnSettingsBumpIt.FlatAppearance.BorderSize = 0;
            btnSettingsBumpIt.FlatStyle = FlatStyle.Flat;
            btnSettingsBumpIt.Font = new Font("Segoe UI", 12F);
            btnSettingsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBumpIt.Image = Properties.Resources.bumpIt;
            btnSettingsBumpIt.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettingsBumpIt.ImeMode = ImeMode.NoControl;
            btnSettingsBumpIt.Location = new Point(14, 266);
            btnSettingsBumpIt.Name = "btnSettingsBumpIt";
            btnSettingsBumpIt.Padding = new Padding(5, 0, 5, 0);
            btnSettingsBumpIt.Size = new Size(180, 40);
            btnSettingsBumpIt.TabIndex = 17;
            btnSettingsBumpIt.Tag = "bumpit";
            btnSettingsBumpIt.Text = "Bump it";
            btnSettingsBumpIt.UseMnemonic = false;
            btnSettingsBumpIt.UseVisualStyleBackColor = false;
            btnSettingsBumpIt.Click += Button_Click;
            // 
            // gbxMainNav
            // 
            gbxMainNav.Controls.Add(btnSettings);
            gbxMainNav.Controls.Add(btnProxies);
            gbxMainNav.Controls.Add(btnTasks);
            gbxMainNav.Controls.Add(btnBundler);
            gbxMainNav.Controls.Add(btnWallets);
            gbxMainNav.Location = new Point(5, 100);
            gbxMainNav.Name = "gbxMainNav";
            gbxMainNav.Size = new Size(200, 762);
            gbxMainNav.TabIndex = 32;
            gbxMainNav.TabStop = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BackgroundImageLayout = ImageLayout.None;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F);
            btnSettings.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.ImeMode = ImeMode.NoControl;
            btnSettings.Location = new Point(10, 274);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(5, 0, 5, 0);
            btnSettings.Size = new Size(180, 40);
            btnSettings.TabIndex = 25;
            btnSettings.Tag = "settings";
            btnSettings.Text = "Settings";
            btnSettings.UseMnemonic = false;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += Button_Click;
            // 
            // btnProxies
            // 
            btnProxies.BackColor = Color.Transparent;
            btnProxies.BackgroundImageLayout = ImageLayout.None;
            btnProxies.FlatAppearance.BorderSize = 0;
            btnProxies.FlatStyle = FlatStyle.Flat;
            btnProxies.Font = new Font("Segoe UI", 12F);
            btnProxies.ForeColor = Color.FromArgb(153, 153, 153);
            btnProxies.Image = Properties.Resources.proxies;
            btnProxies.ImageAlign = ContentAlignment.MiddleLeft;
            btnProxies.ImeMode = ImeMode.NoControl;
            btnProxies.Location = new Point(10, 209);
            btnProxies.Name = "btnProxies";
            btnProxies.Padding = new Padding(5, 0, 5, 0);
            btnProxies.Size = new Size(180, 40);
            btnProxies.TabIndex = 22;
            btnProxies.Tag = "proxies";
            btnProxies.Text = "Proxies";
            btnProxies.UseMnemonic = false;
            btnProxies.UseVisualStyleBackColor = false;
            btnProxies.Click += Button_Click;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = Color.Transparent;
            btnTasks.BackgroundImageLayout = ImageLayout.None;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 12F);
            btnTasks.ForeColor = Color.FromArgb(153, 153, 153);
            btnTasks.Image = Properties.Resources.tasks;
            btnTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnTasks.ImeMode = ImeMode.NoControl;
            btnTasks.Location = new Point(10, 14);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(5, 0, 5, 0);
            btnTasks.Size = new Size(180, 40);
            btnTasks.TabIndex = 21;
            btnTasks.Tag = "tasks";
            btnTasks.Text = "Tasks";
            btnTasks.UseMnemonic = false;
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += Button_Click;
            // 
            // btnBundler
            // 
            btnBundler.BackColor = Color.Transparent;
            btnBundler.BackgroundImageLayout = ImageLayout.None;
            btnBundler.FlatAppearance.BorderSize = 0;
            btnBundler.FlatStyle = FlatStyle.Flat;
            btnBundler.Font = new Font("Segoe UI", 12F);
            btnBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnBundler.Image = Properties.Resources.bundler;
            btnBundler.ImageAlign = ContentAlignment.MiddleLeft;
            btnBundler.ImeMode = ImeMode.NoControl;
            btnBundler.Location = new Point(10, 79);
            btnBundler.Name = "btnBundler";
            btnBundler.Padding = new Padding(5, 0, 5, 0);
            btnBundler.Size = new Size(180, 40);
            btnBundler.TabIndex = 24;
            btnBundler.Tag = "bundler";
            btnBundler.Text = "Bundler";
            btnBundler.UseMnemonic = false;
            btnBundler.UseVisualStyleBackColor = false;
            btnBundler.Click += Button_Click;
            // 
            // btnWallets
            // 
            btnWallets.BackColor = Color.Transparent;
            btnWallets.BackgroundImageLayout = ImageLayout.None;
            btnWallets.FlatAppearance.BorderSize = 0;
            btnWallets.FlatStyle = FlatStyle.Flat;
            btnWallets.Font = new Font("Segoe UI", 12F);
            btnWallets.ForeColor = Color.FromArgb(153, 153, 153);
            btnWallets.Image = Properties.Resources.wallets;
            btnWallets.ImageAlign = ContentAlignment.MiddleLeft;
            btnWallets.ImeMode = ImeMode.NoControl;
            btnWallets.Location = new Point(10, 144);
            btnWallets.Name = "btnWallets";
            btnWallets.Padding = new Padding(5, 0, 5, 0);
            btnWallets.Size = new Size(180, 40);
            btnWallets.TabIndex = 23;
            btnWallets.Tag = "wallets";
            btnWallets.Text = "Wallets";
            btnWallets.UseMnemonic = false;
            btnWallets.UseVisualStyleBackColor = false;
            btnWallets.Click += Button_Click;
            // 
            // settingsVolume1
            // 
            settingsVolume1.BackColor = Color.Transparent;
            settingsVolume1.Location = new Point(450, 43);
            settingsVolume1.Name = "settingsVolume1";
            settingsVolume1.Size = new Size(990, 762);
            settingsVolume1.TabIndex = 36;
            // 
            // settingsBundler1
            // 
            settingsBundler1.BackColor = Color.Transparent;
            settingsBundler1.Location = new Point(450, 43);
            settingsBundler1.Name = "settingsBundler1";
            settingsBundler1.Size = new Size(990, 762);
            settingsBundler1.TabIndex = 37;
            // 
            // settingsBumpIt1
            // 
            settingsBumpIt1.BackColor = Color.Transparent;
            settingsBumpIt1.Location = new Point(450, 43);
            settingsBumpIt1.Name = "settingsBumpIt1";
            settingsBumpIt1.Size = new Size(990, 762);
            settingsBumpIt1.TabIndex = 38;
            // 
            // walletVolume1
            // 
            walletVolume1.BackColor = Color.Transparent;
            walletVolume1.Location = new Point(225, 43);
            walletVolume1.Name = "walletVolume1";
            walletVolume1.Size = new Size(1210, 762);
            walletVolume1.TabIndex = 41;
            // 
            // CatWifTools
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1440, 810);
            ControlBox = false;
            Controls.Add(gbxMainNav);
            Controls.Add(pbxLogo);
            Controls.Add(btnMinimise);
            Controls.Add(lblTitle);
            Controls.Add(btnCloseApp);
            Controls.Add(lblClock);
            Controls.Add(lblAuthor);
            Controls.Add(gbxBackground);
            Controls.Add(gbxSettingsNav);
            Controls.Add(tasksMainPage1);
            Controls.Add(settingsBumpIt1);
            Controls.Add(settingsBundler1);
            Controls.Add(settingsVolume1);
            Controls.Add(proxiesMainPage1);
            Controls.Add(bundlerMainPage1);
            Controls.Add(walletVolume1);
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
            gbxBackground.ResumeLayout(false);
            gbxBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxSettingsNav.ResumeLayout(false);
            gbxSettingsNav.PerformLayout();
            gbxMainNav.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbxLogo;
        private Label lblAuthor;
        private Label lblTitle;
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
        private Label lblSettings;
        private BorderlessGroupBox gbxSettingsNav;
        private BorderlessGroupBox gbxMainNav;
        public Button btnSettings;
        public Button btnProxies;
        public Button btnTasks;
        public Button btnBundler;
        public Button btnWallets;
        private settings.settingsGeneral settingsGeneral1;
        private settings.settingsVolume settingsVolume1;
        private settings.settingsBundler settingsBundler1;
        private settings.settingsBumpIt settingsBumpIt1;
        public Button btnSettingsGeneral;
        public Button btnSettingsVolume;
        public Button btnSettingsBundler;
        public Button btnSettingsBumpIt;
        private wallet.walletGroup walletVolume1;
    }
}