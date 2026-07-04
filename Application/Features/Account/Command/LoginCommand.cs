using Application.Application_DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Command
{
    public record LoginCommand(
    string Email,
    string Password,
    bool RememberMe
) : IRequest<LoginResult>;
}
