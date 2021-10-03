using ActionManager.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager
{
    public class CategoryRep : ICategoryRep
    {
        List<Category> CategoryList;
        private string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=TradingCompany;Integrated Security=True";

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
                    comm.CommandText = "select CategoryId, Name from Category";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        int tmp_Id = (int)reader["CategoryId"];
                        string tmp_Name = (string)reader["Name"];
                        Category tmp = new Category(tmp_Name,tmp_Id);
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



        public List<Category> GetCategories()
        {
            return CategoryList;
        }

        public Category GetObj(int index)
        {
            return CategoryList[index];
        }
    }
}
