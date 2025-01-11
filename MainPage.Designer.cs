namespace catwiftools
{
    partial class CatWifTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatWifTools));
            btnTokenLauncher = new Button();
            btnWalletManager = new Button();
            btnWalletCreator = new Button();
            mainNavBar1 = new mainNavBar();
            SuspendLayout();
            // 
            // btnTokenLauncher
            // 
            resources.ApplyResources(btnTokenLauncher, "btnTokenLauncher");
            btnTokenLauncher.Name = "btnTokenLauncher";
            btnTokenLauncher.UseVisualStyleBackColor = true;
            btnTokenLauncher.Click += btnTokenLauncher_Click;
            // 
            // btnWalletManager
            // 
            resources.ApplyResources(btnWalletManager, "btnWalletManager");
            btnWalletManager.Name = "btnWalletManager";
            btnWalletManager.UseVisualStyleBackColor = true;
            // 
            // btnWalletCreator
            // 
            resources.ApplyResources(btnWalletCreator, "btnWalletCreator");
            btnWalletCreator.Name = "btnWalletCreator";
            btnWalletCreator.UseVisualStyleBackColor = true;
            // 
            // mainNavBar1
            // 
            resources.ApplyResources(mainNavBar1, "mainNavBar1");
            mainNavBar1.BackColor = Color.Transparent;
            mainNavBar1.Name = "mainNavBar1";
            // 
            // CatWifTools
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(25, 25, 25);
            ControlBox = false;
            Controls.Add(mainNavBar1);
            Controls.Add(btnWalletCreator);
            Controls.Add(btnWalletManager);
            Controls.Add(btnTokenLauncher);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CatWifTools";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Load += MainPage_Load;
            MouseDown += CatWifTools_MouseDown;
            MouseMove += CatWifTools_MouseMove;
            MouseUp += CatWifTools_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnTokenLauncher;
        private Button btnWalletManager;
        private Button btnWalletCreator;
        private mainNavBar mainNavBar1;
    }
}