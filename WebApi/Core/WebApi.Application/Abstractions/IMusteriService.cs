using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Application.Abstractions
{
    /// <summary>
    /// Musteri islemleri icin servis arayuzu.
    /// </summary>
    public interface IMusteriService
    {
        /// <summary>
        /// Tum musterileri getirir.
        /// </summary>
        Task<IEnumerable<Musteri>> TumMusterileriGetirAsync();

        /// <summary>
        /// Id ile musteri getirir.
        /// </summary>
        Task<Musteri> IdIleMusteriGetirAsync(int id);

        /// <summary>
        /// Yeni musteri olusturur.
        /// </summary>
        Task<Musteri> YeniMusteriOlusturAsync(Musteri musteri);

        /// <summary>
        /// Var olan musteriyi gunceller.
        /// </summary>
        Task MusteriGuncelleAsync(Musteri musteri);

        /// <summary>
        /// Id ile musteriyi siler.
        /// </summary>
        Task MusteriSilAsync(int id);

        /// <summary>
        /// Bir musterinin tum rezervasyonlarini getirir.
        /// </summary>
        Task<IEnumerable<Rezervasyon>> MusterininRezervasyonlariniGetirAsync(int musteriId);

        /// <summary>
        /// Bir musterinin tum odeme kayitlarini getirir.
        /// </summary>
        Task<IEnumerable<Odeme>> MusterininOdemeleriniGetirAsync(int musteriId);
    }
}
