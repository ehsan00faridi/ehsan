using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Application.Command.MediatR
{
    public class BaseCommandRequest : IPresetModei
    {
        [BindNever]
        public int? UserId { get ; set; }
        [BindNever]
        public bool IsAdmin {  get; set; }
    }
}
