using System;

namespace Final
{
    class Contractor
    {
        private string contractorName;
        private int contractorNumber;
        private DateTime startDate;
        public Contractor (string name, int number, DateTime startDate)
        {
            this.contractorName = name;
            this.contractorNumber = number;
            this.startDate = startDate;
        }

        
        
        public string GetName()
        {
            return contractorName;
        }
        public int GetNumber()
        {
            return contractorNumber;
        }
        public DateTime GetStartDate()
        {
            return startDate;
        }


        public void SetName(string name)
        {
            contractorName = name;
        }
        public void SetNumber(int number)
        {
            contractorNumber = number;
        }
        public void SetStartDate(DateTime startDate)
        {
            this.startDate = startDate;
        }




    }
    class Subcontractor : Contractor
    {
        private int shift; // 1 = day, 2 = night
        private double hourlyPayRate;

        public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyPayRate)
            : base(name, number, startDate)
        {
            this.shift =shift;
            this.hourlyPayRate =hourlyPayRate;
        }

        public int GetShift()
        {
            return shift;
        }
        public double GetHourlyPayRate()
        {
            return hourlyPayRate;
        }

        public float CalculatePay(double hoursWorked)
        {
            double pay = hourlyPayRate * hoursWorked; 
            if (shift == 2)
                pay *= 1.03;
            return (float)pay;
        }
    }

    class Program
    {
        public static void Logs(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        static void Main(string[] args)
        {
            string another = "yes";

            while (another.ToLower() == "yes")
            {
                try
                {
                   Console.Write("Enter Contractor Name: ");
                   string name = Console.ReadLine();

                    Console.Write("Enter contractor number: ");
                    int number = int.Parse(Console.ReadLine());

                    Console.Write("Start Date (yyyy-mm-dd): ");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter shift (1 = Day, 2 = Night): ");
                    int shift = int.Parse(Console.ReadLine());

                    Console.Write("Enter hourly pay rate: ");
                    double hourlyPayRate = double.Parse(Console.ReadLine());

                    Console.Write("Enter hours worked: ");
                    double hours = double.Parse(Console.ReadLine());

                    Subcontractor sub = new Subcontractor(name, number, startDate, shift, hourlyPayRate);
                    float totalPay = sub.CalculatePay(hours);

                    Console.WriteLine($"\nSubcontractor Summary");
                    Console.WriteLine($"Name: {sub.GetName()}");
                    Console.WriteLine($"Number: {sub.GetNumber()}");
                    Console.WriteLine($"Start Date: {sub.GetStartDate():yyyy-MM-dd}");
                    Console.WriteLine($"Shift: {(sub.GetShift() == 1 ? "Day" : "Night")}");
                    Console.WriteLine($"Total Pay: {totalPay:C}\n");
                }
                catch (Exception e)
                {
                    Logs(e);
                }

                Console.Write("Add another subcontractor? (yes/no): ");
                another = Console.ReadLine();
            }

        }
    }
}