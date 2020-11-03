using System;
using System.Collections.Generic;
using System.Text;

namespace Task13
{
    class Worker
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public Worker() { }
        public Worker(string n, int a, string p)
        {
            Name = n;
            Age = a;
            Position = p;
        }
        public void PrintInfo()
        {
            Console.WriteLine("name: "+Name+"\nage: "+Age+"\nposition: "+Position);
        }
        public override bool Equals(object obj)
        {
            Worker w = obj as Worker;
            if (w == null)
                return false;
            else if (Name != w.Name)
                return false;
            else if (Age != w.Age)
                return false;
            else if (Position != w.Position)
                return false;
            else
                return true;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
