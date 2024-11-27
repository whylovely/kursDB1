namespace kursDB1.Models
{
    public class Art
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public int StudioId { get; set; }
        public int LabelId { get; set; }
        public int Duration { get; set; }
        public int MarkArt { get; set; }

        public Album Album { get; set; }
        public Artist Artist { get; set; }
        public Director Director { get; set; }
        public Genre Genre { get; set; }
        public Studio Studio { get; set; }
        public Label Label { get; set; }
    }
}