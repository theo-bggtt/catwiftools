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
using static catwiftools.CatWifTools;

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
                    AppState.WriteConsole($"Wallet Group '{groupName}' with {walletAmount} wallets created!");
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

                await walletHelper.Recall(selectedAddresses);

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
                AppState.WriteConsole($"Group {group_id} deleted!");
            }
            UpdateInfo();
        }

        private void createBorderlessGroupBox(int group_id, int walletAmount, string groupName)
        {
            // Create a new GroupbBox with 2 labels (one for walletAmount and one with groupName) and add that groupbox to flpWalletGroup
            BorderlessGroupBox borderlessGroupBox = new BorderlessGroupBox();
            // 
            // borderlessGroupBox
            // 
            borderlessGroupBox.BackColor = Color.FromArgb(40, 40, 40);
            borderlessGroupBox.FlatStyle = FlatStyle.Flat;
            borderlessGroupBox.ForeColor = Color.White;
            borderlessGroupBox.Location = new Point(29, 29);
            borderlessGroupBox.Margin = new Padding(29);
            borderlessGroupBox.Name = "borderlessGroupBox";
            borderlessGroupBox.Size = new Size(260, 143);
            borderlessGroupBox.TabIndex = 0;
            borderlessGroupBox.TabStop = false;
            borderlessGroupBox.Tag = group_id;
            // 
            // btnWithdraw
            // 
            Button btnWithdraw = new Button();
            btnWithdraw.AutoSize = true;
            btnWithdraw.BackColor = Color.Transparent;
            btnWithdraw.FlatAppearance.BorderColor = Color.FromArgb(78, 93, 148);
            btnWithdraw.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWithdraw.FlatAppearance.BorderSize = 0;
            btnWithdraw.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            btnWithdraw.FlatStyle = FlatStyle.Flat;
            btnWithdraw.ForeColor = Color.White;
            btnWithdraw.Image = Properties.Resources.send;
            btnWithdraw.ImageAlign = ContentAlignment.MiddleRight;
            btnWithdraw.Location = new Point(140, 88);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(110, 45);
            btnWithdraw.TabIndex = 5;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.TextAlign = ContentAlignment.MiddleLeft;
            btnWithdraw.UseVisualStyleBackColor = false;
            btnWithdraw.Click += (s, ev) =>
            
            {
                group_id = Convert.ToInt32(borderlessGroupBox.Tag);
                // Ask the user to confirm with a message box
                DialogResult result = MessageBox.Show("Are you sure you want to withdraw from this group?", "Withdraw from Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    walletHelper.Recall(walletHelper.GetWallets(group_id));
                }
            }
            ;
            // 
            // btnDeposit
            // 
            Button btnDeposit = new Button();
            btnDeposit.AutoSize = true;
            btnDeposit.BackColor = Color.Transparent;
            btnDeposit.FlatAppearance.BorderColor = Color.FromArgb(78, 93, 148);
            btnDeposit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeposit.FlatAppearance.BorderSize = 0;
            btnDeposit.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 25);
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.ForeColor = Color.White;
            btnDeposit.Image = Properties.Resources.receive;
            btnDeposit.ImageAlign = ContentAlignment.MiddleRight;
            btnDeposit.Location = new Point(10, 88);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(110, 45);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Deposit";
            btnDeposit.TextAlign = ContentAlignment.MiddleLeft;
            btnDeposit.UseVisualStyleBackColor = false;
            btnDeposit.Click += (s, ev) =>
            {
                group_id = Convert.ToInt32(borderlessGroupBox.Tag);
                SendToGroup sendToGroup = new SendToGroup(group_id);
                sendToGroup.Show();
            };

            // 
            // lbAmount
            // 
            Label lbAmount = new Label();
            lbAmount.AutoSize = true;
            lbAmount.Location = new Point(10, 45);
            lbAmount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbAmount.Name = "lbAmount";
            lbAmount.Size = new Size(93, 15);
            lbAmount.TabIndex = 0;
            lbAmount.Text = walletAmount + " wallets";
            // 
            // lbName
            // 
            Label lbName = new Label();
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbName.Location = new Point(10, 10);
            lbName.Name = "lbName";
            lbName.Size = new Size(107, 21);
            lbName.TabIndex = 1;
            lbName.Text = groupName;
            // 
            // delButton
            // 
            Button delButton = new Button();
            delButton.AutoSize = true;
            delButton.BackColor = Color.DarkRed;
            delButton.FlatAppearance.BorderSize = 0;
            delButton.FlatStyle = FlatStyle.Flat;
            delButton.ForeColor = Color.White;
            delButton.Image = Properties.Resources.Close;
            delButton.Location = new Point(220, 10);
            delButton.ImageAlign = ContentAlignment.MiddleCenter;
            delButton.Name = "delButton";
            delButton.Size = new Size(30, 30);
            delButton.TabIndex = 2;
            delButton.UseVisualStyleBackColor = false;
            delButton.Click += (sender, e) => delGroup(borderlessGroupBox);
            // 
            // viewButton
            // 
            Button viewButton = new Button();
            viewButton.AutoSize = true;
            viewButton.BackColor = Color.FromArgb(78, 93, 148);
            viewButton.FlatAppearance.BorderSize = 0;
            viewButton.FlatStyle = FlatStyle.Flat;
            viewButton.ForeColor = Color.White;
            viewButton.Image = Properties.Resources.eye1;
            viewButton.Location = new Point(173, 10);
            viewButton.Name = "viewButton";
            viewButton.Size = new Size(30, 30);
            viewButton.TabIndex = 3;
            viewButton.TextAlign = ContentAlignment.MiddleLeft;
            viewButton.UseVisualStyleBackColor = false;
            viewButton.Click += (s, ev) =>
            {
                group_id = Convert.ToInt32(borderlessGroupBox.Tag);
                FormWalletList formWalletList = new FormWalletList(group_id);
                formWalletList.Show();
            };

            borderlessGroupBox.Controls.Add(lbAmount);
            borderlessGroupBox.Controls.Add(lbName);
            borderlessGroupBox.Controls.Add(delButton);
            borderlessGroupBox.Controls.Add(viewButton);
            borderlessGroupBox.Controls.Add(btnDeposit);
            borderlessGroupBox.Controls.Add(btnWithdraw);
            

            flpWalletGroup.Controls.Add(borderlessGroupBox);

        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            AppState.WriteConsole("Wallet Data updated!");
            AppState.RecentAction("Wallet Data updated!");
        }

        public void DisableCreation()
        {
            btnCreateGroup.Enabled = false;
        }
    }
}