namespace ParallelSum
{
    internal interface IDataGenerator
    {
        IEnumerable<int> GenerateColletion(int count);
    }
}
