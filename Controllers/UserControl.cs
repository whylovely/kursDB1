using kursDB1.Services;
using kursDB1.Models;

using System.Collections.Generic;

namespace kursDB1.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public List<Art> GetArts()
        {
            return _userService.GetAllArts();
        }

        public void RateArt(int userId, int artId, int mark)
        {
            _userService.AddMark(userId, artId, mark);
        }

        public List<Mark> GetUserMarks(int userId)
        {
            return _userService.GetUserMarks(userId);
        }
    }
}
