namespace catwiftools.bundler
{
    partial class CreateToken
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbxDescription = new TextBox();
            label4 = new Label();
            tbxWebsite = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            tbxTwitter = new TextBox();
            tbxTelegram = new TextBox();
            tbxName = new TextBox();
            tbxSymbol = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(133, 23);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 0;
            label1.Text = "Create new token";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 55);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(278, 55);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 3;
            label3.Text = "Symbol";
            // 
            // tbxDescription
            // 
            tbxDescription.Location = new Point(115, 131);
            tbxDescription.Name = "tbxDescription";
            tbxDescription.Size = new Size(179, 23);
            tbxDescription.TabIndex = 6;
            tbxDescription.TextChanged += tbxDescription_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(171, 113);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 5;
            label4.Text = "Description";
            // 
            // tbxWebsite
            // 
            tbxWebsite.Location = new Point(39, 297);
            tbxWebsite.Name = "tbxWebsite";
            tbxWebsite.Size = new Size(135, 23);
            tbxWebsite.TabIndex = 8;
            tbxWebsite.TextChanged += tbxWebsite_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 279);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 7;
            label5.Text = "Website";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(280, 279);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 9;
            label6.Text = "Twitter";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(78, 331);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 11;
            label7.Text = "Telegram";
            // 
            // tbxTwitter
            // 
            tbxTwitter.Location = new Point(234, 297);
            tbxTwitter.Name = "tbxTwitter";
            tbxTwitter.Size = new Size(135, 23);
            tbxTwitter.TabIndex = 12;
            tbxTwitter.TextChanged += tbxTwitter_TextChanged;
            // 
            // tbxTelegram
            // 
            tbxTelegram.Location = new Point(39, 363);
            tbxTelegram.Name = "tbxTelegram";
            tbxTelegram.Size = new Size(135, 23);
            tbxTelegram.TabIndex = 13;
            tbxTelegram.TextChanged += tbxTelegram_TextChanged;
            // 
            // tbxName
            // 
            tbxName.Location = new Point(39, 73);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(135, 23);
            tbxName.TabIndex = 14;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // tbxSymbol
            // 
            tbxSymbol.Location = new Point(234, 73);
            tbxSymbol.Name = "tbxSymbol";
            tbxSymbol.Size = new Size(135, 23);
            tbxSymbol.TabIndex = 15;
            tbxSymbol.TextChanged += tbxSymbol_TextChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(167, 173);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(154, 202);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // CreateToken
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 461);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(tbxSymbol);
            Controls.Add(tbxName);
            Controls.Add(tbxTelegram);
            Controls.Add(tbxTwitter);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbxWebsite);
            Controls.Add(label5);
            Controls.Add(tbxDescription);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateToken";
            Text = "CreateToken";
            Load += CreateToken_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbxDescription;
        private Label label4;
        private TextBox tbxWebsite;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox tbxTwitter;
        private TextBox tbxTelegram;
        private TextBox tbxName;
        private TextBox tbxSymbol;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private PictureBox pictureBox1;
    }
}