using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeatures
{
    internal interface IGameItem
    {
        /// <summary>
        /// List of answer
        /// </summary>
        IEnumerable<IAnswer> AnswerOptions { get; }

        /// <summary>
        /// Question
        /// </summary>
        IQuestion Question { get; }

        /// <summary>
        /// Check a user answer
        /// </summary>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        bool CheckAnswer(int userAnswer);
    }
}
