using EmployeeManagement.Data;
using EmployeeManagement.Models.EmployeeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        public UserDbContext obj = null;
        public LeaveController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("get_all_leaves")]
        public IActionResult GetAllleaves()
        {
            var employees = obj.leaveModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployeeDetails = employees
            });
        }
       
        [HttpPost("add_leave")]
        public IActionResult AddEmployee(LeaveModel employeeObj)
        {
            try
            {
                if (employeeObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    obj.leaveModels.Add(employeeObj);
                    obj.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messsage = "Leave  added Successfully"
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut("update_Leave")]
        public IActionResult UpdateEmployee(LeaveModel employeeObj)
        {
            if (employeeObj == null)
            {
                return BadRequest();
            }
            var user = obj.leaveModels.Where(x => x.Sno == employeeObj.Sno).FirstOrDefault();
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                obj.Entry(employeeObj);
                obj.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Updated Successfully"
                });
            }
        }
        [HttpDelete("delete_Leave/{Sno}")]
        public IActionResult DeleteLeave(int Sno)
        {
            var user = obj.leaveModels.Find(Sno);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user not Found"
                });
            }
            else
            {
                obj.Remove(user);
                obj.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "leave Deleted"
                });
            }
        }

    }
}
