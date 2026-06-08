//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Features.Account.Command
//{
//    public class VerifyOtpCommandHandler
//    : IRequestHandler<VerifyOtpCommand, bool>
//    {
//        private readonly IOtpService _otpService;

//        public VerifyOtpCommandHandler(IOtpService otpService)
//        {
//            _otpService = otpService;
//        }

//        public async Task<bool> Handle(
//            VerifyOtpCommand request,
//            CancellationToken cancellationToken)
//        {
//            var isValid = await _otpService.VerifyOtpAsync(
//                request.PhoneNumber,
//                request.Code
//            );

//            if (!isValid)
//                return false;

//            await _otpService.RemoveOtpAsync(request.PhoneNumber);

//            // اینجا PhoneConfirmed = true کن

//            return true;
//        }
//    }

//}
