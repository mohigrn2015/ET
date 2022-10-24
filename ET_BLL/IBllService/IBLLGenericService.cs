using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_BLL.IBllService
{
    public interface IBLLGenericService<Entity> where Entity : class
    {
        IEnumerable<Entity> GetAll();
        Entity GetById(int id);
        void AddItems(Entity entities);
        void RemoveItem(int id);
        void UpdateItem(Entity entities);
    }
}
