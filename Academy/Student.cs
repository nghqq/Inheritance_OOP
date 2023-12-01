using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
    internal class Student:Human
    {
        public string Speciality { get; set; }
        public string Group { get; set; }
        public double Rating { get; set; }
        public double Attendance { get; set; }

        public Student
            (
            string lastName, string firstName, int age,
            string speciality, string group, double rating, double attendance
            ):base(lastName, firstName,age)
        {
            Speciality = speciality;
            Group = group;
            Rating = rating;
            Attendance = attendance;
            Console.WriteLine("SConstuctor:\t"+GetHashCode());
        }
        public Student(Human human, string speciality, string group, double rating, double attendance) : base(human)
        {
            Speciality = speciality;
            Group = group;
            Rating = rating;
            Attendance = attendance;
            Console.WriteLine("SConstuctor:\t" + GetHashCode());
        }
        ~Student() 
        {
            Console.WriteLine("SFinalizer:\t" + GetHashCode());
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine($"{Speciality} {Group} {Rating} {Attendance}");
        }
        public Student(Student other):base(other)
        {
            
            this.Speciality = other.Speciality;
            this.Group = other.Group;
            this.Rating = other.Rating;
            this.Attendance = other.Attendance;
            Console.WriteLine("SCopyconstuctor:\t" + GetHashCode());
        }
        public override string ToString()
        {
            return base.ToString() + $",{Speciality},{Group},{Rating},{Attendance}";
        }
    }
}
