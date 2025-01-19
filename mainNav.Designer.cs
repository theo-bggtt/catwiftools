namespace catwiftools
{
    partial class mainNav
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
            btnSettings = new Button();
            btnProxies = new Button();
            btnTasks = new Button();
            btnBundler = new Button();
            btnWallets = new Button();
            SuspendLayout();
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BackgroundImageLayout = ImageLayout.None;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F);
            btnSettings.ForeColor = Color.FromArgb(153, 153, 153);
            btnSettings.Image = Properties.Resources.settings;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.ImeMode = ImeMode.NoControl;
            btnSettings.Location = new Point(10, 274);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(5, 0, 5, 0);
            btnSettings.Size = new Size(180, 40);
            btnSettings.TabIndex = 20;
            btnSettings.Text = "Settings";
            btnSettings.UseMnemonic = false;
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnProxies
            // 
            btnProxies.BackColor = Color.Transparent;
            btnProxies.BackgroundImageLayout = ImageLayout.None;
            btnProxies.FlatAppearance.BorderSize = 0;
            btnProxies.FlatStyle = FlatStyle.Flat;
            btnProxies.Font = new Font("Segoe UI", 12F);
            btnProxies.ForeColor = Color.FromArgb(153, 153, 153);
            btnProxies.Image = Properties.Resources.proxies;
            btnProxies.ImageAlign = ContentAlignment.MiddleLeft;
            btnProxies.ImeMode = ImeMode.NoControl;
            btnProxies.Location = new Point(10, 209);
            btnProxies.Name = "btnProxies";
            btnProxies.Padding = new Padding(5, 0, 5, 0);
            btnProxies.Size = new Size(180, 40);
            btnProxies.TabIndex = 17;
            btnProxies.Text = "Proxies";
            btnProxies.UseMnemonic = false;
            btnProxies.UseVisualStyleBackColor = false;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = Color.Transparent;
            btnTasks.BackgroundImageLayout = ImageLayout.None;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 12F);
            btnTasks.ForeColor = Color.FromArgb(153, 153, 153);
            btnTasks.Image = Properties.Resources.tasks;
            btnTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnTasks.ImeMode = ImeMode.NoControl;
            btnTasks.Location = new Point(10, 14);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(5, 0, 5, 0);
            btnTasks.Size = new Size(180, 40);
            btnTasks.TabIndex = 16;
            btnTasks.Text = "Tasks";
            btnTasks.UseMnemonic = false;
            btnTasks.UseVisualStyleBackColor = false;
            // 
            // btnBundler
            // 
            btnBundler.BackColor = Color.Transparent;
            btnBundler.BackgroundImageLayout = ImageLayout.None;
            btnBundler.FlatAppearance.BorderSize = 0;
            btnBundler.FlatStyle = FlatStyle.Flat;
            btnBundler.Font = new Font("Segoe UI", 12F);
            btnBundler.ForeColor = Color.FromArgb(153, 153, 153);
            btnBundler.Image = Properties.Resources.bundler;
            btnBundler.ImageAlign = ContentAlignment.MiddleLeft;
            btnBundler.ImeMode = ImeMode.NoControl;
            btnBundler.Location = new Point(10, 79);
            btnBundler.Name = "btnBundler";
            btnBundler.Padding = new Padding(5, 0, 5, 0);
            btnBundler.Size = new Size(180, 40);
            btnBundler.TabIndex = 19;
            btnBundler.Text = "Bundler";
            btnBundler.UseMnemonic = false;
            btnBundler.UseVisualStyleBackColor = false;
            // 
            // btnWallets
            // 
            btnWallets.BackColor = Color.Transparent;
            btnWallets.BackgroundImageLayout = ImageLayout.None;
            btnWallets.FlatAppearance.BorderSize = 0;
            btnWallets.FlatStyle = FlatStyle.Flat;
            btnWallets.Font = new Font("Segoe UI", 12F);
            btnWallets.ForeColor = Color.FromArgb(153, 153, 153);
            btnWallets.Image = Properties.Resources.wallets;
            btnWallets.ImageAlign = ContentAlignment.MiddleLeft;
            btnWallets.ImeMode = ImeMode.NoControl;
            btnWallets.Location = new Point(10, 144);
            btnWallets.Name = "btnWallets";
            btnWallets.Padding = new Padding(5, 0, 5, 0);
            btnWallets.Size = new Size(180, 40);
            btnWallets.TabIndex = 18;
            btnWallets.Text = "Wallets";
            btnWallets.UseMnemonic = false;
            btnWallets.UseVisualStyleBackColor = false;
            // 
            // mainNav
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnSettings);
            Controls.Add(btnProxies);
            Controls.Add(btnTasks);
            Controls.Add(btnBundler);
            Controls.Add(btnWallets);
            Name = "mainNav";
            Size = new Size(200, 762);
            ResumeLayout(false);
        }

        #endregion

        public Button btnSettings;
        public Button btnProxies;
        public Button btnTasks;
        public Button btnBundler;
        public Button btnWallets;
    }
}
