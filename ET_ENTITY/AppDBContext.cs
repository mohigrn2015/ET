using ET_ENTITY.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace ET_ENTITY
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<ExpCategories> ExpCategories { get; set; }
        public DbSet<DailyExpence> DailyExpences { get; set; }
    }
}
