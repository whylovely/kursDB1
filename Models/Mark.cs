namespace kursDB1.Models
{
    public class Mark
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ArtId { get; set; }
        public Art Art { get; set; }

        public int MarkValue { get; set; }
    }
}