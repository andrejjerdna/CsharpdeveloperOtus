using System;
using System.Collections.Generic;
using System.Linq;

namespace Events
{
    public static class Extensions
    {
        /// <summary>
        /// Получаем максимальный файл из указанной последовательности.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="getParameter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            var maxValue = e.Max(getParameter);
            return e.Where(obj => Math.Abs(getParameter(obj) - maxValue) < 0.00000001).FirstOrDefault();
        }
    }
}