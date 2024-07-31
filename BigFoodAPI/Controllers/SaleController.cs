using BigFoodData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFoodAPI.Controllers
{
    [Route("Sale")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        BigFoodDbContext _context = new BigFoodDbContext();

        [HttpGet("Get-All")]
        public ActionResult GetAll(string? search)
        {
            if (search == null || search == "")
            {
                var lst = _context.Sales.ToList();
                return Ok(lst);
            }
            else
            {
                var lstSearch = _context.Sales.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                return Ok(lstSearch);
            }
        }


        [HttpGet("Get-By-Id")]
        public ActionResult GetById(Guid id)
        {
            var obj = _context.Sales.Find(id);
            return Ok(obj);
        }

        [HttpPost("Create")]
        public ActionResult Create(Sale sale)
        {
            try
            {
                _context.Sales.Add(sale);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(Sale sale)
        {
            try
            {
                var obj = _context.Sales.Find(sale.Id);

                obj.Name = sale.Name;
                obj.PercentSale = sale.PercentSale;
                obj.StartDate = sale.StartDate;
                obj.EndDate = sale.EndDate;
                obj.Status = sale.Status;

                _context.Sales.Update(obj);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var obj = _context.Sales.Find(id);

                _context.Sales.Remove(obj);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
