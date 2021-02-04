using SproutExam.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SproutExam.Core.Service
{
    public class PayrollFactory : IPayrollFactory
    {
        public readonly decimal salary = 20000;
        public readonly decimal day_rate = 500;
        public readonly decimal tax = 0.12m;

        public decimal CalculateRegularPayroll(decimal days_abset)
        {
            var working_days = GetWorkingDays();

            if (days_abset >= working_days)
                return 0;

            var days_present = working_days - days_abset;
            var days_present_pay = salary / days_present;
            var taxed_pay = salary * tax;
            var net_pay = salary - days_present_pay - taxed_pay;

            return Math.Round(net_pay, 2);
        }

        public decimal CalculateContractualPayroll(decimal days_present)
        {
            var net_pay = day_rate * days_present;

            return Math.Round(net_pay,2);
        }

        private int GetWorkingDays()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<DateTime> dates = new List<DateTime>();
            for (int i = 1; i <= days; i++)
            {
                dates.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i));
            }

            int weekDays = dates.Where(d => d.DayOfWeek > DayOfWeek.Sunday & d.DayOfWeek < DayOfWeek.Saturday).Count();

            return weekDays;
        }
    }
}
