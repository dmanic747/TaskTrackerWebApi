using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Filters;
using TaskTracker.Data.Models;

namespace TaskTracker.Data.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, ISortable sorter, Dictionary<string, Expression<Func<T, object>>> fieldsMapper)
        {

            if (string.IsNullOrWhiteSpace(sorter.SortBy) || !fieldsMapper.ContainsKey(sorter.SortBy))
                return query;

            if (sorter.IsSortAscending)
                return query.OrderBy(fieldsMapper[sorter.SortBy]);
            else
                return query.OrderByDescending(fieldsMapper[sorter.SortBy]);
        }


    }
}
