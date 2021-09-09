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
            return e.Select(rr => new { item = rr, rrr = getParameter(rr) })
                .OrderBy(t => t.rrr)
                .FirstOrDefault()
                ?.item;
        }
    }
}