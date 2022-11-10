using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.EmployeeModel
{
    public class LeaveModel
    {
        [Key]
        public int Sno { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
        public DateTime When { get; set; }
       
    }
}
