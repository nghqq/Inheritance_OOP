using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Human
    {
        const int LAST_NAME_WIDTH = 10;
        const int FIRST_NAME_WIDTH = 10;
        const int AGE_WIDTH = 5;
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Human(string lastName,string firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Console.WriteLine("HConstructor:\t"+GetHashCode());
        }
        public Human(Human other) 
        { 
            this.LastName = other.LastName;
            this.FirstName = other.FirstName;
            this.Age = other.Age;
            Console.WriteLine("HCopyConstuctor:\t"+GetHashCode());
        }
        ~Human() 
        {
            Console.WriteLine("HFinalizer:\t" + GetHashCode());
        }
        public virtual void Info()
        {
            
            Console.Write($"{LastName.PadRight(LAST_NAME_WIDTH)}" +
                $"{FirstName.PadRight(FIRST_NAME_WIDTH)}" +
                $"{Age.ToString().PadRight(AGE_WIDTH)}");
        }
        public override string ToString()
        {
            return $"{LastName},{FirstName},{Age} ";
        }
        public virtual void Init(string[] values) // принимает массив строк
        {
            LastName = values[1];
            FirstName = values[2];
            Age = Convert.ToInt32(values[3]);
        }

    }
}
