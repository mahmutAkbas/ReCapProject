using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public CustomerDetailDto GetCustomerDetail(int customerId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from u in context.Users
                              join c in context.Customers
                                  on u.UserId equals c.UserId
                              where c.CustomerId == customerId
                              select new CustomerDetailDto
                              {
                                  CustomerId = c.CustomerId,
                                  UserEmail = u.UserEmail,
                                  CompanyName = c.CompanyName,
                                  UserLastName = u.UserLastName,
                                  UserFirstName = u.UserFirstName,
                                  UserPassword = u.UserPassword
                              }).SingleOrDefault();
                return result;
            }
        }

        public List<CustomerDetailDto> GetCustomersDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from u in context.Users
                              join c in context.Customers
                                  on u.UserId equals c.UserId

                              select new CustomerDetailDto
                              {
                                  CustomerId = c.CustomerId,
                                  UserEmail = u.UserEmail,
                                  CompanyName = c.CompanyName,
                                  UserLastName = u.UserLastName,
                                  UserFirstName = u.UserFirstName,
                                  UserPassword = u.UserPassword
                              }).ToList();
                return result;
            }
        }
    }
}
