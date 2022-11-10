using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.EmployeeModel
{
    public class Payment
    {
        [Key]
        public int Sno { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string IfscCode { get; set; }

    }
}
