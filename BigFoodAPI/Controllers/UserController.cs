using BigFoodData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFoodAPI.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        BigFoodDbContext _context = new BigFoodDbContext();

        [HttpGet("Get-All")]
        public ActionResult GetAll(string? search)
        {
            if (search == null || search == "")
            {
                var lst = _context.Users.ToList();
                return Ok(lst);
            }
            else
            {
                var lstSearch = _context.Users.Where(x => x.name.ToLower().Contains(search.ToLower()) || x.phoneNumber.ToLower().Contains(search.ToLower()) || x.email.ToLower().Contains(search.ToLower()) || x.address.ToLower().Contains(search.ToLower())).ToList();
                return Ok(lstSearch);
            }
        }


        [HttpGet("Get-By-Id")]
        public ActionResult GetById(Guid id)
        {
            var obj = _context.Users.Find(id);
            return Ok(obj);
        }

        [HttpPost("Create")]
        public ActionResult Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(User user)
        {
            try
            {
                var obj = _context.Users.Find(user.Id);

                obj.name = user.name;
                obj.phoneNumber = user.phoneNumber;
                obj.email = user.email;
                obj.address = user.address;
                obj.password = user.password;
                obj.userName = user.userName;
                obj.accumulatepoint = user.accumulatepoint;
                obj.RoleId = user.RoleId;
                obj.status = user.status;

                _context.Users.Update(obj);
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
                var obj = _context.Users.Find(id);

                _context.Users.Remove(obj);
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
