using Business.Abstract;
using Business.Constants;
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
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null && _rentalDal.GetRentalDetails(I => I.CarId == rental.CarId).Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(I => I.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter), Messages.RentalReturned);
        }

        public IResult IsRentable(Rental rental)
        {

            var dates = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var date in dates)
            {
                if (date.RentDate <= rental.RentDate && rental.RentDate <= date.ReturnDate)
                {
                    return new ErrorResult();
                }
                else if (date.RentDate <= rental.ReturnDate && rental.ReturnDate <= date.ReturnDate)
                {
                    return new ErrorResult();
                }
                else if (date.RentDate >= rental.RentDate && rental.ReturnDate >= date.ReturnDate)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
