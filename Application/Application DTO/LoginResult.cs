using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application_DTO
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool UserNotFound { get; set; }
        public bool InvalidCredentials { get; set; }
        public bool EmailNotConfirmed { get; set; }
        public bool PhoneNotConfirmed { get; set; }

        public List<string> Errors { get; set; } = new();
    }

}
