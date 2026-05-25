using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook;

/// <summary>
/// Основаная логика
/// </summary>
class Program
{
    static void Main()
    {
        
        // создание пустого листа
        var phoneBook = Manager.CreateData();
        
        // сохраняем лист в файл
        StorageData storage = new StorageData("book.txt"); // сохранение в виртуальной памяти
        storage.StorageSave(phoneBook); // сохранение в памяти физической
        
        PhoneBook.MainMenu();
    }
}

/// <summary>
/// HUD
/// </summary>
public class PhoneBook
{
    public static void MainMenu()
    {
        
    
        if (Manager.subscribers == null )
        {
            if (File.Exists("book.txt"))
            {
                var loadedList = StorageData.StorageLoad("book.txt");
                Manager.SetData(loadedList);
            }
            else
            {
                Manager.CreateData();
            }
        }
    
        Console.WriteLine("Добро пожаловать в ваши контакты");
        Console.WriteLine("Что вы хотите сделать?");
        
        Console.WriteLine("1. Посмотреть все контакты");
        Console.WriteLine("2. Поиск");
        Console.WriteLine("3. Добавить контакт");
        Console.WriteLine("4. Изменить контакт");
        Console.WriteLine("5. Удалить контакт");
        
        string inputPosition = Console.ReadLine();
        int z = int.Parse(inputPosition);

        //Это все пока наметки, потом побольше разберусь
        switch (z)
        {
            case 1:
                var loadedList = StorageData.StorageLoad("book.txt");
                Manager.SetData(loadedList);
                Manager.ShowData(loadedList);
                break;
            case 2:
                Manager.Search();
                break;
            case 3:
                Manager.AddData();
                break;
            case 4:
                Manager.ChangeData();
                break;
            case 5:
                Manager.RemoveData();
                break;
        }
    }
}

/// <summary>
/// Работа с листом
/// </summary>
public class Manager
{
    public static List<Abonent> subscribers; // список как поле класса
    
    /// <summary>
    /// Создние пустого листа
    /// </summary>
    public static  List<Abonent> CreateData()
    {
        if (subscribers == null) //проверка создан ли уже объект
            subscribers = new List<Abonent>(); // создает единственный экземпляр
        return subscribers; //возвращает единственный экземпляр
    }
    
    /// <summary>
    /// Добавить эллемент в лист.
    /// </summary>
    /// <param name="???"></param>
    public static void AddData() 
    {
        if (subscribers == null)
        {
            subscribers = new List<Abonent>();
        }
        
        Console.WriteLine("Введите имя абонента: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите номер абонента: ");
        long number = long.Parse(Console.ReadLine());
        
        Abonent newAbonent = new Abonent(name, number);
        subscribers.Add(newAbonent); 
        
        StorageData storage = new StorageData("book.txt");
        storage.StorageSave((subscribers));
        
        Console.WriteLine($"Контакт {name} добавлен!");
    }

    /// <summary>
    /// Вывести лист
    /// </summary>
    public static void ShowData(List<Abonent> abonents)
    {
        foreach (var sub in abonents)
        {
            Console.WriteLine("{0}, {1}",sub.Name, sub.Number);
        }
    }

    public static void RemoveData()
    {
        Console.WriteLine("Введите номер контакта для удаления (от 0 до {0}):", subscribers.Count-1);
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < subscribers.Count)
        {
            var removed = subscribers[index];
            subscribers.RemoveAt(index);
            Console.WriteLine($"Контакт {removed.Name} удален");
        }
        else
        {
            Console.WriteLine("Неверный индекс!");
        }
    }

    /// <summary>
    /// Сменить информацию абонента
    /// </summary>
    /// <param name="newName"></param>
    /// <param name="newNumber"></param>
    public static void ChangeData()
    {
        Console.WriteLine("Какой контакт вы хотите изменить?");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < subscribers.Count)
        {
            Console.WriteLine("Введите новое имя: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Введите новый номер: ");
            int  newNumber = int.Parse(Console.ReadLine());
            
            string oldName = subscribers[index].Name; subscribers[index].Name = newName;
            long oldNumber = subscribers[index].Number; subscribers[index].Number = newNumber;
            
            Console.WriteLine("Контакт изменен: {0} ({1}) -> {2} ({3})", oldName, oldNumber, newName, newNumber);
        }
        else
        {
            Console.WriteLine("Ошибка: контект не найден!");
        }

    }

    /// <summary>
    /// Поиск контакта
    /// </summary>
    public static void Search()
    {
        Console.WriteLine("Выберите по какому параметру искать: 1. по имени 2. по номеру");
        
        int SearchElement = int.Parse(Console.ReadLine());
        switch(SearchElement) 
        {
            case 1:
                Console.WriteLine("Впишите имя для поиска");
                string SearchName = Console.ReadLine();
                FindByName(SearchName);
                break;
            
            case 2:
                Console.WriteLine("Впишите номер для поиска");
                int SearchNumber = int.Parse(Console.ReadLine());
                FindByNumber(SearchNumber);
                break;
        }
    }

    public static void FindByName(string name)
    {
        bool found = false; // лог. переменная нашел/не нашел
        
        for (int i = 0; i < subscribers.Count; i++) // счетчик i, пока меньше кол-ва элементов, выполняет тело цикла, после чего прибавляет 1
        {
            if (subscribers[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase)) //Обращаемся к полю Name класса Abonent через subcribers[i]
            {
                Console.WriteLine($"Найден контакт #{i}:{subscribers[i].Name},{subscribers[i].Number}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Абонент с именем: {0} не найден", name);
        }
    }

    public static void FindByNumber(int number)
    {
        bool found = false;

        for (int i = 0; i < subscribers.Count; i++)
        {
            if (subscribers[i].Number == number) //обращение к полю Number класса Abonent через subscribers[i]
            {
                Console.WriteLine("Найден контакт #{i}: {subscribers[i].Name}, {subscribers[i].Number}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Абонент с номером {0} не найден.", number);
        }
    }

    /// <summary>
    /// Обновление статического поля subscribers
    /// </summary>
    /// <param name="data"></param>
    public static void SetData(List<Abonent> data)
    {
        subscribers = data;
    }

}


/// <summary>
/// Работа с txt
/// </summary>
public class StorageData
{
    private string filePath;

    // Конструктор для принятия путя файла
    public StorageData(string filePath)
    {
        this.filePath = filePath;
    }
    
    /// <summary>
    /// Сохранение листа в файл
    /// </summary>
    /// <param name="subscribers"></param>
    public void StorageSave(List<Abonent> subscribers)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Abonent abonent in subscribers)
            {
                writer.WriteLine("{0},{1}",abonent.Name, abonent.Number);
            }
        }

        Console.WriteLine("Список абонентов успешно сохранен в файл.");
    }

    /// <summary>
    /// Загрузка листа из файла
    /// </summary>
    /// <returns></returns>
    public static List<Abonent> StorageLoad(string filePath)
    {
        List<Abonent> loadedList = new List<Abonent>(); //создание пустого списка объектов типа Abonent
        
            using (StreamReader reader = new StreamReader(filePath)) // создание нового объекта для чтения из файла
            {
                string line; //временное хранение строчек файла
                while ((line = reader.ReadLine()) != null) 
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        int number = int.Parse(parts[1]);
                        Abonent abonent = new Abonent(name, number);
                        loadedList.Add(abonent);
                    }
                }
            }
            
        Console.WriteLine("Список абонентов успешно загружен из файлы.");
        return loadedList;
    }

}

/// <summary>
/// Данные об абоненте.
/// </summary>
public class Abonent
{
    public string Name; // Объявление полей
    public long Number;
    
    public Abonent(string name, long number) // Создание конструктора для заполнения данных
    {
        Name = name;
        Number = number;
    }
}