using Core.DataAccess.EnityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfCarImageDal :EfEntityRepositoryBase<CarImage, ReCapProjectContext>, ICarImageDal
    {
        //parametrede verilen id ye ait veri varmı ona bakıyır varsa true yoksa falses dönüyor
        public bool IsExist(int id)
        {
            using (ReCapProjectContext context= new ReCapProjectContext())
            {
                return context.CarImages.Any(c => c.Id == id);
            }
        }
    }
}
