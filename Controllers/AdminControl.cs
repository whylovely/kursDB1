using kursDB1.Services;
using kursDB1.Models;

namespace kursDB1.Controllers
{
    public class AdminController
    {
        private readonly AdminService _adminService;

        public AdminController()
        {
            _adminService = new AdminService();
        }

        public void AddArt(Art art)
        {
            _adminService.AddArt(art);
        }

        public void AddAlbum(Album album)
        {
            _adminService.AddAlbum(album);
        }

        public void AddLabel(Label label)
        {
            _adminService.AddLabel(label);
        }

        public void AddStudio(Studio studio)
        {
            _adminService.AddStudio(studio);
        }

        public void AddDirector(Director director)
        {
            _adminService.AddDirector(director);
        }

        public void AddGenre(Genre genre)
        {
            _adminService.AddGenre(genre);
        }
    }
}
