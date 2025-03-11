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
using System.Xml.Linq;

namespace catwiftools.tasks
{
    public partial class formTaskCreation : Form
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        public string task_name, task_type;

        public formTaskCreation()
        {
            InitializeComponent();
        }

        private void tbxTaskName_TextChanged(object sender, EventArgs e)
        {
            task_name = tbxTaskName.Text;
            btnCreate.Enabled = !string.IsNullOrEmpty(task_name);

        }

        private void formTaskCreation_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.TaskNameExists(tbxTaskName.Text))
            {
                MessageBox.Show("This Task name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                task_name = tbxTaskName.Text;
                task_type = cbxTaskType.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
