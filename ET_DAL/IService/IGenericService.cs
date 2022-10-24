using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_DAL.IService
{
    public interface IGenericService<IEntity> where IEntity : class
    {
        IEnumerable<IEntity> GetAll();
        IEntity GetById(int id);
        void AddItems(IEntity entities); 
        void RemoveItem(int id);
        void UpdateItem(IEntity entities); 
    }
}
