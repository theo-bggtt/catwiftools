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
            lvAvaibleDevWallets = new ListView();
            gbxAvaibleBundleWallets = new GroupBox();
            lvAvaibleBundleWallets = new ListView();
            listBoxWallets = new ListBox();
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
            // lvAvaibleDevWallets
            // 
            lvAvaibleDevWallets.Location = new Point(6, 39);
            lvAvaibleDevWallets.Name = "lvAvaibleDevWallets";
            lvAvaibleDevWallets.Size = new Size(188, 339);
            lvAvaibleDevWallets.TabIndex = 2;
            lvAvaibleDevWallets.UseCompatibleStateImageBehavior = false;
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
            // lvAvaibleBundleWallets
            // 
            lvAvaibleBundleWallets.Location = new Point(6, 39);
            lvAvaibleBundleWallets.Name = "lvAvaibleBundleWallets";
            lvAvaibleBundleWallets.Size = new Size(188, 339);
            lvAvaibleBundleWallets.TabIndex = 3;
            lvAvaibleBundleWallets.UseCompatibleStateImageBehavior = false;
            // 
            // listBoxWallets
            // 
            listBoxWallets.FormattingEnabled = true;
            listBoxWallets.ItemHeight = 15;
            listBoxWallets.Location = new Point(530, 70);
            listBoxWallets.Name = "listBoxWallets";
            listBoxWallets.SelectionMode = SelectionMode.MultiSimple;
            listBoxWallets.Size = new Size(188, 334);
            listBoxWallets.TabIndex = 2;
            listBoxWallets.SelectedIndexChanged += listBoxWallets_SelectedIndexChanged;
            // 
            // WalletManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listBoxWallets);
            Controls.Add(gbxAvaibleBundleWallets);
            Controls.Add(gbxAvaibleDevWallets);
            Name = "WalletManager";
            Size = new Size(1067, 591);
            Load += WalletManager_Load;
            gbxAvaibleDevWallets.ResumeLayout(false);
            gbxAvaibleBundleWallets.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxAvaibleDevWallets;
        private ListView lvAvaibleDevWallets;
        private GroupBox gbxAvaibleBundleWallets;
        private ListView lvAvaibleBundleWallets;
        private ListBox listBoxWallets;
    }
}
