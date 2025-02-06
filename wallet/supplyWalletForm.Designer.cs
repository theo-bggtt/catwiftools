namespace catwiftools.wallet
{
    partial class supplyWalletForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbxAmount = new TextBox();
            lblAmount = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // tbxAmount
            // 
            tbxAmount.Location = new Point(203, 28);
            tbxAmount.Name = "tbxAmount";
            tbxAmount.Size = new Size(100, 23);
            tbxAmount.TabIndex = 0;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(27, 31);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(118, 15);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount to distribute";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(136, 67);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Distribute";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnGetMinAmount_Click;
            // 
            // supplyWalletForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 112);
            Controls.Add(btnSubmit);
            Controls.Add(lblAmount);
            Controls.Add(tbxAmount);
            Name = "supplyWalletForm";
            Text = "supplyWalletForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxAmount;
        private Label lblAmount;
        private Button btnSubmit;
    }
}