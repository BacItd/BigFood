using BigFoodData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFoodAPI.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        BigFoodDbContext _context = new BigFoodDbContext();

        [HttpGet("Get-All")]
        public ActionResult GetAll()
        {
            return Ok(_context.Roles.ToList());
        }

        [HttpGet("Get-By-Id")]
        public ActionResult GetById(int id)
        {
            return Ok(_context.Roles.Find(id));
        }
    }
}
