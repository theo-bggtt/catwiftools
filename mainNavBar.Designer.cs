namespace catwiftools
{
    partial class mainNavBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblAuthor = new Label();
            pbxLogo = new PictureBox();
            btnTasks = new Button();
            btnProxies = new Button();
            btnWallets = new Button();
            btnBundler = new Button();
            btnSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(153, 153, 153);
            lblTitle.Location = new Point(74, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(116, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CatWifTools";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.ForeColor = Color.FromArgb(153, 153, 153);
            lblAuthor.Location = new Point(74, 48);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(74, 15);
            lblAuthor.TabIndex = 1;
            lblAuthor.Text = "@water.1213";
            // 
            // pbxLogo
            // 
            pbxLogo.BackColor = Color.FromArgb(25, 25, 25);
            pbxLogo.Image = Properties.Resources._21;
            pbxLogo.Location = new Point(10, 10);
            pbxLogo.Name = "pbxLogo";
            pbxLogo.Size = new Size(54, 54);
            pbxLogo.TabIndex = 2;
            pbxLogo.TabStop = false;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = Color.Transparent;
            btnTasks.BackgroundImageLayout = ImageLayout.None;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTasks.ForeColor = Color.FromArgb(153, 153, 153);
            btnTasks.Image = Properties.Resources.tasks;
            btnTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnTasks.Location = new Point(10, 104);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(5, 0, 5, 0);
            btnTasks.Size = new Size(180, 40);
            btnTasks.TabIndex = 3;
            btnTasks.Text = "Tasks";
            btnTasks.UseMnemonic = false;
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += btnTasks_Click;
            // 
            // btnProxies
            // 
            btnProxies.BackColor = Color.Transparent;
            btnProxies.BackgroundImageLayout = ImageLayout.None;
            btnProxies.FlatAppearance.BorderSize = 0;
            btnProxies.FlatStyle = FlatStyle.Flat;
            btnProxies.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProxies.ForeColor = Color.FromArgb(153, 153, 153);
            btnProxies.Image = Properties.Resources.proxies;
            btnProxies.ImageAlign = ContentAlignment.MiddleLeft;
            btnProxies.Location = new Point(10, 299);
            btnProxies.Name = "btnProxies";
            btnProxies.Padding = new Padding(5, 0, 5, 0);
            btnProxies.Size = new Size(180, 40);
            btnProxies.TabIndex = 4;
            btnProxies.Text = "Proxies";
            btnProxies.UseMnemonic = false;
            btnProxies.UseVisualStyleBackColor = false;
            btnProxies.Click += btnProxies_Click;
            // 
            // btnWallets
            // 
            btnWallets.BackColor = Color.Transparent;
            btnWallets.BackgroundImageLayout = ImageLayout.None;
            btnWallets.FlatAppearance.BorderSize = 0;
            btnWallets.FlatStyle = FlatStyle.Flat;
            btnWallets.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWallets.ForeColor = Color.FromArgb(153, 153, 153);
            btnWallets.Image = Properties.Resources.wallets;
            btnWallets.ImageAlign = ContentAlignment.MiddleLeft;
            btnWallets.Location = new Point(10, 234);
            btnWallets.Name = "btnWallets";
            btnWallets.Padding = new Padding(5, 0, 5, 0);
            btnWallets.Size = new Size(180, 40);
            btnWallets.TabIndex = 5;
            btnWallets.Text = "Wallets";
            btnWallets.UseMnemonic = false;
            btnWallets.UseVisualStyleBackColor = false;
            btnWallets.Click += btnWallets_Click;
            // 
            // btnBundler
            // 
            btnBundler.BackColor = Color.Transparent;
            btnBundler.BackgroundImageLayout = ImageLayout.None;
            btnBundler.FlatAppearance.BorderSize = 0;
            btnBundler.FlatStyle = FlatStyle.Flat;
            btnBundler.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnBundler.Image = Properties.Resources.bundler;
            btnBundler.ImageAlign = ContentAlignment.MiddleLeft;
            btnBundler.Location = new Point(10, 169);
            btnBundler.Name = "btnBundler";
            btnBundler.Padding = new Padding(5, 0, 5, 0);
            btnBundler.Size = new Size(180, 40);
            btnBundler.TabIndex = 6;
            btnBundler.Text = "Bundler";
            btnBundler.UseMnemonic = false;
            btnBundler.UseVisualStyleBackColor = false;
            btnBundler.Click += btnBundler_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BackgroundImageLayout = ImageLayout.None;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(10, 364);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(5, 0, 5, 0);
            btnSettings.Size = new Size(180, 40);
            btnSettings.TabIndex = 7;
            btnSettings.Text = "Settings";
            btnSettings.UseMnemonic = false;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // mainNavBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnSettings);
            Controls.Add(btnBundler);
            Controls.Add(btnWallets);
            Controls.Add(btnProxies);
            Controls.Add(btnTasks);
            Controls.Add(pbxLogo);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Margin = new Padding(0);
            Name = "mainNavBar";
            Size = new Size(200, 810);
            Load += mainNavBar_Load;
            ((System.ComponentModel.ISupportInitialize)pbxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblAuthor;
        private PictureBox pbxLogo;
        public Button btnTasks;
        public Button btnProxies;
        public Button btnWallets;
        public Button btnBundler;
        public Button btnSettings;
    }
}
