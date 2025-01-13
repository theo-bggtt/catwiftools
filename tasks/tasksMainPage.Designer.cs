namespace catwiftools.tasks
{
    partial class tasksMainPage
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
            lblTasksTitle = new Label();
            SuspendLayout();
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.AutoSize = true;
            lblTasksTitle.Font = new Font("Segoe UI", 15F);
            lblTasksTitle.ForeColor = Color.FromArgb(153, 153, 153);
            lblTasksTitle.Location = new Point(10, 5);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Size = new Size(56, 28);
            lblTasksTitle.TabIndex = 2;
            lblTasksTitle.Text = "Tasks";
            // 
            // tasksMainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblTasksTitle);
            Name = "tasksMainPage";
            Size = new Size(1210, 762);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTasksTitle;
    }
}
