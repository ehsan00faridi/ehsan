using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.MediatR
{
    public interface IPresetModel
    {
        int? UserId { get; set; }
        bool IsAdmin {  get; set; }
    }
}
