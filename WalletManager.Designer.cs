namespace catwiftools
{
    partial class WalletManager
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
            gbxAvaibleDevWallets = new GroupBox();
            gbxAvaibleBundleWallets = new GroupBox();
            lvAvaibleDevWallets = new ListView();
            lvAvaibleBundleWallets = new ListView();
            gbxAvaibleDevWallets.SuspendLayout();
            gbxAvaibleBundleWallets.SuspendLayout();
            SuspendLayout();
            // 
            // gbxAvaibleDevWallets
            // 
            gbxAvaibleDevWallets.Controls.Add(lvAvaibleDevWallets);
            gbxAvaibleDevWallets.Location = new Point(39, 45);
            gbxAvaibleDevWallets.Name = "gbxAvaibleDevWallets";
            gbxAvaibleDevWallets.Size = new Size(200, 384);
            gbxAvaibleDevWallets.TabIndex = 0;
            gbxAvaibleDevWallets.TabStop = false;
            gbxAvaibleDevWallets.Text = "Avaible dev Wallets";
            // 
            // gbxAvaibleBundleWallets
            // 
            gbxAvaibleBundleWallets.Controls.Add(lvAvaibleBundleWallets);
            gbxAvaibleBundleWallets.Location = new Point(280, 45);
            gbxAvaibleBundleWallets.Name = "gbxAvaibleBundleWallets";
            gbxAvaibleBundleWallets.Size = new Size(200, 384);
            gbxAvaibleBundleWallets.TabIndex = 1;
            gbxAvaibleBundleWallets.TabStop = false;
            gbxAvaibleBundleWallets.Text = "Avaible Bundle Wallets";
            // 
            // lvAvaibleDevWallets
            // 
            lvAvaibleDevWallets.Location = new Point(6, 39);
            lvAvaibleDevWallets.Name = "lvAvaibleDevWallets";
            lvAvaibleDevWallets.Size = new Size(188, 339);
            lvAvaibleDevWallets.TabIndex = 2;
            lvAvaibleDevWallets.UseCompatibleStateImageBehavior = false;
            // 
            // lvAvaibleBundleWallets
            // 
            lvAvaibleBundleWallets.Location = new Point(6, 39);
            lvAvaibleBundleWallets.Name = "lvAvaibleBundleWallets";
            lvAvaibleBundleWallets.Size = new Size(188, 339);
            lvAvaibleBundleWallets.TabIndex = 3;
            lvAvaibleBundleWallets.UseCompatibleStateImageBehavior = false;
            // 
            // WalletManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbxAvaibleBundleWallets);
            Controls.Add(gbxAvaibleDevWallets);
            Name = "WalletManager";
            Size = new Size(1067, 591);
            gbxAvaibleDevWallets.ResumeLayout(false);
            gbxAvaibleBundleWallets.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxAvaibleDevWallets;
        private ListView lvAvaibleDevWallets;
        private GroupBox gbxAvaibleBundleWallets;
        private ListView lvAvaibleBundleWallets;
    }
}
