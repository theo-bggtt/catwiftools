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
            // walletGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblVolumeTitle);
            Name = "walletGroup";
            Size = new Size(990, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVolumeTitle;
    }
}
