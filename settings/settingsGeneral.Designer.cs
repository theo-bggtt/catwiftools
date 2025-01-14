namespace catwiftools.settings
{
    partial class settingsGeneral
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
            lblSettingsGeneral = new Label();
            gbxWalletNav = new BorderlessGroupBox();
            SuspendLayout();
            // 
            // lblSettingsGeneral
            // 
            lblSettingsGeneral.AutoSize = true;
            lblSettingsGeneral.Font = new Font("Segoe UI", 15F);
            lblSettingsGeneral.ForeColor = Color.FromArgb(153, 153, 153);
            lblSettingsGeneral.Location = new Point(10, 5);
            lblSettingsGeneral.Name = "lblSettingsGeneral";
            lblSettingsGeneral.Size = new Size(79, 28);
            lblSettingsGeneral.TabIndex = 0;
            lblSettingsGeneral.Text = "General";
            // 
            // gbxWalletNav
            // 
            gbxWalletNav.BackColor = Color.FromArgb(25, 25, 25);
            gbxWalletNav.Location = new Point(210, 50);
            gbxWalletNav.Name = "gbxWalletNav";
            gbxWalletNav.Size = new Size(680, 627);
            gbxWalletNav.TabIndex = 19;
            gbxWalletNav.TabStop = false;
            // 
            // settingsGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(gbxWalletNav);
            Controls.Add(lblSettingsGeneral);
            Name = "settingsGeneral";
            Size = new Size(990, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSettingsGeneral;
        private BorderlessGroupBox gbxWalletNav;
    }
}
