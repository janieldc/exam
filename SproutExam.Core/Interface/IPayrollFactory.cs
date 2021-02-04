using System;
using System.Collections.Generic;
using System.Text;

namespace SproutExam.Core.Interface
{
    public interface IPayrollFactory
    {
        decimal CalculateRegularPayroll(decimal days_abset);

        decimal CalculateContractualPayroll(decimal days_present);
    }
}
