namespace EF10.Entities
{
    public class Enrollment
    {
        public int SectionId { get; set; }
        public int StudentId { get; set; }
        public Section Section { get; set; }
        public Student Student { get; set; }
    }
}
