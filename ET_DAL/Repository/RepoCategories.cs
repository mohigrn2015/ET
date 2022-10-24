using ET_DAL.IService;
using ET_ENTITY;
using ET_ENTITY.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ET_DAL.Repository
{
    public class RepoCategories : IGenericService<ExpCategories>
    {
        private AppDBContext _context;
        public RepoCategories(AppDBContext context)
        {
            _context = context;
        }

        public void AddItems(ExpCategories entities)
        {
            _context.Add(entities);
            _context.SaveChanges();
        }
        
        public IEnumerable<ExpCategories> GetAll()
        {
            return _context.ExpCategories.ToList();
        }

        public ExpCategories GetById(int id)
        {
            return _context.ExpCategories.Find(id);
        }

        public void RemoveItem(int id)
        {
            ExpCategories expCategories = _context.ExpCategories.Find(id);
            if (expCategories != null)
            {
                _context.Remove(expCategories);
                _context.SaveChanges();
            }
        }

        public void UpdateItem(ExpCategories entities)
        {
            _context.Update(entities);
            //_context.Entry(entities).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
