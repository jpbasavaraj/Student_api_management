using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Student_api.Database
{
    public class DatabaseHelper
    {

        private static string connectionstring = "Data Source=DESKTOP-OBDFPB9\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        private static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            return conn;
        }


        public static SqlDataReader ExecuteSpQuery(string sp, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sp, GetConnection());
            cmd.Parameters.AddRange(parameters);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 200000;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int  ExecuteSpNonQuery(string sp , params SqlParameter[] parameters)
        {
            int rowsAffected;

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddRange(parameters);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 200000;
                rowsAffected = cmd.ExecuteNonQuery();

            }
            return rowsAffected;
        }

        public static SqlDataReader ExecuteTextquery(string query,params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query,GetConnection());
            cmd.Parameters.AddRange(parameters);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

        }

        public static SqlDataReader ExecuteTextquery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}
