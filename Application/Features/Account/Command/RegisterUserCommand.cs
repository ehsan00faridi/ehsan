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
    public class VerifyOtpCommand() : IRequest<bool> {
        public string UserId { get; set; } =string.Empty;

        public string Code { get; set; } = "";
    }


}
