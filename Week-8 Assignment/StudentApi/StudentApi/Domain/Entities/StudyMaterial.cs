using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Domain.Entities
{
    public class StudyMaterial
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public string FileUrl { get; set; } = string.Empty;

        [Required]
        public Guid TrainerId { get; set; }

        [ForeignKey("TrainerId")]
        public AppUser? Trainer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
