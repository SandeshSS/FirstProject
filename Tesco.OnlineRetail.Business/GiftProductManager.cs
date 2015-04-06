using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    class GiftProductManager : IGiftProductManager
    {

         private IGiftProductRepository repository = null;

        public GiftProductManager(IUnitOfWork uow)
        {
            repository = uow.GetGiftProductRepository();
        }
        public void SaveGiftProduct(GiftProduct giftProduct)
        {
            repository.Create(giftProduct);
        }

        public IList<GiftProduct> GetGiftProductsList()
        {
            return repository.All().ToList<GiftProduct>();
        }

        public IList<GiftProduct> GetGiftProducts()
        {
            return repository.Get(p=>p.GiftProductId==p.GiftProductId,"GiftProductCategory").ToList<GiftProduct>();
        }
        }
    }
