using Application.Command.MediatR;
using Application.Services.CurrentUser.Application.Command.Interfaces;
using MediatR;

namespace Application.Behaviors
{
    public class PresetBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IPresetModel
    {
        private readonly ICurrentUserService _currentUserService;

        public PresetBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_currentUserService.IsAuthenticated)
            {
                request.UserId = _currentUserService.UserId;
                request.IsAdmin = _currentUserService.IsInRole("Admin");
                request.Email = _currentUserService.Email;
                request.UserName = _currentUserService.UserName;
            }
            else
            {
                request.UserId = null;
                request.IsAdmin = false;
            }

            return await next();
        }
    }
}

