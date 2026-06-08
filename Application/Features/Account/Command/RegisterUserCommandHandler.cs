using Application.Command.Exceptions;
using Application.Interfaces;
using Application.Services.Sms;
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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterResult>
    {
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //private readonly ISmsService _smsService;
        private readonly IOtpService _otpService;
        public RegisterUserCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ISmsService smsService = null,
            IOtpService otpService = null)

        {
            _userManager = userManager;
            //_signInManager = signInManager;
            //_smsService = smsService;
            _otpService = otpService;
        }

        public async Task<RegisterResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
           
            if (request.Password != request.ConfirmPassword)
                throw new CustomException(new Dictionary<string, string[]>
                {
                    ["ConfirmPassword"] = ["The Password and Confirm password do not match"]
                });
         

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
            //    Email = request.Email,
            //    PhoneNumber = request.PhoneNumber,
            //    PhoneConfirmed = false
            //};

            var code = GenerateOtp6Digits();

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
               
                var errors = result.Errors
                    .GroupBy(e => e.Code) 
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.Description).ToArray()
                    );

                throw new CustomException(errors);
            }
            // await _smsService.SendOtpAsync(user.PhoneNumber, code);


            await _otpService.SendOtpAsync(user.PhoneNumber);
            //Console.WriteLine("\n\n\n Code="+ code +"\n\n\n" );

            //   await _userManager.CreateAsync(user);
            //  await _signInManager.SignInAsync(user, isPersistent: false);

            return new RegisterResult(user.Id, user.PhoneNumber,code);

           
        }
        private static string GenerateOtp6Digits()
    => Random.Shared.Next(100000, 999999).ToString();
    }


}
