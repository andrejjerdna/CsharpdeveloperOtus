using ParallelSum;

var generator = new DataGenerator();

var collection1 = generator.GenerateColletion(100000);
var collection2 = generator.GenerateColletion(1000000);
var collection3 = generator.GenerateColletion(1000000);

foreach (var item in collection)
{
    Console.WriteLine(item.ToString());
}

