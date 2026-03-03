using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
    internal interface InterTransaction
    {
        void Deposit(int amt);
        void Withdrawal(int amt);
    }

}
