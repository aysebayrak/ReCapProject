using Coore.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public  interface ICarImageDal :IEntityRepository<CarImage>
    {
        bool IsExist(int id);//verilen id ye ait veri varmı ona bak metodeu ef dede içini doldurduk 
    }
}
