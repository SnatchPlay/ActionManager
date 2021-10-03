using ActionManager.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager
{

    public class ActionRep : IActionRep
    {
        List<Action> ActionList;
        protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=TradingCompany;Integrated Security=True";

        public ActionRep()
        {
            ActionList = new List<Action>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "select Id, Name, [Start Time], [End Time], Discount, [Category ID], [Supply ID] from Action";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {

                        int t_id = (int)reader["Id"];
                        string t_Name = (string)reader["Name"];
                        DateTime t_StartTime = (DateTime)reader["Start Time"];
                        DateTime t_EndTime = (DateTime)reader["End Time"];
                        float t_Discount = float.Parse(Convert.ToString(reader["Discount"]));
                        int t_Category_ID = (int)reader["Category ID"];
                        int t_Supply_ID = (int)reader["Supply ID"];
                        Action tmp = new Action(t_Name, t_Discount, t_Category_ID, t_Supply_ID, t_StartTime, t_EndTime, t_id);

                        ActionList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Action tempObj)
        {
            ActionList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"INSERT INTO Action([Name],[Start Time],[End Time],[Discount],[Category ID],[Supply ID]) VALUES('{tempObj.Name}', {tempObj.StartTime}, {tempObj.EndTime}, {tempObj.Discount}, {tempObj.Category_ID}, {tempObj.Supply_ID})";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
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



        public List<Action> GetActions()
        {
            return ActionList;
        }

        public Action GetObj(int index)
        {
            return ActionList[index];
        }

        public void ChangeName(int id, string name)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = $"UPDATE Action SET Name ='{name}' WHERE Id={id} ";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.ExecuteNonQuery();
                connectionSql.Close();

            }
            for(int i = 0; i < ActionList.Count; i++)
            {
                if (ActionList[i].Id == id)
                {
                    ActionList[i].Name = name;
                }
            }


        }
    }
}
