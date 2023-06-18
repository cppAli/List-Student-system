using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class Student
{
    //поля
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public int Year { get; set; }

    //Конструктор
    public Student(string name, string surname, int age, int year)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null.");
        }
        Name = name;
        Surname = surname;
        Age = age;
        Year = year;
    }


    //метод возвращает строковое представление объекта студента
    public override string ToString()
    {
        return $"Студент ID: {Id}. {Name} {Surname} возвраст {Age}, зачислен в {Year}";
    }
}

public class StudentManager : Student
{
    public List<Student> students = new List<Student>();
    private int currentId = 1; // Начальное значение ID

    public StudentManager(string name, string surname, int age, int year) : base(name, surname, age, year)
    {
    }
    public void AddStudent(Student student)
    {
        student.Id = currentId; // Установка ID для студента
        students.Add(student);
        currentId++; // Увеличение текущего значения ID
    }
    public void RemoveStudent(Student student) //RemoveStudent(Student student): удаляет студента из списка.
    {
        students.Remove(student);
    }
    public List<Student> GetStudentsByYear(int year) //GetStudentsByYear(int year): возвращает список студентов, находящихся на указанном курсе.
    {
        List<Student> studentsByYear = new List<Student>(); //список по году обучения
        foreach (Student student in students)
        {
            if (student.Year == year)
            {
                studentsByYear.Add(student);
            }
        }
        return studentsByYear;
    }

    public Student? GetOldestStudent() //GetOldestStudent(): возвращает самого старшего студента из списка.
    {
        if (students.Count == 0) //если список пуст
        {
            return null;
        }

        Student oldestStudent = students[0]; //смого старшего присваивается первому в списке
        foreach (Student student in students)//перебор списка
        {
            if (student.Age > oldestStudent.Age) //условие присвоения
            {
                oldestStudent = student;
            }
        }
        return oldestStudent;
    }
}