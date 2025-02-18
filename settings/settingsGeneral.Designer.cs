namespace catwiftools.settings
{
    partial class settingsGeneral
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
            lblSettingsGeneral = new Label();
            btnSave = new Button();
            tbxFundWallet = new TextBox();
            btnDelFundWall = new Button();
            btnGenFundWall = new Button();
            lblTitleFundWall = new Label();
            lblFundWallAddr = new Label();
            SuspendLayout();
            // 
            // lblSettingsGeneral
            // 
            lblSettingsGeneral.AutoSize = true;
            lblSettingsGeneral.Font = new Font("Segoe UI", 15F);
            lblSettingsGeneral.ForeColor = Color.FromArgb(153, 153, 153);
            lblSettingsGeneral.Location = new Point(10, 5);
            lblSettingsGeneral.Name = "lblSettingsGeneral";
            lblSettingsGeneral.Size = new Size(79, 28);
            lblSettingsGeneral.TabIndex = 0;
            lblSettingsGeneral.Text = "General";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(880, 734);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "button1";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // tbxFundWallet
            // 
            tbxFundWallet.Location = new Point(439, 49);
            tbxFundWallet.Name = "tbxFundWallet";
            tbxFundWallet.Size = new Size(299, 23);
            tbxFundWallet.TabIndex = 2;
            tbxFundWallet.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDelFundWall
            // 
            btnDelFundWall.BackColor = Color.FromArgb(192, 0, 0);
            btnDelFundWall.FlatStyle = FlatStyle.Flat;
            btnDelFundWall.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelFundWall.ImeMode = ImeMode.NoControl;
            btnDelFundWall.Location = new Point(792, 50);
            btnDelFundWall.Name = "btnDelFundWall";
            btnDelFundWall.Size = new Size(89, 22);
            btnDelFundWall.TabIndex = 26;
            btnDelFundWall.Text = "Delete Wallet";
            btnDelFundWall.UseVisualStyleBackColor = false;
            btnDelFundWall.Click += btnDelFundWall_Click;
            // 
            // btnGenFundWall
            // 
            btnGenFundWall.BackColor = Color.FromArgb(37, 37, 53);
            btnGenFundWall.BackgroundImageLayout = ImageLayout.None;
            btnGenFundWall.FlatAppearance.BorderSize = 0;
            btnGenFundWall.FlatStyle = FlatStyle.Flat;
            btnGenFundWall.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenFundWall.ForeColor = Color.White;
            btnGenFundWall.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenFundWall.ImeMode = ImeMode.NoControl;
            btnGenFundWall.Location = new Point(781, 49);
            btnGenFundWall.Name = "btnGenFundWall";
            btnGenFundWall.Padding = new Padding(5, 0, 5, 0);
            btnGenFundWall.Size = new Size(110, 25);
            btnGenFundWall.TabIndex = 39;
            btnGenFundWall.Tag = "1";
            btnGenFundWall.Text = "Generate Wallet";
            btnGenFundWall.UseMnemonic = false;
            btnGenFundWall.UseVisualStyleBackColor = false;
            btnGenFundWall.Click += btnGenFundWall_Click;
            // 
            // lblTitleFundWall
            // 
            lblTitleFundWall.AutoSize = true;
            lblTitleFundWall.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleFundWall.ForeColor = Color.White;
            lblTitleFundWall.Location = new Point(260, 47);
            lblTitleFundWall.Name = "lblTitleFundWall";
            lblTitleFundWall.Size = new Size(92, 21);
            lblTitleFundWall.TabIndex = 40;
            lblTitleFundWall.Text = "Fund Wallet";
            // 
            // lblFundWallAddr
            // 
            lblFundWallAddr.AutoSize = true;
            lblFundWallAddr.ForeColor = Color.White;
            lblFundWallAddr.Location = new Point(439, 53);
            lblFundWallAddr.Name = "lblFundWallAddr";
            lblFundWallAddr.Size = new Size(85, 15);
            lblFundWallAddr.TabIndex = 41;
            lblFundWallAddr.Text = "Wallet Address";
            lblFundWallAddr.Visible = false;
            // 
            // settingsGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblFundWallAddr);
            Controls.Add(lblTitleFundWall);
            Controls.Add(btnDelFundWall);
            Controls.Add(tbxFundWallet);
            Controls.Add(btnSave);
            Controls.Add(lblSettingsGeneral);
            Controls.Add(btnGenFundWall);
            Name = "settingsGeneral";
            Size = new Size(990, 762);
            Load += settingsGeneral_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSettingsGeneral;
        private Button btnSave;
        private TextBox tbxFundWallet;
        private Button btnDelFundWall;
        public Button btnGenFundWall;
        private Label lblTitleFundWall;
        private Label lblFundWallAddr;
    }
}
