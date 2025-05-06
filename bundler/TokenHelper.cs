using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools.bundler
{
    internal class TokenHelper
    {

        public static List<string> GetTokenAddresses()
        {
            List<string> tokenAddresses = new List<string>();
            string query = "SELECT address FROM token";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tokenAddresses.Add(reader.GetString(0));
                    }
                }
            }
            return tokenAddresses;
        }

        public static Dictionary<string, string> GetTokenInfo(string tokeAddress)
        {
            Dictionary<string, string> token = new Dictionary<string, string>();
            string query = $"SELECT * FROM tokens WHERE address = {tokeAddress}";
            using (SqliteConnection connection = new SqliteConnection(ConfigHelper.LoadEnvVariables().ConnectionString))
            using (SqliteCommand command = new SqliteCommand(query, connection))
            {
                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        token["address"] = reader.GetString(0);
                        token["name"] = reader.GetString(1);
                        token["symbol"] = reader.GetString(2);
                        token["description"] = reader.GetString(3);
                        token["imageUrl"] = reader.GetString(4);
                        token["twitterUrl"] = reader.GetString(5);
                        token["telegramUrl"] = reader.GetString(6);
                    }
                }
            }
            return token;
        }

        public static Panel CreateTokenPanel(string address, string name, string symbol, string description, string imageUrl, string twitterUrl, string telegramUrl)
        {
            Panel tokenPanel = new Panel
            {
                Size = new Size(200, 200),
                BackColor = Color.FromArgb(37, 37, 53),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };
            Label nameLabel = new Label
            {
                Text = name,
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tokenPanel.Controls.Add(nameLabel);

            return tokenPanel;
        }
    }
}
