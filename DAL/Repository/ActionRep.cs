using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DTO;
using System.Configuration;


namespace DAL
{
    public class ActionRep : IRepository<ActionDTO>
    {
        List<ActionDTO> ActionList;
        protected string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public ActionRep()
        {
            ActionList = new List<ActionDTO>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "select Id, Name, [Start Time], [End Time], Discount, [TypeId], RowInsertTime, RowUpdateTime from Action";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int t_id = (int)reader["Id"];
                        string t_Name = (string)reader["Name"];
                        DateTime t_StartTime = (DateTime)reader["Start Time"];
                        DateTime t_EndTime = (DateTime)reader["End Time"];
                        float t_Discount = float.Parse(Convert.ToString(reader["Discount"]));
                        int t_Type_Id = (int)reader["TypeId"];
                        
                        DateTime t_RowInsertTime = (DateTime)reader["RowInsertTime"];
                        DateTime t_RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                        ActionDTO tmp = new ActionDTO(t_Name, t_Discount, t_Type_Id, t_StartTime, t_EndTime, t_RowInsertTime, t_RowUpdateTime, t_id);

                        ActionList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(ActionDTO tempObj)
        {
            ActionList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string sqlsatrtdate = tempObj.StartTime.ToString("yyyy-MM-dd");
                string sqlenddate = tempObj.EndTime.ToString("yyyy-MM-dd");
                string CommandText = $"INSERT INTO Action([Name],[Start Time],[End Time],[Discount],[TypeId]) VALUES('{tempObj.Name}'," + sqlsatrtdate + "," + sqlenddate + $", {tempObj.Discount}, {tempObj.Type_ID})";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            ActionList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < ActionList.Count(); i++)
            {
                if (i == id)
                {
                    ActionList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"DELETE FROM Action WHERE Id={id}";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<ActionDTO> GetEnteties()
        {
            return ActionList;
        }
        public void RefreshList()
        {
            ActionList.Clear ();
            ReadFromDB();
        }
        public ActionDTO GetObj(int index)
        {
            return ActionList[index];
        }

        public void UpdateField(string Table,string Field,string NewValue,int id)
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
