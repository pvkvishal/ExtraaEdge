using System;
using System.Collections.Generic;

namespace MobileStore.DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public string Cid { get; set; }
        public string CName { get; set; }
        public string CEmail { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
