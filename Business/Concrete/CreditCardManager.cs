using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public  class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard creditCard)
        {
           IResult result = BusinessRules.Run(IsCardExist(creditCard));//cart olup olmadığı konntrol ediliyor
            if (result != null)
            {
                return result;
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
           
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        private IResult IsCardExist(CreditCard creditCard) //kart varmı 
        {
            var result = _creditCardDal.Get(c =>
            c.NameOnTheCard==creditCard.NameOnTheCard &&
            c.CreditCardNumber==creditCard.CreditCardNumber &&
            c.CVV==creditCard.CVV &&
            c.ExpirationDate==creditCard.ExpirationDate

            );
            if (result != null)
            {
                return new ErrorResult(Messages.CreditCardExist);
            }
            return new SuccessResult();
        }
    }
}
