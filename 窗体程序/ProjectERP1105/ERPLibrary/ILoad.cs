using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public interface ILoan
    {
        float AnnualInterest
        {
            get;
            set;
        }

        float YearLimit
        {
            get;
            set;
        }

        float LoanLimitRate
        {
            get;
            set;
        }

        void Repayment(ref float cash);
    }
}
