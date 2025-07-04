// Controllers/MusteriController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Abstractions;
using WebApi.Api.Dtos.Musteri;
using WebApi.Api.Dtos.Rezervasyon;
using WebApi.Api.Dtos.Odeme;

namespace WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusteriController : ControllerBase
    {
        private readonly IMusteriService _service;
        public MusteriController(IMusteriService service) => _service = service;

        /// <summary>
        /// Tum musterileri getirir.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusteriDto>>> GetAll()
        {
            var musteriler = await _service.TumMusterileriGetirAsync();
            return Ok(musteriler.Select(m => new MusteriDto {
                Id = m.Id,
                AdiSoyadi = m.AdiSoyadi,
                Email = m.Email,
                Rezervasyonlar = m.Rezervasyonlar?.Select(r => new RezervasyonDto {
                    Id = r.Id,
                    MusteriId = r.MusteriId,
                    OdaTipiId = r.OdaTipiId,
                    GirisTarihi = r.GirisTarihi,
                    CikisTarihi = r.CikisTarihi,
                    Durum = r.Durum.ToString()
                }).ToList(),
                Odemeler = m.Odemeler?.Select(o => new OdemeDto {
                    Id = o.Id,
                    Tutar = o.Tutar,
                    RezervasyonId = o.RezervasyonId,
                    Durum = o.Durum.ToString(),
                    OdemeTarihi = o.OdemeTarihi,
                    Yontem = o.Yontem.ToString()
                }).ToList()
            }));
        }

        /// <summary>
        /// Id ile musteri getirir.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MusteriDto>> GetById(int id)
        {
            var m = await _service.IdIleMusteriGetirAsync(id);
            if (m == null) return NotFound();
            return Ok(new MusteriDto {
                Id = m.Id,
                AdiSoyadi = m.AdiSoyadi,
                Email = m.Email,
                Rezervasyonlar = m.Rezervasyonlar?.Select(r => new RezervasyonDto {
                    Id = r.Id,
                    MusteriId = r.MusteriId,
                    OdaTipiId = r.OdaTipiId,
                    GirisTarihi = r.GirisTarihi,
                    CikisTarihi = r.CikisTarihi,
                    Durum = r.Durum.ToString()
                }).ToList(),
                Odemeler = m.Odemeler?.Select(o => new OdemeDto {
                    Id = o.Id,
                    Tutar = o.Tutar,
                    RezervasyonId = o.RezervasyonId,
                    Durum = o.Durum.ToString(),
                    OdemeTarihi = o.OdemeTarihi,
                    Yontem = o.Yontem.ToString()
                }).ToList()
            });
        }

        /// <summary>
        /// Yeni musteri olusturur.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MusteriDto>> Create([FromBody] MusteriCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var musteri = new WebApi.Domain.Entities.Musteri { AdiSoyadi = dto.AdiSoyadi, Email = dto.Email, Sifre = dto.Sifre };
            var yen = await _service.YeniMusteriOlusturAsync(musteri);
            return CreatedAtAction(nameof(GetById), new { id = yen.Id }, new MusteriDto { Id = yen.Id, AdiSoyadi = yen.AdiSoyadi, Email = yen.Email });
        }

        /// <summary>
        /// Var olan musteriyi gunceller.
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MusteriUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != dto.Id) return BadRequest();
            var musteri = await _service.IdIleMusteriGetirAsync(id);
            if (musteri == null) return NotFound();
            musteri.AdiSoyadi = dto.AdiSoyadi;
            musteri.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.Sifre)) musteri.Sifre = dto.Sifre;
            await _service.MusteriGuncelleAsync(musteri);
            return NoContent();
        }

        /// <summary>
        /// Id ile musteriyi siler.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.MusteriSilAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Bir musterinin tum rezervasyonlarini getirir.
        /// </summary>
        [HttpGet("{id:int}/rezervasyonlar")]
        public async Task<ActionResult<IEnumerable<RezervasyonDto>>> GetRezervasyonlar(int id)
        {
            var rezervasyonlar = await _service.MusterininRezervasyonlariniGetirAsync(id);
            return Ok(rezervasyonlar.Select(r => new RezervasyonDto {
                Id = r.Id,
                MusteriId = r.MusteriId,
                OdaTipiId = r.OdaTipiId,
                GirisTarihi = r.GirisTarihi,
                CikisTarihi = r.CikisTarihi,
                Durum = r.Durum.ToString()
            }));
        }

        /// <summary>
        /// Bir musterinin tum odeme kayitlarini getirir.
        /// </summary>
        [HttpGet("{id:int}/odemeler")]
        public async Task<ActionResult<IEnumerable<OdemeDto>>> GetOdemeler(int id)
        {
            var odemeler = await _service.MusterininOdemeleriniGetirAsync(id);
            return Ok(odemeler.Select(o => new OdemeDto {
                Id = o.Id,
                Tutar = o.Tutar,
                RezervasyonId = o.RezervasyonId,
                Durum = o.Durum.ToString(),
                OdemeTarihi = o.OdemeTarihi,
                Yontem = o.Yontem.ToString()
            }));
        }
    }
}
