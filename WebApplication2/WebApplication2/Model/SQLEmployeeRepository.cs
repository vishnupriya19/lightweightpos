using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<EmployeeContract> GetAllEmployee(int id)
        {
            var emps = context.Employee.Include(p => p.Merchant).Include(p => p.Designation).Where(e => e.MerchantId == id).ToList();

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

        public EmployeeContract GetEmployee(int merchId, int empId)
        {
            var emp = context.Employee.Include(e => e.Merchant).Include(e => e.Designation).FirstOrDefault(e => e.EmployeeId == empId && e.MerchantId == merchId);
            if (emp != null)
            {
                EmployeeContract employeeContract = new EmployeeContract();
                employeeContract.EmployeeId = emp.EmployeeId;
                employeeContract.EmployeeName = emp.Name;
                employeeContract.UserName = emp.Username;
                employeeContract.Password = emp.Password;
                employeeContract.EmailId = emp.Email;
                employeeContract.PhoneNumber = emp.Phone;
                employeeContract.Salary = emp.Salary;
                employeeContract.DateOfJoining = emp.Dateofjoining;
                employeeContract.DesignationId = emp.DesignationId;
                employeeContract.DesignantionName = emp.Designation.Name;
                employeeContract.MerchantId = emp.MerchantId;
                employeeContract.MerchantName = emp.Merchant.Name;
                return employeeContract;
            }
            return null;
        }
        public Employee AddEmployee(int id, Employee employee)
        {
            employee.MerchantId = id;
            context.Employee.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int merchId, int empId)
        {
            var employee = context.Employee.FirstOrDefault(e => e.EmployeeId == empId && e.MerchantId == merchId);

            if (employee != null)
            {
                context.Employee.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public LoginReturn ValidateLogin(int id, LoginContract loginContract)
        {
            var emp = context.Employee.Include(e => e.Designation).FirstOrDefault(e => e.Username == loginContract.Username && e.Password == loginContract.Password && e.MerchantId == id);

            LoginReturn loginReturn = new LoginReturn();
            if (emp != null)
                loginReturn.designation = emp.Designation.Name;
            return loginReturn;
        }

    }
}
