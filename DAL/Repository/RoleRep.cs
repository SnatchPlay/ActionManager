using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RoleRep:IRepository<RoleDTO>
    {
        List<RoleDTO> RoleList;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public RoleRep()
        {
            RoleList = new List<RoleDTO>();
            ReadFromDB();
        }
        public void RefreshList()
        {
            RoleList.Clear();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "select RoleId, Name, RowInsertTime, RowUpdateTime from Role";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int tmp_Id = (int)reader["RoleId"];
                        string tmp_Name = (string)reader["Name"];
                        DateTime tmp_RowInsertTime = (DateTime)reader["RowInsertTime"];
                        DateTime tmp_RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                        RoleDTO tmp = new RoleDTO(tmp_Name, tmp_RowInsertTime, tmp_RowUpdateTime, tmp_Id);
                        RoleList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(RoleDTO tmpObj)
        {
            RoleList.Add(tmpObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"INSERT INTO Type([Name]) VALUES({tmpObj.name})";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            RoleList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < RoleList.Count(); i++)
            {
                if (i == id)
                {
                    RoleList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"DELETE FROM Type WHERE RoleId={id}";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();

            }

        }



        public List<RoleDTO> GetEnteties()
        {
            return RoleList;
        }

        public RoleDTO GetObj(int index)
        {
            return RoleList[index];
        }
        public void UpdateField(string Table, string Field, string NewValue, int id)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                //string CommandText = $"UPDATE Action SET Name ='{name}' WHERE Id={id} ";
                string CommandText = $"UPDATE {Table} SET {Field} ='{NewValue}' WHERE Id={id} ";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }
    }
}
