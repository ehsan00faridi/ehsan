using Application.Command.Exceptions;
using Domain.Models.User;
// Application Layer
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterUserCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // نکته: ConfirmPassword را بهتر است با FluentValidation چک کنی
            // (اینجا هم می‌تونیم Defensive چک کنیم)
            if (request.Password != request.ConfirmPassword)
                throw new CustomException(new Dictionary<string, string[]>
                {
                    ["ConfirmPassword"] = ["The Password and Confirm password do not match"]
                });
            //[HttpPost]
            //public async Task<IActionResult> Register(RegisterDto register)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        
            //        var res = await _userManager.CreateAsync(user, register.Password);
            //        if (res.Succeeded)
            //        {
            //            await _signInManager.SignInAsync(user, isPersistent: false);
            //            return RedirectToAction("Index", "Home");
            //        }

            //    }
            //    return View(register);
            //}

            var user = new User {
                FirstName = request.FirstName,
                LastName = request.LastName, 
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber };

            //var user = new User
            //{
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    UserName = request.Email,
            //    Email = request.Email,
            //    PhoneNumber = request.PhoneNumber
            //};

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                // تبدیل خطاهای Identity به همون فرمت CustomException.Errors
                var errors = result.Errors
                    .GroupBy(e => e.Code) // یا "Identity" / یا هر کلید دلخواه مثل ""
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.Description).ToArray()
                    );

                throw new CustomException(errors);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            // اگر User.Id از نوع Guid است:
            return true;

            // اگر User.Id رشته‌ای است (IdentityUser<string>)، اینطور برگردون:
            // return Guid.Parse(user.Id);
        }
    }

}
