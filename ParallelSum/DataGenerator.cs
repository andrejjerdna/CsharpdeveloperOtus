namespace ParallelSum
{
    internal class DataGenerator : IDataGenerator
    {
        public IEnumerable<int> GenerateColletion(int count)
        {
            return Enumerable.Range(0, count);
        }
    }
}
