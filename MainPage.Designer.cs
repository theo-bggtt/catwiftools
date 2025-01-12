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
            gbxProxies = new BorderlessGroupBox();
            lblProxies = new Label();
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
            gbxTasks = new BorderlessGroupBox();
            label2 = new Label();
            gbxBundlerNav = new BorderlessGroupBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            gbxMainNavBar.SuspendLayout();
            gbxWalletNav.SuspendLayout();
            gbxProxies.SuspendLayout();
            gbxSettingsNav.SuspendLayout();
            gbxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxTasks.SuspendLayout();
            gbxBundlerNav.SuspendLayout();
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
            btnSettings.Click += btnSettings_Click;
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
            btnBundler.Click += btnBundler_Click;
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
            btnWallets.Click += btnWallets_Click;
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
            btnProxies.Click += btnProxies_Click;
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
            btnTasks.Click += btnTasks_Click;
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
            lblTitle.ForeColor = Color.FromArgb(153, 153, 153);
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
            btnWalletsVolume.Name = "btnWalletsVolume";
            btnWalletsVolume.UseMnemonic = false;
            btnWalletsVolume.UseVisualStyleBackColor = false;
            // 
            // btnWalletsBundler
            // 
            resources.ApplyResources(btnWalletsBundler, "btnWalletsBundler");
            btnWalletsBundler.BackColor = Color.Transparent;
            btnWalletsBundler.FlatAppearance.BorderSize = 0;
            btnWalletsBundler.ForeColor = Color.FromArgb(153, 153, 153);
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
            btnWalletsBumpIt.Image = Properties.Resources.tasks;
            btnWalletsBumpIt.Name = "btnWalletsBumpIt";
            btnWalletsBumpIt.UseMnemonic = false;
            btnWalletsBumpIt.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(153, 153, 153);
            label1.Name = "label1";
            // 
            // gbxProxies
            // 
            resources.ApplyResources(gbxProxies, "gbxProxies");
            gbxProxies.BackColor = Color.FromArgb(25, 25, 25);
            gbxProxies.Controls.Add(lblProxies);
            gbxProxies.Name = "gbxProxies";
            gbxProxies.TabStop = false;
            // 
            // lblProxies
            // 
            resources.ApplyResources(lblProxies, "lblProxies");
            lblProxies.ForeColor = Color.FromArgb(153, 153, 153);
            lblProxies.Name = "lblProxies";
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
            btnSettingsBumpIt.FlatAppearance.BorderSize = 0;
            btnSettingsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBumpIt.Name = "btnSettingsBumpIt";
            btnSettingsBumpIt.UseMnemonic = false;
            btnSettingsBumpIt.UseVisualStyleBackColor = false;
            // 
            // btnSettingsGeneral
            // 
            resources.ApplyResources(btnSettingsGeneral, "btnSettingsGeneral");
            btnSettingsGeneral.BackColor = Color.Transparent;
            btnSettingsGeneral.FlatAppearance.BorderSize = 0;
            btnSettingsGeneral.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsGeneral.Name = "btnSettingsGeneral";
            btnSettingsGeneral.UseMnemonic = false;
            btnSettingsGeneral.UseVisualStyleBackColor = false;
            // 
            // btnSettingsVolume
            // 
            resources.ApplyResources(btnSettingsVolume, "btnSettingsVolume");
            btnSettingsVolume.BackColor = Color.Transparent;
            btnSettingsVolume.FlatAppearance.BorderSize = 0;
            btnSettingsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsVolume.Name = "btnSettingsVolume";
            btnSettingsVolume.UseMnemonic = false;
            btnSettingsVolume.UseVisualStyleBackColor = false;
            // 
            // btnSettingsBundler
            // 
            resources.ApplyResources(btnSettingsBundler, "btnSettingsBundler");
            btnSettingsBundler.BackColor = Color.Transparent;
            btnSettingsBundler.FlatAppearance.BorderSize = 0;
            btnSettingsBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettingsBundler.Name = "btnSettingsBundler";
            btnSettingsBundler.UseMnemonic = false;
            btnSettingsBundler.UseVisualStyleBackColor = false;
            // 
            // lblSettings
            // 
            resources.ApplyResources(lblSettings, "lblSettings");
            lblSettings.ForeColor = Color.FromArgb(153, 153, 153);
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
            lblBackground.ForeColor = Color.FromArgb(153, 153, 153);
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
            btnMinimise.Click += button1_Click;
            // 
            // gbxTasks
            // 
            resources.ApplyResources(gbxTasks, "gbxTasks");
            gbxTasks.Controls.Add(label2);
            gbxTasks.Name = "gbxTasks";
            gbxTasks.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(153, 153, 153);
            label2.Name = "label2";
            // 
            // gbxBundlerNav
            // 
            resources.ApplyResources(gbxBundlerNav, "gbxBundlerNav");
            gbxBundlerNav.Controls.Add(label3);
            gbxBundlerNav.Name = "gbxBundlerNav";
            gbxBundlerNav.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.FromArgb(153, 153, 153);
            label3.Name = "label3";
            // 
            // CatWifTools
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(25, 25, 25);
            ControlBox = false;
            Controls.Add(pbxLogo);
            Controls.Add(btnMinimise);
            Controls.Add(gbxBackground);
            Controls.Add(lblTitle);
            Controls.Add(btnCloseApp);
            Controls.Add(lblClock);
            Controls.Add(gbxMainNavBar);
            Controls.Add(gbxSettingsNav);
            Controls.Add(lblAuthor);
            Controls.Add(gbxWalletNav);
            Controls.Add(gbxBundlerNav);
            Controls.Add(gbxTasks);
            Controls.Add(gbxProxies);
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
            gbxProxies.ResumeLayout(false);
            gbxProxies.PerformLayout();
            gbxSettingsNav.ResumeLayout(false);
            gbxSettingsNav.PerformLayout();
            gbxBackground.ResumeLayout(false);
            gbxBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxTasks.ResumeLayout(false);
            gbxTasks.PerformLayout();
            gbxBundlerNav.ResumeLayout(false);
            gbxBundlerNav.PerformLayout();
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
        private BorderlessGroupBox gbxProxies;
        private BorderlessGroupBox gbxSettingsNav;
        public Button btnSettingsBumpIt;
        public Button btnSettingsGeneral;
        public Button btnSettingsVolume;
        public Button btnSettingsBundler;
        private Label lblSettings;
        private Label lblProxies;
        private BorderlessGroupBox gbxBackground;
        private PictureBox pictureBox1;
        private Label lblBackground;
        private System.Windows.Forms.Timer tmrClock;
        private Label lblClock;
        private Button btnCloseApp;
        private Button btnMinimise;
        private BorderlessGroupBox gbxTasks;
        private Label label2;
        private BorderlessGroupBox gbxBundlerNav;
        private Label label3;
    }
}