namespace PhoneBook;

class Program
{
    static void Main()
    {
        Create();
    }

    /// <summary>
    /// Прием номера и имя телефона от пользователя.
    /// </summary>
    static void Create()
    {
        Console.WriteLine("Впишите имя абонента");
        string name = Console.ReadLine();
        
        Console.WriteLine("Впишите номер абонента");
        int number = int.Parse(Console.ReadLine());
        
        Abonent abonent = new Abonent(name, number);
        Console.WriteLine("Имя : {0}, Номер: {1}", abonent.Name, abonent.Number);
        
        File.WriteAllText("Book.txt", abonent.ToString());
        Console.WriteLine("Контакт сохранен в phonebook.txt");
    }

    /// <summary>
    /// Считывание из файлы сохранённые номера.
    /// </summary>
    static void Read()
    {
        
    }
    
    /// <summary>
    /// Обновление данный в файле.
    /// </summary>
    static void Update()
    {
        
    }
    
    /// <summary>
    /// Удалить данные в файле.
    /// </summary>
    static void Delete()
    {
        
    }
}

/// <summary>
/// Данные об абоненте.
/// </summary>
internal class Abonent
{ 
    public string Name {get; set;} // Объявление полец
    public int Number {get; set;}

    public Abonent(string name, int number) // Создание конструктора для заполнения данных
    {
        Name = name;
        Number = number;
    }
    
}