using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_ENTITY.EntityModels
{
    public class DailyExpence
    {
        [Key]
        public int ExpenceId { get; set; }
        [Required(ErrorMessage ="Expence Date is required!")]
        public DateTime ExpenceDate { get; set; }
        [Required(ErrorMessage ="Amount is required!")]
        public decimal Amount { get; set; }
        public int CategoryId { get; set; } 
        public virtual ExpCategories categories { get; set; }
    }
}
