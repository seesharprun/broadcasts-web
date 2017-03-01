using System;
using System.ComponentModel.DataAnnotations;

namespace SeeSharpRun.Broadcast.Models
{
    public class Broadcast
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        [Required()]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Required()]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Required()]
        public string SemanticUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Required()]
        public DateTimeOffset LiveDateTime { get; set; }

        [DataType(DataType.Time)]
        [Required()]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.Url)]
        [Required()]
        public string ViewLink { get; set; }

        [DataType(DataType.Url)]
        public string VideoDownloadUrl { get; set; }

        [Required()]
        public Boolean IsPublic { get; set; }
    }
}
