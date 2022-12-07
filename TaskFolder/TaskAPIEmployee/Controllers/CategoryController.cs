using BLL.Repository;

using DL.Model;
using DL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskAPIEmployee.Controllers
{
    [Authorize]
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RepoCategory _repo;

        public CategoryController(RepoCategory repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("GetAllCategory")]
        public ActionResult GetAllCategory()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from DataBase");
            }

        }


        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("GetCategoryById")]
        public ActionResult GetCategoryById(int id)
        {
            try
            {
                return Ok(_repo.GetEntityOne(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from DataBase");
            }

        }


 
        [Produces("application/json")]
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CategoryVM c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest();
                }
               _repo.Add(c);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Add Data To DataBase");
            }

        }

        
        [Produces("application/json")]
        [HttpDelete("DeleteCategoryById")]
        public ActionResult DeleteCategoryById(int id)
        {
            try
            {
                _repo.DeleteEnitity(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Delete Data from DataBase");
            }

        }


       
        [Produces("application/json")]
        [HttpPut("UpdateCategoryById")]
        public IActionResult UpdateCategoryById(int id,CategoryVM c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest();
                }
                _repo.UpdateCategoryById(id,c);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Update Data from DataBase");
            }

        }

    }
}