using System.ComponentModel.DataAnnotations;

namespace WebApi.Api.Dtos.Odeme
{
    public class OdemeCreateDto
    {
        [Required]
        public int RezervasyonId { get; set; }
        [Required]
        public decimal Tutar { get; set; }
        [Required]
        public string Yontem { get; set; }
    }
} 
