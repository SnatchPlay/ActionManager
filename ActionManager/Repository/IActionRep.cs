using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager.Repository
{
    public interface IActionRep
    {
        List<Action> GetActions();
        void AddObj(Action tempObj);
        void DeleteObject(int id);
        void ReadFromDB();
        Action GetObj(int id);
        void ChangeName(int id, string name);
    }
}
