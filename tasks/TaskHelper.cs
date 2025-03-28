using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace catwiftools.tasks
{
    class TaskHelper
    {
        // ======================
        // Execute Task
        // ======================
        public static void ExecuteTask(int task_id)
        {
            string task_type = GetTaskType(task_id);
            switch (task_type)
            {
                case "Bump It":
                    TasksManager.ExecuteBumpItBuyTask(task_id);
                    break;
            }
        }

        // ====================
        // Insert and delete 
        // ====================
        public static void InsertTask(int groupId, string taskName, string taskType)
        {
            string query = "INSERT INTO 'tasks' (group_id, task_name, task_type) VALUES (@groupId, @taskName, @taskType)";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
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

        public static void saveParameters(string task_name, Dictionary<String, String> parameters)
        {
            int task_id = GetTaskId(task_name);
            string query = "INSERT INTO 'task_parameters' (task_id, parameter_name, parameter_value) VALUES (@taskId, @parameterName, @parameterValue)";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    foreach (KeyValuePair<string, string> parameter in parameters)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@taskId", task_id);
                        command.Parameters.AddWithValue("@parameterName", parameter.Key);
                        command.Parameters.AddWithValue("@parameterValue", parameter.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void deleteParameters(int task_id)
        {
            string query = $"DELETE FROM 'task_parameters' WHERE task_id = {task_id}";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertTaskGroup(string groupName, string walletGroup)
        {
            string query = "INSERT INTO 'task_groups' (group_name, walletGroup) VALUES (@groupName, @walletGroup)";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@groupName", groupName);
                    command.Parameters.AddWithValue("@walletGroup", walletGroup);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // ====================
        // Get Method (Tasks)
        // ====================
        public static string GetTaskType(int task_id)
        {
            string task_type = "";
            string query = $"SELECT task_type FROM 'tasks' WHERE task_id = {task_id}";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            task_type = reader.GetString(0);
                        }
                    }
                }
            }
            return task_type;
        }

        public static string GetTaskName(int task_id)
        {
            string task_name = "";
            string query = $"SELECT task_name FROM 'tasks' WHERE task_id = {task_id}";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            task_name = reader.GetString(0);
                        }
                    }
                }
            }
            return task_name;
        }

        public static int GetTaskId(string task_name)
        {
            int task_id = 0;
            string query = $"SELECT task_id FROM 'tasks' WHERE task_name = '{task_name}'";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            task_id = reader.GetInt32(0);
                        }
                    }
                }
            }
            return task_id;
        }

        public static Dictionary<string, string> GetTaskParameters(int task_id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string query = $"SELECT parameter_name, parameter_value FROM 'task_parameters' WHERE task_id = {task_id}";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            parameters.Add(reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
            return parameters;
        }

        public static List<int> GetTasksFromGroupId(int group_id)
        {
            List<int> task_ids = new List<int>();
            string query = $"SELECT task_id FROM 'tasks' WHERE group_id = '{group_id}'";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            task_ids.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            return task_ids;
        }

        // ========================
        // Get Method (group)
        // ========================
        public static int GetTaskGroupId(string groupName)
        {
            int groupId = 0;
            string query = $"SELECT group_id FROM 'task_groups' WHERE group_name = '{groupName}'";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            groupId = reader.GetInt32(0);
                        }
                    }
                }
            }
            return groupId;
        }

        // ====================
        // Count 
        // ====================
        public static int GetGroupCount()
        {
            int groupCount = 0;
            string query = "SELECT COUNT(*) FROM 'task_groups'";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    groupCount = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return groupCount;
        }

        public static int GetTaskCount()
        {
            int taskCount = 0;
            string query = "SELECT COUNT(*) FROM 'tasks'";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
            {
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    connection.Open();
                    taskCount = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return taskCount;
        }

        // ====================
        // Check if exists
        // ====================
        public static bool GroupNameExists(string groupName)
        {
            string query = $"SELECT group_name FROM 'task_groups' WHERE group_name = @groupName";
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
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
            using (SqliteConnection connection = new SqliteConnection(Functions.LoadEnvVariables().ConnectionString))
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
    }
}