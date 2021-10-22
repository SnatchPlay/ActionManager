using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DTO;


namespace DAL
{
    public class CategoryRep : IRepository<Category>
    {
        List<Category> CategoryList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //private string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=TradingCompany;Integrated Security=True";

        public CategoryRep()
        {
            CategoryList = new List<Category>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "select CategoryId, Name, RowInsertTime, RowUpdateTime from Category";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int tmp_Id = (int)reader["CategoryId"];
                        string tmp_Name = (string)reader["Name"];
                        DateTime tmp_RowInsertTime = (DateTime)reader["RowInsertTime"];
                        DateTime tmp_RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                        Category tmp = new Category(tmp_Name, tmp_RowInsertTime, tmp_RowUpdateTime, tmp_Id);
                        CategoryList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Category tmpObj)
        {
            CategoryList.Add(tmpObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"INSERT INTO Category([Name]) VALUES({tmpObj.Name})";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            CategoryList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < CategoryList.Count(); i++)
            {
                if (i == id)
                {
                    CategoryList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"DELETE FROM Category WHERE CategoryId={id}";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();

            }

        }



        public List<Category> GetEnteties()
        {
            return CategoryList;
        }

        public Category GetObj(int index)
        {
            return CategoryList[index];
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
