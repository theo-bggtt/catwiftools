namespace catwiftools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btncreatewallet = new Button();
            tbxwalletqt = new TextBox();
            gbxwalletcreation = new GroupBox();
            lblwalletqt = new Label();
            tbxlog = new TextBox();
            lbllog = new Label();
            gbxwalletcreation.SuspendLayout();
            SuspendLayout();
            // 
            // btncreatewallet
            // 
            btncreatewallet.BackColor = Color.DarkSlateBlue;
            btncreatewallet.Location = new Point(117, 76);
            btncreatewallet.Name = "btncreatewallet";
            btncreatewallet.Size = new Size(97, 35);
            btncreatewallet.TabIndex = 0;
            btncreatewallet.Text = "Create Wallets";
            btncreatewallet.UseVisualStyleBackColor = false;
            btncreatewallet.Click += btncreatewallet_Click;
            // 
            // tbxwalletqt
            // 
            tbxwalletqt.BackColor = Color.DarkSlateBlue;
            tbxwalletqt.ForeColor = Color.White;
            tbxwalletqt.Location = new Point(201, 34);
            tbxwalletqt.Name = "tbxwalletqt";
            tbxwalletqt.Size = new Size(100, 23);
            tbxwalletqt.TabIndex = 1;
            // 
            // gbxwalletcreation
            // 
            gbxwalletcreation.BackColor = Color.DarkSlateBlue;
            gbxwalletcreation.Controls.Add(lblwalletqt);
            gbxwalletcreation.Controls.Add(tbxwalletqt);
            gbxwalletcreation.Controls.Add(btncreatewallet);
            gbxwalletcreation.ForeColor = Color.White;
            gbxwalletcreation.Location = new Point(12, 22);
            gbxwalletcreation.Name = "gbxwalletcreation";
            gbxwalletcreation.Size = new Size(332, 128);
            gbxwalletcreation.TabIndex = 2;
            gbxwalletcreation.TabStop = false;
            gbxwalletcreation.Text = "Create Wallets";
            // 
            // lblwalletqt
            // 
            lblwalletqt.AutoSize = true;
            lblwalletqt.Location = new Point(15, 37);
            lblwalletqt.Name = "lblwalletqt";
            lblwalletqt.Size = new Size(142, 15);
            lblwalletqt.TabIndex = 2;
            lblwalletqt.Text = "Wallet Amount to create: ";
            // 
            // tbxlog
            // 
            tbxlog.BackColor = Color.DarkSlateBlue;
            tbxlog.Cursor = Cursors.No;
            tbxlog.Font = new Font("Segoe UI", 15F);
            tbxlog.ForeColor = Color.Black;
            tbxlog.Location = new Point(853, 64);
            tbxlog.Multiline = true;
            tbxlog.Name = "tbxlog";
            tbxlog.ReadOnly = true;
            tbxlog.ScrollBars = ScrollBars.Vertical;
            tbxlog.Size = new Size(388, 517);
            tbxlog.TabIndex = 3;
            tbxlog.UseWaitCursor = true;
            // 
            // lbllog
            // 
            lbllog.AutoSize = true;
            lbllog.Font = new Font("Segoe UI", 18F);
            lbllog.Location = new Point(853, 22);
            lbllog.Name = "lbllog";
            lbllog.Size = new Size(146, 32);
            lbllog.TabIndex = 3;
            lbllog.Text = "Journal (log)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(1264, 635);
            Controls.Add(lbllog);
            Controls.Add(tbxlog);
            Controls.Add(gbxwalletcreation);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "Form1";
            gbxwalletcreation.ResumeLayout(false);
            gbxwalletcreation.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btncreatewallet;
        private TextBox tbxwalletqt;
        private GroupBox gbxwalletcreation;
        private Label lblwalletqt;
        private TextBox tbxlog;
        private Label lbllog;
    }
}
