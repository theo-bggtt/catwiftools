namespace catwiftools.wallet
{
    partial class walletGroup
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
            lblVolumeTitle = new Label();
            flpWalletGroup = new FlowLayoutPanel();
            btnCreateGroup = new Button();
            SuspendLayout();
            // 
            // lblVolumeTitle
            // 
            lblVolumeTitle.AutoSize = true;
            lblVolumeTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVolumeTitle.ForeColor = Color.White;
            lblVolumeTitle.Location = new Point(10, 38);
            lblVolumeTitle.Name = "lblVolumeTitle";
            lblVolumeTitle.Size = new Size(89, 17);
            lblVolumeTitle.TabIndex = 2;
            lblVolumeTitle.Text = "Wallet Group";
            // 
            // flpWalletGroup
            // 
            flpWalletGroup.AutoScroll = true;
            flpWalletGroup.BorderStyle = BorderStyle.FixedSingle;
            flpWalletGroup.Location = new Point(10, 160);
            flpWalletGroup.Margin = new Padding(0);
            flpWalletGroup.Name = "flpWalletGroup";
            flpWalletGroup.Size = new Size(969, 587);
            flpWalletGroup.TabIndex = 3;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnCreateGroup.FlatAppearance.BorderSize = 0;
            btnCreateGroup.FlatStyle = FlatStyle.Flat;
            btnCreateGroup.ForeColor = Color.White;
            btnCreateGroup.Location = new Point(684, 38);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(136, 23);
            btnCreateGroup.TabIndex = 4;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // walletGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnCreateGroup);
            Controls.Add(flpWalletGroup);
            Controls.Add(lblVolumeTitle);
            Name = "walletGroup";
            Size = new Size(990, 762);
            Load += walletGroup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVolumeTitle;
        private FlowLayoutPanel flpWalletGroup;
        private BorderlessGroupBox borderlessGroupBox4;
        private BorderlessGroupBox borderlessGroupBox5;
        private BorderlessGroupBox borderlessGroupBox6;
        private BorderlessGroupBox borderlessGroupBox7;
        private BorderlessGroupBox borderlessGroupBox8;
        private BorderlessGroupBox borderlessGroupBox9;
        private Button btnCreateGroup;
    }
}
