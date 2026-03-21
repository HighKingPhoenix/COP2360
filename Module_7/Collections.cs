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

        public void RemoveKey(string Key)
        {
            if (wishlist.Remove(Key))
            {
                Console.WriteLine($"{Key} is Removed");
            }
            else
            {
                Console.WriteLine($"{Key} is not found");
            }
        }

        public void AddNew(string Key, string Value)
        {
            if (!wishlist.ContainsKey(Key))
            {
                wishlist.Add(Key, Value);
                Console.WriteLine($"{Key} has been added");
            }
            else
            {
                Console.WriteLine($"{Key} Already Exists");
            }
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
            
        }
    }
}