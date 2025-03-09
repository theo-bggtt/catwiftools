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
            flpTaskList = new FlowLayoutPanel();
            borderlessGroupBox1 = new BorderlessGroupBox();
            btnCreateTask = new Button();
            flpTaskGroupList = new FlowLayoutPanel();
            gbxTaskGroup = new BorderlessGroupBox();
            btnViewGroup = new Button();
            btnDeleteGroup = new Button();
            lblGroupName = new Label();
            btnCreateTaskGroup = new Button();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button1 = new Button();
            button2 = new Button();
            flpTaskList.SuspendLayout();
            borderlessGroupBox1.SuspendLayout();
            flpTaskGroupList.SuspendLayout();
            gbxTaskGroup.SuspendLayout();
            SuspendLayout();
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.AutoSize = true;
            lblTasksTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTasksTitle.ForeColor = Color.White;
            lblTasksTitle.Location = new Point(10, 5);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Size = new Size(126, 28);
            lblTasksTitle.TabIndex = 2;
            lblTasksTitle.Text = "Task Groups";
            // 
            // flpTaskList
            // 
            flpTaskList.BorderStyle = BorderStyle.FixedSingle;
            flpTaskList.Controls.Add(borderlessGroupBox1);
            flpTaskList.Location = new Point(240, 150);
            flpTaskList.Name = "flpTaskList";
            flpTaskList.Size = new Size(910, 602);
            flpTaskList.TabIndex = 3;
            // 
            // borderlessGroupBox1
            // 
            borderlessGroupBox1.BackColor = Color.FromArgb(40, 40, 40);
            borderlessGroupBox1.Controls.Add(button2);
            borderlessGroupBox1.Controls.Add(button1);
            borderlessGroupBox1.Controls.Add(label9);
            borderlessGroupBox1.Controls.Add(label10);
            borderlessGroupBox1.Controls.Add(label7);
            borderlessGroupBox1.Controls.Add(label8);
            borderlessGroupBox1.Controls.Add(label5);
            borderlessGroupBox1.Controls.Add(label6);
            borderlessGroupBox1.Controls.Add(label4);
            borderlessGroupBox1.Controls.Add(label1);
            borderlessGroupBox1.Controls.Add(label3);
            borderlessGroupBox1.Controls.Add(label2);
            borderlessGroupBox1.FlatStyle = FlatStyle.Flat;
            borderlessGroupBox1.Location = new Point(10, 5);
            borderlessGroupBox1.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox1.Name = "borderlessGroupBox1";
            borderlessGroupBox1.Size = new Size(890, 100);
            borderlessGroupBox1.TabIndex = 42;
            borderlessGroupBox1.TabStop = false;
            // 
            // btnCreateTask
            // 
            btnCreateTask.BackColor = Color.FromArgb(78, 93, 148);
            btnCreateTask.BackgroundImageLayout = ImageLayout.None;
            btnCreateTask.FlatAppearance.BorderSize = 0;
            btnCreateTask.FlatStyle = FlatStyle.Flat;
            btnCreateTask.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateTask.ForeColor = Color.White;
            btnCreateTask.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreateTask.ImeMode = ImeMode.NoControl;
            btnCreateTask.Location = new Point(1040, 54);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Padding = new Padding(5, 0, 5, 0);
            btnCreateTask.Size = new Size(110, 25);
            btnCreateTask.TabIndex = 40;
            btnCreateTask.Tag = "";
            btnCreateTask.Text = "New Task";
            btnCreateTask.UseMnemonic = false;
            btnCreateTask.UseVisualStyleBackColor = false;
            // 
            // flpTaskGroupList
            // 
            flpTaskGroupList.Anchor = AnchorStyles.Top;
            flpTaskGroupList.BorderStyle = BorderStyle.FixedSingle;
            flpTaskGroupList.Controls.Add(gbxTaskGroup);
            flpTaskGroupList.Location = new Point(10, 50);
            flpTaskGroupList.Name = "flpTaskGroupList";
            flpTaskGroupList.Size = new Size(200, 702);
            flpTaskGroupList.TabIndex = 4;
            // 
            // gbxTaskGroup
            // 
            gbxTaskGroup.Anchor = AnchorStyles.Top;
            gbxTaskGroup.BackColor = Color.Transparent;
            gbxTaskGroup.Controls.Add(btnViewGroup);
            gbxTaskGroup.Controls.Add(btnDeleteGroup);
            gbxTaskGroup.Controls.Add(lblGroupName);
            gbxTaskGroup.FlatStyle = FlatStyle.Flat;
            gbxTaskGroup.Location = new Point(10, 5);
            gbxTaskGroup.Margin = new Padding(10, 5, 10, 5);
            gbxTaskGroup.Name = "gbxTaskGroup";
            gbxTaskGroup.Size = new Size(180, 78);
            gbxTaskGroup.TabIndex = 4;
            gbxTaskGroup.TabStop = false;
            // 
            // btnViewGroup
            // 
            btnViewGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnViewGroup.FlatStyle = FlatStyle.Flat;
            btnViewGroup.Location = new Point(10, 45);
            btnViewGroup.Name = "btnViewGroup";
            btnViewGroup.Size = new Size(69, 24);
            btnViewGroup.TabIndex = 43;
            btnViewGroup.Text = "View";
            btnViewGroup.UseVisualStyleBackColor = false;
            btnViewGroup.Click += btnViewGroup_Click;
            // 
            // btnDeleteGroup
            // 
            btnDeleteGroup.BackColor = Color.DarkRed;
            btnDeleteGroup.FlatStyle = FlatStyle.Flat;
            btnDeleteGroup.Location = new Point(100, 45);
            btnDeleteGroup.Name = "btnDeleteGroup";
            btnDeleteGroup.Size = new Size(69, 24);
            btnDeleteGroup.TabIndex = 42;
            btnDeleteGroup.Text = "Delete";
            btnDeleteGroup.UseVisualStyleBackColor = false;
            btnDeleteGroup.Click += btnDeleteGroup_Click;
            // 
            // lblGroupName
            // 
            lblGroupName.AutoSize = true;
            lblGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGroupName.ForeColor = Color.White;
            lblGroupName.Location = new Point(6, 11);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new Size(107, 21);
            lblGroupName.TabIndex = 0;
            lblGroupName.Text = "Group Name";
            // 
            // btnCreateTaskGroup
            // 
            btnCreateTaskGroup.BackgroundImage = Properties.Resources.plus2;
            btnCreateTaskGroup.BackgroundImageLayout = ImageLayout.Center;
            btnCreateTaskGroup.FlatAppearance.BorderSize = 0;
            btnCreateTaskGroup.FlatStyle = FlatStyle.Flat;
            btnCreateTaskGroup.Location = new Point(173, 9);
            btnCreateTaskGroup.Name = "btnCreateTaskGroup";
            btnCreateTaskGroup.Size = new Size(28, 28);
            btnCreateTaskGroup.TabIndex = 41;
            btnCreateTaskGroup.UseVisualStyleBackColor = true;
            btnCreateTaskGroup.Click += btnCreateTaskGroup_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 43);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Task Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 9);
            label3.Name = "label3";
            label3.Size = new Size(93, 21);
            label3.TabIndex = 44;
            label3.Text = "Task Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(197, 26);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 45;
            label1.Text = "Param Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(308, 26);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 46;
            label4.Text = "Param Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(308, 56);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 48;
            label5.Text = "Param Value";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(197, 56);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 47;
            label6.Text = "Param Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(553, 26);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 50;
            label7.Text = "Param Value";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(442, 26);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 49;
            label8.Text = "Param Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(553, 56);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 52;
            label9.Text = "Param Value";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(442, 56);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 51;
            label10.Text = "Param Name";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(789, 51);
            button1.Name = "button1";
            button1.Size = new Size(69, 24);
            button1.TabIndex = 44;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(78, 93, 148);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(789, 21);
            button2.Name = "button2";
            button2.Size = new Size(69, 24);
            button2.TabIndex = 44;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = false;
            // 
            // tasksMainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnCreateTaskGroup);
            Controls.Add(flpTaskGroupList);
            Controls.Add(btnCreateTask);
            Controls.Add(flpTaskList);
            Controls.Add(lblTasksTitle);
            Name = "tasksMainPage";
            Size = new Size(1210, 762);
            Load += tasksMainPage_Load;
            flpTaskList.ResumeLayout(false);
            borderlessGroupBox1.ResumeLayout(false);
            borderlessGroupBox1.PerformLayout();
            flpTaskGroupList.ResumeLayout(false);
            gbxTaskGroup.ResumeLayout(false);
            gbxTaskGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTasksTitle;
        private FlowLayoutPanel flpTaskList;
        public Button btnCreateTask;
        private FlowLayoutPanel flpTaskGroupList;
        private Button btnCreateTaskGroup;
        private BorderlessGroupBox gbxTaskGroup;
        private Label lblGroupName;
        private Button btnDeleteGroup;
        private Button btnViewGroup;
        private BorderlessGroupBox borderlessGroupBox1;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label8;
        private Label label5;
        private Label label6;
        private Label label4;
        private Label label1;
        private Label label9;
        private Label label10;
        private Button button2;
        private Button button1;
    }
}
