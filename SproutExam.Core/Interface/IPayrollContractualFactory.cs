using System;
using System.Collections.Generic;
using System.Text;

namespace SproutExam.Core.Interface
{
    interface IPayrollContractualFactory
    {
        decimal CalculatePayroll(decimal days_abset);
    }
}
