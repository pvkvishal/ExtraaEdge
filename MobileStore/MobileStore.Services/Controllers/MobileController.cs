
using Microsoft.AspNetCore.Mvc;
using MobileStore.DataAccessLayer;
using MobileStore.Services.Models;

namespace MobileStore.Services.Controllers
{
    [Route("mobile/[controller]/[action]")]
    public class MobileController : Controller
    {
        RepositoryClass repository;
        public MobileController()
        {
            this.repository = new RepositoryClass();
        }

        [HttpGet]
        public JsonResult GetSale()
        {
           
           var saleList = repository.GetAllSale();
          
           
            return Json(saleList);
        }
        [HttpPost]
        public JsonResult addSale(string saleId, string custId, string mobId, int cost, int qtypurchased, int sellingprice, int discount, DateTime date)
        {

            var result = repository.addSale(saleId, custId, mobId,cost,qtypurchased,sellingprice,discount,date);
            return Json(result);
        }

        [HttpDelete]
        public JsonResult deleteSale(string saleId)
        {

            var result = repository.DeleteSale(saleId);
            return Json(result);
        }
    }
}
