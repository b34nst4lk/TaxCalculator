using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    class Program
    {
        static int[] minIncomeArray = new int[]
            {20000,30000,40000,80000,120000,160000,200000,320000};
        static double[] taxRateArray = new double[]
            {0.02, 0.035,0.07,0.115,0.15,0.17,0.18,0.20 };
        static int[] basePayableAmountArray = new int[]
            {0,200,550,3350,7950,13950,20750,42350 };

        static void Main()
        {
            int annualIncome = AskForIncome();
            int taxBracket = GetTaxBracket(annualIncome);
            double taxPayable = CalculateIncomeTax(annualIncome, taxBracket);
            PrintResult(annualIncome, taxPayable);
        }

        static int AskForIncome()
        {
            bool isInt = false;
            int rv = 0;
            while (!isInt)
            {
                Console.Write("Please enter your annual taxable income: ");
                isInt = Int32.TryParse(Console.ReadLine(), out rv);
            }
            return rv;
        }

        static int GetTaxBracket(int annualIncome)
        {
            int i;
            bool bracketFound = false;

            for (i = 7; i >= 0; i--)
            {
                if (minIncomeArray[i] < annualIncome)
                {
                    bracketFound = true;
                    break;
                }
            }

            if (bracketFound)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }

        static double CalculateIncomeTax(int annualIncome, int taxBracket)
        {
            if (taxBracket == -1)
            {
                return 0;
            }
            else
            {
                int minIncome = minIncomeArray[taxBracket];
                double taxRate = taxRateArray[taxBracket];
                int basePayable = basePayableAmountArray[taxBracket];

                return (annualIncome - minIncome) * taxRate + basePayable;
            }
        }

        static void PrintResult(int annualIncome, double taxPayable)
        {
            Console.WriteLine("For taxable annual income of {0:C}, the tax payable amount is {1:C}", annualIncome, taxPayable);
        }
    }
}
