using System.ComponentModel.DataAnnotations;

namespace WebApi.Api.Dtos.Odeme
{
    public class OdemeUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RezervasyonId { get; set; }
        [Required]
        public decimal Tutar { get; set; }
        [Required]
        public string Yontem { get; set; }
    }
} 