namespace catwiftools.settings
{
    partial class settingsVolume
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
            lblSettingsVolume = new Label();
            SuspendLayout();
            // 
            // lblSettingsVolume
            // 
            lblSettingsVolume.AutoSize = true;
            lblSettingsVolume.Font = new Font("Segoe UI", 15F);
            lblSettingsVolume.ForeColor = Color.FromArgb(153, 153, 153);
            lblSettingsVolume.Location = new Point(10, 5);
            lblSettingsVolume.Name = "lblSettingsVolume";
            lblSettingsVolume.Size = new Size(78, 28);
            lblSettingsVolume.TabIndex = 1;
            lblSettingsVolume.Text = "Volume";
            // 
            // settingsVolume
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblSettingsVolume);
            Name = "settingsVolume";
            Size = new Size(990, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSettingsVolume;
    }
}
