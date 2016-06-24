using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Classes
{
    class RegularPaymentAmortization
    {
        public double RegularPayment(double loanAmount, double interestRate, double loanTerm)
        {
            //double x = loanAmount * (interestRate / 100) * Math.Pow((1 + (interestRate / 100)), loanTerm) / (Math.Pow((1 + (interestRate / 100)), loanTerm) - 1);

            //return x;

            double fee;

            fee = loanAmount * (interestRate / (1 - Math.Pow((1 + interestRate), -loanTerm)));

            return (fee);
        }
    }
}
