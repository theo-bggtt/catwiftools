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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatWifTools));
            btnSettings = new Button();
            btnBundler = new Button();
            btnWallets = new Button();
            btnProxies = new Button();
            btnTasks = new Button();
            pbxLogo = new PictureBox();
            lblAuthor = new Label();
            lblTitle = new Label();
            gbxMainNavBar = new BorderlessGroupBox();
            gbxWalletNav = new BorderlessGroupBox();
            btnWalletsVolume = new Button();
            btnWalletsBundler = new Button();
            btnWalletsBumpIt = new Button();
            label1 = new Label();
            bundlerMainPage1 = new bundler.bundlerMainPage();
            gbxSettingsNav = new BorderlessGroupBox();
            btnSettingsBumpIt = new Button();
            btnSettingsGeneral = new Button();
            btnSettingsVolume = new Button();
            btnSettingsBundler = new Button();
            lblSettings = new Label();
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
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            gbxMainNavBar.SuspendLayout();
            gbxWalletNav.SuspendLayout();
            gbxSettingsNav.SuspendLayout();
            gbxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSettings
            // 
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.BackColor = Color.Transparent;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.Name = "btnSettings";
            btnSettings.UseMnemonic = false;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += Button_Click;
            // 
            // btnBundler
            // 
            resources.ApplyResources(btnBundler, "btnBundler");
            btnBundler.BackColor = Color.Transparent;
            btnBundler.FlatAppearance.BorderSize = 0;
            btnBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnBundler.Image = Properties.Resources.bundler;
            btnBundler.Name = "btnBundler";
            btnBundler.UseMnemonic = false;
            btnBundler.UseVisualStyleBackColor = false;
            btnBundler.Click += Button_Click;
            // 
            // btnWallets
            // 
            resources.ApplyResources(btnWallets, "btnWallets");
            btnWallets.BackColor = Color.Transparent;
            btnWallets.FlatAppearance.BorderSize = 0;
            btnWallets.ForeColor = Color.FromArgb(153, 153, 153);
            btnWallets.Image = Properties.Resources.wallets;
            btnWallets.Name = "btnWallets";
            btnWallets.UseMnemonic = false;
            btnWallets.UseVisualStyleBackColor = false;
            btnWallets.Click += Button_Click;
            // 
            // btnProxies
            // 
            resources.ApplyResources(btnProxies, "btnProxies");
            btnProxies.BackColor = Color.Transparent;
            btnProxies.FlatAppearance.BorderSize = 0;
            btnProxies.ForeColor = Color.FromArgb(153, 153, 153);
            btnProxies.Image = Properties.Resources.proxies;
            btnProxies.Name = "btnProxies";
            btnProxies.UseMnemonic = false;
            btnProxies.UseVisualStyleBackColor = false;
            btnProxies.Click += Button_Click;
            // 
            // btnTasks
            // 
            resources.ApplyResources(btnTasks, "btnTasks");
            btnTasks.BackColor = Color.Transparent;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.ForeColor = Color.FromArgb(153, 153, 153);
            btnTasks.Image = Properties.Resources.tasks;
            btnTasks.Name = "btnTasks";
            btnTasks.UseMnemonic = false;
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += Button_Click;
            // 
            // pbxLogo
            // 
            resources.ApplyResources(pbxLogo, "pbxLogo");
            pbxLogo.BackColor = Color.FromArgb(25, 25, 25);
            pbxLogo.Image = Properties.Resources._21;
            pbxLogo.Name = "pbxLogo";
            pbxLogo.TabStop = false;
            // 
            // lblAuthor
            // 
            resources.ApplyResources(lblAuthor, "lblAuthor");
            lblAuthor.ForeColor = Color.FromArgb(153, 153, 153);
            lblAuthor.Name = "lblAuthor";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.ForeColor = Color.White;
            lblTitle.Name = "lblTitle";
            // 
            // gbxMainNavBar
            // 
            resources.ApplyResources(gbxMainNavBar, "gbxMainNavBar");
            gbxMainNavBar.BackColor = Color.FromArgb(25, 25, 25);
            gbxMainNavBar.Controls.Add(btnSettings);
            gbxMainNavBar.Controls.Add(btnProxies);
            gbxMainNavBar.Controls.Add(btnTasks);
            gbxMainNavBar.Controls.Add(btnBundler);
            gbxMainNavBar.Controls.Add(btnWallets);
            gbxMainNavBar.Name = "gbxMainNavBar";
            gbxMainNavBar.TabStop = false;
            // 
            // gbxWalletNav
            // 
            resources.ApplyResources(gbxWalletNav, "gbxWalletNav");
            gbxWalletNav.Controls.Add(btnWalletsVolume);
            gbxWalletNav.Controls.Add(btnWalletsBundler);
            gbxWalletNav.Controls.Add(btnWalletsBumpIt);
            gbxWalletNav.Controls.Add(label1);
            gbxWalletNav.Name = "gbxWalletNav";
            gbxWalletNav.TabStop = false;
            gbxWalletNav.VisibleChanged += gbxWalletNav_VisibleChanged;
            // 
            // btnWalletsVolume
            // 
            resources.ApplyResources(btnWalletsVolume, "btnWalletsVolume");
            btnWalletsVolume.BackColor = Color.Transparent;
            btnWalletsVolume.FlatAppearance.BorderSize = 0;
            btnWalletsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            btnWalletsVolume.Image = Properties.Resources.folder;
            btnWalletsVolume.Name = "btnWalletsVolume";
            btnWalletsVolume.UseMnemonic = false;
            btnWalletsVolume.UseVisualStyleBackColor = false;
            btnWalletsVolume.Click += Button_Click;
            // 
            // btnWalletsBundler
            // 
            resources.ApplyResources(btnWalletsBundler, "btnWalletsBundler");
            btnWalletsBundler.BackColor = Color.Transparent;
            btnWalletsBundler.FlatAppearance.BorderSize = 0;
            btnWalletsBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnWalletsBundler.Image = Properties.Resources.folder;
            btnWalletsBundler.Name = "btnWalletsBundler";
            btnWalletsBundler.UseMnemonic = false;
            btnWalletsBundler.UseVisualStyleBackColor = false;
            // 
            // btnWalletsBumpIt
            // 
            resources.ApplyResources(btnWalletsBumpIt, "btnWalletsBumpIt");
            btnWalletsBumpIt.BackColor = Color.Transparent;
            btnWalletsBumpIt.FlatAppearance.BorderSize = 0;
            btnWalletsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            btnWalletsBumpIt.Image = Properties.Resources.folder;
            btnWalletsBumpIt.Name = "btnWalletsBumpIt";
            btnWalletsBumpIt.UseMnemonic = false;
            btnWalletsBumpIt.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // bundlerMainPage1
            // 
            resources.ApplyResources(bundlerMainPage1, "bundlerMainPage1");
            bundlerMainPage1.BackColor = Color.Transparent;
            bundlerMainPage1.Name = "bundlerMainPage1";
            // 
            // gbxSettingsNav
            // 
            resources.ApplyResources(gbxSettingsNav, "gbxSettingsNav");
            gbxSettingsNav.Controls.Add(btnSettingsBumpIt);
            gbxSettingsNav.Controls.Add(btnSettingsGeneral);
            gbxSettingsNav.Controls.Add(btnSettingsVolume);
            gbxSettingsNav.Controls.Add(btnSettingsBundler);
            gbxSettingsNav.Controls.Add(lblSettings);
            gbxSettingsNav.Name = "gbxSettingsNav";
            gbxSettingsNav.TabStop = false;
            gbxSettingsNav.VisibleChanged += gbxSettingsNav_VisibleChanged;
            // 
            // btnSettingsBumpIt
            // 
            resources.ApplyResources(btnSettingsBumpIt, "btnSettingsBumpIt");
            btnSettingsBumpIt.BackColor = Color.Transparent;
            btnSettingsBumpIt.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBumpIt.Image = Properties.Resources.bumpIt;
            btnSettingsBumpIt.Name = "btnSettingsBumpIt";
            btnSettingsBumpIt.UseMnemonic = false;
            btnSettingsBumpIt.UseVisualStyleBackColor = false;
            // 
            // btnSettingsGeneral
            // 
            resources.ApplyResources(btnSettingsGeneral, "btnSettingsGeneral");
            btnSettingsGeneral.BackColor = Color.Transparent;
            btnSettingsGeneral.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsGeneral.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsGeneral.Image = Properties.Resources.settings;
            btnSettingsGeneral.Name = "btnSettingsGeneral";
            btnSettingsGeneral.UseMnemonic = false;
            btnSettingsGeneral.UseVisualStyleBackColor = false;
            // 
            // btnSettingsVolume
            // 
            resources.ApplyResources(btnSettingsVolume, "btnSettingsVolume");
            btnSettingsVolume.BackColor = Color.Transparent;
            btnSettingsVolume.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsVolume.Image = Properties.Resources.volume;
            btnSettingsVolume.Name = "btnSettingsVolume";
            btnSettingsVolume.UseMnemonic = false;
            btnSettingsVolume.UseVisualStyleBackColor = false;
            // 
            // btnSettingsBundler
            // 
            resources.ApplyResources(btnSettingsBundler, "btnSettingsBundler");
            btnSettingsBundler.BackColor = Color.Transparent;
            btnSettingsBundler.FlatAppearance.BorderColor = Color.FromArgb(153, 153, 153);
            btnSettingsBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBundler.Image = Properties.Resources.bundler;
            btnSettingsBundler.Name = "btnSettingsBundler";
            btnSettingsBundler.UseMnemonic = false;
            btnSettingsBundler.UseVisualStyleBackColor = false;
            // 
            // lblSettings
            // 
            resources.ApplyResources(lblSettings, "lblSettings");
            lblSettings.ForeColor = Color.White;
            lblSettings.Name = "lblSettings";
            // 
            // gbxBackground
            // 
            resources.ApplyResources(gbxBackground, "gbxBackground");
            gbxBackground.BackColor = Color.FromArgb(25, 25, 25);
            gbxBackground.Controls.Add(pictureBox1);
            gbxBackground.Controls.Add(lblBackground);
            gbxBackground.Name = "gbxBackground";
            gbxBackground.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.BackColor = Color.FromArgb(25, 25, 25);
            pictureBox1.Image = Properties.Resources._21;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // lblBackground
            // 
            resources.ApplyResources(lblBackground, "lblBackground");
            lblBackground.ForeColor = Color.White;
            lblBackground.Name = "lblBackground";
            // 
            // tmrClock
            // 
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // lblClock
            // 
            resources.ApplyResources(lblClock, "lblClock");
            lblClock.ForeColor = Color.FromArgb(153, 153, 153);
            lblClock.Name = "lblClock";
            // 
            // btnCloseApp
            // 
            resources.ApplyResources(btnCloseApp, "btnCloseApp");
            btnCloseApp.BackColor = Color.FromArgb(192, 0, 0);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // btnMinimise
            // 
            resources.ApplyResources(btnMinimise, "btnMinimise");
            btnMinimise.BackColor = Color.DimGray;
            btnMinimise.Name = "btnMinimise";
            btnMinimise.UseVisualStyleBackColor = false;
            btnMinimise.Click += btnMinimise_Click;
            // 
            // tasksMainPage1
            // 
            resources.ApplyResources(tasksMainPage1, "tasksMainPage1");
            tasksMainPage1.BackColor = Color.Transparent;
            tasksMainPage1.Name = "tasksMainPage1";
            // 
            // proxiesMainPage1
            // 
            resources.ApplyResources(proxiesMainPage1, "proxiesMainPage1");
            proxiesMainPage1.BackColor = Color.Transparent;
            proxiesMainPage1.Name = "proxiesMainPage1";
            // 
            // walletVolume1
            // 
            resources.ApplyResources(walletVolume1, "walletVolume1");
            walletVolume1.BackColor = Color.Transparent;
            walletVolume1.Name = "walletVolume1";
            // 
            // CatWifTools
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(25, 25, 25);
            ControlBox = false;
            Controls.Add(pbxLogo);
            Controls.Add(btnMinimise);
            Controls.Add(lblTitle);
            Controls.Add(btnCloseApp);
            Controls.Add(lblClock);
            Controls.Add(gbxMainNavBar);
            Controls.Add(lblAuthor);
            Controls.Add(gbxWalletNav);
            Controls.Add(walletVolume1);
            Controls.Add(gbxBackground);
            Controls.Add(bundlerMainPage1);
            Controls.Add(tasksMainPage1);
            Controls.Add(proxiesMainPage1);
            Controls.Add(gbxSettingsNav);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CatWifTools";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Load += CatWifTools_Load;
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            gbxMainNavBar.ResumeLayout(false);
            gbxWalletNav.ResumeLayout(false);
            gbxWalletNav.PerformLayout();
            gbxSettingsNav.ResumeLayout(false);
            gbxSettingsNav.PerformLayout();
            gbxBackground.ResumeLayout(false);
            gbxBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button btnSettings;
        public Button btnBundler;
        public Button btnWallets;
        public Button btnProxies;
        public Button btnTasks;
        private PictureBox pbxLogo;
        private Label lblAuthor;
        private Label lblTitle;
        private BorderlessGroupBox gbxMainNavBar;
        private BorderlessGroupBox gbxWalletNav;
        public Button btnWalletsVolume;
        public Button btnWalletsBundler;
        public Button btnWalletsBumpIt;
        private Label label1;
        private BorderlessGroupBox gbxSettingsNav;
        public Button btnSettingsBumpIt;
        public Button btnSettingsGeneral;
        public Button btnSettingsVolume;
        public Button btnSettingsBundler;
        private Label lblSettings;
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
    }
}