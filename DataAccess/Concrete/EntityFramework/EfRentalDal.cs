using Core.DataAccess.EnityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId

                             join user in context.Users
                             on customer.UserId equals user.UserId

                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate

                             };
                Debug.Write("asdfghjk--------" + result.ToList());

                return result.ToList();




            }
        }

        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from rental in context.Rentals.Where(r => r.RentalId == rentalId)

                             join car in context.Cars
                             on rental.CarId equals car.CarId

                             join brand in context.Brands
                       on rental.BrandId equals brand.BrandId

                             join customer in context.Customers
                         on rental.CustomerId equals customer.CustomerId

                             join user in context.Users
                         on customer.UserId equals user.UserId

                             select new RentalDetailDto

                             {

                                 RentalId = rental.RentalId,
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate


                             };
                return result.SingleOrDefault();


            }
        }
    }
}
