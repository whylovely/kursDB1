namespace kursDB1.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Art> Arts { get; set; }
    }
}