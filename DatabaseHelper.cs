using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools
{
    class DatabaseHelper
    {
        private static readonly (string ConnectionString, string HeliusUrl, string ApiKey) envVariables = Functions.LoadEnvVariables();
        private static string connectionString = envVariables.ConnectionString;

        public static bool GroupNameExists(string groupName)
        {
            string query = $"SELECT group_name FROM 'task_groups' WHERE group_name = @groupName";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@groupName", groupName);
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public static bool TaskNameExists(string taskName)
        {
            string query = $"SELECT task_name FROM 'tasks' WHERE task_name = @taskName";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taskName", taskName);
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public static void InsertTaskGroup(string groupName)
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

        public static void InsertTask(int groupId, string taskName, string taskType)
        {
            string query = "INSERT INTO 'tasks' (group_id, task_name, task_type) VALUES (@groupId, @taskName, @taskType)";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@groupId", groupId);
                    command.Parameters.AddWithValue("@taskName", taskName);
                    command.Parameters.AddWithValue("@taskType", taskType);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
