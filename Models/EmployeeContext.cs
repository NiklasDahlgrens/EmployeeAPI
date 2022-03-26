using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
    }
}
