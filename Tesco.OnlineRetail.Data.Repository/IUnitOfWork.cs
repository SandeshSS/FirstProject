using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Data.Repository
{
    public interface IUnitOfWork
    {
        ICustomerRepository GetCustomerRepository();
        ICategoryRepository GetCategoryRepository();
        IClubCardRegRepository GetClubCardRegRepository();
        IGiftProductCategoryRepository GetGiftProductCategoryRepository();
        IGiftProductRepository GetGiftProductRepository();
              
    }
}
