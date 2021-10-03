using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager
{
    public class Supply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public Supply(string Name,string Description,float price,int CategoryId,int id=0)
        {
            this.Id = id;
            this.Name = Name;
            this.Description = Description;
            this.Price = price;
            this.CategoryId = CategoryId;
        }
        public string Write()
        {
            string str = $"ID:{Id}|Name:{Name}|Description:{Description}|Category ID:{CategoryId}|Price:{Price}\n";
            return str;
        }
    }

}
