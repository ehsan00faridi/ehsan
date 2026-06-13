using Application.Interfaces;
using Domain.Models.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Command
{
    public class VerifyOtpCommandHandler
    : IRequestHandler<VerifyOtpCommand, bool>{

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IOtpService _otpService;


        public VerifyOtpCommandHandler(IOtpService otpService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _otpService = otpService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Handle(
            VerifyOtpCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());


            if (user == null || string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                return false;

            }


            var result = await _otpService.VerifyOtpAsync(user.PhoneNumber, request.Code);

            if (!result)
            {
                return result;
            }

            user.PhoneNumberConfirmed = true;
            await _signInManager.SignInAsync(user, isPersistent: false);

            await _signInManager.SignInAsync(user, isPersistent: false);
            return true;


        }
    }

}
