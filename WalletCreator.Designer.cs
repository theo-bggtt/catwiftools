namespace catwiftools
{
    partial class WalletCreator
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
            gbxdevwalletcreation = new GroupBox();
            lbldevwalletcreation = new Label();
            btndevwalletcreation = new Button();
            lbllog = new Label();
            tbxlog = new TextBox();
            gbxbundlewalletcreation = new GroupBox();
            lblbundlewalletcreation = new Label();
            tbxbundlewalletcreation = new TextBox();
            btnbundlewalletcreation = new Button();
            gbxdevwalletcreation.SuspendLayout();
            gbxbundlewalletcreation.SuspendLayout();
            SuspendLayout();
            // 
            // gbxdevwalletcreation
            // 
            gbxdevwalletcreation.BackColor = Color.CornflowerBlue;
            gbxdevwalletcreation.Controls.Add(lbldevwalletcreation);
            gbxdevwalletcreation.Controls.Add(btndevwalletcreation);
            gbxdevwalletcreation.ForeColor = Color.White;
            gbxdevwalletcreation.Location = new Point(4, 147);
            gbxdevwalletcreation.Name = "gbxdevwalletcreation";
            gbxdevwalletcreation.Size = new Size(332, 85);
            gbxdevwalletcreation.TabIndex = 6;
            gbxdevwalletcreation.TabStop = false;
            gbxdevwalletcreation.Text = "Dev Wallet Creator";
            // 
            // lbldevwalletcreation
            // 
            lbldevwalletcreation.AutoSize = true;
            lbldevwalletcreation.Location = new Point(26, 32);
            lbldevwalletcreation.Name = "lbldevwalletcreation";
            lbldevwalletcreation.Size = new Size(122, 15);
            lbldevwalletcreation.TabIndex = 2;
            lbldevwalletcreation.Text = "Create new dev wallet";
            // 
            // btndevwalletcreation
            // 
            btndevwalletcreation.BackColor = Color.White;
            btndevwalletcreation.FlatAppearance.BorderColor = Color.Black;
            btndevwalletcreation.FlatAppearance.BorderSize = 3;
            btndevwalletcreation.ForeColor = Color.Black;
            btndevwalletcreation.Location = new Point(198, 22);
            btndevwalletcreation.Name = "btndevwalletcreation";
            btndevwalletcreation.Size = new Size(97, 35);
            btndevwalletcreation.TabIndex = 0;
            btndevwalletcreation.Text = "Create";
            btndevwalletcreation.UseVisualStyleBackColor = false;
            // 
            // lbllog
            // 
            lbllog.AutoSize = true;
            lbllog.Font = new Font("Segoe UI", 18F);
            lbllog.Location = new Point(772, 4);
            lbllog.Name = "lbllog";
            lbllog.Size = new Size(146, 32);
            lbllog.TabIndex = 7;
            lbllog.Text = "Journal (log)";
            // 
            // tbxlog
            // 
            tbxlog.BackColor = Color.CornflowerBlue;
            tbxlog.Cursor = Cursors.No;
            tbxlog.Font = new Font("Segoe UI", 15F);
            tbxlog.ForeColor = Color.Black;
            tbxlog.Location = new Point(653, 41);
            tbxlog.Multiline = true;
            tbxlog.Name = "tbxlog";
            tbxlog.ReadOnly = true;
            tbxlog.ScrollBars = ScrollBars.Vertical;
            tbxlog.Size = new Size(391, 506);
            tbxlog.TabIndex = 8;
            tbxlog.UseWaitCursor = true;
            // 
            // gbxbundlewalletcreation
            // 
            gbxbundlewalletcreation.BackColor = Color.CornflowerBlue;
            gbxbundlewalletcreation.Controls.Add(lblbundlewalletcreation);
            gbxbundlewalletcreation.Controls.Add(tbxbundlewalletcreation);
            gbxbundlewalletcreation.Controls.Add(btnbundlewalletcreation);
            gbxbundlewalletcreation.ForeColor = Color.White;
            gbxbundlewalletcreation.Location = new Point(4, 4);
            gbxbundlewalletcreation.Name = "gbxbundlewalletcreation";
            gbxbundlewalletcreation.Size = new Size(332, 128);
            gbxbundlewalletcreation.TabIndex = 5;
            gbxbundlewalletcreation.TabStop = false;
            gbxbundlewalletcreation.Text = "Bundle wallet creator";
            // 
            // lblbundlewalletcreation
            // 
            lblbundlewalletcreation.AutoSize = true;
            lblbundlewalletcreation.Location = new Point(6, 37);
            lblbundlewalletcreation.Name = "lblbundlewalletcreation";
            lblbundlewalletcreation.Size = new Size(142, 15);
            lblbundlewalletcreation.TabIndex = 2;
            lblbundlewalletcreation.Text = "Wallet Amount to create: ";
            // 
            // tbxbundlewalletcreation
            // 
            tbxbundlewalletcreation.BackColor = Color.White;
            tbxbundlewalletcreation.ForeColor = Color.Black;
            tbxbundlewalletcreation.Location = new Point(198, 34);
            tbxbundlewalletcreation.Name = "tbxbundlewalletcreation";
            tbxbundlewalletcreation.Size = new Size(100, 23);
            tbxbundlewalletcreation.TabIndex = 1;
            // 
            // btnbundlewalletcreation
            // 
            btnbundlewalletcreation.BackColor = Color.White;
            btnbundlewalletcreation.ForeColor = Color.Black;
            btnbundlewalletcreation.Location = new Point(95, 72);
            btnbundlewalletcreation.Name = "btnbundlewalletcreation";
            btnbundlewalletcreation.Size = new Size(128, 35);
            btnbundlewalletcreation.TabIndex = 0;
            btnbundlewalletcreation.Text = "Create Wallets";
            btnbundlewalletcreation.UseVisualStyleBackColor = false;
            btnbundlewalletcreation.Click += btnbundlewalletcreation_Click;
            // 
            // WalletCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbllog);
            Controls.Add(tbxlog);
            Controls.Add(gbxbundlewalletcreation);
            Controls.Add(gbxdevwalletcreation);
            Name = "WalletCreator";
            Size = new Size(1051, 553);
            Load += WalletCreator_Load;
            gbxdevwalletcreation.ResumeLayout(false);
            gbxdevwalletcreation.PerformLayout();
            gbxbundlewalletcreation.ResumeLayout(false);
            gbxbundlewalletcreation.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbxdevwalletcreation;
        private Label lbldevwalletcreation;
        private Button btndevwalletcreation;
        private Label lbllog;
        private TextBox tbxlog;
        private GroupBox gbxbundlewalletcreation;
        private Label lblbundlewalletcreation;
        private TextBox tbxbundlewalletcreation;
        private Button btnbundlewalletcreation;
    }
}
