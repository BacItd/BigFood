using BigFoodData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFoodAPI.Controllers
{
    [Route("Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        BigFoodDbContext _context = new BigFoodDbContext();

        [HttpGet("Get-Cart-By-Id")]
        public ActionResult GetById(Guid id)
        {
            return Ok(_context.Carts.Find(id));
        }

        [HttpGet("Get-Cart-By-Id-User")]
        public ActionResult GetByIdUser(Guid id)
        {
            return Ok(_context.Carts.FirstOrDefault(x => x.UserId == id));
        }

        [HttpPost("Create")]
        public ActionResult Create(Cart cart)
        {
            try
            {
                _context.Carts.Add(cart);
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
