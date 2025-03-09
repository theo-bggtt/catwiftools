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
            flpTaskList.SuspendLayout();
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
            flpTaskList.Controls.Add(borderlessGroupBox1);
            flpTaskList.Location = new Point(240, 150);
            flpTaskList.Name = "flpTaskList";
            flpTaskList.Size = new Size(910, 602);
            flpTaskList.TabIndex = 3;
            // 
            // borderlessGroupBox1
            // 
            borderlessGroupBox1.Location = new Point(10, 5);
            borderlessGroupBox1.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox1.Name = "borderlessGroupBox1";
            borderlessGroupBox1.Size = new Size(890, 100);
            borderlessGroupBox1.TabIndex = 42;
            borderlessGroupBox1.TabStop = false;
            borderlessGroupBox1.Text = "borderlessGroupBox1";
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
    }
}
