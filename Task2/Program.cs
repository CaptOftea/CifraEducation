namespace Task2;

/// <summary>
/// Этот класс посвящен Практике №1
/// </summary>
class Program
{
    static void Main()
    {
        // Задание 1.
        
        Console.WriteLine("Введите свой возраст: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Ваш возраст : {0}", age);
        
        Console.WriteLine("Введите ваше имя: "); // совпадает с 2b и 3, поэтому объединил
        string name = Console.ReadLine();
        Console.WriteLine("Привет, : {0} !", name);
        
        Console.WriteLine("Где вы работаете?");
        string corpName = Console.ReadLine();
        Console.WriteLine("Вы работаете в : {0}", corpName);

        bool a;
        
        Console.WriteLine("Введите свой вес");
        double weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Ваш вес:  {0}", weight);

        
        // Задание 2.
        
        Console.WriteLine("Введите свой год рождения: ");
        int bornYear = int.Parse(Console.ReadLine());
        int myAge = DateTime.Now.Year - bornYear;
        Console.WriteLine("Вам сейчас: {0}", myAge);

        Console.WriteLine("Какая температура за окном?");
        double temp = double.Parse(Console.ReadLine());
        if (temp >= 0) Console.WriteLine("Ура лето");
        else Console.WriteLine("О нет опять зима");

        Console.WriteLine("Вы мужчина?");
        bool gender = bool.Parse(Console.ReadLine());
        switch (gender)
        {
            case true:
                Console.WriteLine("Мужчина");
                break;
            case false:
                Console.WriteLine("Женщина");
                break;
        }
        
        
        // Задание 4.
        
        string quote, quote2;
        string upper1, upper2;
        do
        {
            Console.WriteLine("Введите любимую цитату");
            quote = Console.ReadLine();
            Console.WriteLine("Введите еще одну любимую цитату");
            quote2 = Console.ReadLine();
            upper1 = quote.ToUpper(); upper2 = quote2.ToUpper();

            if (upper1 == upper2)
            {
                Console.WriteLine("Я сказал еще одну, а не ту же самую!!!");
            }
        }
        while (upper1 == upper2);
        
        Console.WriteLine ("Ваша первая любимая цитата: '{0}' -прекрасна!, но вот вторая '{1}'-немного противоречива", quote, quote2);

        
        // Задание 5.

        double rad = 5.5;
        double area = Math.PI * Math.Pow(rad,2);
        
        Console.WriteLine("Площадь окружности с радиусом равным: {0}, равна {1}", rad, area);

        Hipp newProgram = new Hipp();
        newProgram.Calculate();
    }
}

/// <summary>
/// Программа для рассчета гипотенузы
/// </summary>
public class Hipp
{
    public void Calculate()
    {
        Console.WriteLine("Введите первый катет");
        double leg1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите второй катет");
        double leg2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите гипотенузу");
        double hypo = double.Parse(Console.ReadLine());

        if (leg1 > 0 && leg2 == 0 && hypo > 0)
        {
            leg2 = Math.Sqrt(Math.Pow(hypo, 2) - Math.Pow(leg1, 2));
            Console.WriteLine("Второй катет = {0}", leg2);
        }
        else if (leg1 == 0 && leg2 > 0 && hypo > 0)
        {
            leg1 = Math.Sqrt(Math.Pow(hypo, 2) - Math.Pow(leg2, 2));
            Console.WriteLine("Первый катет = {0}", leg1);
        }
        else if (leg1 == 0 && leg2 == 0 && hypo == 0)
        {
            hypo = Math.Sqrt(Math.Pow(leg1, 2) * Math.Pow(leg2, 2));
            Console.WriteLine("Гипотенуза = {0}", hypo);
        }
        else
        {
            Console.WriteLine("Данные не действительны");
        }
    }
}