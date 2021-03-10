using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
      
        [ValidationAspect(typeof(CarImageValidator))]//uymasını istediğim kurallar
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExpired(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = CarImagesFileHelper.Add(file);//uzantıma depola
            carImage.Date = DateTime.Now;//otomatik olsun 
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(carImage.Id));
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.Id).Data.ImagePath;
            CarImagesFileHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));

        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExpired(carImage.CarId),
                 CheckIfImageExists(carImage.Id));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            string OldPath = GetById(carImage.Id).Data.ImagePath;

            carImage.ImagePath= CarImagesFileHelper.Update(file, OldPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }
        private IResult CheckIfImageLimitExpired(int caıId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == caıId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExpiredForCar);

            }
            return new SuccessResult();
        }
        private IResult CheckIfImageExists(int id)
        {//resim varmı diye kontrol etti
            if (_carImageDal.IsExist(id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageMustBeExists);

        }
        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {//ıd ye ait resim varsa GETİR
         //AKTİF UYGULAMANIN YOLUNU VERİR= Directory.GetCurrentDirectory()

            //gitmek istediğim yol= string path 

            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images\default.png";// //o araca ait resim yoksa wwwroot altındaki klasörden belirtilen resmi getir benin default olarak ekleneni
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            }
            return result;
            //CarId'ye göre resimleri getiriyor. Ama o Id'ye sahip araçta hiç resim yoksa default resmi gösteriyor
        }
    } 
}




//ValidImageFileTypes==uzantı isimleir
    //InvalidImageExtension  =uzabtı ile alakalı 