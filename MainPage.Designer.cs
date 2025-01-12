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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatWifTools));
            walletNav1 = new wallet.walletNav();
            bundlerNav1 = new bundler.bundlerNav();
            btnSettings = new Button();
            btnBundler = new Button();
            btnWallets = new Button();
            btnProxies = new Button();
            btnTasks = new Button();
            pbxLogo = new PictureBox();
            lblAuthor = new Label();
            lblTitle = new Label();
            gbxMainNavBar = new BorderlessGroupBox();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            gbxMainNavBar.SuspendLayout();
            SuspendLayout();
            // 
            // walletNav1
            // 
            resources.ApplyResources(walletNav1, "walletNav1");
            walletNav1.BackColor = Color.Transparent;
            walletNav1.Name = "walletNav1";
            // 
            // bundlerNav1
            // 
            resources.ApplyResources(bundlerNav1, "bundlerNav1");
            bundlerNav1.Name = "bundlerNav1";
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
            gbxMainNavBar.Controls.Add(pbxLogo);
            gbxMainNavBar.Controls.Add(btnSettings);
            gbxMainNavBar.Controls.Add(btnProxies);
            gbxMainNavBar.Controls.Add(lblTitle);
            gbxMainNavBar.Controls.Add(btnTasks);
            gbxMainNavBar.Controls.Add(btnBundler);
            gbxMainNavBar.Controls.Add(btnWallets);
            gbxMainNavBar.Controls.Add(lblAuthor);
            gbxMainNavBar.Name = "gbxMainNavBar";
            gbxMainNavBar.TabStop = false;
            // 
            // CatWifTools
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(25, 25, 25);
            ControlBox = false;
            Controls.Add(walletNav1);
            Controls.Add(bundlerNav1);
            Controls.Add(gbxMainNavBar);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CatWifTools";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Load += CatWifTools_Load;
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            gbxMainNavBar.ResumeLayout(false);
            gbxMainNavBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private wallet.walletNav walletNav1;
        private bundler.bundlerNav bundlerNav1;
        public Button btnSettings;
        public Button btnBundler;
        public Button btnWallets;
        public Button btnProxies;
        public Button btnTasks;
        private PictureBox pbxLogo;
        private Label lblAuthor;
        private Label lblTitle;
        private catwiftools.BorderlessGroupBox borderlessGroupBox1;
        private BorderlessGroupBox gbxMainNavBar;
    }
}