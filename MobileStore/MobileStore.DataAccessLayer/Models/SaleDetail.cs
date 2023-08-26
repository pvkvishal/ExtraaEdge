using System;
using System.Collections.Generic;

namespace MobileStore.DataAccessLayer.Models
{
    public partial class SaleDetail
    {
        public string Sid { get; set; }
        public int Costpricepermobile { get; set; }
        public int Totalcostprice { get; set; }
        public int Sellingpricepermobile { get; set; }
        public int TotalsellingPrice { get; set; }
        public int Discount { get; set; }
        public int Discountamount { get; set; }
        public int Actualsellingprice { get; set; }
        public int Totalactualsellingprice { get; set; }
        public int Profiteorloss { get; set; }

        public virtual Sale SidNavigation { get; set; }
    }
}
