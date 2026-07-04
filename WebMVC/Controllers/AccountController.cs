using Application.Command.Exceptions;
using Application.Features.Account.Command;
using Application.Interfaces;
using Domain.Models.User;
using Domain.Models.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace WebMVC.Controllers
{
    //[AllowAnonymous]

    public class AccountController : Controller
    {
        //    private readonly ISmsService _sms;

        private readonly IOtpService _otpService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IMediator _mediator;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IMediator mediator = null, IOtpService otpService = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_sms = sms;
            _mediator = mediator;
            _otpService = otpService;
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            try
            {
              var result =  await _mediator.Send(command);
                return RedirectToAction(nameof(VerifyOtp), new { userId = result.UserId });
            }
            catch (CustomException ex)
            {
                // Errors => ModelState
                foreach (var kv in ex.Errors)
                {
                    var key = kv.Key; // مثل "Email" یا "ConfirmPassword"
                    foreach (var msg in kv.Value)
                        ModelState.AddModelError(key, msg);
                }

                return View(command);
            }
        }
  
        [HttpGet]
        public IActionResult VerifyOtp(int UserId)
        {
            var userId = UserId.ToString();
            return View(new VerifyOtpCommand { UserId = userId ,Code=""});
        }


        [HttpPost]
        public async Task<IActionResult> VerifyOtp(VerifyOtpCommand model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = await _mediator.Send(model);

                if (!result)
                {
                    ModelState.AddModelError(nameof(model.Code),
             "  زمان کد به پایان رسیده یا کد نامعتبر است");
                    return View(model);
                }

                return RedirectToAction("Index", "Home");
            }
            catch (CustomException ex)
            {
                foreach (var kv in ex.Errors)
                    foreach (var msg in kv.Value)
                        ModelState.AddModelError(kv.Key, msg);

                return View(model);
            }
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return View(loginDto);

            var command = new LoginCommand(
                loginDto.Email,
                loginDto.Password,
                loginDto.RememberMe);

            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(loginDto);
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
        //    var user = await _userManager.FindByEmailAsync(loginDto.Email);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "کاربر یافت نشد");
        //        return View(loginDto);
        //    }
        //    user.EmailConfirmed= true;
        //    user.PhoneNumberConfirmed= true;
        //    var res = await _signInManager.PasswordSignInAsync(
        //        user,
        //        loginDto.Password,
        //        loginDto.RememberMe,
        //        false);

        //    if (res.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    if (res.IsNotAllowed)
        //    {
        //        if (!user.EmailConfirmed)
        //        {
        //            ModelState.AddModelError("", "ایمیل شما تایید نشده است.");
        //        }

        //        if (!user.PhoneNumberConfirmed)
        //        {
        //            ModelState.AddModelError("", "شماره موبایل شما تایید نشده است.");
        //        }

        //        return View(loginDto);
        //    }

        //    ModelState.AddModelError("", "اطلاعات ورود اشتباه است");
        //    return View(loginDto);
        //}


        public IActionResult SignInPhoneNumber()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignInPhoneNumber(PhoneNumberViewModel model)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);

            if (user == null)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), ("کاربری با این شماره یافت نشد."));

           //    ModelState.AddModelError("", "کاربری با این شماره یافت نشد.");
                return View(model);
            }
            await _otpService.SendOtpAsync(model.PhoneNumber);

            return RedirectToAction(nameof(VerifyOtp), new { userId = user.Id.ToString()});
        }


        public async Task<IActionResult> Logout()
        {



            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
