using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoleDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public RoleDTO(string name,DateTime rowinserttime,DateTime rowupdtime, int id = 0) { this.name = name;
            this.RowInsertTime=rowinserttime; this.RowUpdateTime=rowupdtime; this.id = id; }
    }
}
