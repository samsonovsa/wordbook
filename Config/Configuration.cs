using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WordBook.Config
{
    public class Configuration : IConfiguration
    {
        public string GetConnectionString(string name)
        {
            string resultConnectionString=String.Empty;
            string sqlExpression = $"Select ConnectionString from Connections Where Name= '{name}'";
            string localDbConnectionString;
            try
            {
                localDbConnectionString = ConfigurationManager.
                    ConnectionStrings["localDbConnection"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error config read: {ex.Message}",ex);
            }


            using (var connection = new SqlConnection(localDbConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        reader.Read();

                        resultConnectionString = reader.GetString(0);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error DB read: {ex.Message}", ex);
                }
            }
            return resultConnectionString;
        }
    }
}