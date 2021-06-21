using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace ЛР6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*---- СОЗДАНИЕ ОБЪЕКТОВ ----*");
            Console.WriteLine("*---- Создание объекта 'машина' ----*");
            Console.Write("Введите модель машины: ");
            string name = Console.ReadLine();
            Console.Write("Введите производителя: ");
            string firm = Console.ReadLine();
            Console.Write("Введите имя владельца: ");
            string owner = Console.ReadLine();
            Car car = new Car(name, firm, owner);
            Console.WriteLine("Объект 'машина' создан.");
            Console.WriteLine();
            Console.WriteLine("*---- Создание объекта 'человек' ----*");
            Console.Write("Введите имя: ");
            string pname = Console.ReadLine();
            Console.Write("Введите возраст: ");
            string age = Console.ReadLine();
            Person person = new Person(pname, age);
            Console.WriteLine("Объект 'человек' создан.");

            string path = @"C:\Users\пользователь\Desktop\Учеба\6й семестр\ТМП\ЛР7\Сериализованные объекты";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            Console.WriteLine();
            Console.WriteLine("*---- СЕРИАЛИЗАЦИЯ ----*");
            Console.WriteLine();
            Console.WriteLine("*---- Процесс базовой бинарной сериализации ----*");
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream($@"{path}\bin_car.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, car);
                Console.WriteLine("Объект 'машина' сериализован.");
            }
            using (FileStream fs = new FileStream($@"{path}\bin_people.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, person);
                Console.WriteLine("Объект 'человек' сериализован.");
            }
            Console.WriteLine();
            Console.WriteLine("*---- Процесс XML-сериализации ----*");
            XmlSerializer xmlFormatter1 = new XmlSerializer(typeof(Car));
            using (FileStream fs = new FileStream($@"{path}\xml_car.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter1.Serialize(fs, car);
                Console.WriteLine("Объект 'машина' сериализован.");
            }
            XmlSerializer xmlFormatter2 = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream($@"{path}\xml_person.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter2.Serialize(fs, person);
                Console.WriteLine("Объект 'человек' сериализован.");
            }
            Console.WriteLine();
            Console.WriteLine("*---- Процесс JSON-сериализации ----*");
            string json_car = JsonSerializer.Serialize<Car>(car);
            Console.WriteLine("Объект 'машина' сериализован.");
            string json_person = JsonSerializer.Serialize<Person>(person);
            Console.WriteLine("Объект 'человек' сериализован.");

            Console.WriteLine();
            Console.WriteLine("*---- ДЕСЕРИАЛИЗАЦИЯ ----*");
            Console.WriteLine();
            Console.WriteLine("*---- Процесс бинарной десериализации ----*");
            using (FileStream fs = new FileStream($@"{path}\bin_car.dat", FileMode.OpenOrCreate))
            {
                Car newCar = (Car)binaryFormatter.Deserialize(fs);
                Console.Write("Объект 'машина' десериализован: ");
                Console.WriteLine($"Модель: {newCar.Name} --- Фирма: {newCar.Firm} --- Имя владельца: {newCar.Owner}.");
            }
            using (FileStream fs = new FileStream($@"{path}\bin_people.dat", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)binaryFormatter.Deserialize(fs);
                Console.Write("Объект 'человек' десериализован: ");
                Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}.");
            }
            Console.WriteLine();
            Console.WriteLine("*---- Процесс XML-десериализации ----*");
            using (FileStream fs = new FileStream($@"{path}\xml_car.xml", FileMode.OpenOrCreate))
            {
                Car newCar = (Car)xmlFormatter1.Deserialize(fs);
                Console.Write("Объект 'машина' десериализован: ");
                Console.WriteLine($"Модель: {newCar.Name} --- Фирма: {newCar.Firm} --- Имя владельца: {newCar.Owner}.");
            }
            using (FileStream fs = new FileStream($@"{path}\xml_person.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)xmlFormatter2.Deserialize(fs);
                Console.Write("Объект десериализован: ");
                Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            }
            Console.WriteLine();
            Console.WriteLine("*---- Процесс JSON-десериализации ----*");
            Car someCar = JsonSerializer.Deserialize<Car>(json_car);
            Console.Write("Объект десериализован: ");
            Console.WriteLine($"Модель: {someCar.Name} --- Фирма: {someCar.Firm} --- Имя владельца: {someCar.Owner}.");
            Person somePerson = JsonSerializer.Deserialize<Person>(json_person);
            Console.Write("Объект десериализован: ");
            Console.WriteLine($"Имя: {somePerson.Name} --- Возраст: {somePerson.Age}");

            Console.ReadLine();
        }
    }
}
