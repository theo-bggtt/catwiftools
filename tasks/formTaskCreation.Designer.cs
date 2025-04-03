namespace catwiftools.tasks
{
    partial class formTaskCreation
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
            lblTaskType = new Label();
            lblTaskName = new Label();
            tbxTaskName = new TextBox();
            btnCancel = new Button();
            btnCreate = new Button();
            cbxTaskType = new ComboBox();
            pnlBuyParameters = new Panel();
            textBox4 = new TextBox();
            label5 = new Label();
            tbxMaximumBuy = new TextBox();
            label4 = new Label();
            tbxMinimumBuy = new TextBox();
            label13 = new Label();
            pnlSellAll = new Panel();
            tbxCycle = new TextBox();
            lblCycle = new Label();
            textBox5 = new TextBox();
            label9 = new Label();
            pnlSingleSell = new Panel();
            cbxWallet = new ComboBox();
            label11 = new Label();
            pnlCommentBot = new Panel();
            tbxComments = new TextBox();
            lblComments = new Label();
            pnlBumpIt = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            pnlBuyParameters.SuspendLayout();
            pnlSellAll.SuspendLayout();
            pnlSingleSell.SuspendLayout();
            pnlCommentBot.SuspendLayout();
            pnlBumpIt.SuspendLayout();
            SuspendLayout();
            // 
            // lblTaskType
            // 
            lblTaskType.AutoSize = true;
            lblTaskType.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskType.ForeColor = Color.White;
            lblTaskType.Location = new Point(269, 25);
            lblTaskType.Name = "lblTaskType";
            lblTaskType.Size = new Size(92, 28);
            lblTaskType.TabIndex = 1;
            lblTaskType.Text = "Task type";
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskName.ForeColor = Color.White;
            lblTaskName.Location = new Point(53, 25);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(105, 28);
            lblTaskName.TabIndex = 2;
            lblTaskName.Text = "Task Name";
            // 
            // tbxTaskName
            // 
            tbxTaskName.Location = new Point(55, 80);
            tbxTaskName.Name = "tbxTaskName";
            tbxTaskName.Size = new Size(100, 23);
            tbxTaskName.TabIndex = 3;
            tbxTaskName.TextChanged += tbxTaskName_TextChanged;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(270, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 25);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(78, 93, 148);
            btnCreate.Enabled = false;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(60, 400);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(90, 25);
            btnCreate.TabIndex = 14;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // cbxTaskType
            // 
            cbxTaskType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTaskType.FormattingEnabled = true;
            cbxTaskType.Items.AddRange(new object[] { "Micro-Buy", "Generate Volume", "Sell All", "Single Sell", "Comment Bot", "Bump It" });
            cbxTaskType.Location = new Point(255, 80);
            cbxTaskType.Name = "cbxTaskType";
            cbxTaskType.Size = new Size(121, 23);
            cbxTaskType.TabIndex = 16;
            cbxTaskType.SelectedIndexChanged += cbxTaskType_SelectedIndexChanged;
            // 
            // pnlBuyParameters
            // 
            pnlBuyParameters.Controls.Add(textBox4);
            pnlBuyParameters.Controls.Add(label5);
            pnlBuyParameters.Controls.Add(tbxMaximumBuy);
            pnlBuyParameters.Controls.Add(label4);
            pnlBuyParameters.Controls.Add(tbxMinimumBuy);
            pnlBuyParameters.Controls.Add(label13);
            pnlBuyParameters.Location = new Point(25, 140);
            pnlBuyParameters.Name = "pnlBuyParameters";
            pnlBuyParameters.Size = new Size(370, 235);
            pnlBuyParameters.TabIndex = 67;
            pnlBuyParameters.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(144, 163);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(81, 23);
            textBox4.TabIndex = 70;
            textBox4.TextChanged += tbxDelay_TextChanged;
            textBox4.KeyPress += tbx_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(157, 137);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 69;
            label5.Text = "Delay (S)";
            // 
            // tbxMaximumBuy
            // 
            tbxMaximumBuy.Location = new Point(251, 92);
            tbxMaximumBuy.Name = "tbxMaximumBuy";
            tbxMaximumBuy.Size = new Size(81, 23);
            tbxMaximumBuy.TabIndex = 68;
            tbxMaximumBuy.TextChanged += tbxMaximumBuy_TextChanged;
            tbxMaximumBuy.KeyPress += tbx_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(224, 66);
            label4.Name = "label4";
            label4.Size = new Size(135, 15);
            label4.TabIndex = 67;
            label4.Text = "Maximum Buy Amount";
            // 
            // tbxMinimumBuy
            // 
            tbxMinimumBuy.Location = new Point(40, 91);
            tbxMinimumBuy.Name = "tbxMinimumBuy";
            tbxMinimumBuy.Size = new Size(81, 23);
            tbxMinimumBuy.TabIndex = 66;
            tbxMinimumBuy.TextChanged += tbxMinimumBuy_TextChanged;
            tbxMinimumBuy.KeyPress += tbx_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(14, 65);
            label13.Name = "label13";
            label13.Size = new Size(132, 15);
            label13.TabIndex = 57;
            label13.Text = "Minimum Buy Amount";
            // 
            // pnlSellAll
            // 
            pnlSellAll.Controls.Add(tbxCycle);
            pnlSellAll.Controls.Add(lblCycle);
            pnlSellAll.Controls.Add(textBox5);
            pnlSellAll.Controls.Add(label9);
            pnlSellAll.Location = new Point(25, 140);
            pnlSellAll.Name = "pnlSellAll";
            pnlSellAll.Size = new Size(370, 235);
            pnlSellAll.TabIndex = 71;
            pnlSellAll.Visible = false;
            // 
            // tbxCycle
            // 
            tbxCycle.Location = new Point(249, 45);
            tbxCycle.Name = "tbxCycle";
            tbxCycle.Size = new Size(81, 23);
            tbxCycle.TabIndex = 72;
            tbxCycle.TextChanged += tbxCycle_TextChanged;
            tbxCycle.KeyPress += tbx_KeyPress;
            // 
            // lblCycle
            // 
            lblCycle.AutoSize = true;
            lblCycle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCycle.ForeColor = Color.White;
            lblCycle.Location = new Point(248, 19);
            lblCycle.Name = "lblCycle";
            lblCycle.Size = new Size(82, 15);
            lblCycle.TabIndex = 71;
            lblCycle.Text = "Cycle amount";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(40, 45);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(81, 23);
            textBox5.TabIndex = 70;
            textBox5.TextChanged += tbxDelay_TextChanged;
            textBox5.KeyPress += tbx_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(53, 19);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 69;
            label9.Text = "Delay (S)";
            // 
            // pnlSingleSell
            // 
            pnlSingleSell.Controls.Add(cbxWallet);
            pnlSingleSell.Controls.Add(label11);
            pnlSingleSell.Location = new Point(25, 140);
            pnlSingleSell.Name = "pnlSingleSell";
            pnlSingleSell.Size = new Size(370, 235);
            pnlSingleSell.TabIndex = 72;
            pnlSingleSell.Visible = false;
            // 
            // cbxWallet
            // 
            cbxWallet.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxWallet.FormattingEnabled = true;
            cbxWallet.Location = new Point(88, 119);
            cbxWallet.Name = "cbxWallet";
            cbxWallet.Size = new Size(192, 23);
            cbxWallet.TabIndex = 70;
            cbxWallet.SelectedIndexChanged += cbxWallet_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(163, 84);
            label11.Name = "label11";
            label11.Size = new Size(43, 15);
            label11.TabIndex = 69;
            label11.Text = "Wallet";
            // 
            // pnlCommentBot
            // 
            pnlCommentBot.Controls.Add(tbxComments);
            pnlCommentBot.Controls.Add(lblComments);
            pnlCommentBot.Location = new Point(25, 140);
            pnlCommentBot.Name = "pnlCommentBot";
            pnlCommentBot.Size = new Size(370, 235);
            pnlCommentBot.TabIndex = 73;
            pnlCommentBot.Visible = false;
            // 
            // tbxComments
            // 
            tbxComments.Location = new Point(38, 48);
            tbxComments.Multiline = true;
            tbxComments.Name = "tbxComments";
            tbxComments.Size = new Size(292, 162);
            tbxComments.TabIndex = 70;
            tbxComments.TextChanged += tbxDelay_TextChanged;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblComments.ForeColor = Color.White;
            lblComments.Location = new Point(156, 19);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(67, 15);
            lblComments.TabIndex = 69;
            lblComments.Text = "Comments";
            // 
            // pnlBumpIt
            // 
            pnlBumpIt.Controls.Add(textBox2);
            pnlBumpIt.Controls.Add(label2);
            pnlBumpIt.Controls.Add(textBox3);
            pnlBumpIt.Controls.Add(label3);
            pnlBumpIt.Location = new Point(25, 140);
            pnlBumpIt.Name = "pnlBumpIt";
            pnlBumpIt.Size = new Size(370, 235);
            pnlBumpIt.TabIndex = 74;
            pnlBumpIt.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(251, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(81, 23);
            textBox2.TabIndex = 74;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(272, 88);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 73;
            label2.Text = "Delay";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(40, 114);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(81, 23);
            textBox3.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(42, 88);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 71;
            label3.Text = "Buy Amount";
            // 
            // formTaskCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(418, 448);
            ControlBox = false;
            Controls.Add(cbxTaskType);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(tbxTaskName);
            Controls.Add(lblTaskName);
            Controls.Add(lblTaskType);
            Controls.Add(pnlSellAll);
            Controls.Add(pnlBuyParameters);
            Controls.Add(pnlBumpIt);
            Controls.Add(pnlCommentBot);
            Controls.Add(pnlSingleSell);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formTaskCreation";
            StartPosition = FormStartPosition.CenterParent;
            Load += formTaskCreation_Load;
            pnlBuyParameters.ResumeLayout(false);
            pnlBuyParameters.PerformLayout();
            pnlSellAll.ResumeLayout(false);
            pnlSellAll.PerformLayout();
            pnlSingleSell.ResumeLayout(false);
            pnlSingleSell.PerformLayout();
            pnlCommentBot.ResumeLayout(false);
            pnlCommentBot.PerformLayout();
            pnlBumpIt.ResumeLayout(false);
            pnlBumpIt.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTaskType;
        private Label lblTaskName;
        private TextBox tbxTaskName;
        private Button btnCancel;
        private Button btnCreate;
        private ComboBox cbxTaskType;
        private Panel pnlBuyParameters;
        private TextBox tbxMaximumBuy;
        private Label label4;
        private TextBox tbxMinimumBuy;
        private Label label13;
        private Label label5;
        private TextBox textBox4;
        private Panel pnlSellAll;
        private TextBox textBox5;
        private Label label9;
        private Panel pnlSingleSell;
        private Label label11;
        private Panel pnlCommentBot;
        private TextBox tbxComments;
        private Label lblComments;
        private Panel pnlBumpIt;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private ComboBox cbxWallet;
        private TextBox tbxCycle;
        private Label lblCycle;
    }
}