using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PaginationAPI.Models.Dto
{
    public class PagedResponse<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalEntites { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PagedResponse(IQueryable<T> source, int pageIndex, int pageSize,string sortOrder)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalEntites = source.Count();
            TotalPages = (int)Math.Ceiling((double)TotalEntites / PageSize);
            Data = ApplySorting(source, sortOrder)
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
        }

        private IQueryable<T> ApplySorting(IQueryable<T> source, string sortOrder)
        {
            bool isDesc = false;
            if (sortOrder.EndsWith("Desc"))
            {
                isDesc = true;
                sortOrder = sortOrder.Substring(0, sortOrder.Length - 4);
            }                

            if (!string.IsNullOrEmpty(sortOrder))
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, sortOrder);
                var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

                if (isDesc)                
                    return source.OrderByDescending(lambda);               
                else                
                    return source.OrderBy(lambda);                
            }

            return source;
        }
    }
}
