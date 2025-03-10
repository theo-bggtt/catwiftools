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

namespace catwiftools.tasks
{
    public partial class tasksMainPage : UserControl
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        public int active_group;

        public tasksMainPage()
        {
            InitializeComponent();
        }

        private void tasksMainPage_Load(object sender, EventArgs e)
        {
            LoadTaskGroups();
        }

        private void btnCreateTaskGroup_Click(object sender, EventArgs e)
        {
            using (formTaskGroupCreation formTaskGroupCreation = new formTaskGroupCreation())
            {
                string groupName = formTaskGroupCreation.groupName;
                if (formTaskGroupCreation.ShowDialog() == DialogResult.OK)
                {
                    createTaskGroup(formTaskGroupCreation.groupName);
                }
            }
            LoadTaskGroups();
        }

        private void createTaskGroup(string groupName)
        {
            string query = "INSERT INTO 'task_groups' (group_name) VALUES (@groupName)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@groupName", groupName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadTaskGroups()
        {
            flpTaskGroupList.Controls.Clear();
            string query = "SELECT group_name FROM 'task_groups'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
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

            Functions functions = new Functions();
            int group_id = functions.GetTaskGroupId(groupName);
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



        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Button btnDeleteGroup = (Button)sender;
                string groupName = btnDeleteGroup.Name;
                Functions functions = new Functions();
                int group_id = functions.GetTaskGroupId(groupName);
                string query = $"DELETE FROM 'task_groups' WHERE group_id = {group_id}";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                LoadTaskGroups();
            }
        }

        private void btnViewGroup_Click(object sender, EventArgs e)
        {
            Button btnViewGroup = (Button)sender;
            Functions functions = new Functions();
            active_group = functions.GetTaskGroupId(btnViewGroup.Name);
            Console.WriteLine($"Group Box Clicked: {active_group}");
            LoadTasks(active_group);
        }

        

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            using (formTaskCreation formTaskCreation = new formTaskCreation())
            {
                if (formTaskCreation.ShowDialog() == DialogResult.OK)
                {
                    string task_name = formTaskCreation.task_name;
                    string task_type = "Test";
                    CreateTask(active_group, task_name, task_type);
                }
            }
            LoadTasks(active_group);
        }

        private void CreateTask(int group_id, string task_name, string task_type)
        {
            string query = "INSERT INTO 'tasks' (group_id, task_name, task_type) VALUES (@group_id, @task_name, @task_type)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@group_id", group_id);
                    command.Parameters.AddWithValue("@task_name", task_name);
                    command.Parameters.AddWithValue("@task_type", task_type);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private void CreateTaskBox(int task_id)
        {

        }

        private void LoadTasks(int active_group)
        {
            flpTaskList.Controls.Clear();
            List<int> loaded_tasks = new List<int>();
            string query = $"SELECT task_id FROM tasks WHERE group_id = '{active_group}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
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
                CreateTaskBox(task_id);
            }
            Console.WriteLine(loaded_tasks);
        }


    }
}
