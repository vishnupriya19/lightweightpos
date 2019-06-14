using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Models
{
    public interface IEmployeeRepository
    {
        List<EmployeeContract> GetAllEmployee();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee DeleteEmployee(int empId, int merchId);
    }
}
