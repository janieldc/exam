using SproutExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SproutExam.Core.Interface
{
    public interface IEmployeeFactory
    {
        List<Employee> CreateNewEmployee(Employee employeeModel, List<Employee> cachedEmployeeList);

        Employee GetEmployeeByTIN(string tin, List<Employee> cachedEmployeeList);
    }
}
