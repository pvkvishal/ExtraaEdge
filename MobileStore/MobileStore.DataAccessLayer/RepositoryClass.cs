using MobileStore.DataAccessLayer.Models;



namespace MobileStore.DataAccessLayer
{
    public class RepositoryClass
    {
        MobileStoreContext context;
        public RepositoryClass()
        {
            this.context = new MobileStoreContext();
        }

        public List<Sale> GetAllSale()
        {
            var SaleList = new List<Sale>();
            try
            {
                SaleList = context.Sales.ToList();
            }
            catch
            {
                SaleList = null;
            }

            return SaleList;
        }



        public bool addSale(string saleId, string custId, string mobId, int cost, int qtypurchased, int sellingprice, int discount, DateTime date)
        {
            bool result = false;
            var obj = new Sale();
            obj.Sid = saleId;
            obj.Cid = custId;
            obj.Mid = mobId;
            obj.Costpermobile = cost;
            obj.QtyPurchesed = qtypurchased;
            obj.Sellingpricepermobile = sellingprice;
            obj.Discount = discount;
            obj.Saledate = date;    
            try
            {
                SaleDetail saleobj = new SaleDetail();
                saleobj.Sid = saleId;
                saleobj.Totalcostprice = qtypurchased * cost;
                saleobj.TotalsellingPrice = sellingprice * qtypurchased;
                saleobj.Costpricepermobile = cost;
                saleobj.Sellingpricepermobile = sellingprice;
                saleobj.Actualsellingprice = (int)(sellingprice - (discount * 0.1 * sellingprice));
                saleobj.Totalactualsellingprice = (int)(sellingprice - (discount * 0.1 * sellingprice)) * qtypurchased;
                context.Add<Sale>(obj);
                context.SaveChanges();
                context.Add<SaleDetail>(saleobj);
                context.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool DeleteSale(string saleId)
        {
            bool result = false;

            try
            {
                var sale = context.Sales.Where(s => s.Sid == saleId).FirstOrDefault();

                if (sale != null)
                {
                    context.Sales.Remove(sale);
                    context.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }


}