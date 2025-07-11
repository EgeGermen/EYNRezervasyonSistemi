using System;

namespace WebApi.Api.Dtos.Odeme
{
    public class OdemeDto
    {
        public int Id { get; set; }
        public int RezervasyonId { get; set; }
        public decimal Tutar { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string Yontem { get; set; }
        public string Durum { get; set; }
    }
} 