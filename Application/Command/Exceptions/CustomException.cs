using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Exceptions
{
    public sealed class CustomException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }

        public CustomException(IReadOnlyDictionary<string, string[]> errors)
            : base("Validation failed")
            => Errors = errors;
    }
}
