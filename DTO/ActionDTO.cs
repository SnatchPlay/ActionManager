using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ActionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Discount { get; set; }
        public int Type_ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public ActionDTO(string Name, float Discount, int Category_Id, DateTime StartTime, DateTime EndTime, DateTime RowInsertTime, DateTime RowUpdateTime, int id = 0)
        {
            this.Name = Name;
            this.Discount = Discount;
            this.Type_ID = Category_Id;

            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Id = id;
            this.RowInsertTime = RowInsertTime;
            this.RowUpdateTime = RowUpdateTime;
        }
        public string Write()
        {
            string str = $"ID:{Id}|Name:{Name}|Discount:{Discount}|Category ID:{Type_ID}|Start Time:{StartTime}|End Time:{EndTime}\n";
            return str;
        }
    }
}
