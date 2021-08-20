using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var testClass = F.Get();

            var csv = Serialize.SerializeFromObjectToCsv(testClass);
            
            Console.WriteLine("Results my serialize: {0}", csv);
            
            ResetTime(timer, "My serialize:=");

            var obj = Serialize.DeserializeFromCsvToObject<F>(csv);
            
            ResetTime(timer, "My deserialize:");
            
            var json = JsonConvert.SerializeObject(testClass);
            
            Console.WriteLine("Results Newtonsoft: {0}", json);
            
            ResetTime(timer, "My Newtonsoft serialize:");
            
            var m = JsonConvert.DeserializeObject<F>(json);
            
            ResetTime(timer, "My Newtonsoft deserialize:");
            
            timer.Stop();
        }

        private static void ResetTime(Stopwatch timer, string mark)
        {
            timer.Stop();
            Console.WriteLine("{0} {1} {2}", mark, timer.ElapsedMilliseconds,"milliseconds");
            timer.Reset();
            timer.Start();
        }
    }
}