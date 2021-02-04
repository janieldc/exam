using NUnit.Framework;
using SproutExam.Core.Service;
using SproutExam.Data.Models;
using System;
using System.Collections.Generic;

namespace SproutExam.Test
{
    public class EmployeeCreateTest
    {
        [Test]
        public void TestCreate()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = new Employee();

            employee.name = "John";
            employee.birth_date = DateTime.Now;
            employee.employee_type = EmployeeTypeEnum.Regular;
            employee.tin = "000111222555";

            List<Employee> employeeList = new List<Employee>();

            var result = employeeFactory.CreateNewEmployee(employee, employeeList);

            Assert.IsFalse(employee == null, "Employee is empty");
            Assert.IsFalse(result == null, "Employee is empty");
            Assert.IsFalse(employee == null, "Employee is empty");
            Assert.Pass();


        }
    }
}
