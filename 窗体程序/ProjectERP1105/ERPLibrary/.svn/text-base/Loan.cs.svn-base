using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class Loan : ILoan
    {
        public Loan()
        {
            annualInterest = new float();
            yearLimit = new float();
            loanLimitRate = string.Empty;
            loanAmount = new float();
        }
        private double annualInterest;
        private float yearLimit;
        private string loanLimitRate;
        private float loanAmount;

        public double AnnualInterest
        {
            get
            {
                return annualInterest;
            }
            set
            {
                annualInterest = value;
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
                yearLimit = value;
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
                loanLimitRate = value;
            }
        }

        public float LoanAmount
        {
            get
            {
                return loanAmount;
            }
            set
            {
                loanAmount = value;
            }
        }

        public void Repayment(ref float cash)
        {
        }
    }
}
