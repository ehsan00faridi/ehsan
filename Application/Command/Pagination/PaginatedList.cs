using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Pagination
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages   { get; }

        public int TotalCount { get; }

        public PaginatedList(List<T> items, int pageNumber, int PageSize, int count)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count/(double)PageSize);
            TotalCount = count;

        }

        public bool HasPreviousPage=>     PageNumber > 1;
        public bool HasNextPage=> PageNumber < TotalPages;



        public static async Task<PaginatedList<T>> CreatAsync(IQueryable<T> Source ,int pageNumber, int pageSize, bool disablepaging)
        {
            var Count = await Source.CountAsync();
            if (!disablepaging)
            {
                var items = await Source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                return new PaginatedList<T>(items,pageNumber,pageSize,Count);
            }
            else
            {
                var itemsWithoutPagination=await Source.ToListAsync();
                return new PaginatedList<T>(itemsWithoutPagination,pageNumber,pageSize, Count);
            }


        }
    }
}
