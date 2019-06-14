using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private featherDBContext context;

        public SQLEmployeeRepository(featherDBContext context)
        {
            this.context = context;
        }
        public List<EmployeeContract> GetAllEmployee()
        {
            var emps= context.Employee.Include(p=>p.Merchant).Include(p=>p.Designation).ToList();

            var employeeData = (from data in emps
                                select new EmployeeContract
                                {
                                    EmployeeId = data.EmployeeId,
                                    DesignantionName = data.Designation.Name,
                                    EmailId = data.Email,
                                    EmployeeName = data.Name,
                                    MerchantId = data.MerchantId,
                                    DateOfJoining = data.Dateofjoining,
                                    Salary = data.Salary,
                                    MerchantName = data.Merchant.Name,
                                    Password = data.Password,
                                    UserName = data.Username,
                                    PhoneNumber = data.Phone,
                                    DesignationId = data.DesignationId
                                   //EmployeeId = data.EmployeeId,
                               }).ToList(); 

            return employeeData;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employee.Find(id);
        }
        public Employee AddEmployee(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int empId, int merchId)
        {
            var employee = context.Employee.FirstOrDefault(e => e.EmployeeId == empId && e.MerchantId == merchId);

            if (employee != null)
            {
                context.Employee.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }
    }
}
