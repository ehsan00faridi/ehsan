using Application.Application_DTO;
using Domain.Models.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace Application.Features.Account.Command
{
   

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = new LoginResult();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                result.UserNotFound = true;
                result.Errors.Add("کاربر یافت نشد");
                return result;
            }

          
            //user.EmailConfirmed = true;
            //user.PhoneNumberConfirmed = true;

            await _userManager.UpdateAsync(user);

            var signInResult = await _signInManager.PasswordSignInAsync(
                user,
                request.Password,
                request.RememberMe,
                lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                result.Succeeded = true;
                return result;
            }

            if (signInResult.IsNotAllowed)
            {
                result.IsNotAllowed = true;

                if (!user.EmailConfirmed)
                {
                    result.EmailNotConfirmed = true;
                    result.Errors.Add("ایمیل شما تایید نشده است.");
                }

                if (!user.PhoneNumberConfirmed)
                {
                    result.PhoneNotConfirmed = true;
                    result.Errors.Add("شماره موبایل شما تایید نشده است.");
                }

                return result;
            }

            result.InvalidCredentials = true;
            result.Errors.Add("اطلاعات ورود اشتباه است");

            return result;
        }
    }

}
