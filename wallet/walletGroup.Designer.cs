﻿namespace catwiftools.wallet
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
            lb = new Label();
            flpWalletGroup = new FlowLayoutPanel();
            btnCreateGroup = new Button();
            lblSettings = new Label();
            label1 = new Label();
            label2 = new Label();
            btnUpdateGroup = new Button();
            SuspendLayout();
            // 
            // lb
            // 
            lb.AutoSize = true;
            lb.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb.ForeColor = Color.White;
            lb.Location = new Point(10, 57);
            lb.Name = "lb";
            lb.Size = new Size(108, 17);
            lb.TabIndex = 2;
            lb.Text = "Group Amount :";
            // 
            // flpWalletGroup
            // 
            flpWalletGroup.AutoScroll = true;
            flpWalletGroup.BorderStyle = BorderStyle.FixedSingle;
            flpWalletGroup.Location = new Point(10, 160);
            flpWalletGroup.Margin = new Padding(0);
            flpWalletGroup.Name = "flpWalletGroup";
            flpWalletGroup.Size = new Size(1140, 587);
            flpWalletGroup.TabIndex = 3;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnCreateGroup.FlatAppearance.BorderSize = 0;
            btnCreateGroup.FlatStyle = FlatStyle.Flat;
            btnCreateGroup.ForeColor = Color.White;
            btnCreateGroup.Location = new Point(1014, 54);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(136, 23);
            btnCreateGroup.TabIndex = 4;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSettings.ForeColor = Color.White;
            lblSettings.ImeMode = ImeMode.NoControl;
            lblSettings.Location = new Point(10, 5);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(137, 28);
            lblSettings.TabIndex = 12;
            lblSettings.Text = "Wallet Group";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 115);
            label1.Name = "label1";
            label1.Size = new Size(96, 17);
            label1.TabIndex = 13;
            label1.Text = "Total Wallets: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 86);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 14;
            label2.Text = "Total SOL :";
            // 
            // btnUpdateGroup
            // 
            btnUpdateGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnUpdateGroup.FlatAppearance.BorderSize = 0;
            btnUpdateGroup.FlatStyle = FlatStyle.Flat;
            btnUpdateGroup.ForeColor = Color.White;
            btnUpdateGroup.Location = new Point(841, 55);
            btnUpdateGroup.Name = "btnUpdateGroup";
            btnUpdateGroup.Size = new Size(136, 23);
            btnUpdateGroup.TabIndex = 15;
            btnUpdateGroup.Text = "Update Group Info";
            btnUpdateGroup.UseVisualStyleBackColor = false;
            // 
            // walletGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnUpdateGroup);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblSettings);
            Controls.Add(btnCreateGroup);
            Controls.Add(flpWalletGroup);
            Controls.Add(lb);
            Name = "walletGroup";
            Size = new Size(1210, 762);
            Load += walletGroup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb;
        private FlowLayoutPanel flpWalletGroup;
        private Button btnCreateGroup;
        private Label lblSettings;
        private Label label1;
        private Label label2;
        private Button btnUpdateGroup;
    }
}
