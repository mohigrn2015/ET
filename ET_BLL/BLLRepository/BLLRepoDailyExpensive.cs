using ET_BLL.IBllService;
using ET_ENTITY.EntityModels;
using ET_DAL.Repository;
using ET_DAL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace ET_BLL.BLLRepository
{
    public class BLLRepoDailyExpensive : IBLLGenericService<DailyExpence>
    {
        private IGenericService<DailyExpence> _expense;
        public BLLRepoDailyExpensive(IGenericService<DailyExpence> expence)
        {
            _expense = expence;  
        }
        public void AddItems(DailyExpence entities)
        {
            _expense.AddItems(entities);
        }

        public IEnumerable<DailyExpence> GetAll()
        {
            return _expense.GetAll();
        }

        public DailyExpence GetById(int id)
        {
            return _expense.GetById(id);    
        }

        public void RemoveItem(int id)
        {
           _expense.RemoveItem(id); 
        }

        public void UpdateItem(DailyExpence entities)
        {
            _expense.UpdateItem(entities);  
        }
    }
}
