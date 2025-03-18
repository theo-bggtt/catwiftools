namespace catwiftools.wallet
{
    partial class FormWalletList
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
            btnCloseApp = new Button();
            lblWalletList = new Label();
            flpWallets = new FlowLayoutPanel();
            gbxWallet = new BorderlessGroupBox();
            lblBalance = new Label();
            btnExport = new Button();
            lblWalletAddress = new Label();
            flpWallets.SuspendLayout();
            gbxWallet.SuspendLayout();
            SuspendLayout();
            // 
            // btnCloseApp
            // 
            btnCloseApp.BackColor = Color.FromArgb(192, 0, 0);
            btnCloseApp.FlatStyle = FlatStyle.Flat;
            btnCloseApp.ImeMode = ImeMode.NoControl;
            btnCloseApp.Location = new Point(766, 12);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(22, 22);
            btnCloseApp.TabIndex = 26;
            btnCloseApp.Text = "X";
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // lblWalletList
            // 
            lblWalletList.AutoSize = true;
            lblWalletList.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWalletList.ForeColor = Color.White;
            lblWalletList.ImeMode = ImeMode.NoControl;
            lblWalletList.Location = new Point(12, 12);
            lblWalletList.Name = "lblWalletList";
            lblWalletList.Size = new Size(112, 28);
            lblWalletList.TabIndex = 27;
            lblWalletList.Text = "Wallet List";
            // 
            // flpWallets
            // 
            flpWallets.AutoScroll = true;
            flpWallets.BackgroundImageLayout = ImageLayout.None;
            flpWallets.Controls.Add(gbxWallet);
            flpWallets.Location = new Point(12, 55);
            flpWallets.Margin = new Padding(0, 3, 3, 3);
            flpWallets.Name = "flpWallets";
            flpWallets.Size = new Size(700, 383);
            flpWallets.TabIndex = 28;
            // 
            // gbxWallet
            // 
            gbxWallet.BackColor = Color.FromArgb(40, 40, 40);
            gbxWallet.Controls.Add(lblBalance);
            gbxWallet.Controls.Add(btnExport);
            gbxWallet.Controls.Add(lblWalletAddress);
            gbxWallet.Location = new Point(0, 5);
            gbxWallet.Margin = new Padding(0, 5, 0, 5);
            gbxWallet.Name = "gbxWallet";
            gbxWallet.Size = new Size(700, 36);
            gbxWallet.TabIndex = 0;
            gbxWallet.TabStop = false;
            gbxWallet.Visible = false;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(472, 10);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(36, 15);
            lblBalance.TabIndex = 6;
            lblBalance.Text = "NULL";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(78, 93, 148);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(587, 6);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(97, 23);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export Key";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // lblWalletAddress
            // 
            lblWalletAddress.AutoSize = true;
            lblWalletAddress.ForeColor = Color.White;
            lblWalletAddress.Location = new Point(18, 10);
            lblWalletAddress.Name = "lblWalletAddress";
            lblWalletAddress.Size = new Size(36, 15);
            lblWalletAddress.TabIndex = 0;
            lblWalletAddress.Text = "NULL";
            // 
            // FormWalletList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            Controls.Add(flpWallets);
            Controls.Add(lblWalletList);
            Controls.Add(btnCloseApp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWalletList";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormWalletList_Load;
            flpWallets.ResumeLayout(false);
            gbxWallet.ResumeLayout(false);
            gbxWallet.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCloseApp;
        private Label lblWalletList;
        private FlowLayoutPanel flpWallets;
        private BorderlessGroupBox gbxWallet;
        private Label lblWalletAddress;
        private Button btnExport;
        private Label lblBalance;
    }
}