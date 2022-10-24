using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_ENTITY.ViewModel
{
    public class ExpenseDataNodel
    {
        public int ExpenceId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ExpenceDate { get; set; }
        public decimal Amount { get; set; }
    }
}
