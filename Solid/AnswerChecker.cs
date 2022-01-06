using Solid.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class AnswerChecker : IAnswerChecker
    {
        public bool CheckAnswer(IDigitAnswer answer, IDigitAnswer userAnswer)
        {
           return answer.DigitAnswer == userAnswer.DigitAnswer;
        }

        //TODO: Not implemented
        public bool CheckAnswer(IStringAnswer answer, IStringAnswer userAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
