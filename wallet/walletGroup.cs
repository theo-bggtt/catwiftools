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
        private List<String> groupNames = new List<String>();
        public static int group_id = 0;
        private List<String> walletMnemonics = new List<string>();

        public walletGroup()
        {
            InitializeComponent();
        }

        private void walletGroup_Load(object sender, EventArgs e)
        {

            GetGroups();
            
            foreach (string groupName in groupNames)
            {
                group_id = GetGroupId(groupName);
                int walletAmount = GetWalletAmount(group_id);
                createBorderlessGroupBox(group_id, walletAmount, groupName);
            }
            UpdateInfo();
        }

        private void GetGroups()
        {
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
        }

        private void UpdateInfo()
        {
            int TotalWallet = 0;
            foreach (string groupName in groupNames)
            {
                int group_id = GetGroupId(groupName);
                TotalWallet += GetWalletAmount(group_id);
            }

            lbGroupAmount.Text = "Group Amount: " + groupNames.Count;
            lbTotalWallet.Text = "Total Wallet: " + TotalWallet;
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            
            using (WalletGroupForm optionsForm = new WalletGroupForm())
            {
                if (optionsForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the values entered in pop-up 
                    int walletAmount = Convert.ToInt32(optionsForm.walletAmount);
                    string groupName = optionsForm.groupName;

                    // Insert into database
                    string query = "INSERT INTO 'wallet_groups' (group_name) VALUES (@groupName)";
                    using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
                    {
                        using (SqliteCommand command = new SqliteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@groupName", groupName);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    int group_id = GetGroupId(groupName);
                    createBorderlessGroupBox(group_id, walletAmount, groupName);
                    walletMnemonics = WalletGenerator.WalletCreator.GenWallet(walletAmount);
                    WalletGenerator.WalletCreator walletCreator = new WalletGenerator.WalletCreator();
                    walletCreator.SaveWallets(walletMnemonics, group_id);
                    UpdateInfo();
                }
            }
        }

        private int GetWalletAmount(int group_id)
        {
            int walletAmount = 0;
            string query = $"SELECT COUNT(walletAddress) FROM wallets WHERE group_id = {group_id}";
            using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            walletAmount = reader.GetInt32(0);
                        }
                    }
                }
            }
            return walletAmount;
        }

        private int GetGroupId(string groupName)
        {
            int group_id = 0;
            string query = $"SELECT group_id FROM 'wallet_groups' WHERE group_name = @groupName";
            using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
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
            return group_id;
        }

        private async void delGroup(BorderlessGroupBox borderlessGroupBox)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (borderlessGroupBox.Tag == null)
                {
                    MessageBox.Show("Group ID is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string group_id = borderlessGroupBox.Tag?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(group_id))
                {
                    MessageBox.Show("Group ID is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                flpWalletGroup.Controls.Remove(borderlessGroupBox);

                // Recall the wallets
                List<String> selectedAddresses = new List<string>();
                string query = $"SELECT walletAddress FROM wallets WHERE group_id = {group_id}";
                using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                selectedAddresses.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                await DistributeWallets.Recall(selectedAddresses);

                // Delete the wallets of the group
                query = $"DELETE FROM wallets WHERE group_id = @group_id";
                using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                query = $"DELETE FROM 'wallet_groups' WHERE group_id = @group_id";
                using (SqliteConnection connection = new SqliteConnection(Functions.connectionString))
                {
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@group_id", group_id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }          
            }
            UpdateInfo();
        }

        private void createBorderlessGroupBox(int group_id, int walletAmount, string groupName)
        {
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
            viewButton.Location = new Point(20, 120);
            viewButton.ForeColor = Color.White;
            viewButton.BackColor = Color.FromArgb(78, 93, 148);
            viewButton.AutoSize = true;
            // On click, use FormWalletList to show the wallets of the group
            viewButton.Click += (s, ev) =>
            {
                FormWalletList formWalletList = new FormWalletList();
                formWalletList.Show();
            };

            borderlessGroupBox.Controls.Add(lbAmount);
            borderlessGroupBox.Controls.Add(lbName);
            borderlessGroupBox.Controls.Add(delButton);
            borderlessGroupBox.Controls.Add(viewButton);

            flpWalletGroup.Controls.Add(borderlessGroupBox);

        }
    }
}