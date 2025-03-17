using catwiftools.wallet;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace catwiftools.tasks
{
    public partial class tasksMainPage : UserControl
    {
        private int active_group = 0;

        public tasksMainPage()
        {
            InitializeComponent();
        }

        private void tasksMainPage_Load(object sender, EventArgs e)
        {
            LoadTaskGroups();
            LoadTasks(active_group);
        }

        private void btnCreateTaskGroup_Click(object sender, EventArgs e)
        {
            using (formTaskGroupCreation formTaskGroupCreation = new formTaskGroupCreation())
            {
                if (formTaskGroupCreation.ShowDialog() == DialogResult.OK)
                {
                    TaskHelper.InsertTaskGroup(formTaskGroupCreation.groupName);
                    active_group = TaskHelper.GetTaskGroupId(formTaskGroupCreation.groupName);
                }
            }
            LoadTaskGroups();
            LoadTasks(active_group);
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Button btnDeleteGroup = (Button)sender;
                string groupName = btnDeleteGroup.Name;
                int group_id = TaskHelper.GetTaskGroupId(groupName);
                string query = $"DELETE FROM 'task_groups' WHERE group_id = {group_id}";
                using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                query = $"DELETE FROM 'tasks' WHERE group_id = {group_id}";
                using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                active_group = 0;
            }
            LoadTaskGroups();
            LoadTasks(active_group);
        }

        private void btnViewGroup_Click(object sender, EventArgs e)
        {
            Button btnViewGroup = (Button)sender;
            active_group = TaskHelper.GetTaskGroupId(btnViewGroup.Name);
            Console.WriteLine($"Group Box Clicked: {active_group}");
            LoadTaskGroups();
            LoadTasks(active_group);
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            using (formTaskCreation formTaskCreation = new formTaskCreation())
            {
                if (formTaskCreation.ShowDialog() == DialogResult.OK)
                {
                    TaskHelper.InsertTask(active_group, formTaskCreation.task_name, formTaskCreation.task_type);
                    TaskHelper.saveParameters(formTaskCreation.task_name, formTaskCreation.parameters);
                }
            }
            LoadTaskGroups();
            LoadTasks(active_group);
        }

        private void btnDeleteTask_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Button btnDeleteTask = (Button)sender;
                int task_id = int.Parse(btnDeleteTask.Name);
                string query = "DELETE FROM tasks WHERE task_id = @task_id";
                using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
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
            LoadTasks(active_group);
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {

        }

        private void LoadTasks(int active_group) // Gets the task_ids and creates a task box for each task
        {
            flpTaskList.Controls.Clear();
            List<int> loaded_tasks = new List<int>();
            string query = $"SELECT task_id FROM tasks WHERE group_id = '{active_group}'";
            using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
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

        private void LoadTaskGroups() // Gets the group_names and creates a group box for each group
        {
            flpTaskGroupList.Controls.Clear();
            string query = "SELECT group_name FROM 'task_groups'";
            using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
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

            int group_id = TaskHelper.GetTaskGroupId(groupName);
            BorderlessGroupBox gbxTaskGroup = new BorderlessGroupBox();
            Label lblGroupName = new Label();
            Button btnDeleteGroup = new Button();
            Button btnViewGroup = new Button();
            // 
            // gbxTaskGroup
            // 
            gbxTaskGroup.Anchor = AnchorStyles.Top;
            gbxTaskGroup.BackColor = Color.Transparent;
            gbxTaskGroup.Controls.Add(lblGroupName);
            gbxTaskGroup.Controls.Add(btnDeleteGroup);
            gbxTaskGroup.Controls.Add(btnViewGroup);
            gbxTaskGroup.FlatStyle = FlatStyle.Flat;
            gbxTaskGroup.Location = new Point(10, 5);
            gbxTaskGroup.Margin = new Padding(10, 5, 10, 5);
            gbxTaskGroup.Name = groupName;
            gbxTaskGroup.Size = new Size(180, 78);
            gbxTaskGroup.TabIndex = 4;
            gbxTaskGroup.TabStop = false;
            // 
            // lblGroupName
            // 
            lblGroupName.AutoSize = true;
            lblGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGroupName.ForeColor = Color.White;
            lblGroupName.Location = new Point(10, 15);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new Size(107, 21);
            lblGroupName.TabIndex = 0;
            lblGroupName.Text = groupName;
            // 
            // btnDeleteGroup
            // 
            btnDeleteGroup.BackColor = Color.DarkRed;
            btnDeleteGroup.FlatStyle = FlatStyle.Flat;
            btnDeleteGroup.Location = new Point(100, 45);
            btnDeleteGroup.Name = groupName;
            btnDeleteGroup.Size = new Size(69, 24);
            btnDeleteGroup.TabIndex = 42;
            btnDeleteGroup.Text = "Delete";
            btnDeleteGroup.UseVisualStyleBackColor = false;
            btnDeleteGroup.Click += btnDeleteGroup_Click;
            // 
            // btnViewGroup
            // 
            btnViewGroup.BackColor = Color.FromArgb(78, 93, 148);
            btnViewGroup.FlatStyle = FlatStyle.Flat;
            btnViewGroup.Location = new Point(10, 45);
            btnViewGroup.Name = groupName;
            btnViewGroup.Size = new Size(69, 24);
            btnViewGroup.TabIndex = 43;
            btnViewGroup.Text = "View";
            btnViewGroup.UseVisualStyleBackColor = false;
            btnViewGroup.Click += btnViewGroup_Click;

            flpTaskGroupList.Controls.Add(gbxTaskGroup);
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
            gbxTask.Controls.Add(lblParamValue1);
            gbxTask.Controls.Add(lblParamName1);
            gbxTask.Controls.Add(lblTaskName);
            gbxTask.Controls.Add(lblTaskType);
            gbxTask.Location = new Point(10, 5);
            gbxTask.Margin = new Padding(10, 5, 10, 5);
            gbxTask.Name = "gbxTask";
            gbxTask.Text = "";
            gbxTask.Size = new Size(890, 100);
            gbxTask.TabIndex = 42;
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
        
    }
}
