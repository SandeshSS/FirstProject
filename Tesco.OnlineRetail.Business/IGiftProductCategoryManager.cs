using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    public interface IGiftProductCategoryManager
    {

        void SaveGiftProductCategory(GiftProductCategory giftproductCategory);
        IList<GiftProductCategory> GetGiftProductCategorys();

    }
}
