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
    public class EmployeeController : ControllerBase
    {
        public UserDbContext obj = null;
        public EmployeeController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("get_all_employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = obj.employees.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployeeDetails = employees
            });
        }
        [HttpGet("get_employee/id")]
        public IActionResult Getemployee(int EmployeeId)
        {
            var employee = obj.employees.Find(EmployeeId);
            if (employee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                return Ok(employee);

            }
        }
        [HttpPost("add_employee")]
        public IActionResult AddEmployee(Employee employeeObj)
        {
            try
            {
                if (employeeObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    obj.employees.Add(employeeObj);
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

                throw ex;
            }

        }
        [HttpPut("update_employee")]
        public IActionResult UpdateEmployee(Employee employeeObj)
        {
            if (employeeObj == null)
            {
                return BadRequest();
            }
            var user = obj.employees.FirstOrDefault(x => x.EmployeeID == employeeObj.EmployeeID);
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
                user.EmployeeID = employeeObj.EmployeeID;
                user.EmployeeName = employeeObj.EmployeeName;
                user.PhoneNumber = employeeObj.PhoneNumber;
                user.MailId = employeeObj.MailId;
                user.Address = employeeObj.Address;

                obj.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee Updated Successfully"
                });
            }
        }
        [HttpDelete("delete_employee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var user = obj.employees.Find(id);
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
