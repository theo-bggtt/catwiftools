using catwiftools.wallet;
using Microsoft.Data.Sqlite;

namespace catwiftools.tasks
{
    public partial class formTaskCreation : Form
    {
        public string task_name, task_type, buy_amount, minimum_buy, maximum_buy, delay, comments, wallet, cycle;
        public Dictionary<string, string> parameters = [];
        private Panel active_panel;
        public bool isEditMode = false;

        public formTaskCreation(int? task)
        {

            InitializeComponent();
            if (task != null)
            {
                int task_id = task ?? 0;
                task_type = TaskHelper.GetTaskType(task_id);
                var parameters = TaskHelper.GetTaskParameters(task_id);
                // Set it all up
                tbxTaskName.Text = TaskHelper.GetTaskName(task_id);
                cbxTaskType.SelectedItem = task_type;
                tbxTaskName.Enabled = false;
                cbxTaskType.Enabled = false;
                tbxTaskName.Enabled = false;
                updateParameters();
            }
        }

        private void formTaskCreation_Load(object sender, EventArgs e)
        {
            cbxWallet.Items.AddRange(GetAllWallets());
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (TaskHelper.TaskNameExists(tbxTaskName.Text) && (isEditMode == false))
            {
                MessageBox.Show("This Task name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                updateParameters();
                isEditMode = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void cbxTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameters.Clear();

            task_type = cbxTaskType.SelectedItem.ToString();

            List<Panel> parameters_panel = [pnlBuyParameters, pnlSellAll, pnlSingleSell, pnlCommentBot, pnlBumpIt];
            foreach (Panel panel in parameters_panel)
            {
                panel.Visible = false;
            }
            switch (task_type)
            {
                case "Micro-Buy":
                    pnlBuyParameters.Visible = true;
                    active_panel = pnlBuyParameters;
                    break;
                case "Generate Volume":
                    pnlBuyParameters.Visible = true;
                    active_panel = pnlBuyParameters;
                    break;
                case "Sell All":
                    pnlSellAll.Visible = true;
                    active_panel = pnlSellAll;
                    break;
                case "Single Sell":
                    pnlSingleSell.Visible = true;
                    active_panel = pnlSingleSell;
                    break;
                case "Comment Bot":
                    pnlCommentBot.Visible = true;
                    active_panel = pnlCommentBot;
                    break;
                case "Bump It":
                    pnlBumpIt.Visible = true;
                    active_panel = pnlBumpIt;
                    break;
            }
            checkRequisit();
        }

        private void tbxTaskName_TextChanged(object sender, EventArgs e)
        {
            task_name = tbxTaskName.Text;
            checkRequisit();
        }

        private void tbxDelay_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                delay = textBox.Text;
                checkRequisit();
            }
        }

        private void tbxMinimumBuy_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                minimum_buy = textBox.Text;
                checkRequisit();
            }
        }

        private void tbxMaximumBuy_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                maximum_buy = textBox.Text;
                checkRequisit();
            }
        }
        private void cbxWallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            wallet = cbxWallet.Text;
            checkRequisit();
        }

        private void tbxCycle_TextChanged(object sender, EventArgs e)
        {
            cycle = tbxCycle.Text;
            checkRequisit();
        }

        private void checkRequisit()
        {
            if (active_panel == pnlBuyParameters)
            {
                minimum_buy = tbxMinimumBuy.Text;
                delay = textBox4.Text;
                maximum_buy = tbxMaximumBuy.Text;
                if (string.IsNullOrEmpty(minimum_buy) || string.IsNullOrEmpty(maximum_buy) || string.IsNullOrEmpty(delay))
                {
                    btnCreate.Enabled = false;
                }
                else
                {
                    btnCreate.Enabled = true;
                }
            }
            else if (active_panel == pnlSellAll)
            {
                delay = textBox5.Text;
                cycle = tbxCycle.Text;
                if (string.IsNullOrEmpty(delay) || string.IsNullOrEmpty(cycle))
                {
                    btnCreate.Enabled = false;
                }
                else
                {
                    btnCreate.Enabled = true;
                }
            }
            else if (active_panel == pnlSingleSell)
            {
                wallet = cbxWallet.Text;
                // Add wallet
                if (string.IsNullOrEmpty(wallet))
                {
                    btnCreate.Enabled = false;
                }
                else
                {
                    btnCreate.Enabled = true;
                }
            }
            else if (active_panel == pnlCommentBot)
            {
                comments = tbxComments.Text;
                // Add comments
                if (string.IsNullOrEmpty(comments))
                {
                    btnCreate.Enabled = false;
                }
                else
                {
                    btnCreate.Enabled = true;
                }
            }
            else if (active_panel == pnlBumpIt)
            {
                buy_amount = textBox3.Text;
                delay = textBox2.Text;
                // Add wallet
                if (string.IsNullOrEmpty(buy_amount) || string.IsNullOrEmpty(delay))
                {
                    btnCreate.Enabled = false;
                }
                else
                {
                    btnCreate.Enabled = true;
                }
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void updateParameters()
        {
            if (active_panel == pnlBuyParameters)
            {
                if (!string.IsNullOrEmpty(minimum_buy))
                {
                    parameters.Add("Minimum Buy", minimum_buy);
                }
                if (!string.IsNullOrEmpty(maximum_buy))
                {
                    parameters.Add("Maximum Buy", maximum_buy);
                }
                if (!string.IsNullOrEmpty(delay))
                {
                    parameters.Add("Delay", delay);
                }
            }
            else if (active_panel == pnlSellAll)
            {
                if (!string.IsNullOrEmpty(delay))
                {
                    parameters.Add("Delay", delay);

                }
                if (!string.IsNullOrEmpty(cycle))
                {
                    parameters.Add("Cycle", cycle);
                }
            }
            else if (active_panel == pnlSingleSell)
            {
                if (!string.IsNullOrEmpty(wallet))
                {
                    parameters.Add("Wallets", wallet);
                }

            }
            else if (active_panel == pnlCommentBot)
            {
                if (!string.IsNullOrEmpty(comments))
                {
                    parameters.Add("Comments", comments);
                }
                if (!string.IsNullOrEmpty(comments))
                {
                    parameters.Add("Comments", comments);
                }
            }
            else if (active_panel == pnlBumpIt)
            {
                if (!string.IsNullOrEmpty(buy_amount))
                {
                    parameters.Add("Buy Amount", buy_amount);
                }
                if (!string.IsNullOrEmpty(delay))
                {
                    parameters.Add("Delay", delay);
                }
                if (!string.IsNullOrEmpty(wallet))
                {
                    parameters.Add("Wallet", wallet);
                }
            }
        }

        private static string[] GetAllWallets()
        {
            string fundwallet = walletHelper.CheckForFundWallet();

            List<string> wallets = new List<string>();
            string query = "SELECT walletAddress FROM 'wallets' WHERE walletAddress != @fundwallet";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fundwallet", fundwallet);
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wallets.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return wallets.ToArray();
        }

        public void SetTaskType(string taskType)
        {
            cbxTaskType.SelectedItem = taskType;
            if (isEditMode)
            {
                cbxTaskType.Enabled = false;
            }
            else
            {
                cbxTaskType.Enabled = true;
            }
        }

        public void SetTaskName(string taskName)
        {
            tbxTaskName.Text = taskName;
        }


        public void SetTaskParameters(Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                switch (parameter.Key)
                {
                    case "Minimum Buy":
                        tbxMinimumBuy.Text = parameter.Value;
                        break;
                    case "Maximum Buy":
                        tbxMaximumBuy.Text = parameter.Value;
                        break;
                    case "Delay":
                        textBox4.Text = parameter.Value;
                        break;
                    case "Cycle":
                        tbxCycle.Text = parameter.Value;
                        break;
                    case "Wallets":
                        cbxWallet.Text = parameter.Value;
                        break;
                    case "Comments":
                        tbxComments.Text = parameter.Value;
                        break;
                    case "Buy Amount":
                        textBox3.Text = parameter.Value;
                        break;
                }
            }
        }
    }
}
