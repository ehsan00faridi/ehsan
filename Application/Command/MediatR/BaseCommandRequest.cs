
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Application.Command.MediatR
{
    public class BaseCommandRequest : IPresetModel
    {
        [BindNever]
        public int? UserId { get ; set; } 
        [BindNever]
        public bool IsAdmin {  get; set; }=false;

        public bool IsAuthenticated = false;

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public bool IsInRole(string role)
        {
           return false;
        }
    }
}
