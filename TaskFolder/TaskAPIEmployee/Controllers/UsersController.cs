using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Repository;
using DL.Model;
using DL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPIEmployee.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RepoUserInfo _repo;

        public UsersController(RepoUserInfo repo)
        {
            _repo = repo;
        }

        
        [Produces("application/json")]
        [HttpGet("GetAllUser")]
        public ActionResult GetAllUser()
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
      
        [Produces("application/json")]
        [HttpGet("GetUsertById")]
        public ActionResult GetUsertById(int id)
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

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("Register")]
        public IActionResult Register(UserInfo u)
        {
            try
            {
                if (u == null)
                {
                    return BadRequest();
                }
                _repo.Register(u);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Add Data from DataBase");
            }

        }
       
        [Produces("application/json")]
        [HttpDelete("DeleteUserById")]
        public ActionResult DeleteUserById(int id)
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
        [HttpPut("UpdateUserById")]
        public IActionResult UpdateUserById(int id, UserInfo u)
        {
            try
            {
                if (u == null)
                {
                    return BadRequest();
                }
                _repo.UpdateUserById(id, u);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Update Data from DataBase");
            }

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(UserInfo u)
        {
            try
            {
                if (u == null)
                {
                    return BadRequest();
                }
             var result =  await _repo.LoginUser(u);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from DataBase");
            }

        }


    }
}