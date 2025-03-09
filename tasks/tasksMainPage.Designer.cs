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
            btnCreateTask = new Button();
            flpTaskGroupList = new FlowLayoutPanel();
            borderlessGroupBox1 = new BorderlessGroupBox();
            borderlessGroupBox2 = new BorderlessGroupBox();
            borderlessGroupBox3 = new BorderlessGroupBox();
            borderlessGroupBox4 = new BorderlessGroupBox();
            borderlessGroupBox5 = new BorderlessGroupBox();
            borderlessGroupBox6 = new BorderlessGroupBox();
            btnCreateTaskGroup = new Button();
            flpTaskGroupList.SuspendLayout();
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
            flpTaskList.Location = new Point(240, 150);
            flpTaskList.Name = "flpTaskList";
            flpTaskList.Size = new Size(910, 602);
            flpTaskList.TabIndex = 3;
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
            flpTaskGroupList.Controls.Add(borderlessGroupBox1);
            flpTaskGroupList.Controls.Add(borderlessGroupBox2);
            flpTaskGroupList.Controls.Add(borderlessGroupBox3);
            flpTaskGroupList.Controls.Add(borderlessGroupBox4);
            flpTaskGroupList.Controls.Add(borderlessGroupBox5);
            flpTaskGroupList.Controls.Add(borderlessGroupBox6);
            flpTaskGroupList.Location = new Point(10, 50);
            flpTaskGroupList.Name = "flpTaskGroupList";
            flpTaskGroupList.Size = new Size(200, 702);
            flpTaskGroupList.TabIndex = 4;
            // 
            // borderlessGroupBox1
            // 
            borderlessGroupBox1.Anchor = AnchorStyles.Top;
            borderlessGroupBox1.Location = new Point(10, 5);
            borderlessGroupBox1.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox1.Name = "borderlessGroupBox1";
            borderlessGroupBox1.Size = new Size(180, 65);
            borderlessGroupBox1.TabIndex = 0;
            borderlessGroupBox1.TabStop = false;
            // 
            // borderlessGroupBox2
            // 
            borderlessGroupBox2.Anchor = AnchorStyles.Top;
            borderlessGroupBox2.Location = new Point(10, 80);
            borderlessGroupBox2.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox2.Name = "borderlessGroupBox2";
            borderlessGroupBox2.Size = new Size(180, 65);
            borderlessGroupBox2.TabIndex = 1;
            borderlessGroupBox2.TabStop = false;
            // 
            // borderlessGroupBox3
            // 
            borderlessGroupBox3.Anchor = AnchorStyles.Top;
            borderlessGroupBox3.Location = new Point(10, 155);
            borderlessGroupBox3.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox3.Name = "borderlessGroupBox3";
            borderlessGroupBox3.Size = new Size(180, 65);
            borderlessGroupBox3.TabIndex = 2;
            borderlessGroupBox3.TabStop = false;
            // 
            // borderlessGroupBox4
            // 
            borderlessGroupBox4.Anchor = AnchorStyles.Top;
            borderlessGroupBox4.Location = new Point(10, 230);
            borderlessGroupBox4.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox4.Name = "borderlessGroupBox4";
            borderlessGroupBox4.Size = new Size(180, 65);
            borderlessGroupBox4.TabIndex = 3;
            borderlessGroupBox4.TabStop = false;
            // 
            // borderlessGroupBox5
            // 
            borderlessGroupBox5.Anchor = AnchorStyles.Top;
            borderlessGroupBox5.Location = new Point(10, 305);
            borderlessGroupBox5.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox5.Name = "borderlessGroupBox5";
            borderlessGroupBox5.Size = new Size(180, 65);
            borderlessGroupBox5.TabIndex = 4;
            borderlessGroupBox5.TabStop = false;
            // 
            // borderlessGroupBox6
            // 
            borderlessGroupBox6.Anchor = AnchorStyles.Top;
            borderlessGroupBox6.Location = new Point(10, 380);
            borderlessGroupBox6.Margin = new Padding(10, 5, 10, 5);
            borderlessGroupBox6.Name = "borderlessGroupBox6";
            borderlessGroupBox6.Size = new Size(180, 65);
            borderlessGroupBox6.TabIndex = 5;
            borderlessGroupBox6.TabStop = false;
            // 
            // btnCreateTaskGroup
            // 
            btnCreateTaskGroup.BackgroundImage = Properties.Resources.plus2;
            btnCreateTaskGroup.BackgroundImageLayout = ImageLayout.Center;
            btnCreateTaskGroup.FlatAppearance.BorderSize = 0;
            btnCreateTaskGroup.FlatStyle = FlatStyle.Flat;
            btnCreateTaskGroup.Location = new Point(172, 3);
            btnCreateTaskGroup.Name = "btnCreateTaskGroup";
            btnCreateTaskGroup.Size = new Size(28, 28);
            btnCreateTaskGroup.TabIndex = 41;
            btnCreateTaskGroup.UseVisualStyleBackColor = true;
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
            flpTaskGroupList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTasksTitle;
        private FlowLayoutPanel flpTaskList;
        public Button btnCreateTask;
        private FlowLayoutPanel flpTaskGroupList;
        private Button btnCreateTaskGroup;
        private BorderlessGroupBox borderlessGroupBox1;
        private BorderlessGroupBox borderlessGroupBox2;
        private BorderlessGroupBox borderlessGroupBox3;
        private BorderlessGroupBox borderlessGroupBox4;
        private BorderlessGroupBox borderlessGroupBox5;
        private BorderlessGroupBox borderlessGroupBox6;
    }
}
