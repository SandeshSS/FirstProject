using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Models
{
    public class GiftProduct
    {
        public int GiftProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int RedeemPoints { get; set; }

        public int GiftProductCategoryId { get; set; }
        [ForeignKey("GiftProductCategoryId")]
        public GiftProductCategory giftproductcategory { get; set; }
        
        public bool IsActive { get; set; }


    }
}
