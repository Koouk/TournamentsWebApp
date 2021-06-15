using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentsWebApp.Services
{
    public class CheckDateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt >= DateTime.UtcNow)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Make sure your date is not in the past");
        }

    }

    public class DateLessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateLessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue > comparisonValue)
                return new ValidationResult("Deadline date cannot be after starting");

            return ValidationResult.Success;
        }
    }

    public class NumberHigherThannAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public NumberHigherThannAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (int)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (int)property.GetValue(validationContext.ObjectInstance);

            if (currentValue < comparisonValue)
                return new ValidationResult("You need to increase maxiumum members");

            return ValidationResult.Success;
        }
    }



    public class isOneOfTwo : ValidationAttribute
    {
        private readonly string _comparisonProperty1;
        private readonly string _comparisonProperty2;

        public isOneOfTwo(string comparisonProperty1, string comparisonProperty2)
        {
            _comparisonProperty1 = comparisonProperty1;
            _comparisonProperty2 = comparisonProperty2;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (string)value;

            var property1 = validationContext.ObjectType.GetProperty(_comparisonProperty1);
            var property2 = validationContext.ObjectType.GetProperty(_comparisonProperty2);

            if (property1 == null || property2 ==null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue1 = (string)property1.GetValue(validationContext.ObjectInstance);
            var comparisonValue2 = (string)property2.GetValue(validationContext.ObjectInstance);

            if (currentValue != comparisonValue1 && currentValue != comparisonValue2)
                return new ValidationResult("There is no such oponnent");

            return ValidationResult.Success;
        }
    }




}
