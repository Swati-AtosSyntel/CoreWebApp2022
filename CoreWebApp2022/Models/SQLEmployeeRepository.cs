using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp2022.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext context;

        public SQLEmployeeRepository(EmployeeDBContext context)
        {
            this.context = context;
        }
        public void AddEmployee(Employee e)
        {
            context.employees.Add(e);
            context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee e = context.employees.Find(id);
            if (e != null)
            {
                context.employees.Remove(e);
                context.SaveChanges();
            }
        }

        public Employee GetEmployee(int id)
        {
            return context.employees.Find(id);
        }

        public List<Employee> GetEmployees()
        {
            return context.employees.ToList(); ;
        }

        public void UpdateEmployee(Employee newEmployee)
        {
           
        }
    }
}
