namespace catwiftools.wallet
{
    partial class SendToGroup
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
            lblDepositToGroup = new Label();
            btnConfirm = new Button();
            lblAmountPerWallet = new Label();
            hsbAmount = new HScrollBar();
            tbxAmount = new TextBox();
            lblAmount = new Label();
            lblMax = new Label();
            lblAmountToSend = new Label();
            btnMinimise = new Button();
            btnCloseApp = new Button();
            SuspendLayout();
            // 
            // lblDepositToGroup
            // 
            lblDepositToGroup.AutoSize = true;
            lblDepositToGroup.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepositToGroup.ForeColor = Color.White;
            lblDepositToGroup.ImeMode = ImeMode.NoControl;
            lblDepositToGroup.Location = new Point(52, 9);
            lblDepositToGroup.Name = "lblDepositToGroup";
            lblDepositToGroup.Size = new Size(146, 28);
            lblDepositToGroup.TabIndex = 28;
            lblDepositToGroup.Text = "Send to group";
            // 
            // btnConfirm
            // 
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Location = new Point(25, 140);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(200, 23);
            btnConfirm.TabIndex = 29;
            btnConfirm.Text = "Send";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblAmountPerWallet
            // 
            lblAmountPerWallet.AutoSize = true;
            lblAmountPerWallet.BackColor = Color.Transparent;
            lblAmountPerWallet.ForeColor = Color.LimeGreen;
            lblAmountPerWallet.Location = new Point(250, 100);
            lblAmountPerWallet.Name = "lblAmountPerWallet";
            lblAmountPerWallet.Size = new Size(173, 15);
            lblAmountPerWallet.TabIndex = 30;
            lblAmountPerWallet.Text = "Amount to send / wallet : NULL";
            // 
            // hsbAmount
            // 
            hsbAmount.Location = new Point(39, 102);
            hsbAmount.Maximum = 109;
            hsbAmount.Name = "hsbAmount";
            hsbAmount.Size = new Size(173, 17);
            hsbAmount.TabIndex = 31;
            hsbAmount.Scroll += hsbAmount_Scroll;
            // 
            // tbxAmount
            // 
            tbxAmount.Location = new Point(128, 58);
            tbxAmount.Name = "tbxAmount";
            tbxAmount.Size = new Size(70, 23);
            tbxAmount.TabIndex = 32;
            tbxAmount.TextChanged += tbxAmount_TextChanged;
            tbxAmount.KeyPress += tbxAmount_KeyPress;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.White;
            lblAmount.Location = new Point(44, 59);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(71, 20);
            lblAmount.TabIndex = 33;
            lblAmount.Text = "Amount ";
            // 
            // lblMax
            // 
            lblMax.AutoSize = true;
            lblMax.BackColor = Color.Transparent;
            lblMax.ForeColor = Color.LimeGreen;
            lblMax.Location = new Point(250, 50);
            lblMax.Name = "lblMax";
            lblMax.Size = new Size(142, 15);
            lblMax.TabIndex = 34;
            lblMax.Text = "Maximum to send : NULL";
            // 
            // lblAmountToSend
            // 
            lblAmountToSend.AutoSize = true;
            lblAmountToSend.BackColor = Color.Transparent;
            lblAmountToSend.ForeColor = Color.LimeGreen;
            lblAmountToSend.Location = new Point(250, 75);
            lblAmountToSend.Name = "lblAmountToSend";
            lblAmountToSend.Size = new Size(132, 15);
            lblAmountToSend.TabIndex = 35;
            lblAmountToSend.Text = "Amount to send : 0 SOL";
            // 
            // btnMinimise
            // 
            btnMinimise.BackColor = Color.DimGray;
            btnMinimise.FlatStyle = FlatStyle.Flat;
            btnMinimise.ImeMode = ImeMode.NoControl;
            btnMinimise.Location = new Point(386, 12);
            btnMinimise.Name = "btnMinimise";
            btnMinimise.Size = new Size(22, 22);
            btnMinimise.TabIndex = 37;
            btnMinimise.Text = "-";
            btnMinimise.UseVisualStyleBackColor = false;
            btnMinimise.Click += btnMinimise_Click;
            // 
            // btnCloseApp
            // 
            btnCloseApp.BackColor = Color.FromArgb(192, 0, 0);
            btnCloseApp.FlatStyle = FlatStyle.Flat;
            btnCloseApp.ImeMode = ImeMode.NoControl;
            btnCloseApp.Location = new Point(414, 12);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(22, 22);
            btnCloseApp.TabIndex = 36;
            btnCloseApp.Text = "X";
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // SendToGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(448, 198);
            ControlBox = false;
            Controls.Add(btnMinimise);
            Controls.Add(btnCloseApp);
            Controls.Add(lblAmountToSend);
            Controls.Add(lblMax);
            Controls.Add(lblAmount);
            Controls.Add(tbxAmount);
            Controls.Add(hsbAmount);
            Controls.Add(lblAmountPerWallet);
            Controls.Add(btnConfirm);
            Controls.Add(lblDepositToGroup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SendToGroup";
            Load += SendToGroup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDepositToGroup;
        private Button btnConfirm;
        private Label lblAmountPerWallet;
        private HScrollBar hsbAmount;
        private TextBox tbxAmount;
        private Label lblAmount;
        private Label lblMax;
        private Label lblAmountToSend;
        private Button btnMinimise;
        private Button btnCloseApp;
    }
}