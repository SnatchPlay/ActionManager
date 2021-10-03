using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ActionManager.Repository;

namespace ActionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Command com = new Command();
            com.AllActions();
            //com.AllGoods();
            com.ChangeNameAction();
            //com.AddAction();
            com.AllActions();
           //com.AddGoods();
            //com.AddGoods();
            //com.AllGoods();
            //com.DeleteGoods();
           // com.AllGoods();
            Console.ReadLine();
        }
        
    }
}
