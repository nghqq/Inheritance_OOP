﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Academy
{
    internal class Teacher : Human
    {
        public string Speciality { get; set; }
        public int Experience { get; set; }
        public Teacher
            (
            string lastName, string firstName, int age,
            string speciality, int experience
            ) : base(lastName, firstName, age)
        {
            Speciality = speciality;
            Experience = experience;
            Console.WriteLine("TConstructor:\t" + GetHashCode());
        }
        ~Teacher()
        {
            Console.WriteLine("TFinalizer:\t" + GetHashCode());
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine($"{Speciality}, {Experience}");
        }
        public override string ToString()
        {
            return base.ToString() + $",{Speciality},{Experience} ";
        }
    }
}
