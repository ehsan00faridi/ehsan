using Application.Services.CurrentUser.Application.Command.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CurrentUser.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public int? UserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user == null) return null;

                var userIdClaim =
                    user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? user.FindFirst("sub")?.Value
                    ?? user.FindFirst("UserId")?.Value;

                if (int.TryParse(userIdClaim, out var userId))
                    return userId;

                return null;
            }
        }

        public string? UserName =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        public string? Email =>
            _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

        public bool IsInRole(string role) =>
            _httpContextAccessor.HttpContext?.User?.IsInRole(role) ?? false;
    }
}
