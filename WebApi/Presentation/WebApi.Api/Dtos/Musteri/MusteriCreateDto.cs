using System.ComponentModel.DataAnnotations;

namespace WebApi.Api.Dtos.Musteri
{
    public class MusteriCreateDto
    {
        [Required, MaxLength(100)]
        public string AdiSoyadi { get; set; }
        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string Sifre { get; set; }
    }
} 