using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class LongLoan_15 : ILoan
    {
        public LongLoan_15()
        {
            annualInterest = new float();
            yearLimit = new float();
            loanLimitRate = string.Empty;
        }
        double annualInterest;
        float yearLimit;
        string loanLimitRate;

        public double AnnualInterest
        {
            get
            {
                return annualInterest;
            }
            set
            {
                annualInterest=value;
            }
        }

        public float YearLimit
        {
            get
            {
                return yearLimit;
            }
            set
            {
                yearLimit=value;
            }
        }

        public string LoanLimitRate
        {
            get
            {
                return loanLimitRate;
            }
            set
            {
                loanLimitRate=value;
            }
        }

        public void Repayment(ref float cash)
        {
        }
    }
}
