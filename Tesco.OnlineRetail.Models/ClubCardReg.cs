using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Models
{
    public class ClubCardReg
    {
        [Key]
        public int ClubCardRegId { get; set; }
        
        public string ClubCardNumber { get; set; }
       
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer customer { get; set; }


    }
}
