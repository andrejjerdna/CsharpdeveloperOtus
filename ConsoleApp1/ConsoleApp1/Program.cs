using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static string _path = @"C:\Users\33pro\OneDrive\Рабочий стол\test";

        static void Main(string[] args)
        {
            var documentsReceiver = new DocumentsReceiver();
            documentsReceiver.Start(_path, 20000);
            documentsReceiver.TimedOut += DocumentsReceiver_TimedOut;
            documentsReceiver.DocumentsReady += DocumentsReceiver_DocumentsReady;

            Console.ReadLine();
        }

        private static void DocumentsReceiver_DocumentsReady()
        {
            Console.WriteLine("Успешно загружено!");
        }

        private static void DocumentsReceiver_TimedOut()
        {
            Console.WriteLine("Не успели!");
        }
    }
}
