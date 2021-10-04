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
            while (true)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("Options:");
                Console.WriteLine("1.Show All Actions");
                Console.WriteLine("2.Show All Goods");
                Console.WriteLine("3.Add New Goods");
                Console.WriteLine("4.Add New Action");
                Console.WriteLine("5.Delete Goods");
                Console.WriteLine("6.Change Action Name");
                int input =Convert.ToInt32( Console.ReadLine());
                if (input == 1)
                {
                    com.AllActions();
                }
                else if (input == 2)
                {
                    com.AllGoods();
                }
                else if (input == 3)
                {
                    com.AddGoods();
                }
                else if (input == 4)
                {
                    com.AddAction();
                }
                else if (input == 5)
                {
                    com.DeleteGoods();
                }
                else if (input == 6)
                {
                    com.ChangeNameAction();
                }
                else
                {
                    break;
                }
            }
            
            //com.AllActions();
            //com.AllGoods();
            //com.ChangeNameAction();
            //com.AddAction();
           // com.AllActions();
           //com.AddGoods();
            //com.AddGoods();
            //com.AllGoods();
            //com.DeleteGoods();
           // com.AllGoods();
            //Console.ReadLine();
        }
        
    }
}
