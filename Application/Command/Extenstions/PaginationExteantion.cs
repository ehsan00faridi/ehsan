using Application.Command.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Extenstions
{
    public static class PaginationExteantion
    {
        ///test
        public static async Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> gueryable ,
            int pageNumber,
            int pageSie,bool disablepaging=false) { 
        return await PaginatedList<TDestination> .CreatAsync(gueryable,pageNumber, pageSie, disablepaging);
        }
    }
}
