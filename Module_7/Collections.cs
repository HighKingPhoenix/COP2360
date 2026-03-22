using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class DictionaryManager
    {
        private Dictionary<string, string> wishlist = new Dictionary<string, string>();

        public void Populate()
        {
            wishlist["David"] = "ROG Ally";
            wishlist["Alica"] = "IPhone 17 Pro Max";
            wishlist["Claire"] = "Audi R7";
        }

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
        public static void Logs(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        static void Main(string[] args)
        {
            DictionaryManager manage = new DictionaryManager();
            bool running = true;

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
                        Console.Write("Enter Name of the person whos wish list you want to remove: ");
                        manage.RemoveKey(Console.ReadLine());
                        break;
                    case "d":
                        Console.Write("Name: ");
                        string person = Console.ReadLine();
                        Console.Write("Wish: ");
                        string wish = Console.ReadLine();
                        manage.AddNew(person,wish);
                        break;
                    case "e":
                        Console.Write("Name: ");
                        string person = Console.ReadLine();
                        Console.Write("Aditional Wish: ");
                        string wish = Console.ReadLine();
                        manage.AppendValue(person,wish);
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