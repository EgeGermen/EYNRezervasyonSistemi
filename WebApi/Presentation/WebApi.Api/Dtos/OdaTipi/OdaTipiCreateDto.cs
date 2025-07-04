using System.ComponentModel.DataAnnotations;

namespace WebApi.Api.Dtos.OdaTipi
{
    public class OdaTipiCreateDto
    {
        [Required, MaxLength(100)]
        public string OdaTipiAdi { get; set; }
        public string Aciklama { get; set; }
        [Required]
        public int OtelId { get; set; }
        [Required]
        public int Kapasite { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
    }
} 