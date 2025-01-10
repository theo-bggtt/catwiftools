namespace catwiftools
{
    partial class MainPage
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            walletCreator1 = new WalletCreator();
            walletManager1 = new WalletManager();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(85, 13);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(201, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(305, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // walletCreator1
            // 
            walletCreator1.Location = new Point(7, 40);
            walletCreator1.Name = "walletCreator1";
            walletCreator1.Size = new Size(1051, 553);
            walletCreator1.TabIndex = 3;
            // 
            // walletManager1
            // 
            walletManager1.Location = new Point(7, 42);
            walletManager1.Name = "walletManager1";
            walletManager1.Size = new Size(1047, 551);
            walletManager1.TabIndex = 4;
            walletManager1.Load += walletManager1_Load;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 600);
            Controls.Add(walletManager1);
            Controls.Add(walletCreator1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainPage";
            Text = "MainPage";
            Load += MainPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private WalletCreator walletCreator1;
        private WalletManager walletManager1;
    }
}