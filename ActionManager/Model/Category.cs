using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager
{
   public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category(string Name,int id=0)
        {
            this.Name = Name;
            this.Id = id;
        }
        public string Write()
        {
            string str = $"ID:{Id}|Name:{Name}\n";
            return str;
        }
    }
}
