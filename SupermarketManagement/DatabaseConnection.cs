using System;
using Npgsql;

namespace SupermarketManagement.Utils
{
    public class DatabaseConnection
    {
        private static string connectionString = 
            "Host=db.fyhylcwdpzbdbemucewi.supabase.co;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=saobien54321!;" +
            "Database=postgres;" +
            "SslMode=Require;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}