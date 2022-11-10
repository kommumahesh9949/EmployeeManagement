using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.EmployeeModel
{
    public class Employee
    {
        [Key]
        public int SerialNo { get; set; }
        public string EmployeeID { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "USE ALPHABETS ONLY PLEASE")]
        public string EmployeeName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string MailId { get; set; }
        public string Address { get; set; }
    }
}
