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
        public string groupName, walletGroup;

        public formTaskGroupCreation()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (TaskHelper.GroupNameExists(tbxName.Text))
            {
                MessageBox.Show("This group name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Return the group_name to the main form
                groupName = tbxName.Text;
                walletGroup = cbxWalletGroup.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbxName_TextChanged(object sender, EventArgs e) // Check if the name is empty
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text) || string.IsNullOrWhiteSpace(cbxWalletGroup.Text))
            {
                btnCreate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = true;
            }
        }

        private void formTaskGroupCreation_Load(object sender, EventArgs e)
        {
            List<string> groupNames = GetAllWalletGroupNames();
            foreach (string groupName in groupNames)
            {
                cbxWalletGroup.Items.Add(groupName);
            }
        }

        private void cbxWalletGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text) || string.IsNullOrWhiteSpace(cbxWalletGroup.Text))
            {
                btnCreate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = true;
            }
        }

        private static List<string> GetAllWalletGroupNames()
        {
            List<string> groupNames = new List<string>();
            string query = "SELECT group_name FROM 'wallet_groups'";
            using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groupNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return groupNames;
        }
    }
}
