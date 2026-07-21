
namespace Application.Command.MediatR
{
    public class BaseQueryRequest
    {
        public string Search {  get; set; }=string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public bool DisablePaging { get; set; } = false;

    }
}
