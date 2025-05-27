
using catwiftools.wallet;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace catwiftools.tasks
{
    public partial class tasksMainPage : UserControl
    {

        public tasksMainPage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private void tasksMainPage_Load(object sender, EventArgs e)
        {
            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void btnCreateTaskGroup_Click(object sender, EventArgs e)
        {
            using (formTaskGroupCreation formTaskGroupCreation = new formTaskGroupCreation())
            {
                if (formTaskGroupCreation.ShowDialog() == DialogResult.OK)
                {
                    TaskHelper.InsertTaskGroup(formTaskGroupCreation.groupName, formTaskGroupCreation.walletGroup, formTaskGroupCreation.contractAddress);
                    ConfigHelper.selectedTaskGroup = TaskHelper.GetTaskGroupIdFromName(formTaskGroupCreation.groupName);
                }
            }
            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Button btnDeleteGroup = (Button)sender;
                string groupName = btnDeleteGroup.Name;
                int group_id = TaskHelper.GetTaskGroupIdFromName(groupName);

                string query = $"DELETE FROM 'task_groups' WHERE group_id = {group_id}";
                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                query = $"DELETE FROM 'tasks' WHERE group_id = {group_id}";
                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                ConfigHelper.selectedTaskGroup = 0;
            }

            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void btnViewGroup_Click(object sender, EventArgs e)
        {
            if (sender is Label lblViewGroup)
            {
                ConfigHelper.selectedTaskGroup = TaskHelper.GetTaskGroupIdFromName(lblViewGroup.Name);
                lblGroupName.Text = lblViewGroup.Name;
            }
            else if (sender is Panel pnlTaskGroup)
            {
                ConfigHelper.selectedTaskGroup = TaskHelper.GetTaskGroupIdFromName(pnlTaskGroup.Name);
                lblGroupName.Text = pnlTaskGroup.Name;
            }
            else
            {
                return;
            }
            
            lblGroupName.Visible = true;
            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            using (formTaskCreation formTaskCreation = new formTaskCreation(null))
            {
                if (formTaskCreation.ShowDialog() == DialogResult.OK)
                {
                    TaskHelper.InsertTask(formTaskCreation.task_name, formTaskCreation.task_type);
                    TaskHelper.saveParameters(formTaskCreation.task_name, formTaskCreation.parameters);
                }
            }
            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void btnDeleteTask_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Button btnDeleteTask = (Button)sender;
                int task_id = int.Parse(btnDeleteTask.Name);
                string query = "DELETE FROM tasks WHERE task_id = @task_id";

                using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@task_id", task_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                TaskHelper.deleteParameters(task_id);
            }

            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            Button btnEditTask = (Button)sender;
            int task_id = (int)btnEditTask.Tag;

            Dictionary<string, string> parameters = TaskHelper.GetTaskParameters(task_id);
            string task_name = TaskHelper.GetTaskName(task_id);
            string task_type = TaskHelper.GetTaskType(task_id);

            using (formTaskCreation formTaskCreation = new formTaskCreation(null))
            {
                formTaskCreation.task_name = task_name;
                formTaskCreation.task_type = task_type;
                formTaskCreation.parameters = parameters;
                formTaskCreation.isEditMode = true;
                formTaskCreation.SetTaskType(task_type);
                formTaskCreation.SetTaskName(task_name);
                formTaskCreation.SetTaskParameters(parameters);

                if (formTaskCreation.ShowDialog() == DialogResult.OK)
                {
                    TaskHelper.UpdateTask(task_id, formTaskCreation.task_name, formTaskCreation.task_type, formTaskCreation.parameters);
                }
            }

            LoadTaskGroups();
            LoadTasks(ConfigHelper.selectedTaskGroup);
        }

        private void LoadTasks(int GroupId)
        {
            flpTaskList.Controls.Clear();
            List<int> loaded_tasks = new List<int>();

            string query = $"SELECT task_id FROM tasks WHERE group_id = '{GroupId}'";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loaded_tasks.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            foreach (int task_id in loaded_tasks)
            {
                Dictionary<string, string> parameters = TaskHelper.GetTaskParameters(task_id);
                CreateTaskBox(task_id, parameters);
            }

            lblGroupAmount.Text = "Total Groups: " + TaskHelper.GetGroupCount();
            lblTaskAmount.Text = "Total Tasks: " + TaskHelper.GetTaskCount();
        }

        private void LoadTaskGroups()
        {
            flpTaskGroupList.Controls.Clear();

            string query = "SELECT group_name FROM 'task_groups'";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string groupName = reader.GetString(0);
                            CreateTaskGroupBox(groupName);
                        }
                    }
                }
            }
        }

        private void CreateTaskGroupBox(string groupName)
        {
            int group_id = TaskHelper.GetTaskGroupIdFromName(groupName);

            Panel pnlTaskGroup = new Panel();
            Label lblGroupName = new Label();
            Label lblTaskCount = new Label();

            pnlTaskGroup.Controls.Add(lblGroupName);
            pnlTaskGroup.Controls.Add(lblTaskCount);
            pnlTaskGroup.Location = new Point(10, 5);
            pnlTaskGroup.Margin = new Padding(10, 5, 10, 5);
            pnlTaskGroup.BackColor = Color.FromArgb(40, 40, 40);
            pnlTaskGroup.Name = groupName;
            pnlTaskGroup.Size = new Size(150, 33);
            pnlTaskGroup.TabIndex = 5;
            pnlTaskGroup.Click += btnViewGroup_Click;
            pnlTaskGroup.MouseEnter += (s, e) => pnlTaskGroup.BackColor = Color.FromArgb(60,60,60);
            pnlTaskGroup.MouseLeave += (s, e) => pnlTaskGroup.BackColor = Color.FromArgb(40, 40, 40);

            lblGroupName.AutoSize = true;
            lblGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGroupName.ForeColor = Color.White;
            lblGroupName.Location = new Point(20, 5);
            lblGroupName.Name = groupName;
            lblGroupName.Size = new Size(107, 21);
            lblGroupName.TabIndex = 0;
            lblGroupName.Text = groupName;
            lblGroupName.TextAlign = ContentAlignment.MiddleCenter;
            lblGroupName.Tag = group_id;
            lblGroupName.Click += btnViewGroup_Click;
            lblGroupName.MouseEnter += (s, e) => pnlTaskGroup.BackColor = Color.FromArgb(60, 60, 60);
            lblGroupName.MouseLeave += (s, e) => pnlTaskGroup.BackColor = Color.FromArgb(40, 40, 40);

            lblTaskCount.AutoSize = true;
            lblTaskCount.ForeColor = Color.White;
            lblTaskCount.Location = new Point(15, 30);
            lblTaskCount.Name = groupName;
            lblTaskCount.Size = new Size(36, 15);
            lblTaskCount.TabIndex = 45;
            lblTaskCount.Text = TaskHelper.GetTaskCountByGroupId(group_id).ToString();

            flpTaskGroupList.Controls.Add(pnlTaskGroup);
        }

        private void CreateTaskBox(int task_id, Dictionary<string, string> parameters) // Method to create a task box
        {
            TaskHelper taskHelper = new TaskHelper();

            GroupBox gbxTask = new GroupBox();
            Label lblParamValue4 = new Label();
            Label lblParamValue3 = new Label();
            Label lblParamValue2 = new Label();
            Label lblParamValue1 = new Label();
            Label lblParamName4 = new Label();
            Label lblParamName3 = new Label();
            Label lblParamName2 = new Label();
            Label lblParamName1 = new Label();
            Label lblTaskName = new Label();
            Label lblTaskType = new Label();
            Button btnEditTask = new Button();
            Button btnDeleteTask = new Button();
            Button btnstartTask = new Button();

            // 
            // gbxTask
            // 
            gbxTask.BackColor = Color.FromArgb(40, 40, 40);
            gbxTask.Controls.Add(lblParamValue4);
            gbxTask.Controls.Add(lblParamName4);
            gbxTask.Controls.Add(lblParamValue3);
            gbxTask.Controls.Add(lblParamName3);
            gbxTask.Controls.Add(lblParamValue2);
            gbxTask.Controls.Add(lblParamName2);
            gbxTask.Controls.Add(btnEditTask);
            gbxTask.Controls.Add(btnDeleteTask);
            gbxTask.Controls.Add(btnstartTask);
            gbxTask.Controls.Add(lblParamValue1);
            gbxTask.Controls.Add(lblParamName1);
            gbxTask.Controls.Add(lblTaskName);
            gbxTask.Controls.Add(lblTaskType);
            gbxTask.Location = new Point(10, 5);
            gbxTask.Margin = new Padding(10, 5, 10, 5);
            gbxTask.Name = task_id.ToString();
            gbxTask.Size = new Size(890, 100);
            gbxTask.TabStop = false;
            gbxTask.FlatStyle = FlatStyle.Flat;



            if (parameters.Count > 0)
            {
                // 
                // lblParamName1
                // 
                lblParamName1.AutoSize = true;
                lblParamName1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                lblParamName1.ForeColor = Color.White;
                lblParamName1.Location = new Point(197, 26);
                lblParamName1.Name = "lblParamName1";
                lblParamName1.Size = new Size(78, 15);
                lblParamName1.TabIndex = 45;
                // 
                // lblParamValue1
                // 
                lblParamValue1.AutoSize = true;
                lblParamValue1.ForeColor = Color.White;
                lblParamValue1.Location = new Point(308, 26);
                lblParamValue1.Name = "lblParamValue1";
                lblParamValue1.Size = new Size(72, 15);
                lblParamValue1.TabIndex = 46;
                lblParamName1.Text = parameters.ElementAt(0).Key;
                lblParamValue1.Text = parameters.ElementAt(0).Value;
            }
            if (parameters.Count > 1)
            {
                // 
                // lblParamValue2
                // 
                lblParamValue2.AutoSize = true;
                lblParamValue2.ForeColor = Color.White;
                lblParamValue2.Location = new Point(308, 56);
                lblParamValue2.Name = "lblParamValue2";
                lblParamValue2.Size = new Size(72, 15);
                lblParamValue2.TabIndex = 48;
                // 
                // lblParamName2
                // 
                lblParamName2.AutoSize = true;
                lblParamName2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                lblParamName2.ForeColor = Color.White;
                lblParamName2.Location = new Point(197, 56);
                lblParamName2.Name = "lblParamName2";
                lblParamName2.Size = new Size(78, 15);
                lblParamName2.TabIndex = 47;
                lblParamName2.Text = parameters.ElementAt(1).Key;
                lblParamValue2.Text = parameters.ElementAt(1).Value;
            }
            if (parameters.Count > 2)
            {
                // 
                // lblParamValue3
                // 
                lblParamValue3.AutoSize = true;
                lblParamValue3.ForeColor = Color.White;
                lblParamValue3.Location = new Point(554, 26);
                lblParamValue3.Name = "lblParamValue3";
                lblParamValue3.Size = new Size(72, 15);
                lblParamValue3.TabIndex = 50;
                // 
                // lblParamName3
                // 
                lblParamName3.AutoSize = true;
                lblParamName3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                lblParamName3.ForeColor = Color.White;
                lblParamName3.Location = new Point(443, 26);
                lblParamName3.Name = "lblParamName3";
                lblParamName3.Size = new Size(78, 15);
                lblParamName3.TabIndex = 49;
                lblParamName3.Text = parameters.ElementAt(2).Key;
                lblParamValue3.Text = parameters.ElementAt(2).Value;
            }
            if (parameters.Count > 3)
            {
                // 
                // lblParamValue4
                // 
                lblParamValue4.AutoSize = true;
                lblParamValue4.ForeColor = Color.White;
                lblParamValue4.Location = new Point(554, 56);
                lblParamValue4.Name = "lblParamValue4";
                lblParamValue4.Size = new Size(72, 15);
                lblParamValue4.TabIndex = 52;
                // 
                // lblParamName4
                // 
                lblParamName4.AutoSize = true;
                lblParamName4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                lblParamName4.ForeColor = Color.White;
                lblParamName4.Location = new Point(443, 56);
                lblParamName4.Name = "lblParamName4";
                lblParamName4.Size = new Size(78, 15);
                lblParamName4.TabIndex = 51;
                lblParamName4.Text = parameters.ElementAt(3).Key;
                lblParamValue4.Text = parameters.ElementAt(3).Value;
            }


            // 
            // btnEditTask
            // 
            btnEditTask.BackColor = Color.FromArgb(78, 93, 148);
            btnEditTask.FlatStyle = FlatStyle.Flat;
            btnEditTask.Location = new Point(789, 21);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(69, 24);
            btnEditTask.TabIndex = 44;
            btnEditTask.Text = "Edit";
            btnEditTask.UseVisualStyleBackColor = false;
            btnEditTask.Tag = task_id;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.BackColor = Color.DarkRed;
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.Location = new Point(789, 51);
            btnDeleteTask.Name = Convert.ToString(task_id);
            btnDeleteTask.Size = new Size(69, 24);
            btnDeleteTask.TabIndex = 44;
            btnDeleteTask.Text = "Delete";
            btnDeleteTask.UseVisualStyleBackColor = false;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnstartTask
            // 
            btnstartTask.BackColor = Color.Lime;
            btnstartTask.FlatStyle = FlatStyle.Flat;
            btnstartTask.Location = new Point(691, 30);
            btnstartTask.Name = "btnstartTask";
            btnstartTask.Size = new Size(69, 40);
            btnstartTask.TabIndex = 53;
            btnstartTask.Text = "Start";
            btnstartTask.UseVisualStyleBackColor = false;
            btnstartTask.Click += btnstartTask_Click;
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaskName.ForeColor = Color.White;
            lblTaskName.Location = new Point(6, 9);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(93, 21);
            lblTaskName.TabIndex = 44;
            lblTaskName.Text = TaskHelper.GetTaskName(task_id);
            //
            // lblTaskType
            //
            lblTaskType.AutoSize = true;
            lblTaskType.ForeColor = Color.White;
            lblTaskType.Location = new Point(9, 43);
            lblTaskType.Name = "lblTaskType";
            lblTaskType.Size = new Size(56, 15);
            lblTaskType.TabIndex = 1;
            lblTaskType.Text = TaskHelper.GetTaskType(task_id);

            flpTaskList.Controls.Add(gbxTask);
        }

        private async void btnStartStopTask_Click(object sender, EventArgs e)
        {
            Button btnStartStopTask = (Button)sender;
            if (btnStartStopTask.Tag.ToString() == "active")
            {
                btnStartStopTask.BackColor = Color.Lime;
                btnStartStopTask.Text = "Start";
                btnStartStopTask.Tag = "inactive";

                List<int> task_ids = TaskHelper.GetTasksFromGroupId(ConfigHelper.selectedTaskGroup);
                foreach (int task_id in task_ids)
                {
                    await Task.Run(() => TaskHelper.StartTask(task_id));
                }
            }
            else
            {
                btnStartStopTask.BackColor = Color.Red;
                btnStartStopTask.Text = "Stop";
                btnStartStopTask.Tag = "inactive";

                List<int> task_ids = TaskHelper.GetTasksFromGroupId(ConfigHelper.selectedTaskGroup);
                foreach (int task_id in task_ids)
                {
                    await Task.Run(() => TaskHelper.StopTask(task_id));
                }
            }


        }

        private async void btnstartTask_Click(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Parent is GroupBox parentGroupBox)
            {
                await Task.Run(() =>
                {
                    int task_id = int.Parse(parentGroupBox.Name);
                    TaskHelper.StartTask(task_id);
                });
            }
        }

        private void lblTaskAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
