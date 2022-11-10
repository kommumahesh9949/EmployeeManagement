using EmployeeManagement.Data;
using EmployeeManagement.Models.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserDbContext obj = null;
        public UserController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = obj.users.AsQueryable();
            return Ok(userdetails);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(Registration p)
        {
            if (obj.users.Any(u => u.Email == p.Email))
            {
                return BadRequest("Account Already Exist");
            }
            var user = new User
            {
                Email = p.Email,
                password = p.password

            };
            obj.users.Add(user);

            await obj.SaveChangesAsync();


            return Ok(new
            {
                StatusCode = 200,
                Messsage = "SignIn Successfully"
            });
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(Login p)
        {
            try
            {
                var user = await obj.users.FirstOrDefaultAsync(u => u.Email == p.Email);

                if (user == null)
                {
                    return BadRequest("user not found");
                }

                if (user.password != p.password)
                {
                    return BadRequest("PASSWORD INCORRECT DEAR!");
                }

                return Ok(new
                {
                    StatusCode = 200,
                    Messsage = "login Successfully"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }


        }
    }
}
