﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
    internal class Student:Human
    {
        const int SPECIALITY_WIDTH = 20;
        const int GROUP_WIDTH = 8;
        const int RATING_WIDTH = 6;
        const int ATTENDANCE_WIDTH = 6;
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
        public Student(Student other) : base(other)
        {

            this.Speciality = other.Speciality;
            this.Group = other.Group;
            this.Rating = other.Rating;
            this.Attendance = other.Attendance;
            Console.WriteLine("SCopyconstuctor:\t" + GetHashCode());
        }
        ~Student() 
        {
            Console.WriteLine("SFinalizer:\t" + GetHashCode());
        }
        public override void Info()
        {
            base.Info();
            Console.Write($"{Speciality.PadRight(SPECIALITY_WIDTH)}" +
                $"{Group.PadRight(GROUP_WIDTH)} {Rating.ToString().PadRight(RATING_WIDTH)}" +
                $"{Attendance.ToString().PadRight(ATTENDANCE_WIDTH)}");
        }
        
        public override string ToString()
        {
            return base.ToString() + $",{Speciality},{Group},{Rating},{Attendance}";
        }
        public override void Init(string[] values)
        {
            base.Init(values);
            Speciality = (values[4].Trim()); // Трим убирает лишние пробелы
            Group = values[5];
            values[6] = values[6].Trim();
            Rating = Convert.ToDouble(values[6]);
            Attendance = Convert.ToDouble(values[7]);
        }
    }
}
