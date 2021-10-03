using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager.Repository
{
    public interface ISupplyRep
    {
        List<Supply> GetGoods();
        void AddObj(Supply tempObj);
        void DeleteObject(int id);
        void ReadFromDB();
        Supply GetObj(int id);
    }
}
