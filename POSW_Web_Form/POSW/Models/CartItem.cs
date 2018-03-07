using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSW.Models
{
    public class CartItem
    {

        public int ProductId { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public float Rate { get; set; }

        public float SubTotal
        {
            get
            {
                return Qty * Rate;
            }
        }

        public List<CartItem> Cart()
        {
            return new List<Models.CartItem>();
        }

    }
}