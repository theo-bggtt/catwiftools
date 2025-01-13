namespace catwiftools.proxies
{
    partial class proxiesMainPage
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
            lblProxiesTitle = new Label();
            SuspendLayout();
            // 
            // lblProxiesTitle
            // 
            lblProxiesTitle.AutoSize = true;
            lblProxiesTitle.Font = new Font("Segoe UI", 15F);
            lblProxiesTitle.ForeColor = Color.FromArgb(153, 153, 153);
            lblProxiesTitle.Location = new Point(10, 5);
            lblProxiesTitle.Name = "lblProxiesTitle";
            lblProxiesTitle.Size = new Size(74, 28);
            lblProxiesTitle.TabIndex = 1;
            lblProxiesTitle.Text = "Proxies";
            // 
            // proxiesMainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblProxiesTitle);
            Name = "proxiesMainPage";
            Size = new Size(1210, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProxiesTitle;
    }
}
