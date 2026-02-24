using System.ComponentModel.DataAnnotations;

namespace StudentApi.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;
    }
}
