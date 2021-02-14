using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();


        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}

            //foreach (var car in carManager.GetByDailyPrice(20, 50))
            //{
            //    Console.WriteLine(car.CarName);
            //}

            //foreach (var car in carManager.GetAllByColorId(2))
            //{

            //    Console.WriteLine(car.ColorId);
            //}


            //foreach (var car in carManager.GetCarDetails())
            //{

            //    Console.WriteLine(car.CarName+"/" + car.BrandName);
            //}

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                   
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}

