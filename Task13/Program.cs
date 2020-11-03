using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Crew(1);
            list.Add(new Worker("Tom", 21, "b"));
            list.Add(new Worker("Bob", 32, "d"));
            list.Add(new Worker("Jack", 23, "a"));
            list.Add(new Worker("Jessy", 24, "c"));

            list.Insert(0, new Worker("zzz", 1, "zzz"));
            foreach (var l in list)
            {
                l.PrintInfo();
                Console.WriteLine();
            }
            Console.WriteLine("Contains: " + list.Contains(new Worker("Jessy", 24, "c")));
            list.Remove(new Worker("zzz", 1, "zzz"));
            list.Sort(new PositionComparer());
            Console.WriteLine("\nnew list: ");
            foreach (var l in list)
            {
                l.PrintInfo();
                Console.WriteLine();
            }
            try
            {
                list.RemoveAt(7);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
