using System;
using System.Collections.Generic;

// Категории сотрудников
enum Department
{
    Начальство,
    Системщики,
    Разработчики,
    Бухгалтерия
}

// Класс задачи
class TaskItem
{
    public int Number { get; set; }
    public string Description { get; set; }
    public string Action { get; set; }
    public Department Type { get; set; }

    public TaskItem(int number, string description,
                    string action, Department type)
    {
        Number = number;
        Description = description;
        Action = action;
        Type = type;
    }
}

// Класс сотрудника
class Employee
{
    public string Name { get; set; }
    public Department Department { get; set; }

    // Непосредственные руководители сотрудника
    public List<Employee> Managers { get; set; }

    // Подчиненные сотрудника
    public List<Employee> Subordinates { get; set; }

    public Employee(string name, Department department)
    {
        Name = name;
        Department = department;
        Managers = new List<Employee>();
        Subordinates = new List<Employee>();
    }

    // Добавление руководителя
    public void AddManager(Employee manager)
    {
        Managers.Add(manager);
        manager.Subordinates.Add(this);
    }

    // Проверка, является ли человек прямым руководителем
    public bool IsDirectManager(Employee manager)
    {
        return Managers.Contains(manager);
    }

    // Принятие задачи
    public void AcceptTask(Employee sender, TaskItem task)
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Номер задачи: " + task.Number);
        Console.WriteLine("Описание: " + task.Description);
        Console.WriteLine("Необходимо выполнить: " + task.Action);

        Console.WriteLine(
            "От человека " + sender.Name +
            " даётся задача человеку " + Name
        );

        // Проверяем категорию задачи
        if (task.Type != Department)
        {
            Console.WriteLine("Результат: " + Name +
                " ОТКАЗЫВАЕТСЯ от задачи.");
            Console.WriteLine("Причина: задача предназначена для другого отдела.");
            return;
        }

        // Проверяем непосредственного руководителя
        if (IsDirectManager(sender))
        {
            Console.WriteLine("Результат: " + Name +
                " ПРИНИМАЕТ задачу.");
        }
        else
        {
            Console.WriteLine("Результат: " + Name +
                " ОТКАЗЫВАЕТСЯ от задачи.");
            Console.WriteLine("Причина: " + sender.Name +
                " не является непосредственным руководителем.");
        }
    }

    // Вывод подчиненных
    public void PrintHierarchy(string indent = "")
    {
        Console.WriteLine(indent + Name);

        foreach (Employee employee in Subordinates)
        {
            employee.PrintHierarchy(indent + "    ");
        }
    }
}

class Program
{
    static void Main()
    {
        // Создание сотрудников
        Employee timur = new Employee("Тимур", Department.Начальство);

        Employee rashid = new Employee("Рашид", Department.Начальство);
        Employee ilham = new Employee("О Ильхам", Department.Начальство);

        Employee lukas = new Employee("Лукас", Department.Бухгалтерия);

        Employee orkady = new Employee("Оркадий", Department.Начальство);
        Employee volodya = new Employee("Володя", Department.Начальство);

        Employee ilshat = new Employee("Ильшат", Department.Системщики);
        Employee ivanych = new Employee("Иваныч", Department.Системщики);

        Employee ilya = new Employee("Илья", Department.Системщики);
        Employee vitya = new Employee("Витя", Department.Системщики);
        Employee zhenya = new Employee("Женя", Department.Системщики);

        Employee sergey = new Employee("Сергей", Department.Разработчики);
        Employee laysan = new Employee("Ляйсан", Department.Разработчики);

        Employee marat = new Employee("Марат", Department.Разработчики);
        Employee dina = new Employee("Дина", Department.Разработчики);
        Employee ildar = new Employee("Ильдар", Department.Разработчики);
        Employee anton = new Employee("Антон", Department.Разработчики);

        // Формирование иерархии фирмы

        // Генеральный директор
        rashid.AddManager(timur);
        ilham.AddManager(timur);

        // Финансовый директор
        lukas.AddManager(rashid);

        // Отдел информационных технологий
        orkady.AddManager(ilham);
        volodya.AddManager(ilham);

        // Сектор системщиков
        ilshat.AddManager(orkady);
        ilshat.AddManager(volodya);

        ivanych.AddManager(ilshat);

        ilya.AddManager(ivanych);
        vitya.AddManager(ivanych);
        zhenya.AddManager(ivanych);

        // Сектор разработчиков
        sergey.AddManager(orkady);
        sergey.AddManager(volodya);

        laysan.AddManager(sergey);

        marat.AddManager(laysan);
        dina.AddManager(laysan);
        ildar.AddManager(laysan);
        anton.AddManager(laysan);

        // Вывод иерархии
        Console.WriteLine("ИЕРАРХИЯ СОТРУДНИКОВ");
        timur.PrintHierarchy();

        // Создание задач
        TaskItem task1 = new TaskItem(
            1,
            "Настроить сервер",
            "Проверить подключение и настроить сервер",
            Department.Системщики
        );

        TaskItem task2 = new TaskItem(
            2,
            "Разработка программы",
            "Написать программу для автоматизации бухгалтерии",
            Department.Разработчики
        );

        TaskItem task3 = new TaskItem(
            3,
            "Проверка сети",
            "Проверить работу локальной сети",
            Department.Системщики
        );

        TaskItem task4 = new TaskItem(
            4,
            "Разработка приложения",
            "Создать приложение для учета расходов",
            Department.Разработчики
        );

        TaskItem task5 = new TaskItem(
            5,
            "Организация работы отдела",
            "Проконтролировать выполнение задач",
            Department.Начальство
        );

        // Распределение задач

        Console.WriteLine("\n\nРАСПРЕДЕЛЕНИЕ ЗАДАЧ");

        // Задача от О Ильхама начальнику отдела
        orkady.AcceptTask(ilham, task5);

        // Задача от Оркадия начальнику разработчиков
        sergey.AcceptTask(orkady, task2);

        // Задача от Володи начальнику разработчиков
        sergey.AcceptTask(volodya, task4);

        // Задача от Сергея его заместителю
        laysan.AcceptTask(sergey, task2);

        // Задача от Ляйсан сотруднику
        dina.AcceptTask(laysan, task4);

        // Попытка передать задачу не от прямого начальника
        marat.AcceptTask(sergey, task2);

        // Задача от Оркадия начальнику системщиков
        ilshat.AcceptTask(orkady, task1);

        // Задача от Ильшата заместителю
        ivanych.AcceptTask(ilshat, task3);

        // Задача от Иваныча сотруднику
        ilya.AcceptTask(ivanych, task1);

        // Попытка передать задачу не от прямого начальника
        zhenya.AcceptTask(orkady, task3);

        Console.WriteLine("\n\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
