using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPLibrary
{
    public class Account
    {
        public Account()
        {
            yearLimit = new int();
            fund = new int();
            accountType = new AccountType();
        }
        private int yearLimit;
        private double fund;
        private AccountType accountType;

        public double Fund
        {
            get { return fund; }
            set { fund = value; }
        }

        public int YearLimit
        {
            get { return yearLimit; }
            set { yearLimit = value; }
        }
        public AccountType AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;
            }
        }
        public double UpdateAccount(List<Account> listAccount,AccountType accountType,ref double cash)
        {
            double Fund = 0;
     
            if (accountType == AccountType.Pay)
            {
                for (int i = 0; i < listAccount.Count; i++)
                {
                    listAccount[i].YearLimit--;
                }
                for (int j = listAccount.Count-1; j >= 0; j--)
                {
                    if (listAccount[j].YearLimit == 0)
                    {
                        cash -= listAccount[j].Fund;
                        Fund += listAccount[j].Fund;
                        listAccount.Remove(listAccount[j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < listAccount.Count; i++)
                {
                    listAccount[i].YearLimit--;
                }
                for (int j = listAccount.Count-1; j >=0; j--)
                {
                    if (listAccount[j].YearLimit == 0)
                    {
                        cash += listAccount[j].Fund;
                        Fund += listAccount[j].Fund; ;
                        listAccount.Remove(listAccount[j]);
                    }
                }
            }
            return Fund;
        }
    }
}
