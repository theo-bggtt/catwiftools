namespace catwiftools.tasks
{
    partial class formTaskCreation
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
            lblTaskType = new Label();
            lblTaskName = new Label();
            tbxTaskName = new TextBox();
            btnCancel = new Button();
            btnCreate = new Button();
            cbxTaskType = new ComboBox();
            SuspendLayout();
            // 
            // lblTaskType
            // 
            lblTaskType.AutoSize = true;
            lblTaskType.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskType.ForeColor = Color.White;
            lblTaskType.Location = new Point(258, 24);
            lblTaskType.Name = "lblTaskType";
            lblTaskType.Size = new Size(92, 28);
            lblTaskType.TabIndex = 1;
            lblTaskType.Text = "Task type";
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskName.ForeColor = Color.White;
            lblTaskName.Location = new Point(43, 24);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(105, 28);
            lblTaskName.TabIndex = 2;
            lblTaskName.Text = "Task Name";
            // 
            // tbxTaskName
            // 
            tbxTaskName.Location = new Point(45, 93);
            tbxTaskName.Name = "tbxTaskName";
            tbxTaskName.Size = new Size(100, 23);
            tbxTaskName.TabIndex = 3;
            tbxTaskName.TextChanged += tbxTaskName_TextChanged;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(220, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 25);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(78, 93, 148);
            btnCreate.Enabled = false;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(105, 200);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(90, 25);
            btnCreate.TabIndex = 14;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // cbxTaskType
            // 
            cbxTaskType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTaskType.FormattingEnabled = true;
            cbxTaskType.Items.AddRange(new object[] { "Volume", "BumpIt", "Bundle" });
            cbxTaskType.Location = new Point(244, 93);
            cbxTaskType.Name = "cbxTaskType";
            cbxTaskType.Size = new Size(121, 23);
            cbxTaskType.TabIndex = 16;
            // 
            // formTaskCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(417, 270);
            ControlBox = false;
            Controls.Add(cbxTaskType);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(tbxTaskName);
            Controls.Add(lblTaskName);
            Controls.Add(lblTaskType);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formTaskCreation";
            StartPosition = FormStartPosition.CenterParent;
            Load += formTaskCreation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTaskType;
        private Label lblTaskName;
        private TextBox tbxTaskName;
        private Button btnCancel;
        private Button btnCreate;
        private ComboBox cbxTaskType;
    }
}