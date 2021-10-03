using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionManager.Repository
{
    public interface ICategoryRep
    {
        List<Category> GetCategories();
        void AddObj(Category tempObj);
        void DeleteObject(int id);
        void ReadFromDB();
        Category GetObj(int id);
    }
}
