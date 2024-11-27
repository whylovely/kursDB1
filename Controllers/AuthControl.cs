using kursDB1.Services;
using kursDB1.Models;

namespace kursDB1.Controllers
{
    public class AuthController
    {
        private readonly AuthService _authService;

        public AuthController()
        {
            _authService = new AuthService();
        }

        public User Login(string email, string password)
        {
            return _authService.Authenticate(email, password);
        }

        public void Register(string name, string email, string password, int roleId)
        {
            _authService.RegisterUser(new User
            {
                Name = name,
                Email = email,
                Password = password,
                RoleId = roleId
            });
        }
    }
}
