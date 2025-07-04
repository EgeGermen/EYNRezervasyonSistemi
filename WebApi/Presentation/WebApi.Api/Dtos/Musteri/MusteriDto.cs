using System.Collections.Generic;
using WebApi.Api.Dtos.Odeme;
using WebApi.Api.Dtos.Rezervasyon;

namespace WebApi.Api.Dtos.Musteri
{
    public class MusteriDto
    {
        public int Id { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public ICollection<RezervasyonDto> Rezervasyonlar { get; set; }
        public ICollection<OdemeDto> Odemeler { get; set; }
    }
} 