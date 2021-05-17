using System.Linq;

namespace Datarynx.Helpers
{
    /// <summary>
    /// Helper class
    /// </summary>
    public static class LinqHelper
    {
        /// <summary>
        /// Used to sort based on column and type of sorting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <param name="isAscending"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName, bool isAscending = true)
        { 
                if (isAscending)
                {
                    var orderedItems = source.OrderBy(item => typeof(T).GetProperty(columnName).GetValue(item).ToString());
                    return orderedItems;
                }
                else
                {
                    var orderedItems = source.OrderByDescending(item => typeof(T).GetProperty(columnName).GetValue(item).ToString());
                    return orderedItems;
                }
            }
        }
    
}
