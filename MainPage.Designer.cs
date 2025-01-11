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
            mainNavBar1 = new mainNavBar();
            walletNav1 = new wallet.walletNav();
            bundlerNav1 = new bundler.bundlerNav();
            SuspendLayout();
            // 
            // mainNavBar1
            // 
            resources.ApplyResources(mainNavBar1, "mainNavBar1");
            mainNavBar1.BackColor = Color.Transparent;
            mainNavBar1.Name = "mainNavBar1";
            // 
            // walletNav1
            // 
            resources.ApplyResources(walletNav1, "walletNav1");
            walletNav1.BackColor = Color.Transparent;
            walletNav1.Name = "walletNav1";
            // 
            // bundlerNav1
            // 
            resources.ApplyResources(bundlerNav1, "bundlerNav1");
            bundlerNav1.Name = "bundlerNav1";
            // 
            // CatWifTools
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(25, 25, 25);
            ControlBox = false;
            Controls.Add(walletNav1);
            Controls.Add(mainNavBar1);
            Controls.Add(bundlerNav1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CatWifTools";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Load += CatWifTools_Load;
            MouseDown += CatWifTools_MouseDown;
            MouseMove += CatWifTools_MouseMove;
            MouseUp += CatWifTools_MouseUp;
            ResumeLayout(false);
        }

        #endregion
        private mainNavBar mainNavBar1;
        private wallet.walletNav walletNav1;
        private bundler.bundlerNav bundlerNav1;
    }
}