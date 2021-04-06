using Core.DataAccess.EnityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDto(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapProjectContext context= new ReCapProjectContext())
            {

                var result = from customer in filter is null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users on customer.UserId equals user.UserId
                             select new CustomerDetailDto()
                             {
                                 CustomerId = customer.CustomerId,
                                 FirstName=user.FirstName,
                                 CompanyName = customer.CompanyName,
                                 LastName=user.LastName,
                                 Email=user.Email,
                                 FindexScore=customer.FindexScore

                             };

                return result.ToList();

            }
        }
    }
}
