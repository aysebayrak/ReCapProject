using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c=> c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c=> c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(Messages.CarDailyPriceInvalid);

        //    RuleFor(p => p.Description).Must(StartWithA).When(p => p.Description != null).WithMessage("Description Must start with the letter A");
        //}
        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        
    }
    }
}
