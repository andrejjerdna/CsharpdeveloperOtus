using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSum
{
    internal struct AdditionResult
    {
        /// <summary>
        /// The result of addition
        /// </summary>
        public double Sum { get; }

        /// <summary>
        /// Total seconds
        /// </summary>
        public double TotalSec { get; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; }

        public AdditionResult(double sum, double totalSec, string title)
        {
            Sum = sum;
            TotalSec = totalSec;
            Title = title;
        }
    }
}
