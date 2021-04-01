using Core.DataAccess.EnityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cr in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                                 on cr.BrandId equals b.BrandId
                             join cl in context.Colors
                                 on cr.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = cr.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 ModelYear = cr.ModelYear,
                                 Description = cr.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                // ImagePath = (from carImage in context.CarImages where carImage.CarId == cr.CarId select carImage.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            };

            }
          
        }
    }

