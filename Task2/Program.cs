namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите свой возраст: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Ваш возраст : {0}", age);
        
        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Ваше имя : {0}", name);
        
        Console.WriteLine("Где вы работаете?");
        string corpName = Console.ReadLine();
        Console.WriteLine("Вы работаете в : {0}", corpName);

        bool a;
        
        Console.WriteLine("Введите свой вес");
        double weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Ваш вес:  {0}", weight);
    }
}