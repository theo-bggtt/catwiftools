namespace catwiftools.wallet
{
    partial class walletGroup
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
            lbGroupAmount = new Label();
            flpWalletGroup = new FlowLayoutPanel();
            borderlessGroupBox = new BorderlessGroupBox();
            btnWithdraw = new Button();
            btnDeposit = new Button();
            lbAmount = new Label();
            lbName = new Label();
            delButton = new Button();
            viewButton = new Button();
            btnCreateGroup = new Button();
            lblSettings = new Label();
            lbTotalWallet = new Label();
            label2 = new Label();
            btnUpdateGroup = new Button();
            flpWalletGroup.SuspendLayout();
            borderlessGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // lbGroupAmount
            // 
            lbGroupAmount.AutoSize = true;
            lbGroupAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbGroupAmount.ForeColor = Color.White;
            lbGroupAmount.Location = new Point(10, 57);
            lbGroupAmount.Name = "lbGroupAmount";
            lbGroupAmount.Size = new Size(108, 17);
            lbGroupAmount.TabIndex = 2;
            lbGroupAmount.Text = "Group Amount :";
            // 
            // flpWalletGroup
            // 
            flpWalletGroup.AutoScroll = true;
            flpWalletGroup.BorderStyle = BorderStyle.FixedSingle;
            flpWalletGroup.Controls.Add(borderlessGroupBox);
            flpWalletGroup.Location = new Point(10, 160);
            flpWalletGroup.Margin = new Padding(0);
            flpWalletGroup.Name = "flpWalletGroup";
            flpWalletGroup.Size = new Size(1140, 587);
            flpWalletGroup.TabIndex = 3;
            // 
            // borderlessGroupBox
            // 
            borderlessGroupBox.BackColor = Color.FromArgb(40, 40, 40);
            borderlessGroupBox.Controls.Add(btnWithdraw);
            borderlessGroupBox.Controls.Add(btnDeposit);
            borderlessGroupBox.Controls.Add(lbAmount);
            borderlessGroupBox.Controls.Add(lbName);
            borderlessGroupBox.Controls.Add(delButton);
            borderlessGroupBox.Controls.Add(viewButton);
            borderlessGroupBox.FlatStyle = FlatStyle.Flat;
            borderlessGroupBox.ForeColor = Color.White;
            borderlessGroupBox.Location = new Point(29, 29);
            borderlessGroupBox.Margin = new Padding(29);
            borderlessGroupBox.Name = "borderlessGroupBox";
            borderlessGroupBox.Size = new Size(260, 143);
            borderlessGroupBox.TabIndex = 0;
            borderlessGroupBox.TabStop = false;
            borderlessGroupBox.Visible = false;
            // 
            // btnWithdraw
            // 
            btnWithdraw.AutoSize = true;
            btnWithdraw.BackColor = Color.Transparent;
            btnWithdraw.FlatAppearance.BorderColor = Color.FromArgb(78, 93, 148);
            btnWithdraw.FlatAppearance.BorderSize = 0;
            btnWithdraw.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            btnWithdraw.FlatStyle = FlatStyle.Flat;
            btnWithdraw.ForeColor = Color.White;
            btnWithdraw.Image = Properties.Resources.send;
            btnWithdraw.ImageAlign = ContentAlignment.MiddleRight;
            btnWithdraw.Location = new Point(140, 88);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(110, 45);
            btnWithdraw.TabIndex = 5;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.TextAlign = ContentAlignment.MiddleLeft;
            btnWithdraw.UseVisualStyleBackColor = false;
            // 
            // btnDeposit
            // 
            btnDeposit.AutoSize = true;
            btnDeposit.BackColor = Color.Transparent;
            btnDeposit.FlatAppearance.BorderColor = Color.FromArgb(78, 93, 148);
            btnDeposit.FlatAppearance.BorderSize = 0;
            btnDeposit.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.ForeColor = Color.White;
            btnDeposit.Image = Properties.Resources.receive;
            btnDeposit.ImageAlign = ContentAlignment.MiddleRight;
            btnDeposit.Location = new Point(10, 88);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(110, 45);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Deposit";
            btnDeposit.TextAlign = ContentAlignment.MiddleLeft;
            btnDeposit.UseVisualStyleBackColor = false;
            // 
            // lbAmount
            // 
            lbAmount.AutoSize = true;
            lbAmount.Location = new Point(10, 49);
            lbAmount.Name = "lbAmount";
            lbAmount.Size = new Size(93, 15);
            lbAmount.TabIndex = 0;
            lbAmount.Text = "Wallet Amount: ";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbName.Location = new Point(10, 13);
            lbName.Name = "lbName";
            lbName.Size = new Size(107, 21);
            lbName.TabIndex = 1;
            lbName.Text = "Group Name: ";
            // 
            // delButton
            // 
            delButton.AutoSize = true;
            delButton.BackColor = Color.DarkRed;
            delButton.FlatAppearance.BorderSize = 0;
            delButton.FlatStyle = FlatStyle.Flat;
            delButton.ForeColor = Color.White;
            delButton.Image = Properties.Resources.Close;
            delButton.Location = new Point(220, 10);
            delButton.Name = "delButton";
            delButton.Size = new Size(30, 30);
            delButton.TabIndex = 2;
            delButton.UseVisualStyleBackColor = false;
            // 
            // viewButton
            // 
            viewButton.AutoSize = true;
            viewButton.BackColor = Color.FromArgb(78, 93, 148);
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.ForeColor = Color.White;
            viewButton.Image = Properties.Resources.eye1;
            viewButton.Location = new Point(173, 10);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(30, 30);
            viewButton.TabIndex = 3;
            viewButton.TextAlign = ContentAlignment.MiddleLeft;
            viewButton.UseVisualStyleBackColor = false;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnCreateGroup.FlatAppearance.BorderSize = 0;
            btnCreateGroup.FlatStyle = FlatStyle.Flat;
            btnCreateGroup.ForeColor = Color.White;
            btnCreateGroup.Location = new Point(1014, 54);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(136, 23);
            btnCreateGroup.TabIndex = 4;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSettings.ForeColor = Color.White;
            lblSettings.ImeMode = ImeMode.NoControl;
            lblSettings.Location = new Point(10, 5);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(137, 28);
            lblSettings.TabIndex = 12;
            lblSettings.Text = "Wallet Group";
            // 
            // lbTotalWallet
            // 
            lbTotalWallet.AutoSize = true;
            lbTotalWallet.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotalWallet.ForeColor = Color.White;
            lbTotalWallet.Location = new Point(10, 115);
            lbTotalWallet.Name = "lbTotalWallet";
            lbTotalWallet.Size = new Size(96, 17);
            lbTotalWallet.TabIndex = 13;
            lbTotalWallet.Text = "Total Wallets: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 86);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 14;
            label2.Text = "Total SOL :";
            // 
            // btnUpdateGroup
            // 
            btnUpdateGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnUpdateGroup.FlatAppearance.BorderSize = 0;
            btnUpdateGroup.FlatStyle = FlatStyle.Flat;
            btnUpdateGroup.ForeColor = Color.White;
            btnUpdateGroup.Location = new Point(841, 55);
            btnUpdateGroup.Name = "btnUpdateGroup";
            btnUpdateGroup.Size = new Size(136, 23);
            btnUpdateGroup.TabIndex = 15;
            btnUpdateGroup.Text = "Update Group Info";
            btnUpdateGroup.UseVisualStyleBackColor = false;
            btnUpdateGroup.Click += btnUpdateGroup_Click;
            // 
            // walletGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnUpdateGroup);
            Controls.Add(label2);
            Controls.Add(lbTotalWallet);
            Controls.Add(lblSettings);
            Controls.Add(btnCreateGroup);
            Controls.Add(flpWalletGroup);
            Controls.Add(lbGroupAmount);
            Name = "walletGroup";
            Size = new Size(1210, 762);
            Load += walletGroup_Load;
            flpWalletGroup.ResumeLayout(false);
            borderlessGroupBox.ResumeLayout(false);
            borderlessGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbGroupAmount;
        private FlowLayoutPanel flpWalletGroup;
        private Button btnCreateGroup;
        private Label lblSettings;
        private Label lbTotalWallet;
        private Label label2;
        private Button btnUpdateGroup;
        private BorderlessGroupBox borderlessGroupBox;
        private Button btnWithdraw;
        private Button btnDeposit;
        private Label lbAmount;
        private Label lbName;
        private Button delButton;
        private Button viewButton;
    }
}
