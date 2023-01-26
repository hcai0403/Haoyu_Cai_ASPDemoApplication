using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL_Layer.Model;

namespace DAL_Layer
{
    public class DAL_Layer_Class
    {
        String connString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=ProductDB;Integrated Security=true;";
        public DataSet GetUser()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("select * from [UserDB].[dbo].[User]", connection);
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();

                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Users - " + ex.Message.ToString());
            }
        }


        public int AddUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {

                    int result;

                    connection.Open();
                    var sql = "INSERT INTO [UserDB].[dbo].[User](Name, Email, Password) VALUES(@n, @e, @p)";
                    using (var cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@n", user.userName);
                        cmd.Parameters.AddWithValue("@e", user.emailAddress);
                        cmd.Parameters.AddWithValue("@p", user.password);
                        result =cmd.ExecuteNonQuery();
                    }


                    connection.Close();
                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while Adding User - " + ex.Message.ToString());
            }
        }
    }
}
