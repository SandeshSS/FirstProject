using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;

namespace Tesco.OnlineRetail.Data.EFRepository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public ICustomerRepository GetCustomerRepository()
        {
            return new CustomerEFRepository();
        }
        public ICategoryRepository GetCategoryRepository()
        {
            return new CategoryEFRepository();
        }
        public IGiftProductRepository GetGiftProductRepository()
        {
            return new GiftProductEFRepository();
        }
        public IGiftProductCategoryRepository GetGiftProductCategoryRepository()
        {
            return new GiftProductCategoryEFRepository();
        }
       public IClubCardRegRepository GetClubCardRegRepository()
        {
            return new ClubCardRegEFRepository();
        }
       
    }

}
