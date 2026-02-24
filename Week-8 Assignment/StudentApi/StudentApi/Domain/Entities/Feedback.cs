using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Domain.Entities
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public AppUser? Student { get; set; }

        [Required]
        public Guid TrainerId { get; set; }

        [ForeignKey("TrainerId")]
        public AppUser? Trainer { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
