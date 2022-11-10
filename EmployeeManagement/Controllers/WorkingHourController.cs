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
    public class WorkingHourController : ControllerBase
    {
        public UserDbContext obj = null;
        public WorkingHourController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("get_all_workinghours")]
        public IActionResult GetAllEmployees()
        {
            var employees = obj.workingHours.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployeeDetails = employees
            });
        }
        //[HttpGet("get_employee/id")]
        //public IActionResult Getemployee(int EmployeeId)
        //{
        //    var employee = obj.employees.Find(EmployeeId);
        //    if (employee == null)
        //    {
        //        return NotFound(new
        //        {
        //            StatusCode = 404,
        //            Message = "User Not Found"
        //        });
        //    }
        //    else
        //    {
        //        return Ok(employee);

        //    }
        //}
        [HttpPost("add_workingHour")]
        public IActionResult AddEmployee(WorkingHour employeeObj)
        {
            try
            {
                if (employeeObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    obj.workingHours.Add(employeeObj);
                    obj.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messsage = "Employee added Successfully"
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut("update/{Sno}")]
        public IActionResult UpdateEmployee(WorkingHour employeeObj)
        {
            if (employeeObj == null)
            {
                return BadRequest();
            }
            var user = obj.workingHours.FirstOrDefault(x => x.Sno == employeeObj.Sno);
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
                user.CompanyMonthlyHours = employeeObj.CompanyMonthlyHours;
                user.CompanyMonthlyHours = employeeObj.EmployeeMonthlyHours;
                obj.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Updated Successfully"
                });
            }
        }
        [HttpDelete("delete/{SNO}")]
        public IActionResult DeleteEmployee(int SNO)
        {
            var user = obj.workingHours.Find(SNO);
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
                    Message = "EmployeeAPI Deleted"
                });
            }
        }

    }
}

