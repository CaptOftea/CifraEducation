namespace Practice3;

class Program
{
    static void Main()
    { 
        Person p1 = new Person{Name = "Тонни", Age = 18};
        p1.Print();
        
        Person2 p2 = new Person2{Name = "Майкл", Age = 18, MGrade = 8 };
        p2.Print2();
        
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Mass(2,5));
        Console.WriteLine(calc.Menos(5,5));
        Console.WriteLine(calc.Multiplicacion(6,6));
        Console.WriteLine(calc.Dividir(4,2));
    }
}

/// <summary>
/// Задание 1. Вывод информаци имя/возраст в консоль
/// </summary>
public class Person
{
    public string Name;
    public int Age;
    
    public void Print()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

/// <summary>
/// Задание 2. 
/// </summary>
public class Person2
{
    public string Name;
    public int Age;
    private int grade;

    public int MGrade
    {
        get => grade;
        set
        {
            if (value >= 0 && value <= 5) grade = value;
            else Console.WriteLine("данные введены некорректно");
        }
    }
    
    public void Print2()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {MGrade}");
    }
}

/// <summary>
/// Задание 3. Калькулятор
/// </summary>

public class Calculator
{
    public int Mass(int a, int b)
    {
        return a + b;
    }
    public int Menos(int a, int b)
    {
        return a - b;
    }
    public int Multiplicacion(int a, int b)
    {
        return a * b;
    }
    public int Dividir(int a, int b)
    {
        return a / b;
    }
}