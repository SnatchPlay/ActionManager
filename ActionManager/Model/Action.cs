using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Discount { get; set; }
        public int Category_ID { get; set; }
        public int Supply_ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Action(string Name,float Discount,int Category_Id,int Supply_Id,DateTime StartTime,DateTime EndTime, int id = 0)
        {
            this.Name = Name;
            this.Discount = Discount;
            this.Category_ID = Category_Id;
            this.Supply_ID = Supply_Id;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Id = id;
        }
        public string Write()
        {
            string str = $"ID:{Id}|Name:{Name}|Discount:{Discount}|Category ID:{Category_ID}|Supply ID:{Supply_ID}|Start Time:{StartTime}|End Time:{EndTime}\n";
            return str;
        }
    }
}
