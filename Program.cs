//Разработайте приложение для учета студентов в университете.
//Ваша задача - создать класс "Student" для представления студента и класс "StudentManager",
//который будет отвечать за управление списком студентов.

//Класс "Student" должен содержать следующие поля:

//Имя(Name) - строковое поле.
//Фамилия(Surname) - строковое поле.
//Возраст(Age) - целочисленное поле.
//Курс(Year) - целочисленное поле.
//Класс "Student" должен также иметь конструктор, который принимает значения для всех полей и метод "ToString()",
//который возвращает строковое представление объекта студента.

//Класс "StudentManager" должен содержать список (List) студентов и иметь следующие методы:

//AddStudent(Student student): добавляет студента в список.
//RemoveStudent(Student student): удаляет студента из списка.
//GetStudentsByYear(int year): возвращает список студентов, находящихся на указанном курсе.
//GetOldestStudent(): возвращает самого старшего студента из списка.

//Создайте консольное приложение, которое будет взаимодействовать с пользователем.
//Пользователь должен иметь возможность добавлять студентов, удалять студентов,
//просматривать список студентов на определенном курсе и получать информацию о самом старшем студенте.

//Приложение должно работать до тех пор, пока пользователь не введет команду для выхода.

        StudentManager manager = new StudentManager("Default", "Default", 0, 0);
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Добавить Студента в Базу");
            Console.WriteLine("2. Удалить Студента из Базы");
            Console.WriteLine("3. Получить список студентов по годам");
            Console.WriteLine("4. Получить Возвраст самого старшего ученика");
            Console.WriteLine("5. Выход");
            Console.WriteLine("Введите свой выбор: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите данные Студента:");
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Фамилия: ");
                    string surname = Console.ReadLine();
                    Console.Write("Возраст: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Год поступления: ");
                    int year = int.Parse(Console.ReadLine());

                    Student newStudent = new(name: name, surname: surname, age: age, year: year);
                    manager.AddStudent(newStudent);
                    Console.WriteLine($"Студент {surname} успешно добавлен.");
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("Введите ID студента, которого нужно удалить:");
                    int id = int.Parse(Console.ReadLine());
                    Student studentToRemove = manager.students.FirstOrDefault(student => student.Id == id);
                    if (studentToRemove != null)
                    {
                        manager.RemoveStudent(studentToRemove);
                        Console.WriteLine("Данные успешно удалены.");
                    }
                    else
                    {
                        Console.WriteLine("Студент с указанным ID не найден.");
                    }
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Write("Ввведите год факультета: ");
                    int searchYear = int.Parse(Console.ReadLine());
                    List<Student> studentsByYear = manager.GetStudentsByYear(searchYear);
                    Console.WriteLine($"Студенты, зачисленные в {searchYear}:");
                    if (studentsByYear.Count > 0)
                    {
                        foreach (Student student in studentsByYear)
                        {
                            Console.WriteLine(student.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не найдено данных.");
                    }
                    Console.WriteLine();
                    break;

                case "4":
                    Student oldestStudent = manager.GetOldestStudent();
                    if (oldestStudent != null)
                    {
                        Console.WriteLine("Самый старший ученик:");
                        Console.WriteLine(oldestStudent.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Студенты не найдены.");
                    }
                    Console.WriteLine();
                    break;

                case "5":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте еще раз.");
                    Console.WriteLine();
                    break;
            }
        }