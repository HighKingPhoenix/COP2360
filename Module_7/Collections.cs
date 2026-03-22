using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class DictionaryManager
    {
        private Dictionary<string, string> wishlist = new Dictionary<string, string>();

        //Create Default Dictionary
        public void Populate()
        {
            wishlist["David"] = "ROG Ally";
            wishlist["Alica"] = "IPhone 17 Pro Max";
            wishlist["Claire"] = "Audi R7";
        }

        //Display Contents of the Dictionary
        public void Display()
        {
            if (wishlist.Count == 0)
            {
                Console.WriteLine("The Dicttionary is Empty please Pupulate or add new Key Value Pair");
                return;
            }

            foreach (KeyValuePair<string, string> wishlistEntry in wishlist)
            {
                Console.WriteLine($"Name: {wishlistEntry.Key} | Whish: {wishlistEntry.Value}");
            }
        }

        //Remove a Key from Dictionary
        public void RemoveKey(string key)
        {
            if (wishlist.Remove(key))
            {
                Console.WriteLine($"{key} is Removed");
            }
            else
            {
                Console.WriteLine($"{key} is not found");
            }
        }

        //Add New Key and Value to the Dictionary
        public void AddNew(string key, string Value)
        {
            if (!wishlist.ContainsKey(key))
            {
                wishlist.Add(key, Value);
                Console.WriteLine($"{key} has been added");
            }
            else
            {
                Console.WriteLine($"{key} Already Exists");
            }
        }

        //Append value to to existing key after checking if key exisit
        public void AppendValue(string key, String appendedValue)
        {
            if (wishlist.TryGetValue(key, out string existingValue))
            {
                wishlist[key] = $"{existingValue} , {appendedValue}";
                Console.WriteLine($"{key} Value Updated");
            }
            else
            {
                Console.WriteLine($"{key} Not Found in Wish List");

            }
        }

        //Sort by Keys in Dictionary by Alphabetical Order
        public void DisplaySorted()
        {
            /*var sortedKeys = wishlist.Keys.ToList();
            sortedKeys.Sort();

            foreach (var key in sortedKeys)
            {
                Console.WriteLine($"{key}: {wishlist[key]}");
            }*/


            foreach (var keyValue in wishlist.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }

        }
    }


    class Program
    {
        //Outputs Error from Try Catch
        public static void Logs(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        static void Main(string[] args)
        {
            DictionaryManager manage = new DictionaryManager();
            bool running = true;
            //As long as running is True Application will keep Running until user tell it to quit
            while (running)
            {
                Console.WriteLine("""
                Choices:
                (a) Create Default Dictionary
                (b) Display Dictionary
                (c) Remove a Key from Dictionary
                (d) Add New Key to Dictionary
                (e) Append Value to Key
                (f) Sort by Keys in Dictionary
                (q) Quit
                """);

                Console.WriteLine("Choice: ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "a":
                        manage.Populate();
                        break;
                    case "b":
                        manage.Display();
                        break;
                    case "c":
                        try
                        {
                            Console.Write("Enter Name of the person whos wish list you want to remove: ");
                            string nRemove = Console.ReadLine();
                            //Checks if user input is not Empty or Null
                            if (string.IsNullOrEmpty(nRemove))
                            {
                                throw new Exception("Name Cannot Be Blank");
                            }
                            //Checks if user input is not a number
                            else if (nRemove.Any(char.IsDigit))
                            {
                                throw new Exception("Name Cannot Contain Numbers");
                            }
                            manage.RemoveKey(nRemove);  
                        }
                        catch (Exception ex)
                        {
                            Logs(ex);
                        }
                        
                        break;
                    case "d":
                        try
                        {
                            Console.Write("Name: ");
                            string n = Console.ReadLine();
                            //Checks if user input is not Empty or Null
                            if (string.IsNullOrEmpty(n))
                            {
                                throw new Exception("Name Cannot Be Blank");
                            }
                            //Checks if user input is not a number
                            else if (n.Any(char.IsDigit))
                            {
                                throw new Exception("Name Cannot Contain Numbers");
                            }
                            Console.Write("Wish: ");
                            string w = Console.ReadLine();
                            manage.AddNew(n,w);  
                        }
                        catch (Exception ex)
                        {
                            Logs(ex);
                        }
                        
                        break;
                    case "e":
                        try
                        {
                            Console.Write("Name: ");
                            string person = Console.ReadLine();
                            //Checks if user input is not Empty or Null
                            if (string.IsNullOrEmpty(person))
                            {
                                throw new Exception("Name Cannot Be Blank");
                            }
                            //Checks if user input is not a number
                            else if (person.Any(char.IsDigit))
                            {
                                throw new Exception("Name Cannot Contain Numbers");
                            }
                            Console.Write("Aditional Wish: ");
                            string wish = Console.ReadLine();
                            manage.AppendValue(person,wish);
                        }
                        catch (Exception ex)
                        {
                            Logs(ex);
                        }
                        
                        break;
                    case "f":
                        manage.DisplaySorted();
                        break;
                    case "q":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ivalid Choice");
                        break;

                }
            }

        }
    }
}