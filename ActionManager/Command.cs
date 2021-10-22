using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Action = DTO.Action;

namespace ActionManager.Repository
{
    public class Command
    {
        public IRepository<Action> actionRep=new ActionRep();
        public IRepository<Category> categoryRep =new CategoryRep();
        public IRepository<Supply> supplyRep =new SupplyRep();
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
            DateTime rowinsert = DateTime.UtcNow;
            DateTime rowupdate = DateTime.UtcNow;
            Action tmp = new Action(name, discount, CategoryId, SupplyId, starttime, endtime,rowinsert,rowupdate);
            actionRep.AddObj(tmp);
        }
        public void AddCategory()
        {
            Console.WriteLine("Type name of category:");
            string name = Console.ReadLine();
            DateTime rowinsert = DateTime.UtcNow;
            DateTime rowupdate = DateTime.UtcNow;
            Category tmp = new Category(name,rowinsert, rowupdate);
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
            DateTime rowinsert = DateTime.UtcNow;
            DateTime rowupdate = DateTime.UtcNow;
            tmp = new Supply(name, descr, price, CategoryId, rowinsert, rowupdate);
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
            for(int i = 0; i < supplyRep.GetEnteties().Count(); i++)
            {
                Console.WriteLine(supplyRep.GetEnteties()[i].Write());
            }
        }
        public void AllActions()
        {
            for (int i = 0; i < actionRep.GetEnteties().Count(); i++)
            {
                Console.WriteLine(actionRep.GetEnteties()[i].Write());
            }
        }
        public void AllCategories()
        {
            for (int i = 0; i < categoryRep.GetEnteties().Count(); i++)
            {
                Console.WriteLine(categoryRep.GetEnteties()[i].Write());
            }
        }
        //--------------------------------------------------------------------------------------------------
        public void ChangeNameAction()
        {
            Console.WriteLine("Type id:");
            int id= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Typen new name:");
            string name = Console.ReadLine();
            for (int i = 0; i < actionRep.GetEnteties().Count; i++)
                {
                    if (actionRep.GetEnteties()[i].Id == id)
                    {
                    actionRep.GetEnteties()[i].Name = name;
                    }
                }
            //string CommandText = $"UPDATE Action SET Name ='{name}' WHERE Id={id} ";
            actionRep.UpdateField("Action","Name",name,id);
        }
        public void ChangeCategoryName()
        {
            Console.WriteLine("Type id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Typen new name:");
            string name = Console.ReadLine();
            for (int i = 0; i < categoryRep.GetEnteties().Count; i++)
            {
                if (categoryRep.GetEnteties()[i].Id == id)
                {
                    categoryRep.GetEnteties()[i].Name = name;
                }
            }
            //string CommandText = $"UPDATE Category SET Name ='{name}' WHERE Id={id} ";
            categoryRep.UpdateField("Category", "Name", name, id) ;
        }
        public void ChangeSupplyName()
        {
            Console.WriteLine("Type id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Typen new name:");
            string name = Console.ReadLine();
            for (int i = 0; i < supplyRep.GetEnteties().Count; i++)
            {
                if (supplyRep.GetEnteties()[i].Id == id)
                {
                    supplyRep.GetEnteties()[i].Name = name;
                }
            }
            //string CommandText = $"UPDATE Supply SET Name ='{name}' WHERE Id={id} ";
            supplyRep.UpdateField("Supply", "Name", name, id);
        }
    }
}
