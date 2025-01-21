namespace catwiftools.settings
{
    partial class settingsBumpIt
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
            lblSettingsBumpIt = new Label();
            SuspendLayout();
            // 
            // lblSettingsBumpIt
            // 
            lblSettingsBumpIt.AutoSize = true;
            lblSettingsBumpIt.Font = new Font("Segoe UI", 15F);
            lblSettingsBumpIt.ForeColor = Color.FromArgb(153, 153, 153);
            lblSettingsBumpIt.Location = new Point(10, 5);
            lblSettingsBumpIt.Name = "lblSettingsBumpIt";
            lblSettingsBumpIt.Size = new Size(80, 28);
            lblSettingsBumpIt.TabIndex = 1;
            lblSettingsBumpIt.Text = "Bump It";
            // 
            // settingsBumpIt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblSettingsBumpIt);
            Name = "settingsBumpIt";
            Size = new Size(990, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSettingsBumpIt;
    }
}
