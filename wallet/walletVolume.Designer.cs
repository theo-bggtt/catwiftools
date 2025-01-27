namespace catwiftools.wallet
{
    partial class walletVolume
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblVolumeTitle = new Label();
            lblWalletQt = new Label();
            lblSolBalance = new Label();
            btnCheckBalances = new Button();
            btnCloseAccount = new Button();
            btnProfiles = new Button();
            btnImport = new Button();
            btnExport = new Button();
            btnGenWallet = new Button();
            dataGridViewWallets = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWallets).BeginInit();
            SuspendLayout();
            // 
            // lblVolumeTitle
            // 
            lblVolumeTitle.AutoSize = true;
            lblVolumeTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVolumeTitle.ForeColor = Color.White;
            lblVolumeTitle.Location = new Point(10, 38);
            lblVolumeTitle.Name = "lblVolumeTitle";
            lblVolumeTitle.Size = new Size(55, 17);
            lblVolumeTitle.TabIndex = 1;
            lblVolumeTitle.Text = "Volume";
            // 
            // lblWalletQt
            // 
            lblWalletQt.AutoSize = true;
            lblWalletQt.ForeColor = Color.White;
            lblWalletQt.Location = new Point(11, 70);
            lblWalletQt.Name = "lblWalletQt";
            lblWalletQt.Size = new Size(52, 15);
            lblWalletQt.TabIndex = 2;
            lblWalletQt.Text = "0 wallets";
            // 
            // lblSolBalance
            // 
            lblSolBalance.AutoSize = true;
            lblSolBalance.ForeColor = Color.White;
            lblSolBalance.Location = new Point(134, 70);
            lblSolBalance.Name = "lblSolBalance";
            lblSolBalance.Size = new Size(139, 15);
            lblSolBalance.TabIndex = 3;
            lblSolBalance.Text = "Total Balance : NULL SOL";
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
            btnCheckBalances.TabIndex = 13;
            btnCheckBalances.Text = "Check Balance";
            btnCheckBalances.UseMnemonic = false;
            btnCheckBalances.UseVisualStyleBackColor = false;
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
            btnCloseAccount.TabIndex = 14;
            btnCloseAccount.Text = "Close Token Accounts";
            btnCloseAccount.UseMnemonic = false;
            btnCloseAccount.UseVisualStyleBackColor = false;
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
            btnProfiles.TabIndex = 15;
            btnProfiles.Text = "Create Profiles";
            btnProfiles.UseMnemonic = false;
            btnProfiles.UseVisualStyleBackColor = false;
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
            btnImport.TabIndex = 16;
            btnImport.Text = "Import";
            btnImport.UseMnemonic = false;
            btnImport.UseVisualStyleBackColor = false;
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
            btnExport.TabIndex = 17;
            btnExport.Text = "Export";
            btnExport.UseMnemonic = false;
            btnExport.UseVisualStyleBackColor = false;
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
            btnGenWallet.TabIndex = 18;
            btnGenWallet.Tag = "2";
            btnGenWallet.Text = "+  Gen Wallets";
            btnGenWallet.TextAlign = ContentAlignment.MiddleLeft;
            btnGenWallet.UseMnemonic = false;
            btnGenWallet.UseVisualStyleBackColor = false;
            btnGenWallet.Click += btnGenWallet_Click;
            // 
            // dataGridViewWallets
            // 
            dataGridViewWallets.AllowUserToAddRows = false;
            dataGridViewWallets.AllowUserToDeleteRows = false;
            dataGridViewWallets.AllowUserToResizeColumns = false;
            dataGridViewWallets.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.ForeColor = Color.WhiteSmoke;
            dataGridViewWallets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewWallets.BackgroundColor = Color.FromArgb(25, 25, 25);
            dataGridViewWallets.BorderStyle = BorderStyle.None;
            dataGridViewWallets.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewWallets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Padding = new Padding(25);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewWallets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewWallets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewWallets.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewWallets.EnableHeadersVisualStyles = false;
            dataGridViewWallets.GridColor = Color.White;
            dataGridViewWallets.Location = new Point(11, 183);
            dataGridViewWallets.Name = "dataGridViewWallets";
            dataGridViewWallets.RowHeadersVisible = false;
            dataGridViewWallets.RowTemplate.Height = 40;
            dataGridViewWallets.RowTemplate.ReadOnly = true;
            dataGridViewWallets.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewWallets.ScrollBars = ScrollBars.Horizontal;
            dataGridViewWallets.Size = new Size(815, 540);
            dataGridViewWallets.TabIndex = 46;
            // 
            // walletVolume
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(dataGridViewWallets);
            Controls.Add(btnGenWallet);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(btnProfiles);
            Controls.Add(btnCloseAccount);
            Controls.Add(btnCheckBalances);
            Controls.Add(lblSolBalance);
            Controls.Add(lblWalletQt);
            Controls.Add(lblVolumeTitle);
            Name = "walletVolume";
            Size = new Size(990, 762);
            Tag = "2";
            ((System.ComponentModel.ISupportInitialize)dataGridViewWallets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVolumeTitle;
        private Label lblWalletQt;
        private Label lblSolBalance;
        public Button btnCheckBalances;
        public Button btnCloseAccount;
        public Button btnProfiles;
        public Button btnImport;
        public Button btnExport;
        public Button btnGenWallet;
        private DataGridView dataGridViewWallets;
    }
}
