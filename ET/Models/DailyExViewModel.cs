using ET.Utility;
using ET_ENTITY.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ET.Models
{
    public class DailyExViewModel
    {
        public int ExpenceId { get; set; } 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ExpenceDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ToDate { get; set; } 
        public DateTime? FromDate { get; set; }
    }
}
