namespace catwiftools.wallet
{
    partial class WalletGroupForm
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
            lbAmount = new Label();
            lbName = new Label();
            tbxName = new TextBox();
            tbxAmount = new TextBox();
            btnCreate = new Button();
            lbTitle = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // lbAmount
            // 
            lbAmount.AutoSize = true;
            lbAmount.ForeColor = Color.White;
            lbAmount.Location = new Point(35, 114);
            lbAmount.Name = "lbAmount";
            lbAmount.Size = new Size(93, 15);
            lbAmount.TabIndex = 0;
            lbAmount.Text = "Wallet Amount :";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.ForeColor = Color.White;
            lbName.Location = new Point(41, 67);
            lbName.Name = "lbName";
            lbName.Size = new Size(81, 15);
            lbName.TabIndex = 1;
            lbName.Text = "Group Name :";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(146, 63);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(100, 23);
            tbxName.TabIndex = 2;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // tbxAmount
            // 
            tbxAmount.Location = new Point(146, 110);
            tbxAmount.Name = "tbxAmount";
            tbxAmount.Size = new Size(100, 23);
            tbxAmount.TabIndex = 3;
            tbxAmount.TextChanged += tbxAmount_TextChanged;
            tbxAmount.KeyPress += tbxAmount_KeyPress;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(78, 93, 148);
            btnCreate.Enabled = false;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(41, 163);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(90, 25);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.ForeColor = Color.White;
            lbTitle.Location = new Point(84, 20);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(113, 15);
            lbTitle.TabIndex = 5;
            lbTitle.Text = "Create Wallet Group";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(156, 163);
            button1.Name = "button1";
            button1.Size = new Size(90, 25);
            button1.TabIndex = 6;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // WalletGroupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(280, 200);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(lbTitle);
            Controls.Add(btnCreate);
            Controls.Add(tbxAmount);
            Controls.Add(tbxName);
            Controls.Add(lbName);
            Controls.Add(lbAmount);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "WalletGroupForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbAmount;
        private Label lbName;
        private TextBox tbxName;
        private TextBox tbxAmount;
        private Button btnCreate;
        private Label lbTitle;
        private Button button1;
    }
}