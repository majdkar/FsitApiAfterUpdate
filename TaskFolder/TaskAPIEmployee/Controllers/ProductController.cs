using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.Repository;
using DL.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DL.ViewModels;

namespace TaskAPIEmployee.Controllers
{
    [Authorize]
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly RepoProduct _repo;

        public ProductController(RepoProduct repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("GetAllProduct")]
        public ActionResult GetAllProduct()
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
        [HttpGet("GetProductById")]
        public ActionResult GetProductById(int id)
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
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductVM c)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Add Data from DataBase");
            }

        }

    
        [Produces("application/json")]
        [HttpDelete("DeleteProductById")]
        public ActionResult DeleteProductById(int id)
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
        [HttpPut("UpdateProductById")]
        public IActionResult UpdateProductById(int id, ProductVM p)
        {
            try
            {
                if (p == null)
                {
                    return BadRequest();
                }
                _repo.UpdateProductById(id, p);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Update Data from DataBase");
            }

        }
    }
}