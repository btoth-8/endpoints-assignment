using System.ComponentModel.DataAnnotations;

namespace EndpointImplementationProject.Models
{
    public class Toy
    {
        [Required]
        public int ToyId { get; set; }
        [Required]
        public required string ElementId { get; set; }
        [Required]
        public required string UserId { get; set; }
        [Required]
        public required string PictureId { get; set; }
        [Required]
        [MaxLength(255)]
        public required string Description { get; set; }
        public List<Score> Scores { get; set; } = new List<Score>();
    }

    public class Score
    {
        [Required]
        public required string UserId { get; set; }
        [Required]
        public int CreativityScore { get; set; }
        [Required]
        public int UniquenessScore { get; set; }
    }
}
