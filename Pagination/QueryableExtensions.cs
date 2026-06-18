using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BookOnline.Shared.Pagination
{
    public static class QueryableExtensions
    {
        public static async Task<PagedData<T>> ToPagedListAsync<T>(
      this IQueryable<T> source,
      int pageNumber,
      int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedData<T>(items, count, pageNumber, pageSize);
        }

        // متد جدید (Overload) برای راحتی کار با PaginationParams
        public static Task<PagedData<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            PaginationParams @params)
        {
            return source.ToPagedListAsync(@params.PageNumber, @params.PageSize);
        }
    }
}
