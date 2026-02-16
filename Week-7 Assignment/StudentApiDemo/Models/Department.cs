namespace StudentApiDemo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Student>? Students { get; set; }
    }
}
