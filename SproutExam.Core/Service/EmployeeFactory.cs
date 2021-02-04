using Newtonsoft.Json;
using SproutExam.Core.Interface;
using SproutExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SproutExam.Core.Service
{
    public class EmployeeFactory :  IEmployeeFactory
    {
        public List<Employee> CreateNewEmployee(Employee employeeModel, List<Employee> cachedEmployeeList)
        {
            var employeeList = cachedEmployeeList == null ? new List<Employee>() : cachedEmployeeList;

            employeeList.Add(employeeModel);

            return employeeList;
        }

        public Employee GetEmployeeByTIN(string tin, List<Employee> cachedEmployeeList)
        {
            if (cachedEmployeeList == null)
                return null;

            var employee = cachedEmployeeList.FirstOrDefault(x => x.tin == tin);

            return employee;
        }
    }
}
