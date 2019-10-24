using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTicaretCore.Entity
{
    public class OrderPayment : BaseEntity
    {
        public int OrderID { get; set; }
        public int _OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }

    }
    public enum _OrderType
    {
        Havale = 0,
        KrediKarti = 1
    }
}
