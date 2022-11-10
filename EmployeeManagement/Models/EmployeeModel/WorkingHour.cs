using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.EmployeeModel
{
    public class WorkingHour
    {
        [Key]
        public int Sno { get; set; }
        public string CompanyMonthlyHours { get; set; }
        public string EmployeeMonthlyHours { get; set; }
    }
}
