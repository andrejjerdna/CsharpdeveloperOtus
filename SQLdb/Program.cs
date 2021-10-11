using System;
using System.Linq;
using Npgsql;
using SQLdb.Models;

namespace SQLdb
{
    class Program
    {
        static void Main(string[] args)
        {
            var status = true;

            while (status)
            {
                Console.WriteLine(
                    @"Введите один из вариантов:
                       1 - создание таблиц
                       2 - сгенерировать новые данные для таблиц
                       3 - вывести содержание таблиц
                       4 - завершить работу приложения");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        var createTables = new TablesCreator(CommonParameters.ConnectString);
                        createTables.CreateMessage += MessageWriter;
                        createTables.CreateTables();
                        createTables.CreateMessage -= MessageWriter;
                        break;

                    case "2":
                        var dataGenerator = new DataGenerator(CommonParameters.ConnectString);
                        dataGenerator.CreateMessage += MessageWriter;
                        dataGenerator.Generate();
                        dataGenerator.CreateMessage -= MessageWriter;
                        break;
                    
                    case "3":
                        var dataReader = new DataReader(CommonParameters.ConnectString); 
                        dataReader.CreateMessage += MessageWriter;
                        dataReader.WriteAllStores();
                        dataReader.WriteAllProducts();
                        dataReader.CreateMessage -= MessageWriter;
                        break;
                    
                    case "4":
                        status = false;
                        Console.WriteLine("Работа приложения завершена!");
                        break;

                    default:
                        Console.WriteLine("Введена неправильная команда!");
                        break;
                }
            }
        }

        private static void MessageWriter(object? sender, string message)
        {
            Console.WriteLine(message);
        }
    }
}