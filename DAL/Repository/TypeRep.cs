using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Repository
{
    public class TypeRep:IRepository<TypeDTO>
    {
        List<TypeDTO> TypeList;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TypeRep()
        {
            TypeList = new List<TypeDTO>();
            ReadFromDB();
        }
        public void RefreshList()
        {
            TypeList.Clear();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "select TypeId, Name, RowInsertTime, RowUpdateTime from Type";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int tmp_Id = (int)reader["TypeId"];
                        string tmp_Name = (string)reader["Name"];
                        DateTime tmp_RowInsertTime = (DateTime)reader["RowInsertTime"];
                        DateTime tmp_RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                        TypeDTO tmp = new TypeDTO(tmp_Name, tmp_RowInsertTime, tmp_RowUpdateTime, tmp_Id);
                        TypeList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(TypeDTO tmpObj)
        {
            TypeList.Add(tmpObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"INSERT INTO Type([Name]) VALUES({tmpObj.Name})";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            TypeList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < TypeList.Count(); i++)
            {
                if (i == id)
                {
                    TypeList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"DELETE FROM Type WHERE TypeId={id}";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();

            }

        }



        public List<TypeDTO> GetEnteties()
        {
            return TypeList;
        }

        public TypeDTO GetObj(int index)
        {
            return TypeList[index];
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
