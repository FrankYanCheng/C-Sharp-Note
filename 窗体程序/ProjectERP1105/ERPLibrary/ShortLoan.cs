using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class ShortLoan : ILoan
    {
        public double AnnualInterest
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float YearLimit
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LoanLimitRate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Repayment(ref float cash)
        {
            throw new NotImplementedException();
        }
    }
}
