namespace Application.Services.CurrentUser
{
    namespace Application.Command.Interfaces
    {
        public interface ICurrentUserService
        {
            bool IsAuthenticated { get; }
            int? UserId { get; }
            string? UserName { get; }
            string Email { get; }
            bool IsInRole(string role);
        }
    }

}
