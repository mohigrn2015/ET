using ET_BLL.IBllService;
using ET_ENTITY.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ET_DAL.IService;
using ET_DAL.Repository;

namespace ET_BLL.BLLRepository
{
    public class BLLRepoCategories : IBLLGenericService<ExpCategories>
    {
        private IGenericService<ExpCategories> _categories;
        public BLLRepoCategories(IGenericService<ExpCategories> categories)
        {
            _categories = categories;
        }
        public void AddItems(ExpCategories entities)
        {
            _categories.AddItems(entities);
        }

        public IEnumerable<ExpCategories> GetAll()
        {
            return _categories.GetAll();
        }

        public ExpCategories GetById(int id)
        {
            return _categories.GetById(id);
        }

        public void RemoveItem(int id)
        {
            _categories.RemoveItem(id);
        }

        public void UpdateItem(ExpCategories entities)
        {
            _categories.UpdateItem(entities);   
        }
    }
}
