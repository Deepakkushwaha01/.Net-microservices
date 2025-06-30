using System.Linq.Expressions;
using Mst.Common.Packages.Dtos;
using Mst.Common.Packages.Enumerations;
using System.Linq.Dynamic.Core;


namespace Mst.Common.Packages.Extensions
{
    public static class PaginatedQueryExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PaginatedRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                query = query.ApplyOrderBy(request.OrderBy);
            }

            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                query = query.ApplyFilterBy(request.Filter);
            }

            if (request.Offset.HasValue)
            {
                query = query.Skip(request.Offset.Value);
            }

            if (request.Limit.HasValue)
            {
                query = query.Take(request.Limit.Value);
            }

            return query;
        }

        public static IQueryable<T> ApplyFilterBy<T>(this IQueryable<T> query, string filter)
        {
            try
            {
                string transformedFilter = filter.Replace(" eq ", " == ")
.Replace(" ne ", " != ")
.Replace(" gt ", " > ")
.Replace(" lt ", " < ")
.Replace(" ge ", " >= ")
.Replace(" le ", " <= ");

                return query.Where(transformedFilter);
            }
            catch
            {
                return query;
            }
        }

        public static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> query, string OrderBy)
        {
            var OrderByValue = OrderBy.Trim().Split(" ");
            var OrderByProperty = OrderByValue[0];
            var OrderByPropertyValue = OrderByValue[1];
            if (OrderByPropertyValue.ToLower() != OrderByEnumeration.Asc?.ToString()?.ToLower() && OrderByPropertyValue.ToLower() != OrderByEnumeration.Desc?.ToString()?.ToLower())
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, OrderByProperty);
            var lambda = Expression.Lambda(property, parameter);

            var isDescending = OrderByPropertyValue.ToLower() != OrderByEnumeration.Desc?.ToString()?.ToLower();
            var methodName = isDescending ? "OrderByDescending" : "OrderBy";

            var result = typeof(Queryable).GetMethods()
    .First(method => method.Name == methodName
                     && method.GetParameters().Length == 2)
    .MakeGenericMethod(typeof(T), property.Type)
    .Invoke(null, new object[] { query, lambda });

            return (IQueryable<T>)result!;
        }
    }
}