using System.Data.Entity;

namespace WpfApplication1
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("DbContext")
        { }
        
        public DbSet<Employee> Employees { get; set; } 
    }
}