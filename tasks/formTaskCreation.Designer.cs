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
            label16 = new Label();
            tbxContracttbxContract = new TextBox();
            pnlSellAll = new Panel();
            textBox5 = new TextBox();
            label9 = new Label();
            textBox8 = new TextBox();
            label14 = new Label();
            pnlSingleSell = new Panel();
            cbxWallet = new ComboBox();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            pnlCommentBot = new Panel();
            tbxComments = new TextBox();
            lblComments = new Label();
            tbxContract = new TextBox();
            label17 = new Label();
            pnlBumpIt = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox12 = new TextBox();
            label19 = new Label();
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
            pnlBuyParameters.Controls.Add(label16);
            pnlBuyParameters.Controls.Add(tbxContracttbxContract);
            pnlBuyParameters.Location = new Point(25, 140);
            pnlBuyParameters.Name = "pnlBuyParameters";
            pnlBuyParameters.Size = new Size(370, 235);
            pnlBuyParameters.TabIndex = 67;
            pnlBuyParameters.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(144, 193);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(81, 23);
            textBox4.TabIndex = 70;
            textBox4.TextChanged += tbxDelay_TextChanged;
            textBox4.KeyPress += tbxDelay_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(157, 167);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 69;
            label5.Text = "Delay (S)";
            // 
            // tbxMaximumBuy
            // 
            tbxMaximumBuy.Location = new Point(251, 122);
            tbxMaximumBuy.Name = "tbxMaximumBuy";
            tbxMaximumBuy.Size = new Size(81, 23);
            tbxMaximumBuy.TabIndex = 68;
            tbxMaximumBuy.TextChanged += tbxMaximumBuy_TextChanged;
            tbxMaximumBuy.KeyPress += tbxDelay_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(224, 96);
            label4.Name = "label4";
            label4.Size = new Size(135, 15);
            label4.TabIndex = 67;
            label4.Text = "Maximum Buy Amount";
            // 
            // tbxMinimumBuy
            // 
            tbxMinimumBuy.Location = new Point(40, 121);
            tbxMinimumBuy.Name = "tbxMinimumBuy";
            tbxMinimumBuy.Size = new Size(81, 23);
            tbxMinimumBuy.TabIndex = 66;
            tbxMinimumBuy.TextChanged += textBox1_TextChanged;
            tbxMinimumBuy.KeyPress += tbxDelay_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(14, 95);
            label13.Name = "label13";
            label13.Size = new Size(132, 15);
            label13.TabIndex = 57;
            label13.Text = "Minimum Buy Amount";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(115, 19);
            label16.Name = "label16";
            label16.Size = new Size(139, 15);
            label16.TabIndex = 53;
            label16.Text = "Token Contract Address";
            // 
            // tbxContracttbxContract
            // 
            tbxContracttbxContract.Location = new Point(38, 45);
            tbxContracttbxContract.Name = "tbxContracttbxContract";
            tbxContracttbxContract.Size = new Size(292, 23);
            tbxContracttbxContract.TabIndex = 65;
            tbxContracttbxContract.TextChanged += token_contract_TextChanged;
            // 
            // pnlSellAll
            // 
            pnlSellAll.Controls.Add(textBox5);
            pnlSellAll.Controls.Add(label9);
            pnlSellAll.Controls.Add(textBox8);
            pnlSellAll.Controls.Add(label14);
            pnlSellAll.Location = new Point(25, 140);
            pnlSellAll.Name = "pnlSellAll";
            pnlSellAll.Size = new Size(370, 235);
            pnlSellAll.TabIndex = 71;
            pnlSellAll.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(144, 156);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(81, 23);
            textBox5.TabIndex = 70;
            textBox5.TextChanged += tbxDelay_TextChanged;
            textBox5.KeyPress += tbxDelay_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(157, 130);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 69;
            label9.Text = "Delay (S)";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(38, 45);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(292, 23);
            textBox8.TabIndex = 65;
            textBox8.TextChanged += token_contract_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(115, 19);
            label14.Name = "label14";
            label14.Size = new Size(139, 15);
            label14.TabIndex = 53;
            label14.Text = "Token Contract Address";
            // 
            // pnlSingleSell
            // 
            pnlSingleSell.Controls.Add(cbxWallet);
            pnlSingleSell.Controls.Add(label11);
            pnlSingleSell.Controls.Add(textBox7);
            pnlSingleSell.Controls.Add(label12);
            pnlSingleSell.Location = new Point(25, 140);
            pnlSingleSell.Name = "pnlSingleSell";
            pnlSingleSell.Size = new Size(370, 235);
            pnlSingleSell.TabIndex = 72;
            pnlSingleSell.Visible = false;
            // 
            // cbxWallet
            // 
            cbxWallet.FormattingEnabled = true;
            cbxWallet.Location = new Point(88, 166);
            cbxWallet.Name = "cbxWallet";
            cbxWallet.Size = new Size(192, 23);
            cbxWallet.TabIndex = 70;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(163, 131);
            label11.Name = "label11";
            label11.Size = new Size(43, 15);
            label11.TabIndex = 69;
            label11.Text = "Wallet";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(38, 45);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(292, 23);
            textBox7.TabIndex = 65;
            textBox7.TextChanged += token_contract_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(115, 19);
            label12.Name = "label12";
            label12.Size = new Size(139, 15);
            label12.TabIndex = 53;
            label12.Text = "Token Contract Address";
            // 
            // pnlCommentBot
            // 
            pnlCommentBot.Controls.Add(tbxComments);
            pnlCommentBot.Controls.Add(lblComments);
            pnlCommentBot.Controls.Add(tbxContract);
            pnlCommentBot.Controls.Add(label17);
            pnlCommentBot.Location = new Point(25, 140);
            pnlCommentBot.Name = "pnlCommentBot";
            pnlCommentBot.Size = new Size(370, 235);
            pnlCommentBot.TabIndex = 73;
            pnlCommentBot.Visible = false;
            // 
            // tbxComments
            // 
            tbxComments.Location = new Point(38, 114);
            tbxComments.Multiline = true;
            tbxComments.Name = "tbxComments";
            tbxComments.Size = new Size(292, 102);
            tbxComments.TabIndex = 70;
            tbxComments.TextChanged += tbxDelay_TextChanged;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblComments.ForeColor = Color.White;
            lblComments.Location = new Point(156, 85);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(67, 15);
            lblComments.TabIndex = 69;
            lblComments.Text = "Comments";
            // 
            // tbxContract
            // 
            tbxContract.Location = new Point(38, 45);
            tbxContract.Name = "tbxContract";
            tbxContract.Size = new Size(292, 23);
            tbxContract.TabIndex = 65;
            tbxContract.TextChanged += token_contract_TextChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(115, 19);
            label17.Name = "label17";
            label17.Size = new Size(139, 15);
            label17.TabIndex = 53;
            label17.Text = "Token Contract Address";
            // 
            // pnlBumpIt
            // 
            pnlBumpIt.Controls.Add(textBox2);
            pnlBumpIt.Controls.Add(label2);
            pnlBumpIt.Controls.Add(textBox3);
            pnlBumpIt.Controls.Add(label3);
            pnlBumpIt.Controls.Add(textBox12);
            pnlBumpIt.Controls.Add(label19);
            pnlBumpIt.Location = new Point(25, 140);
            pnlBumpIt.Name = "pnlBumpIt";
            pnlBumpIt.Size = new Size(370, 235);
            pnlBumpIt.TabIndex = 74;
            pnlBumpIt.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(251, 154);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(81, 23);
            textBox2.TabIndex = 74;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(272, 128);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 73;
            label2.Text = "Delay";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(40, 154);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(81, 23);
            textBox3.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(42, 128);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 71;
            label3.Text = "Buy Amount";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(38, 45);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(292, 23);
            textBox12.TabIndex = 65;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.White;
            label19.Location = new Point(115, 19);
            label19.Name = "label19";
            label19.Size = new Size(139, 15);
            label19.TabIndex = 53;
            label19.Text = "Token Contract Address";
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
            Controls.Add(pnlBuyParameters);
            Controls.Add(pnlBumpIt);
            Controls.Add(pnlCommentBot);
            Controls.Add(pnlSingleSell);
            Controls.Add(pnlSellAll);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formTaskCreation";
            StartPosition = FormStartPosition.CenterParent;
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
        private TextBox tbxContracttbxContract;
        private Label label13;
        private Label label16;
        private Label label5;
        private TextBox textBox4;
        private Panel pnlSellAll;
        private TextBox textBox5;
        private Label label9;
        private TextBox textBox8;
        private Label label14;
        private Panel pnlSingleSell;
        private Label label11;
        private TextBox textBox7;
        private Label label12;
        private Panel pnlCommentBot;
        private TextBox tbxComments;
        private Label lblComments;
        private TextBox tbxContract;
        private Label label17;
        private Panel pnlBumpIt;
        private TextBox textBox12;
        private Label label19;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private ComboBox cbxWallet;
    }
}