using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.Repository;

namespace BusinessLogic
{
    public class ActionLogic
    {
        public IRepository<ActionDTO> actionrep =new ActionRep();
        public IRepository<TypeDTO> typerep =new TypeRep();
        public IRepository<Goods> supplyRep = new GoodsRep();   
        List<ActionDTO> actionList;
        
        public ActionLogic() { actionList = actionrep.GetEnteties(); }
        public List<string> PropertyNames()
        {
            List<string> propertyNames = new List<string>();
            propertyNames.Add("Name");
            propertyNames.Add("Discount");
            propertyNames.Add("Start Time");
            propertyNames.Add("End Time");
            return propertyNames;
        }
        public List<ActionDTO> GetPastAction()
        {
            List<ActionDTO> pastAction = new List<ActionDTO>();
            foreach (ActionDTO action in actionList)
            {
                if (action.EndTime < DateTime.Now)
                {
                    pastAction.Add(action);
                }
            }
            return pastAction;
        }
        public List<string> TypeNames()
        {
            List<string> typeNames = new List<string>();
            foreach(TypeDTO type in typerep.GetEnteties())
            {
                typeNames.Add(type.Name);
            }
            return typeNames;
        }
        public List<ActionDTO> GetActiveAction()
        {
            List<ActionDTO> activeAction = new List<ActionDTO>();
            foreach (ActionDTO action in actionList)
            {
                if (action.StartTime<=DateTime.UtcNow && action.EndTime >= DateTime.Now)
                {
                    activeAction.Add(action);
                }
            }
            return activeAction;
        }
        public List<ActionDTO> GetFutureAction()
        {
            List<ActionDTO> futureAction = new List<ActionDTO>();
            foreach (ActionDTO action in actionList)
            {
                if (action.StartTime > DateTime.Now)
                {
                    futureAction.Add(action);
                }
            }
            return futureAction;
        }
        public void UpdateActionName(string newname,int id)
        {
            foreach (ActionDTO action in actionList)
            {
                if(action.Id == id)
                {
                    action.Name = newname;
                }
            }
            actionrep.UpdateField("Action", "Name", newname, id);
        }
        public void UpdateActionStartTime(DateTime newdata,int id)
        {
            foreach (ActionDTO action in actionList)
            {
                if (action.Id == id)
                {
                    action.StartTime = newdata;
                }
            }
            string sqldate = newdata.ToString("yyyy-MM-dd");
            actionrep.UpdateField("Action", "Start Time", sqldate, id);
        }
        public void UpdateActionEndTime(DateTime newdata, int id)
        {
            foreach (ActionDTO action in actionList)
            {
                if (action.Id == id)
                {
                    action.EndTime = newdata;
                }
            }
            string sqldate = newdata.ToString("yyyy-MM-dd");
            actionrep.UpdateField("Action", "End Time", sqldate, id);
        }
        public void UpdateActionDiscount(float newdiscount, int id)
        {
            foreach (ActionDTO action in actionList)
            {
                if (action.Id == id)
                {
                    action.Discount = newdiscount;
                }
            }
            actionrep.UpdateField("Action", "Discount", newdiscount.ToString(), id);
        }
        public List<Goods> actionSupply(int id)
        {
            List<Goods> list = new List<Goods>();
            foreach(Goods s in supplyRep.GetEnteties())
            {
                if(s.ActionId == id)
                {
                    list.Add(s);
                }
            }
            return list;
        }
        public List<Goods> avalaibleSupply()
        {
            List<Goods> list = new List<Goods>();
            foreach(Goods s in supplyRep.GetEnteties())
            {
                if (s.ActionId == 1)
                {
                    list.Add(s);
                }
            }
            return list;
        }

    }
}
