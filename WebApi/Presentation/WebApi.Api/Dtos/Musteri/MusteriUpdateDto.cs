using System.ComponentModel.DataAnnotations;

namespace WebApi.Api.Dtos.Musteri
{
    public class MusteriUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string AdiSoyadi { get; set; }
        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; }
        [MinLength(4)]
        public string Sifre { get; set; }
    }
} 