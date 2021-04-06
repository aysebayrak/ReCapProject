using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult paymentTransaction(Payment payment)
        {
           if(payment.Quantity<750)
            {
                return new ErrorResult("Miktar Hatası");
            }
            return new SuccessResult();
        }
    }
}
