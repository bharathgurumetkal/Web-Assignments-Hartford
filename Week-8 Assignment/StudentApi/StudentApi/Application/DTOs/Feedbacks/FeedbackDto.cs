using System;

namespace StudentApi.Application.DTOs.Feedbacks
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public Guid TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class CreateFeedbackDto
    {
        public Guid TrainerId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
