using BigFoodData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFoodAPI.Controllers
{
    [Route("Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        BigFoodDbContext _context = new BigFoodDbContext();

        [HttpGet("Get-All")]
        public ActionResult GetAll()
        {
            var lst = _context.Categorys.ToList();
            return Ok(lst);
        }


        [HttpGet("Get-By-Id")]
        public ActionResult GetCategoryById(int id)
        {
            var obj = _context.Categorys.Find(id);
            return Ok(obj);
        }

        [HttpPost("Create")]
        public ActionResult CreateCategory(Category category)
        {
            try
            {
                _context.Categorys.Add(category);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                var obj = _context.Categorys.Find(category.Id);

                obj.Name = category.Name;
                obj.Status = category.Status;

                _context.Categorys.Update(obj);
                _context.SaveChanges();
                return Ok();

            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = _context.Categorys.Find(id);

                _context.Categorys.Remove(obj);
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
