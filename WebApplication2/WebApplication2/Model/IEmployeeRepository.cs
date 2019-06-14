using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public interface IEmployeeRepository
    {
        List<EmployeeContract> GetAllEmployee(int id);
        EmployeeContract GetEmployee(int merchId, int empId);
        Employee AddEmployee(int id, Employee employee);
        Employee DeleteEmployee(int merchId, int empId);
        LoginReturn ValidateLogin(int id, LoginContract loginContract);
    }
} 
