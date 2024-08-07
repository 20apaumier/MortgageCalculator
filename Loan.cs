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
        private readonly double _loanAmount;
        private readonly int _loanLengthInYears;
        private readonly double _yearlyInterestRate;

        public Loan(double loanAmount, int loanLengthInYears, double yearlyInterestRate)
        {
            // handle the inputs
            if (loanAmount <= 0)
            {
                throw new ArgumentException("The loan amount must be greater than 0");
            }
            else { _loanAmount = loanAmount; }

            if (loanLengthInYears <= 0)
            {
                throw new ArgumentException("The loan length in years must be greater than 0");
            }
            else { _loanLengthInYears = loanLengthInYears; }

            if (yearlyInterestRate < 0)
            {
                throw new ArgumentException("The yearly interest rate cannot be negative");
            }
            else { _yearlyInterestRate = yearlyInterestRate; }
        }

        // method to calculate monthly payment for mortgage
        public static double CalculateMonthlyMortgagePayment(double loanAmount, int loanLengthInYears, double yearlyInterestRate)
        {
            // do the conversions
            double monthlyInterestRate = yearlyInterestRate / 12 / 100; // convert to 0.05 format
            int totalPayments = loanLengthInYears * 12;
            
            // do the calculations
            double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalPayments)) / (Math.Pow(1 + monthlyInterestRate, totalPayments) - 1);
            return Math.Round(monthlyPayment, 2);
        }
    }
}
