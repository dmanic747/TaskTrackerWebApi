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

        public static IQueryable<Project> ApplyRangeFiltering(this IQueryable<Project> query, IRangeFilter filter)
        {
            if (filter.StartAt.HasValue && filter.EndAt.HasValue)
            {
                return query.Where(project => 
                    project.StartDate >= filter.StartAt &&
                    project.CompletionDate <= filter.EndAt);
            }

            if (filter.StartAt.HasValue)
                return query.Where(project => project.StartDate == filter.StartAt);


            if (filter.EndAt.HasValue)
                return query.Where(project => project.CompletionDate == filter.EndAt);

            return query;
        }

        public static IQueryable<Project> ApplyExactValueFiltering(this IQueryable<Project> query, IExactValueFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(project => 
                    project.Name.Equals(filter.Name));

            if (filter.Priority.HasValue)
                query = query.Where(project => project.Priority == filter.Priority.Value);

            if (filter.Status.HasValue)
                query = query.Where(project => (byte)project.Status == filter.Status.Value);

            return query;
        }




    }
}
