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
    public class PaymentController : ControllerBase
    {
        public UserDbContext obj = null;
        public PaymentController(UserDbContext _obj)
        {
            obj = _obj;
        }
        [HttpGet("get_all_Details")]
        public IActionResult GetAllEmployees()
        {
            var employees = obj.payments.AsQueryable();
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
        [HttpPost("add_Payment")]
        public IActionResult AddEmployee(Payment employeeObj)
        {
            try
            {
                if (employeeObj == null)
                {
                    return BadRequest();
                }
                else
                {
                    obj.payments.Add(employeeObj);
                    obj.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messsage = "Payment added Successfully"
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut("update")]
        public IActionResult Update(Payment employeeObj)
        {
            if (employeeObj == null)
            {
                return BadRequest();
            }
            var user = obj.payments.FirstOrDefault(x => x.Sno == employeeObj.Sno);
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
                user.AccountType = employeeObj.AccountType;
                user.AccountNumber = employeeObj.AccountNumber;
                user.IfscCode = employeeObj.IfscCode;
                obj.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Updated Successfully"
                });
            }
        }
        [HttpDelete("delete/{Sno}")]
        public IActionResult Delete(int Sno)
        {
            var user = obj.payments.Find(Sno);
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
                    Message = "Payment Deleted"
                });
            }
        }

    }
}
