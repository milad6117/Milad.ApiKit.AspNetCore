using System;
using System.Collections.Generic;
using System.Linq;

namespace BookOnline.Shared.Pagination
{
    public class PagedData<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PaginationMetadata Metadata { get; set; }

        public PagedData(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            Metadata = new PaginationMetadata
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
        }

        // در کلاس PagedData
        // برای وقتی که میخوایم از Dapper استفاده کنیم
        public static PagedData<T> Create(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            return new PagedData<T>(items.ToList(), count, pageNumber, pageSize);
        }
    }

}
