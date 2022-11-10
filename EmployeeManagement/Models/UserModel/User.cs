using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.UserModel
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
