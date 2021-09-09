using System;

namespace SQLdb
{
    class Program
    {
        static void Main(string[] args)
        {
            var dd = new SqlProvider();

            var version = dd.GetVersion();
            
            Console.WriteLine(version);
        }
    }
}