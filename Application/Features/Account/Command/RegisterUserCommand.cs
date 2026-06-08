using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Command
{
    public record RegisterUserCommand(
      string FirstName,
      string LastName,
      string Email,
      string Password,
      string ConfirmPassword,
      string PhoneNumber
  ) : IRequest<RegisterResult>;

    public record RegisterResult(int UserId, string PhoneNumber,string Code);
    public record VerifyOtpCommand(string UserId, string Code) : IRequest<bool>;


}
