using System.Data.SqlClient;
namespace Hellper.DataBase
{
    public static class DataBaseConnectionTester
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>True if connection are successfully. False if connection failed. </returns>
        public static bool TestConnectionStringOnCorrent(string connectionString)
        {
            connectionString = connectionString ?? "";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}