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
    public class DesignationController : ControllerBase
    {
        public UserDbContext obj = null;
        public DesignationController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("get_all_Designations")]
        public IActionResult GetAllEmployees()
        {
            var employees = obj.designations.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployeeDetails = employees
            });
        }
        [HttpPost("add_designation")]
        public IActionResult AddDesignation(Designation employeeObj)
        {
            try
            {
                if (employeeObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    obj.designations.Add(employeeObj);
                    obj.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messsage = "Added Successfully"
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut("update_Designation")]
        public IActionResult UpdateDesignation(Designation employeeObj)
        {
            if (employeeObj == null)
            {
                return BadRequest();
            }
            var user = obj.designations.FirstOrDefault(x => x.DesignationName == employeeObj.DesignationName);
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
                user.DesignationName = employeeObj.DesignationName;
                user.RoleName = employeeObj.RoleName;
                user.DepartmentName = employeeObj.DepartmentName;
                obj.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Designation Updated Successfully"
                });
            }
        }
        [HttpDelete("delete_designation/{DesignationName}")]
        public IActionResult Delete(string DesignationName)
        {
            var user = obj.designations.Where(x=>x.DesignationName== DesignationName).First();
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
                    Message = "Designation  Deleted"
                });
            }
        }
    }
}


