using BigFoodData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigFoodAPI.Controllers
{
    [Route("Food")]
    [ApiController]
    public class FoodController : ControllerBase
    { 
        BigFoodDbContext _context = new BigFoodDbContext();

        [HttpGet("Get-All")]
        public ActionResult GetAllFood()
        {
            var lst = _context.Foods.ToList();
            return Ok(lst);
        }

        [HttpGet("Get-By-Id")]
        public  ActionResult GetFoodById(Guid id)
        {
            var obj = _context.Foods.Find(id);
            return Ok(obj);
        }

        [HttpPost("Create")]
        public ActionResult CreateFood(Food food)
        {
            try
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPut("Update")]
        public  ActionResult UpdateFood(Food food)
        {
            try
            {
                var obj = _context.Foods.Find(food.Id);

                obj.Name = food.Name;
                obj.Description = food.Description;
                obj.Category = food.Category;
                obj.Status = food.Status;
                obj.QrCode = food.QrCode;
                obj.PriceCurrent = food.PriceCurrent;
                obj.PriceSale = food.PriceSale;
                obj.Quantity = food.Quantity;
                obj.QuantitySold = food.QuantitySold;
                obj.DateCreate = food.DateCreate;
                obj.ImageUrl = food.ImageUrl;
                obj.Ingredient = food.Ingredient;
                obj.SaleId = food.SaleId;

                _context.Foods.Update(obj);
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
                var obj =  _context.Foods.Find(id);

                _context.Foods.Remove(obj);
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
