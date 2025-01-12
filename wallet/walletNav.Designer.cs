namespace catwiftools.wallet
{
    partial class walletNav
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
            btnTasks = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F);
            lblTitle.ForeColor = Color.FromArgb(153, 153, 153);
            lblTitle.Location = new Point(10, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(75, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Wallets";
            // 
            // btnTasks
            // 
            btnTasks.BackColor = Color.Transparent;
            btnTasks.BackgroundImageLayout = ImageLayout.None;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTasks.ForeColor = Color.FromArgb(153, 153, 153);
            btnTasks.Image = Properties.Resources.tasks;
            btnTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnTasks.Location = new Point(10, 234);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(5, 0, 5, 0);
            btnTasks.Size = new Size(180, 40);
            btnTasks.TabIndex = 4;
            btnTasks.Text = "Bump it";
            btnTasks.UseMnemonic = false;
            btnTasks.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(153, 153, 153);
            button1.Image = Properties.Resources.tasks;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(10, 169);
            button1.Name = "button1";
            button1.Padding = new Padding(5, 0, 5, 0);
            button1.Size = new Size(180, 40);
            button1.TabIndex = 5;
            button1.Text = "Bundler";
            button1.UseMnemonic = false;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(153, 153, 153);
            button2.Image = Properties.Resources.tasks;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(10, 104);
            button2.Name = "button2";
            button2.Padding = new Padding(5, 0, 5, 0);
            button2.Size = new Size(180, 40);
            button2.TabIndex = 6;
            button2.Text = "Volume";
            button2.UseMnemonic = false;
            button2.UseVisualStyleBackColor = false;
            // 
            // walletNav
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnTasks);
            Controls.Add(lblTitle);
            Name = "walletNav";
            Size = new Size(200, 810);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        public Button btnTasks;
        public Button button1;
        public Button button2;
    }
}
