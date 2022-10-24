using ET_DAL.IService;
using ET_ENTITY;
using ET_ENTITY.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_DAL.Repository
{
    public class RepoDailyExpence : IGenericService<DailyExpence>, IDisposable
    {
        private AppDBContext _context;
        public RepoDailyExpence(AppDBContext context)
        {
            _context = context;
        }
        public void AddItems(DailyExpence entities)
        {
            _context.Add(entities);
            _context.SaveChanges(); 
        }

        public IEnumerable<DailyExpence> GetAll()
        {
            return _context.DailyExpences.ToList();
        }

        public DailyExpence GetById(int id)
        {
            return _context.DailyExpences.Find(id);
        }

        public void RemoveItem(int id)
        {
            DailyExpence dailyExpence = _context.DailyExpences.Find(id);
            if (dailyExpence != null)
            {
                _context.DailyExpences.Remove(dailyExpence);
                _context.SaveChanges();
            }
        }

        public void UpdateItem(DailyExpence entities)
        {
            _context.Entry(entities).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }
        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }        
    }
}
