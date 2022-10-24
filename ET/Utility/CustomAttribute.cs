using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ET.Utility 
{
    public class DateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime selectDate = (DateTime)value;
            if(selectDate > DateTime.Now) 
            {
                return new ValidationResult("Date must be less then or equal today!");
            }
            return ValidationResult.Success;
        }
    }
}
