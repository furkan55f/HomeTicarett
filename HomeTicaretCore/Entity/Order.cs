using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTicaretCore.Entity
{
    public class Order : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int UserAddressID { get; set; }
        public UserAddress UserAddress { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public decimal TotalProductPrice { get; set; }
        public decimal TotalTaxPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; } //Virtual : Tabloda olmayan sanal görünüm
        public virtual List<OrderProduct> OrderProducts { get; set; }

    }
}
