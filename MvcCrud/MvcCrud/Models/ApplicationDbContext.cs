using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcCrud.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("MVCCrud")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}