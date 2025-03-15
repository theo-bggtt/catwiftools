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
            pnlTaskParameters = new Panel();
            lblParamName1 = new Label();
            lblParamValue1 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            pnlTaskParameters.SuspendLayout();
            SuspendLayout();
            // 
            // lblTaskType
            // 
            lblTaskType.AutoSize = true;
            lblTaskType.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskType.ForeColor = Color.White;
            lblTaskType.Location = new Point(269, 25);
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
            lblTaskName.Location = new Point(53, 25);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(105, 28);
            lblTaskName.TabIndex = 2;
            lblTaskName.Text = "Task Name";
            // 
            // tbxTaskName
            // 
            tbxTaskName.Location = new Point(55, 80);
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
            btnCancel.Location = new Point(270, 400);
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
            btnCreate.Location = new Point(60, 400);
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
            cbxTaskType.Location = new Point(255, 80);
            cbxTaskType.Name = "cbxTaskType";
            cbxTaskType.Size = new Size(121, 23);
            cbxTaskType.TabIndex = 16;
            cbxTaskType.SelectedIndexChanged += cbxTaskType_SelectedIndexChanged;
            // 
            // pnlTaskParameters
            // 
            pnlTaskParameters.Controls.Add(label7);
            pnlTaskParameters.Controls.Add(label8);
            pnlTaskParameters.Controls.Add(label9);
            pnlTaskParameters.Controls.Add(label10);
            pnlTaskParameters.Controls.Add(label3);
            pnlTaskParameters.Controls.Add(label4);
            pnlTaskParameters.Controls.Add(label5);
            pnlTaskParameters.Controls.Add(label6);
            pnlTaskParameters.Controls.Add(label1);
            pnlTaskParameters.Controls.Add(lblParamValue1);
            pnlTaskParameters.Controls.Add(lblParamName1);
            pnlTaskParameters.Controls.Add(label2);
            pnlTaskParameters.Location = new Point(25, 140);
            pnlTaskParameters.Name = "pnlTaskParameters";
            pnlTaskParameters.Size = new Size(370, 235);
            pnlTaskParameters.TabIndex = 17;
            pnlTaskParameters.Paint += pnlTaskParameters_Paint;
            // 
            // lblParamName1
            // 
            lblParamName1.AutoSize = true;
            lblParamName1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblParamName1.ForeColor = Color.White;
            lblParamName1.Location = new Point(41, 19);
            lblParamName1.Name = "lblParamName1";
            lblParamName1.Size = new Size(78, 15);
            lblParamName1.TabIndex = 53;
            lblParamName1.Text = "Param Name";
            // 
            // lblParamValue1
            // 
            lblParamValue1.AutoSize = true;
            lblParamValue1.ForeColor = Color.White;
            lblParamValue1.Location = new Point(44, 49);
            lblParamValue1.Name = "lblParamValue1";
            lblParamValue1.Size = new Size(72, 15);
            lblParamValue1.TabIndex = 54;
            lblParamValue1.Text = "Param Value";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(254, 49);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 56;
            label1.Text = "Param Value";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(251, 19);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 55;
            label2.Text = "Param Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(254, 125);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 60;
            label3.Text = "Param Value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(44, 125);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 58;
            label4.Text = "Param Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(41, 95);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 57;
            label5.Text = "Param Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(251, 95);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 59;
            label6.Text = "Param Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(254, 201);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 64;
            label7.Text = "Param Value";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(44, 201);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 62;
            label8.Text = "Param Value";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(41, 171);
            label9.Name = "label9";
            label9.Size = new Size(78, 15);
            label9.TabIndex = 61;
            label9.Text = "Param Name";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(251, 171);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 63;
            label10.Text = "Param Name";
            // 
            // formTaskCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(418, 448);
            ControlBox = false;
            Controls.Add(pnlTaskParameters);
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
            pnlTaskParameters.ResumeLayout(false);
            pnlTaskParameters.PerformLayout();
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
        private Panel pnlTaskParameters;
        private Label lblParamValue1;
        private Label lblParamName1;
        private Label label1;
        private Label label2;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}