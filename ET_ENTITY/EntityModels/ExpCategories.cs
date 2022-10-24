using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ET_ENTITY.EntityModels
{
    public class ExpCategories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category is required!")]
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        public virtual ICollection<DailyExpence> Expenses { get; set; }

    }
}
