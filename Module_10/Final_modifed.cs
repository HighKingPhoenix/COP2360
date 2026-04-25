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
        private TimeSpan shiftStart;
        private TimeSpan shiftEnd;
        private double hourlyPayRate;

        public Subcontractor(string name, int number, DateTime startDate, TimeSpan shiftStart, TimeSpan shiftEnd, double hourlyPayRate)
            : base(name, number, startDate)
        {
            this.shiftStart = shiftStart;
            this.shiftEnd = shiftEnd;
            this.hourlyPayRate =hourlyPayRate;
        }

        public TimeSpan GetShiftStart()
        {return shiftStart;}
        public TimeSpan GetShiftEnd()
        {return shiftEnd;}
        public double GetHourlyPayRate()
        {
            return hourlyPayRate;
        }

        public double GetHoursWorked()
        {
            if (shiftEnd > shiftStart)
            {return (shiftEnd - shiftStart).TotalHours;}
            else
                {return (TimeSpan.FromHours(24) - shiftStart + shiftEnd).TotalHours;}
        }

        public bool IsNightShift()
        {
            TimeSpan nightStart = new TimeSpan(18,0,0);
            TimeSpan nightEnd = new TimeSpan(6, 0, 0);
            return shiftStart >= nightStart || shiftStart <nightEnd;
        }

        public float CalculatePay()
        {
            TimeSpan nightStart = new TimeSpan(18, 0, 0);  // 6:00 PM
            TimeSpan nightEnd = new TimeSpan(6, 0, 0);     // 6:00 AM

            double dayHours = 0;
            double nightHours = 0;
            if (shiftStart >= nightEnd && shiftEnd <= nightStart)
            {
                dayHours = (shiftEnd - shiftStart).TotalHours;
            }
            else if (shiftStart >= nightStart || shiftEnd <= nightEnd)
            {
                nightHours = GetHoursWorked();
            }
            else if (shiftStart < nightStart && shiftEnd > nightStart)
            {
                
                dayHours = (nightStart - shiftStart).TotalHours;
                nightHours = (shiftEnd - nightStart).TotalHours;
            }

            double dayPay = dayHours * hourlyPayRate;
            double nightPay = nightHours * hourlyPayRate * 1.03;
            return (float)(dayPay + nightPay);

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

                    Console.Write("Enter shift start time (HH:MM): ");
                    TimeSpan shiftStart = TimeSpan.Parse(Console.ReadLine());

                    Console.Write("Enter shift end time (HH:MM): ");
                    TimeSpan shiftEnd = TimeSpan.Parse(Console.ReadLine());

                    Console.Write("Enter hourly pay rate: ");
                    double hourlyPayRate = double.Parse(Console.ReadLine());

                    Subcontractor sub = new Subcontractor(name, number, startDate, shiftStart, shiftEnd, hourlyPayRate);
                    float totalPay = sub.CalculatePay();

                    Console.WriteLine($"\nSubcontractor Summary");
                    Console.WriteLine($"Name: {sub.GetName()}");
                    Console.WriteLine($"Number: {sub.GetNumber()}");
                    Console.WriteLine($"Start Date: {sub.GetStartDate():yyyy-MM-dd}");
                    Console.WriteLine($"Hours Worked: {sub.GetHoursWorked():F2}");
                    Console.WriteLine($"Night Shift Differential Applied: {(sub.IsNightShift() ? "Yes" : "No")}");
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