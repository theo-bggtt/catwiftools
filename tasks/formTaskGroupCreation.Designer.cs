namespace catwiftools.tasks
{
    partial class formTaskGroupCreation
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
            btnCancel = new Button();
            lbTitle = new Label();
            btnCreate = new Button();
            tbxName = new TextBox();
            lbName = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(157, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 25);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.ForeColor = Color.White;
            lbTitle.Location = new Point(95, 31);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(103, 15);
            lbTitle.TabIndex = 12;
            lbTitle.Text = "Create Task Group";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(78, 93, 148);
            btnCreate.Enabled = false;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(42, 160);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(90, 25);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // tbxName
            // 
            tbxName.Location = new Point(147, 85);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(100, 23);
            tbxName.TabIndex = 9;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.ForeColor = Color.White;
            lbName.Location = new Point(42, 89);
            lbName.Name = "lbName";
            lbName.Size = new Size(81, 15);
            lbName.TabIndex = 8;
            lbName.Text = "Group Name :";
            // 
            // formTaskGroupCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(278, 198);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(lbTitle);
            Controls.Add(btnCreate);
            Controls.Add(tbxName);
            Controls.Add(lbName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "formTaskGroupCreation";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Label lbTitle;
        private Button btnCreate;
        private TextBox tbxName;
        private Label lbName;
    }
}