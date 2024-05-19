using System.ComponentModel.DataAnnotations;

namespace PPTWebApiService.DataAccess.Entities
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

