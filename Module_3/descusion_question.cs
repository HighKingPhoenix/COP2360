using System.Security.Cryptography;
using sys = System;

namespace COP2360
{
    public class Person
    {
        public string Name;
        public int Age;
    }

    public class SimpleInterest : Person
    {
        public double principle;
        public double annualRate;

        public int yearsInvested;

        public double CalculateValue()
        {
            return principle * annualRate *yearsInvested;
        }
    }



    class Program
    {
        static void Main(string [] args)
        {
            SimpleInterest myInvestment = new SimpleInterest{Name="Mark", Age=18, principle=10000, annualRate=0.0405,yearsInvested = 6};
            int futureAge = myInvestment.Age + myInvestment.yearsInvested;
            double valueReturn = myInvestment.CalculateValue();
            sys.Console.WriteLine($"{myInvestment.Name} at {futureAge} earned {valueReturn}");
            
        }
    }
}