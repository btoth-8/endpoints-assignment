using System.ComponentModel.DataAnnotations;

namespace EndpointImplementationProject.Models
{
    public class Toy
    {
        [Required]
        public Guid ToyId { get; set; }
        [Required]
        public List<string> ElementIds { get; set; } = new List<string>();
        [Required]
        public string? UserId { get; set; }
        [Required]
        public string? PictureId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }
        public List<Score> Scores { get; set; } = new List<Score>();
    }

    public class AddNewToyRequest
    {
        [Required]
        public List<string> ElementIds { get; set; } = new List<string>();
        [Required]
        public string? UserId { get; set; }
        [Required]
        public string? PictureId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }
        public List<Score> Scores { get; set; } = new List<Score>();
    }

    public class ToyUpdateDto
    {
        [Required]
        public List<string> ElementIds { get; set; } = new List<string>();
        [Required]
        public string? PictureId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Description { get; set; }
    }

    public class Score
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        [Range(1, 5)]
        public int CreativityScore { get; set; }
        [Required]
        [Range(1, 5)]
        public int UniquenessScore { get; set; }
    }
}
