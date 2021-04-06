using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        ICustomerDal _customerDal;
        public RentalManager(IRentalDal rentalDal,ICustomerDal customerDal,ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _customerDal = customerDal;

        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CarRentalStatus(rental),
                CheckFindexScoreByCustomer(rental.CustomerId, rental.CarId));//findeks kontrolu 
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult <RentalDetailDto> GetRentalDetailsById(int rentalId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetails(rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CarRentalStatus(Rental rental)
        {
            var result = _rentalDal.Get(r => (r.CarId == rental.CarId && r.ReturnDate == null)
            || (r.RentDate>=rental.RentDate&& r.ReturnDate>=rental.RentDate)

            );
            if(result != null)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }
            return new SuccessResult();
               
        }

        private IResult CheckFindexScoreByCustomer(int customerId, int carId)
        {
            var car =_carDal.Get(c => c.CarId == carId);

            var customer = _customerDal.Get(c => c.CustomerId == customerId);

            var carScore = car.MinFindexScore;
            var customerScore = customer.FindexScore;

            if (customerScore >= carScore)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotEnough);

        }
    }
}
