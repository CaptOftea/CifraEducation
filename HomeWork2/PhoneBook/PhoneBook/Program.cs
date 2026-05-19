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
                List<Abonent> loadedList = StorageData.StorageLoad("book.txt");
                Manager.ShowData(loadedList);
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
/// Работа с листом
/// </summary>
public class Manager
{
    private static List<Abonent> subscribers; // список как поле класса
    
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
        Console.WriteLine("Введите имя абонента: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите номер абонента: ");
        int number = int.Parse(Console.ReadLine());
        Abonent newAbonent = new Abonent(name, number);
        subscribers.Add(newAbonent); 
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
        subscribers.RemoveAt(subscribers.Count - 1);
    }

    /// <summary>
    /// Сменить информацию абонента
    /// </summary>
    /// <param name="newName"></param>
    /// <param name="newNumber"></param>
    public static void ChangeData( string newName, int newNumber)
    {
        Console.WriteLine("Какой контакт вы хотите изменить?");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < subscribers.Count)
        {
            string oldName = subscribers[index].Name; subscribers[index].Name = newName;
            int oldNumber = subscribers[index].Number; subscribers[index].Number = newNumber;
            
            Console.WriteLine("Контакт изменен: {0} ({1}) -> {2} ({3})", oldName, oldNumber, newName, newNumber);
        }
        else
        {
            Console.WriteLine("Ошибка: контект не найден!");
        }

    }
    
}


//Работа с txt
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
        {
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
        }
        return loadedList;
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