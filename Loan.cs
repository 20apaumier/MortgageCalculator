using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    public class Loan
    {
        // Loan class should accept loan amount, loan length in months, and monthly interest rate in a constructor
        private readonly decimal _loanAmount;
        private readonly int _loanLengthInMonths;
        private readonly decimal _monthlyInterestRate;

        public Loan(decimal loanAmount, int loanLengthInMonths, decimal monthlyInterestRate)
        {
            // handle the inputs
            if (loanAmount <= 0)
            {
                throw new ArgumentException("The loan amount must be greater than 0");
            }
            else { _loanAmount = loanAmount; }

            if (loanLengthInMonths <= 0)
            {
                throw new ArgumentException("The loan length in months must be greater than 0");
            }
            else { _loanLengthInMonths = loanLengthInMonths; }

            if (monthlyInterestRate < 0)
            {
                throw new ArgumentException("The monthly interest rate cannot be negative");
            }
            else { _monthlyInterestRate = monthlyInterestRate; }
        }

        // method to calculate monthly payment for mortgage
        public static decimal CalculateMonthlyMortgagePayment(decimal loanAmount, int loanLengthInMonths, decimal monthlyInterestRate)
        {
            // do the calculations
            decimal numerator = loanAmount * (monthlyInterestRate / 1200);
            decimal denominator = 1 - (1 + (monthlyInterestRate / 1200) * 60);
            return Math.Abs(numerator / denominator);
        }
    }
}
