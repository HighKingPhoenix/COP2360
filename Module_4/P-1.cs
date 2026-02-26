using Sys = System;

namespace P1
{
    public class Division
    {
        private int result;
        public void Excute()
        {
            Sys.Console.WriteLine("Enter The First Number: ");
            int number1 = Sys.Convert.ToInt32(Sys.Console.ReadLine());

            Sys.Console.WriteLine("Enter The Second Number: ");
            int number2 = Sys.Convert.ToInt32(Sys.Console.ReadLine());

            result = number1 / number2;
        }
        public void Display()
        {
            Sys.Console.WriteLine($"The Value is: {result}");
        }
    }
    



    class Program
    {

        public static void Logs(Sys.Exception e)
        {
                Sys.Console.WriteLine($"Error: {e.Message}");
        }
        
        static void Main(string [] args)
        {
            Division div = new Division();

            try
            {
                div.Excute();
                div.Display();
            }
            catch (Sys.DivideByZeroException e)
            {
                Sys.Console.WriteLine("You Cannot Divide by Zero");
                Logs(e);
            }
            catch (Sys.FormatException e)
            {
                Sys.Console.WriteLine("Enter Valid Numbers Only");
                Logs(e); 
            }
            catch (Sys.OverflowException e)
            {
                Sys.Console.WriteLine("The Number is Too Big");
                Logs(e);
            }
            catch (Sys.Exception e)
            {
                Sys.Console.WriteLine("Something Went Wrong");
                Logs(e);
            }
        }

        /*static void Main(string [] args)
        {
            Division div = new Division();
            try
            {
                div.Excute();
                div.Display();
            }
            catch (Sys.Exception e)
            {
                string userMessage = e switch
                {
                    Sys.DivideByZeroException => "You Cannot Divide by Zero";
                    Sys.FormatException => "Enter Valid Numbers Only",
                    Sys.OverflowException => "The Number is Too Big",
                    _ => "An unknown error occurred."
                };
                Sys.Console.WriteLine(userMessage);
                Logs(e);
            }
        }*/

    }
}