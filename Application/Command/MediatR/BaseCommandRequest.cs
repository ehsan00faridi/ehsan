
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Application.Command.MediatR
{
    public class BaseCommandRequest : IPresetModel
    {
        [BindNever]
        public int? UserId { get ; set; } 
        [BindNever]
        public bool IsAdmin {  get; set; }
    }
}
