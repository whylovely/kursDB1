namespace kursDB1.Models
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string FontFamily { get; set; }  // Имя шрифта (например, Arial)
        public float FontSize { get; set; }     // Размер шрифта (например, 12.0)
    }
}