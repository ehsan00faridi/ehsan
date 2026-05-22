using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application_DTO
{
    public sealed class EmailMessage
    {
        public string To { get; init; } = default!;
        public string Subject { get; init; } = default!;
        public string Body { get; init; } = default!;
        public bool IsHtml { get; init; } = true;
    }

}
