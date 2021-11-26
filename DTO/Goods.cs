using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public int ActionId { get; set; }
        public Goods(string Name, string Description, float price, int CategoryId, DateTime RowInsertTime, DateTime RowUpdateTime,int ActionId, int id = 0)
        {
            this.Id = id;
            this.Name = Name;
            this.Description = Description;
            this.Price = price;
            this.CategoryId = CategoryId;
            this.RowInsertTime = RowInsertTime;
            this.RowUpdateTime = RowUpdateTime;
            this.ActionId = ActionId;
        }
        public string Write()
        {
            string str = $"ID:{Id}|Name:{Name}|Description:{Description}|Category ID:{CategoryId}|Price:{Price}|Action:{ActionId}\n";
            return str;
        }
    }
}
