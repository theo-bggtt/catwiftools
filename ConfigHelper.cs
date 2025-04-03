using DotNetEnv;
using Solnet.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools
{
    internal class ConfigHelper
    {
        public static (string ConnectionString, string HeliusUrl, string ApiKey, Cluster cluster) LoadEnvVariables()
        {
            Env.Load();
            string heliusApiKey = Env.GetString("API_KEY");
            string connectionString = "Data Source=catwiftools.db;";
            string clusterString = Env.GetString("CLUSTER");
            Cluster cluster = (Cluster)Enum.Parse(typeof(Cluster), clusterString, true);
            string heliusUrl = $"https://devnet.helius-rpc.com/?api-key={heliusApiKey}";
            return (connectionString, heliusUrl, heliusApiKey, cluster);
        }

        public static IRpcClient GetRpcClient()
        {
            Cluster cluster = LoadEnvVariables().cluster;
            return ClientFactory.GetClient(cluster);
        }
    }
}
