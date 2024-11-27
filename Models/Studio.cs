namespace kursDB1.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountArts { get; set; }
        public DateTime BDay { get; set; }

        public ICollection<Art> Arts { get; set; }
    }
}