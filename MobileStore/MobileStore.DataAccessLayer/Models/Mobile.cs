using System;
using System.Collections.Generic;

namespace MobileStore.DataAccessLayer.Models
{
    public partial class Mobile
    {
        public Mobile()
        {
            Sales = new HashSet<Sale>();
        }

        public string Mid { get; set; }
        public string MModel { get; set; }
        public string MBrand { get; set; }
        public DateTime MDate { get; set; }
        public int Qty { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
