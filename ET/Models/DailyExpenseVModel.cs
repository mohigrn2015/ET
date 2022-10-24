using ET_ENTITY.EntityModels;
using System.ComponentModel.DataAnnotations;
using System;
using ET.Utility;
using System.Collections.Generic;

namespace ET.Models
{
    public class DailyExpenseVModel
    {        
        [DataType(DataType.Date)]
        [DateRange]
        [Required(ErrorMessage = "Expence Date is required!")]
        public DateTime ExpenceDate { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public List<ExpCategories> categories { get; set; }

    }
}
