using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Extenstions
{
  public static class SearchExtesntion
    {
        public static IQueryable<T> SearchQuery<T>(this IQueryable<T> query, string search, params string[] fields)
        {
            string normalizedSearchQuery = search?.Trim();
            if (string.IsNullOrWhiteSpace(normalizedSearchQuery))
            {
                return query;
            }

            if (fields == null || fields.Length == 0)
            {
                fields = typeof(T).GetProperties()
                                  .Where(p => p.PropertyType == typeof(string))
                                  .Select(p => p.Name)
                                  .ToArray();
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression body = null;

            foreach (var field in fields)
            {
                var property = typeof(T).GetProperty(field);
                if (property == null || property.PropertyType != typeof(string))
                {
                    continue;
                }

                var propertyAccess = Expression.Property(parameter, property);
                var likeExpression = Expression.Call(
                    typeof(DbFunctionsExtensions).GetMethod(nameof(DbFunctionsExtensions.Like), new[] { typeof(DbFunctions), typeof(string), typeof(string) }),
                    Expression.Constant(EF.Functions),
                    propertyAccess,
                    Expression.Constant($"%{normalizedSearchQuery}%")
                );

                body = body == null ? likeExpression : Expression.OrElse(body, likeExpression);
            }

            if (body == null)
            {
                return query;
            }

            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(predicate);
        }
    }
}
