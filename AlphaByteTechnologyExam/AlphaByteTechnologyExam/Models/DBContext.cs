using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlphaByteTechnologyExam.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("OracleDbContext")
        {
        }

        public DbSet<Employee> tEmployee { get; set; }
        public DbSet<Department> tDepartment { get; set; }
        public DbSet<Division> tDivision { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("INTERVIEW");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}