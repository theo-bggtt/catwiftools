namespace catwiftools.wallet
{
    partial class walletBundler
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
            loadWalletsButton = new Button();
            btnGenWallet = new Button();
            btnExport = new Button();
            btnImport = new Button();
            btnProfiles = new Button();
            btnCloseAccount = new Button();
            btnCheckBalances = new Button();
            lblSolBalance = new Label();
            lblWalletQt = new Label();
            lblBundlerTitle = new Label();
            SuspendLayout();
            // 
            // loadWalletsButton
            // 
            loadWalletsButton.BackColor = Color.FromArgb(78, 93, 148);
            loadWalletsButton.BackgroundImageLayout = ImageLayout.None;
            loadWalletsButton.FlatAppearance.BorderSize = 0;
            loadWalletsButton.FlatStyle = FlatStyle.Flat;
            loadWalletsButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loadWalletsButton.ForeColor = Color.White;
            loadWalletsButton.ImageAlign = ContentAlignment.MiddleLeft;
            loadWalletsButton.ImeMode = ImeMode.NoControl;
            loadWalletsButton.Location = new Point(476, 61);
            loadWalletsButton.Name = "loadWalletsButton";
            loadWalletsButton.Padding = new Padding(5, 0, 5, 0);
            loadWalletsButton.Size = new Size(120, 30);
            loadWalletsButton.TabIndex = 30;
            loadWalletsButton.Text = "Load wallets";
            loadWalletsButton.TextAlign = ContentAlignment.MiddleLeft;
            loadWalletsButton.UseMnemonic = false;
            loadWalletsButton.UseVisualStyleBackColor = false;
            // 
            // btnGenWallet
            // 
            btnGenWallet.BackColor = Color.FromArgb(78, 93, 148);
            btnGenWallet.BackgroundImageLayout = ImageLayout.None;
            btnGenWallet.FlatAppearance.BorderSize = 0;
            btnGenWallet.FlatStyle = FlatStyle.Flat;
            btnGenWallet.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenWallet.ForeColor = Color.White;
            btnGenWallet.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenWallet.ImeMode = ImeMode.NoControl;
            btnGenWallet.Location = new Point(324, 55);
            btnGenWallet.Name = "btnGenWallet";
            btnGenWallet.Padding = new Padding(5, 0, 5, 0);
            btnGenWallet.Size = new Size(120, 30);
            btnGenWallet.TabIndex = 29;
            btnGenWallet.Tag = "1";
            btnGenWallet.Text = "+  Gen Wallets";
            btnGenWallet.TextAlign = ContentAlignment.MiddleLeft;
            btnGenWallet.UseMnemonic = false;
            btnGenWallet.UseVisualStyleBackColor = false;
            btnGenWallet.Click += btnGenWallet_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(37, 37, 53);
            btnExport.BackgroundImageLayout = ImageLayout.None;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.ImeMode = ImeMode.NoControl;
            btnExport.Location = new Point(706, 125);
            btnExport.Name = "btnExport";
            btnExport.Padding = new Padding(5, 0, 5, 0);
            btnExport.Size = new Size(120, 30);
            btnExport.TabIndex = 28;
            btnExport.Text = "Export";
            btnExport.UseMnemonic = false;
            btnExport.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(37, 37, 53);
            btnImport.BackgroundImageLayout = ImageLayout.None;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImport.ForeColor = Color.White;
            btnImport.ImageAlign = ContentAlignment.MiddleLeft;
            btnImport.ImeMode = ImeMode.NoControl;
            btnImport.Location = new Point(571, 125);
            btnImport.Name = "btnImport";
            btnImport.Padding = new Padding(5, 0, 5, 0);
            btnImport.Size = new Size(120, 30);
            btnImport.TabIndex = 27;
            btnImport.Text = "Import";
            btnImport.UseMnemonic = false;
            btnImport.UseVisualStyleBackColor = false;
            // 
            // btnProfiles
            // 
            btnProfiles.BackColor = Color.FromArgb(37, 37, 53);
            btnProfiles.BackgroundImageLayout = ImageLayout.None;
            btnProfiles.FlatAppearance.BorderSize = 0;
            btnProfiles.FlatStyle = FlatStyle.Flat;
            btnProfiles.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProfiles.ForeColor = Color.White;
            btnProfiles.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfiles.ImeMode = ImeMode.NoControl;
            btnProfiles.Location = new Point(391, 125);
            btnProfiles.Name = "btnProfiles";
            btnProfiles.Padding = new Padding(5, 0, 5, 0);
            btnProfiles.Size = new Size(150, 30);
            btnProfiles.TabIndex = 26;
            btnProfiles.Text = "Create Profiles";
            btnProfiles.UseMnemonic = false;
            btnProfiles.UseVisualStyleBackColor = false;
            // 
            // btnCloseAccount
            // 
            btnCloseAccount.BackColor = Color.FromArgb(37, 37, 53);
            btnCloseAccount.BackgroundImageLayout = ImageLayout.None;
            btnCloseAccount.FlatAppearance.BorderSize = 0;
            btnCloseAccount.FlatStyle = FlatStyle.Flat;
            btnCloseAccount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseAccount.ForeColor = Color.White;
            btnCloseAccount.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseAccount.ImeMode = ImeMode.NoControl;
            btnCloseAccount.Location = new Point(176, 125);
            btnCloseAccount.Name = "btnCloseAccount";
            btnCloseAccount.Padding = new Padding(5, 0, 5, 0);
            btnCloseAccount.Size = new Size(200, 30);
            btnCloseAccount.TabIndex = 25;
            btnCloseAccount.Text = "Close Token Accounts";
            btnCloseAccount.UseMnemonic = false;
            btnCloseAccount.UseVisualStyleBackColor = false;
            // 
            // btnCheckBalances
            // 
            btnCheckBalances.BackColor = Color.FromArgb(37, 37, 53);
            btnCheckBalances.BackgroundImageLayout = ImageLayout.None;
            btnCheckBalances.FlatAppearance.BorderSize = 0;
            btnCheckBalances.FlatStyle = FlatStyle.Flat;
            btnCheckBalances.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckBalances.ForeColor = Color.White;
            btnCheckBalances.ImageAlign = ContentAlignment.MiddleLeft;
            btnCheckBalances.ImeMode = ImeMode.NoControl;
            btnCheckBalances.Location = new Point(11, 125);
            btnCheckBalances.Name = "btnCheckBalances";
            btnCheckBalances.Padding = new Padding(5, 0, 5, 0);
            btnCheckBalances.Size = new Size(150, 30);
            btnCheckBalances.TabIndex = 24;
            btnCheckBalances.Text = "Check Balance";
            btnCheckBalances.UseMnemonic = false;
            btnCheckBalances.UseVisualStyleBackColor = false;
            // 
            // lblSolBalance
            // 
            lblSolBalance.AutoSize = true;
            lblSolBalance.ForeColor = Color.White;
            lblSolBalance.Location = new Point(134, 70);
            lblSolBalance.Name = "lblSolBalance";
            lblSolBalance.Size = new Size(139, 15);
            lblSolBalance.TabIndex = 23;
            lblSolBalance.Text = "Total Balance : NULL SOL";
            // 
            // lblWalletQt
            // 
            lblWalletQt.AutoSize = true;
            lblWalletQt.ForeColor = Color.White;
            lblWalletQt.Location = new Point(11, 70);
            lblWalletQt.Name = "lblWalletQt";
            lblWalletQt.Size = new Size(52, 15);
            lblWalletQt.TabIndex = 22;
            lblWalletQt.Text = "0 wallets";
            // 
            // lblBundlerTitle
            // 
            lblBundlerTitle.AutoSize = true;
            lblBundlerTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBundlerTitle.ForeColor = Color.White;
            lblBundlerTitle.Location = new Point(10, 38);
            lblBundlerTitle.Name = "lblBundlerTitle";
            lblBundlerTitle.Size = new Size(56, 17);
            lblBundlerTitle.TabIndex = 21;
            lblBundlerTitle.Text = "Bundler";
            // 
            // walletBundler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(loadWalletsButton);
            Controls.Add(btnGenWallet);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(btnProfiles);
            Controls.Add(btnCloseAccount);
            Controls.Add(btnCheckBalances);
            Controls.Add(lblSolBalance);
            Controls.Add(lblWalletQt);
            Controls.Add(lblBundlerTitle);
            Name = "walletBundler";
            Size = new Size(990, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button loadWalletsButton;
        public Button btnGenWallet;
        public Button btnExport;
        public Button btnImport;
        public Button btnProfiles;
        public Button btnCloseAccount;
        public Button btnCheckBalances;
        private Label lblSolBalance;
        private Label lblWalletQt;
        private Label lblBundlerTitle;
    }
}
