using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DTO;

namespace DAL
{
    public class SupplyRep : IRepository<Supply>
    {
        List<Supply> SupplyList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        // private string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=TradingCompany;Integrated Security=True";

        public SupplyRep()
        {
            SupplyList = new List<Supply>();
            ReadFromDB();

        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "select SupplyId,Name,Description,Price,CategoryID, RowInsertTime, RowUpdateTime from Supply";
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int tmp_Id = (int)reader["SupplyId"];
                        string tmp_Name = (string)reader["Name"];
                        string tmp_Description = (string)reader["Description"];
                        float tmp_Price = float.Parse(Convert.ToString(reader["Price"]));
                        int tmp_CategoryId = (int)reader["CategoryID"];
                        DateTime tmp_RowInsertTime = (DateTime)reader["RowInsertTime"];
                        DateTime tmp_RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                        Supply tmp = new Supply(tmp_Name, tmp_Description, tmp_Price, tmp_CategoryId, tmp_RowInsertTime, tmp_RowUpdateTime, tmp_Id);
                        SupplyList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Supply tmpObj)
        {
            SupplyList.Add(tmpObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = $"INSERT INTO Supply(Name,Description,Price,CategoryID)VALUES('{tmpObj.Name}','{tmpObj.Description}',{tmpObj.Price},{tmpObj.CategoryId})";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            SupplyList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < SupplyList.Count(); i++)
            {
                if (SupplyList[i].Id == id)
                {
                    SupplyList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"DELETE FROM Supply WHERE SupplyId={id}";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }




        public List<Supply> GetEnteties()
        {
            return SupplyList;
        }

        public Supply GetObj(int index)
        {
            return SupplyList[index];
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
