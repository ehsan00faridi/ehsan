using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Email
{
    public sealed class EmailSettings
    {
        public string Host { get; init; } = default!;
        public int Port { get; init; }
        public string Username { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string From { get; init; } = default!;
    }

}
