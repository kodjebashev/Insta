using Insta.Data.Identity;

namespace Insta.Services.Interfaces
{
    public interface IUserServices
    {
        List<AppUser> GetAllUsers();
        AppUser GetUserByEmail(string mail);
        AppUser GetByUsername(string username);
        userProxy findLogedUserProxy();
        AppUser GetCurrentUser();
        void CreateUser(AppUser user);
    }
}