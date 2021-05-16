using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Datarynx.Helpers
{
   public static class LinqHelper
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName, bool isAscending = true)
        {
            try
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

              

                //ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

                //MemberExpression property = Expression.Property(parameter, columnName);
                //LambdaExpression lambda = Expression.Lambda(property, parameter);

                //string methodName = isAscending ? "OrderBy" : "OrderByDescending";




                //Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                //                      new Type[] { source.ElementType, property.Type },
                //                      source.Expression, Expression.Quote(lambda));

                //return source.Provider.CreateQuery<T>(methodCallExpression);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
