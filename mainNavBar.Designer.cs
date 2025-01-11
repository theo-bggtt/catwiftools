namespace catwiftools
{
    partial class mainNavBar
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
            lblTitle = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(153, 153, 153);
            lblTitle.Location = new Point(74, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(116, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CatWifTools";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(153, 153, 153);
            label1.Location = new Point(74, 48);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 1;
            label1.Text = "@water.1213";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(25, 25, 25);
            pictureBox1.Image = Properties.Resources._21;
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 54);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(153, 153, 153);
            button1.Image = Properties.Resources.box;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(10, 104);
            button1.Name = "button1";
            button1.Padding = new Padding(5, 0, 5, 0);
            button1.Size = new Size(180, 40);
            button1.TabIndex = 3;
            button1.Text = "Bundler";
            button1.UseMnemonic = false;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(153, 153, 153);
            button2.Image = Properties.Resources.box;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(10, 302);
            button2.Name = "button2";
            button2.Padding = new Padding(5, 0, 5, 0);
            button2.Size = new Size(180, 40);
            button2.TabIndex = 4;
            button2.Text = "Bundler";
            button2.UseMnemonic = false;
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(153, 153, 153);
            button3.Image = Properties.Resources.box;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(10, 236);
            button3.Name = "button3";
            button3.Padding = new Padding(5, 0, 5, 0);
            button3.Size = new Size(180, 40);
            button3.TabIndex = 5;
            button3.Text = "Bundler";
            button3.UseMnemonic = false;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(153, 153, 153);
            button4.Image = Properties.Resources.box;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(10, 170);
            button4.Name = "button4";
            button4.Padding = new Padding(5, 0, 5, 0);
            button4.Size = new Size(180, 40);
            button4.TabIndex = 6;
            button4.Text = "Bundler";
            button4.UseMnemonic = false;
            button4.UseVisualStyleBackColor = false;
            // 
            // mainNavBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Margin = new Padding(0);
            Name = "mainNavBar";
            Size = new Size(200, 810);
            Load += mainNavBar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
