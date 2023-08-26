using System;
using System.Collections.Generic;

namespace MobileStore.Services.Models
{
    public class Sale
    {
        public string Sid { get; set; }
        public string Cid { get; set; }
        public string Mid { get; set; }
        public int QtyPurchesed { get; set; }
        public int Costpermobile { get; set; }
        public DateTime Saledate { get; set; }
        public int Sellingpricepermobile { get; set; }
        public int Discount { get; set; }
    }
}
