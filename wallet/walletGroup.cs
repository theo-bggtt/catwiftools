using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace catwiftools.wallet
{
    public partial class walletGroup : UserControl
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;
        private List<String> groupNames = new List<String>();

        public walletGroup()
        {
            InitializeComponent();
        }

        private void walletGroup_Load(object sender, EventArgs e)
        {
            string query = "SELECT group_name FROM 'group'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
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
            foreach (string groupName in groupNames)
            {
                // Create a new GroupbBox with 2 labels (one for walletAmount and one with groupName) and add that groupbox to flpWalletGroup
                BorderlessGroupBox borderlessGroupBox = new BorderlessGroupBox();
                borderlessGroupBox.Size = new Size(260, 160);
                borderlessGroupBox.Text = "";
                borderlessGroupBox.ForeColor = Color.White;
                borderlessGroupBox.BackColor = Color.FromArgb(40, 40, 40);
                borderlessGroupBox.Margin = new Padding(29);
                borderlessGroupBox.FlatStyle = FlatStyle.Flat;
                Label lbAmount = new Label();
                lbAmount.Text = "Wallet Amount: 100";
                lbAmount.Location = new Point(10, 40);
                lbAmount.AutoSize = true;
                Label lbName = new Label();
                lbName.Text = "Group Name: " + groupName;
                lbName.Location = new Point(10, 20);
                lbName.AutoSize = true;
                Button delButton = new Button();
                delButton.Text = "Delete";
                delButton.Location = new Point(170, 120);
                delButton.ForeColor = Color.White;
                delButton.BackColor = Color.DarkRed;
                delButton.AutoSize = true;
                delButton.Click += (s, ev) => delGroup(borderlessGroupBox);
                Button viewButton = new Button();
                viewButton.Text = "View";
                viewButton.Location = new Point(100, 120);
                viewButton.ForeColor = Color.White;
                viewButton.BackColor = Color.FromArgb(78, 93, 148);
                viewButton.AutoSize = true;
                //viewButton.Click += (s, ev) =>;
                borderlessGroupBox.Controls.Add(lbAmount);
                borderlessGroupBox.Controls.Add(lbName);
                borderlessGroupBox.Controls.Add(delButton);
                borderlessGroupBox.Controls.Add(viewButton);
                flpWalletGroup.Controls.Add(borderlessGroupBox);
            }
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            // Create and show the WalletOptionsForm as a dialog
            using (WalletGroupForm optionsForm = new WalletGroupForm())
            {
                if (optionsForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the values entered in the pop-up form
                    int walletAmount = Convert.ToInt32(optionsForm.walletAmount);
                    string groupName = optionsForm.groupName;
                    int group_id = 0;

                    // Get the id of that group and set the borderlessGroupBox tag to that id
                    string query = $"SELECT group_id FROM 'group' WHERE group_name = @groupName";
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        using (SqliteCommand command = new SqliteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@groupName", groupName);
                            connection.Open();
                            using (SqliteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    group_id = reader.GetInt32(0);
                                }
                            }
                        }
                    }

                    // Create a new GroupbBox with 2 labels (one for walletAmount and one with groupName) and add that groupbox to flpWalletGroup
                    BorderlessGroupBox borderlessGroupBox = new BorderlessGroupBox();
                    borderlessGroupBox.Size = new Size(260, 160);
                    borderlessGroupBox.Text = "";
                    borderlessGroupBox.ForeColor = Color.White;
                    borderlessGroupBox.BackColor = Color.FromArgb(40, 40, 40);
                    borderlessGroupBox.Margin = new Padding(29);
                    borderlessGroupBox.FlatStyle = FlatStyle.Flat;
                    borderlessGroupBox.Tag = group_id;

                    Label lbAmount = new Label();
                    lbAmount.Text = "Wallet Amount: " + walletAmount;
                    lbAmount.Location = new Point(10, 40);
                    lbAmount.AutoSize = true;

                    Label lbName = new Label();
                    lbName.Text = "Group Name: " + groupName;
                    lbName.Location = new Point(10, 20);
                    lbName.AutoSize = true;

                    Button delButton = new Button();
                    delButton.Text = "Delete";
                    delButton.Location = new Point(170, 120);
                    delButton.ForeColor = Color.White;
                    delButton.BackColor = Color.DarkRed;
                    delButton.AutoSize = true;
                    //delButton.Click += (s, ev) => flpWalletGroup.Controls.Remove(borderlessGroupBox);
                    delButton.Click += (s, ev) => delGroup(borderlessGroupBox);

                    Button viewButton = new Button();
                    viewButton.Text = "View";
                    viewButton.Location = new Point(100, 120);
                    viewButton.ForeColor = Color.White;
                    viewButton.BackColor = Color.FromArgb(78, 93, 148);
                    viewButton.AutoSize = true;
                    //viewButton.Click += (s, ev) =>;

                    borderlessGroupBox.Controls.Add(lbAmount);
                    borderlessGroupBox.Controls.Add(lbName);
                    borderlessGroupBox.Controls.Add(delButton);
                    borderlessGroupBox.Controls.Add(viewButton);

                    flpWalletGroup.Controls.Add(borderlessGroupBox);
                }
            }
        }

        private void delGroup(BorderlessGroupBox borderlessGroupBox)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string group_id = borderlessGroupBox.Tag.ToString();
                string query = $"DELETE FROM 'group' WHERE group_id = @group_id";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                flpWalletGroup.Controls.Remove(borderlessGroupBox);
            }
        }
    }
}