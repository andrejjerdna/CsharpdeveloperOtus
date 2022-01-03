using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSum
{
    internal interface ISummator
    {
        /// <summary>
        /// Using only foreach for summation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AdditionResult Sum(IEnumerable<int> data);

        /// <summary>
        /// Using threads for summation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AdditionResult ParallelSum(IEnumerable<int> data);

        /// <summary>
        /// Using LINQ for summation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AdditionResult LinqSum(IEnumerable<int> data);
    }
}
