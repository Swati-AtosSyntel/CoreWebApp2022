using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp2022.Models
{
   public interface IEmployeeRepository
    {
        void AddEmployee(Employee e);
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee newEmployee);
    }
}
