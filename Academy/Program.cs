//#define WRITE_TO_FILE
#define READ_FROM_FILE
#define SOMETHINK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if WRITE_TO_FILE
            Human human = new Human("Vercetti", "Tommy", 30);
            human.Info();
            Console.WriteLine(human);
            Student student = new Student("Pinkman", "Jessie", 25, "Chemistry", "WW_220", 95, 98);
            student.Info();
            Console.WriteLine(student);
            Teacher teacher = new Teacher("Walter", "White", 50, "Chemistry", 20);
            teacher.Info();
            Console.WriteLine(teacher);
            Graduate graduate = new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 70, 40, "How to catch Heisenberg");
            graduate.Info();
            Console.WriteLine(graduate);

            Student tommy = new Student(human, "Theft", "Vice", 98, 99);
            Console.WriteLine(tommy);

            Graduate tommy_grad = new Graduate(tommy, "How to make money");
            Console.WriteLine(tommy_grad);
            Console.WriteLine("\n_________________________________________________________\n");

            Human[] group = new Human[]
            {
                student,teacher, tommy_grad,graduate,
                new Graduate("Rosenberg","Ken",30,"Lawyer","Vice",45,22,"How to get money back"),
                new Teacher("Diaz","Ricardo",50,"Weapons distribution",25)
            };
            Console.WriteLine("\n_________________________________________________________\n");
            Print(group);
            Save(group, "group.txt");
            Console.WriteLine("\n_________________________________________________________\n"); 
#endif
#if READ_FROM_FILE
            Human[] group = Load("group.txt");
            Print(group); 
#endif
        }
        public static void Print(Human[] group)
        {
            for (int i = 0; i < group.Length; i++)
            {
                //Console.WriteLine(group[i]);
                group[i].Info();
                Console.WriteLine();
            }
        }
        public static void Save(Human[] group, string filename)
        {
            Directory.SetCurrentDirectory("..\\..");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine("\n_________________________________________________________\n");
            StreamWriter sw = new StreamWriter(filename);
            foreach (Human i in group)
                sw.WriteLine
                (
                $"{i.GetType().ToString().Split('.').Last()}:{i};"
                );
            sw.Close();
            System.Diagnostics.Process.Start("notepad", $"{Directory.GetCurrentDirectory()}\\group.txt");
        }
        public static Human[] Load(string filename)
        {
            Directory.SetCurrentDirectory("..\\..");
            Console.WriteLine(Directory.GetCurrentDirectory());
            List<Human> group = new List<Human>();
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string buffer = sr.ReadLine();
                string[] values = buffer.Split(':', ',', ';');
                group.Add(HumanFactory(values[0]));
                if (group.Last() == null) group.RemoveAt(group.Count - 1);
                else group.Last().Init(values);
            }
            sr.Close();
            return group.ToArray();
        }
        public static Human HumanFactory(string type)
        {
            if (type == "Student") return new Student("", "", 0, "", "", 0, 0);
            if (type == "Graduate") return new Graduate("", "", 0, "", "", 0, 0, "");
            if (type == "Teacher") return new Teacher("", "", 0, "", 0);
            return null;
        }

    }
}