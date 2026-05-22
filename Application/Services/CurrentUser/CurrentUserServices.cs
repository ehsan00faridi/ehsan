using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Services.CurrentUser
{
    public class CurrentUserServices : ICurrentUserServices
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserServices(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }



        public int? UserId { get {
                var User = _contextAccessor.HttpContext?.User;
                if (User != null) {
                    var claim = User.FindFirst(ClaimTypes.NameIdentifier);
                    if (claim!= null)
                    {
                        if (int.TryParse(claim.Value,out int userId ))
                        {
                          return userId;
                        }
                    }
                }

                return null;
            
            } }


        public bool IsAdmin { get {
                var user = _contextAccessor.HttpContext?.User;
                if (user != null) { 
                var rolecliam= user.FindFirst(ClaimTypes.Role);
                    if (rolecliam != null && rolecliam.Value=="Admin")
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
