namespace PhoneBook;

/// <summary>
/// Основаная логика
/// </summary>
class Program
{
    static void Main()
    {
        HUD.MainMenu();
            
        Create();
        SaveToFile();
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
        
    }

    /// <summary>
    /// Создает и записывает текстовый файл
    /// </summary>
    /// <param name="???"></param>
    public void SaveToFile(List<Abonent> abonents, string filePath)
    {
        File.WriteAllText(filePath, abonents.ToString());
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
public class Abonent
{
    public string Name; // Объявление полей
    public int Number;
    public Abonent(string name, int number) // Создание конструктора для заполнения данных
    {
        Name = name;
        Number = number;
    }
}

/// <summary>
/// Паттерн одиночка.
/// </summary>
public class Singleton // объявление класса, который гарантирует, что есть только один экземпляр
{
        private static Singleton dBase; //снаружи не изменить

        private Singleton() //конструктор, запрещающий создавать объекты извне и ед. способ олучить объект, через стат. метод
        { }

        public static Singleton getDBase() //возвращает ед. экземпляр и вызывает на объекте Singleton.getInstance()
        {
            if (dBase == null) //проверка создан ли уже объект
                dBase == new Singleton(); // создает единственный экземпляр
            return dBase; //возвращает единственный экземпляр
        }
}

public class HUD
{
    public static void MainMenu()
    {
        Console.WriteLine("Добро пожаловать в ваши контакты");
        Console.WriteLine("Что вы хотите сделать?");
        
        Console.WriteLine("1. Посмотреть все контакты");
        Console.WriteLine("2. Поиск");
        Console.WriteLine("3. Добавить контакт");
        Console.WriteLine("4. Изменить контакт");
        Console.WriteLine("5. Удалить контакт");
        
        Manager.CreateData();
        
        string inputPosition = Console.ReadLine();
        int z = int.Parse(inputPosition);

        //Это все пока наметки, потом побольше разберусь
        switch (z)
        {
            case 1:
                Manager.ShowData();
                break;
            case 2:
                ;
                break;
            case 3:
                Manager.AddData();
                break;
            case 4:
                ;
                break;
            case 5:
                Manager.RemoveData();
                break;
        }
    }
}

/// <summary>
/// Класс работы со списком
/// </summary>
public class Manager
{
    private static List<(string Name,int Number)> subscribers; // список как поле класса

    /// <summary>
    /// Создние листа, но пустого
    /// </summary>
    public static void CreateData()
    {
        
        subscribers = new List<(Abonent)>();
    }
    
    /// <summary>
    /// Добавить эллемент в лист.
    /// </summary>
    /// <param name="???"></param>
    public static void AddData(Abonent) 
    {
        Console.WriteLine("Введите имя абонента: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите номер абонента: ");
        int number = int.Parse(Console.ReadLine());
        Abonent newAbonent = new Abonent(name, number);
        subscribers.Add((Abonent)); 
    }

    public static void ShowData()
    {
        foreach (var sub in subscribers)
        {
            Console.WriteLine("{0}, {1}",{sub.Name}, {sub.Number});
        }
    }

    public static void RemoveData()
    {
        subscribers.RemoveAt(subscribers.Count - 1);
    }

    public static void ChangeData(int index, string newName, int newNumber)
    {
        Console.WriteLine("Какой контакт вы хотите изменить?");
        int index  = int.Parse(Console.ReadLine());
        
        string oldName = subscribers[index].Name; subscribers[index].Name = newName;
        int oldNumber = subscribers[index].Number; subscribers[index].Number = newNumber;
        
    }
}