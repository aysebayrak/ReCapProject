using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
       

        public BrandManager(IBrandDal brandDal )
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                
                return new ErrorResult(Messages.BrandBrandNameInvalid);
               // Console.WriteLine("marka başarı ile eklendi");
            }
            //  else
            //{
            //  Console.WriteLine($"Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz. Girdiğiniz marka ismi : {brand.BrandName}");
            //}
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);  
        }

        public IResult Delete(Brand brand)
        {

            _brandDal.Delete(brand);
            // Console.WriteLine("Marka başarıyla silindi.");
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult< List<Brand>> GetAll()
        {
            return new  SuccessDataResult<List < Brand >>(_brandDal.GetAll());
        }

        public IDataResult <Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(  _brandDal.Get(c => c.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {

                return new ErrorResult(Messages.BrandBrandNameInvalid);
                // Console.WriteLine("marka başarı ile eklendi");
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
