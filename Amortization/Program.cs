using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amortization.Classes;

namespace Amortization
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                double c, p, i, regularPayment;
                RegularPaymentAmortization cfa = new RegularPaymentAmortization();

                try
                {
                    Console.WriteLine("Enter Loan Amount: " + Environment.NewLine);
                    c = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(Environment.NewLine + "Enter Loan Term: " + Environment.NewLine);
                    p = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(Environment.NewLine + "Enter Loan Rate: " + Environment.NewLine);
                    i = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    throw e;
                }

                double month = 12 * p;
                double interest_decimal = (i / 100) / 12;
                regularPayment = cfa.RegularPayment(c, interest_decimal, month);
                Console.WriteLine(Environment.NewLine + "Montly Regular Payment: " + regularPayment.ToString("#,##0.00"));

                string header = string.Format("\n{0,1}{1,15}{2,15}{3,15}{4,15}\n",
                                              "Month", "Ending Balance", "Principal", "Interest (" + i + "%)", "  RegularPayment(Payment)");
                Console.WriteLine(header);

                for (int plz = 1; plz <= month; plz++)
                {

                    double rate = interest_decimal * c;
                    double amortizacion = (regularPayment - rate);
                    double saldoDeuda = (c -= amortizacion);

                    string output = string.Format("\n{0,1}{1,15}{2,15}{3,15}{4,15}\n",
                                              plz, saldoDeuda.ToString("#,##0.00"), amortizacion.ToString("#,##0.00"), rate.ToString("#,##0.00"), regularPayment.ToString("#,##0.00"));

                    Console.WriteLine(output);
                }

                Console.WriteLine(Environment.NewLine + "To exit press button X. To Continue press any other button....");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.X);
        }
    }
}
