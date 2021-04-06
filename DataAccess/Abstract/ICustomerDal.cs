using Coore.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICustomerDal: IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetailDto(Expression<Func<Customer, bool>> filter = null);
    }
}
