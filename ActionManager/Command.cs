using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager.Repository
{
    public class Command
    {
        public IActionRep actionRep=new ActionRep();
        public ICategoryRep categoryRep=new CategoryRep();
        public ISupplyRep supplyRep=new SupplyRep();
        //--------------------------------------------------------------------------------------------------------
        public void AddAction()
        {
            Console.WriteLine("Type name of action:");
            string name=Console.ReadLine();
            Console.WriteLine("Type size of discount :");
            float discount = float.Parse(Console.ReadLine());
            Console.WriteLine("Type id of category:");
            int CategoryId =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type id of supply:");
            int SupplyId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type start time:");
            DateTime starttime =Convert.ToDateTime( Console.ReadLine());
            Console.WriteLine("Type end time:");
            DateTime endtime = Convert.ToDateTime(Console.ReadLine());
            Action tmp = new Action(name, discount, CategoryId, SupplyId, starttime, endtime);
            actionRep.AddObj(tmp);
        }
        public void AddCategory()
        {
            Console.WriteLine("Type name of category:");
            string name = Console.ReadLine();
            Category tmp = new Category(name);
            categoryRep.AddObj(tmp);
        }
        public void AddGoods()
        {
            Console.WriteLine("Type name of goods:");
            string name = Console.ReadLine();
            Console.WriteLine("Type cost of goods :");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Type id of category:");
            int CategoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type description:");
            string descr = Console.ReadLine();
            Supply tmp;
            tmp = new Supply(name, descr, price, CategoryId);
            supplyRep.AddObj(tmp);
        }
        //-----------------------------------------------------------------------------------------------------------------------
        public void DeleteGoods()
        {
            Console.WriteLine("Type id of goods:");
            int t = Convert.ToInt32(Console.ReadLine());
            supplyRep.DeleteObject(t);
        }
        public void DeleteAction()
        {
            Console.WriteLine("Type id of action:");
            int t = Convert.ToInt32(Console.ReadLine());
            actionRep.DeleteObject(t);
        }
        public void DeleteCategory()
        {
            Console.WriteLine("Type id of category:");
            int t = Convert.ToInt32(Console.ReadLine());
            categoryRep.DeleteObject(t);
        }


        //-------------------------------------------------------------------------------------------
        public void AllGoods()
        {
            for(int i = 0; i < supplyRep.GetGoods().Count(); i++)
            {
                Console.WriteLine(supplyRep.GetGoods()[i].Write());
            }
        }
        public void AllActions()
        {
            for (int i = 0; i < actionRep.GetActions().Count(); i++)
            {
                Console.WriteLine(actionRep.GetActions()[i].Write());
            }
        }
        public void AllCategories()
        {
            for (int i = 0; i < categoryRep.GetCategories().Count(); i++)
            {
                Console.WriteLine(categoryRep.GetCategories()[i].Write());
            }
        }
        //--------------------------------------------------------------------------------------------------
        public void ChangeNameAction()
        {
            Console.WriteLine("Type id:");
            int id= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Typen new name:");
            string name = Console.ReadLine();
            actionRep.ChangeName(id, name);
        }

    }
}
