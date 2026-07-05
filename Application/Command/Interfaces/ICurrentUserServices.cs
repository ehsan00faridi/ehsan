using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CurrentUser
{
    namespace Application.Command.Interfaces
    {
        public interface ICurrentUserService
        {
            bool IsAuthenticated { get; }
            int? UserId { get; }
            string? UserName { get; }
            string Email { get; }
            bool IsInRole(string role);
        }
    }

}
