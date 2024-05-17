using System.ComponentModel.DataAnnotations;

namespace PPTWebApiService.Entities
{
    public class Image
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Url { get; set; }
    }
}

