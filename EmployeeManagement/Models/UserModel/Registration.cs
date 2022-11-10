﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.UserModel
{
    public class Registration
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string password { get; set; } 
        [Required, Compare("password")]
        public string ConfirmPassword { get; set; }
    }
}
