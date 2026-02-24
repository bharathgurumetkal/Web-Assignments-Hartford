using System;

namespace StudentApi.Application.DTOs.StudyMaterials
{
    public class StudyMaterialDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public Guid TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateStudyMaterialDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
    }
}
