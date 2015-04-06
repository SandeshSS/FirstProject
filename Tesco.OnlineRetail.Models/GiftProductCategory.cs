using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Models
{
    public class GiftProductCategory
    {
        public int GiftProductCategoryId { get; set; }
        [Required]
        public String GiftCategoryName { get; set; }
        public bool IsActive { get; set; }

    }
}
