using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public  interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);

        IDataResult<RentalDetailDto> GetRentalDetailsById(int rentalId);


        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
      //  IResult IsRentable(Rental rental);
    }
}
