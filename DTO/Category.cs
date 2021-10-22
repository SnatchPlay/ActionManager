using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Category(string Name, DateTime RowInsertTime, DateTime RowUpdateTime, int id = 0)
        {
            this.Name = Name;
            this.Id = id;
            this.RowInsertTime = RowInsertTime;
            this.RowUpdateTime = RowUpdateTime;
        }
        public string Write()
        {
            string str = $"ID:{Id}|Name:{Name}\n";
            return str;
        }
    }
}
