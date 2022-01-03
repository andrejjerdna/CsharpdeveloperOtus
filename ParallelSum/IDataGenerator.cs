namespace ParallelSum
{
    internal interface IDataGenerator
    {
        /// <summary>
        /// Generate list of int
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<int> GenerateColletion(int count);
    }
}
