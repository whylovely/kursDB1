namespace kursDB1.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountArts { get; set; }
        public DateTime BDate { get; set; }

        public ICollection<Art> Arts { get; set; }
    }
}