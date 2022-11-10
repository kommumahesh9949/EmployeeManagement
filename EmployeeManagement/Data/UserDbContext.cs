using EmployeeManagement.Models.EmployeeModel;
using EmployeeManagement.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options):base(options)
        {

        }
       public  DbSet<User> users { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Designation>designations { get; set; }
        public DbSet<LeaveModel> leaveModels { get; set; }

        public DbSet<WorkingHour> workingHours { get; set; }
        public DbSet<Payment> payments { get; set; }

    }
}
