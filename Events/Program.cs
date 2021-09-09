using System;

namespace Events
{
    class Program
    {
        private const string FileFoundMessage = @"Успешно загружен файл";
        private const string MaxFileFoundMessage = @"Самый большой файл найден! Выполнение остановлено!";
        private const string Path = @"C:\Users\33pro\OneDrive\Рабочий стол\ConfuserEx_bin";
        
        static void Main(string[] args)
        {
            var v = new CatalogWatcher(Path);
            v.FileFound += NotificationFilesFound;
            v.MaxFileFound += NotificationMaxFilesFound;
            v.SearchingFilesStart();
        }

        private static void NotificationFilesFound(object? sender, FileArgs e)
        {
            Console.WriteLine("{0}: {1}", FileFoundMessage, e.FileName);
        }
        
        private static void NotificationMaxFilesFound(object? sender, FileArgs e)
        {
            Console.WriteLine(MaxFileFoundMessage);
        }
    }
}