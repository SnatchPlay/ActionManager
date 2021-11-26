using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        List<User> UserList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserRepository()
        {
            UserList = new List<User>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [UserId],[Login],[Email],[Password],[Salt],[RowInsertTime],[RowUpdateTime] FROM [User]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int t_id = (int)reader["UserId"];
                        string t_login = (string)reader["Login"];
                        string t_email= (string)reader["Email"];
                        byte[] t_password = (byte[])reader["Password"];
                        Guid t_salt = (Guid)reader["Salt"];
                        DateTime t_insert = (DateTime)reader["RowInsertTime"];
                        DateTime t_update = (DateTime)reader["RowUpdateTime"];

                        User tmp = new User(t_login,t_password,t_email,t_salt,t_insert,t_update,t_id);

                        UserList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(User tempObj)
        {
            UserList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string sqlsatrtdate = tempObj.RowInsertTime.ToString("yyyy-MM-dd");
                string sqlenddate = tempObj.RowUpdateTime.ToString("yyyy-MM-dd");
                string pass = BitConverter.ToString(tempObj.Password).Replace("-", "").ToLower();
                string pss = "0x" + pass;
                string CommandText = $"INSERT INTO [User] ([Login],[Email],[Password],[Salt],[RowInsertTime],[RowUpdateTime]) VALUES('{tempObj.Login}','{tempObj.Email}',{pss},'{tempObj.Salt}','{sqlsatrtdate}','{sqlenddate}')";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            UserList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            UserList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < UserList.Count(); i++)
            {
                if (i == id)
                {
                    UserList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"DELETE FROM User WHERE UserId={id}";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<User> GetEnteties()
        {
            return UserList;
        }

        public User GetObj(int index)
        {
            return UserList[index];
        }

        public void UpdateField(string Table, string Field, string NewValue, int id)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"UPDATE {Table} SET {Field} ='{NewValue}' WHERE Id={id} ";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
        
    }
}
