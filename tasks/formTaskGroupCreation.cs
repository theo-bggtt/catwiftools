using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools.tasks
{
    public partial class formTaskGroupCreation : Form
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        public string groupName;

        public formTaskGroupCreation()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = $"SELECT group_name FROM 'task_groups' WHERE group_name = '{tbxName.Text}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("This group name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            // Return the group_name to the main form
                            groupName = tbxName.Text;

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbxName_TextChanged(object sender, EventArgs e) // Check if the name is empty
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text))
            {
                btnCreate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = true;
            }
        }
    }
}
