using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
    //{
    //    List<Car> _cars;
    //    public InMemoryCarDal()
    //    {
    //        _cars = new List<Car>
    //        {
    //            new Car{CarId=1,ColarId=1,ModelYear="1920",DailyPrice=500,Description="uzun yol "},
    //            new Car{CarId=2,ColarId=1,ModelYear="1925",DailyPrice=900,Description="iki kişilik"},
    //            new Car{CarId=3,ColarId=2,ModelYear="1950",DailyPrice=400,Description="kısa yol "}
    //        };

    //    }
    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        //LINQ LİSTE BAZLI YAPILARI FİLTRELEDİK
    //        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
    //        _cars.Remove(carToDelete);
    //    }

    //    public Car Get(Expression<Func<Car, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAllBrand(int brandId)
    //    {
    //        return _cars.Where(c => c.BrandId == brandId).ToList();
    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
    //        carToUpdate.CarId = car.CarId;
    //        carToUpdate.BrandId= car.BrandId;
    //        carToUpdate.ColarId = car.ColarId;
    //        carToUpdate.ModelYear = car.ModelYear;
    //        carToUpdate.DailyPrice = car.DailyPrice;
    //        carToUpdate.Description = car.Description;
    //    }
    }

