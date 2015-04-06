using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    internal class GiftProductCategoryManager : IGiftProductCategoryManager
    {

        private IGiftProductCategoryRepository repository;

        public GiftProductCategoryManager(IUnitOfWork uow)
        {
            repository = uow.GetGiftProductCategoryRepository();
        }

        public void SaveGiftProductCategory(Models.GiftProductCategory giftproductcategory)
        {
            repository.Create(giftproductcategory);
        }

        public IList<Models.GiftProductCategory> GetGiftProductCategorys()
        {
            return repository.All().ToList<GiftProductCategory>();
        }

        //public IList<GiftProductCategory> GetGiftProductCategoryById(string GiftProductCategoryId)
        //{
        //    return repository.Get(c => c.GiftProductCategoryId.Equals(GiftProductCategoryId)).ToList<GiftProductCategory>();
        //}

    }
}