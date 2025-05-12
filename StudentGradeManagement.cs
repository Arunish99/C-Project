using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int RollNo { get; set; }
    public List<int> Marks { get; set; } = new List<int>();

    public double GetAverage() => Marks.Average();

    public string GetGrade()
    {
        double avg = GetAverage();
        if (avg >= 90) return "A";
        if (avg >= 80) return "B";
        if (avg >= 70) return "C";
        if (avg >= 60) return "D";
        return "F";
    }

    public override string ToString()
    {
        return $"Roll No: {RollNo}, Name: {Name}, Avg: {GetAverage():0.00}, Grade: {GetGrade()}";
    }

    public string ToFileFormat()
    {
        return $"{RollNo}|{Name}|{string.Join(",", Marks)}";
    }

    public static Student FromFileFormat(string line)
    {
        var parts = line.Split('|');
        var marks = parts[2].Split(',').Select(int.Parse).ToList();
        return new Student
        {
            RollNo = int.Parse(parts[0]),
            Name = parts[1],
            Marks = marks
        };
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    const string FilePath = "students.txt";

    static void Main()
    {
        LoadData();
        while (true)
        {
            Console.WriteLine("\n--- Student Grade Management ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by Roll No");
            Console.WriteLine("4. Save & Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddStudent(); break;
                case "2": DisplayAll(); break;
                case "3": SearchStudent(); break;
                case "4":
                    SaveData();
                    Console.WriteLine("Data saved. Exiting...");
                    return;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Roll No: ");
        int roll = int.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        List<int> marks = new List<int>();
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Enter marks for Subject {i}: ");
            marks.Add(int.Parse(Console.ReadLine()));
        }
        students.Add(new Student { RollNo = roll, Name = name, Marks = marks });
        Console.WriteLine("Student added successfully.");
    }

    static void DisplayAll()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Roll No to search: ");
        int roll = int.Parse(Console.ReadLine());
        var student = students.FirstOrDefault(s => s.RollNo == roll);
        if (student != null)
        {
            Console.WriteLine("Student Found:");
            Console.WriteLine(student);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void SaveData()
    {
        var lines = students.Select(s => s.ToFileFormat()).ToArray();
        File.WriteAllLines(FilePath, lines);
    }

    static void LoadData()
    {
        if (!File.Exists(FilePath)) return;
        var lines = File.ReadAllLines(FilePath);
        foreach (var line in lines)
        {
            students.Add(Student.FromFileFormat(line));
        }
    }
}
