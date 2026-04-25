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

    }

    class Program
    {
        public static void Logs(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        static void Main(string[] args)
        {

        }
    }
}