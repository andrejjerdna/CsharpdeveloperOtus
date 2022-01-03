using ParallelSum;

var generator = new DataGenerator();

var collection1 = generator.GenerateColletion(100000);
var collection2 = generator.GenerateColletion(1000000);
var collection3 = generator.GenerateColletion(10000000);

var summator = new Summator();

ParagraphWriter("FOREACH");
ResultWriter(summator.Sum(collection1));
ResultWriter(summator.Sum(collection2));
ResultWriter(summator.Sum(collection3));

ParagraphWriter("PARALLEL");
ResultWriter(summator.ParallelSum(collection1));
ResultWriter(summator.ParallelSum(collection2));
ResultWriter(summator.ParallelSum(collection3));

ParagraphWriter("LINQ");
ResultWriter(summator.LinqSum(collection1));
ResultWriter(summator.LinqSum(collection2));
ResultWriter(summator.LinqSum(collection3));

void ResultWriter(AdditionResult additionResult)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{additionResult.Title}: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Sum: {additionResult.Sum}, Total time: {additionResult.TotalSec} sec.");
    Console.ForegroundColor = ConsoleColor.White;
}

void ParagraphWriter(string name)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"_____{name}_____");
    Console.ForegroundColor = ConsoleColor.White;
}



