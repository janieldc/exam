using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SproutExam.Core.Interface;
using SproutExam.Data.Models;
using SproutExam.Data.Utilities;
using System;
using System.Collections.Generic;

namespace SproutExam.Controllers
{
    public class EmployeeController : Controller
    {
        private IMemoryCache _cache;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IPayrollFactory _payrollFactory;

        public EmployeeController(
            IMemoryCache memoryCache,
            IEmployeeFactory employeeFactory,
            IPayrollFactory payrollFactory)
        {
            _cache = memoryCache;
            _employeeFactory = employeeFactory;
            _payrollFactory = payrollFactory;
        }

        public ActionResult Index()
        {
            var model = _cache.Get("_EmployeeList");

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            List<Employee> cacheEntry;

            try
            {
                if(ModelState.IsValid)
                {
                    var cachedEmployeeList = _cache.Get<List<Employee>>(CacheKeys.EmployeeList);

                    if (_employeeFactory.GetEmployeeByTIN(model.tin, cachedEmployeeList) != null)
                    {
                        ModelState.AddModelError(model.tin, "Employee with the same TIN already exists");
                        return View(model);
                    }

                    var employee = _employeeFactory.CreateNewEmployee(model, cachedEmployeeList);

                    cacheEntry = employee;
                    _cache.Set(CacheKeys.EmployeeList, cacheEntry);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                //do some error logging here
                return RedirectToAction(nameof(Create));
            }
        }



        public ActionResult Edit(string tin)
        {
            try
            {
                var cachedEmployeeList = _cache.Get<List<Employee>>(CacheKeys.EmployeeList);

                var model = _employeeFactory.GetEmployeeByTIN(tin, cachedEmployeeList);

                return View(model);
            }
            catch
            {
                //do some error logging here
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {
            try
            {
                if (model.employee_type == EmployeeTypeEnum.Regular)
                {
                    model.salary = _payrollFactory.CalculateRegularPayroll(model.days_absent);
                }
                else
                {
                    model.salary = _payrollFactory.CalculateContractualPayroll(model.days_worked);
                }
            }
            catch 
            {
                //do some error logging here
            }

            return View(model);
        }
    }
}
