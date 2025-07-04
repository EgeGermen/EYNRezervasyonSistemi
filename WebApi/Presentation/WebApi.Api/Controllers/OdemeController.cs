// Controllers/OdemeController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Abstractions;
using WebApi.Api.Dtos.Odeme;

namespace WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OdemeController : ControllerBase
    {
        private readonly IOdemeService _service;
        public OdemeController(IOdemeService service) => _service = service;

        /// <summary>
        /// Tum odemeleri getirir.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OdemeDto>>> GetAll()
        {
            var odemeler = await _service.TumOdemeleriGetirAsync();
            var result = odemeler.Select(o => new OdemeDto
            {
                Id = o.Id,
                Tutar = o.Tutar,
                RezervasyonId = o.RezervasyonId,
                Durum = o.Durum.ToString(),
                OdemeTarihi = o.OdemeTarihi,
                Yontem = o.Yontem.ToString()
            }).ToList();
            return Ok(result);
        }

        /// <summary>
        /// Id ile odeme getirir.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OdemeDto>> GetById(int id)
        {
            var o = await _service.IdIleOdemeGetirAsync(id);
            if (o == null) return NotFound();
            return Ok(new OdemeDto
            {
                Id = o.Id,
                Tutar = o.Tutar,
                RezervasyonId = o.RezervasyonId,
                Durum = o.Durum.ToString(),
                OdemeTarihi = o.OdemeTarihi,
                Yontem = o.Yontem.ToString()
            });
        }

        /// <summary>
        /// Yeni odeme kaydi olusturur (odeme islemini gerceklestirir).
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<OdemeDto>> Create([FromBody] OdemeCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var odeme = new WebApi.Domain.Entities.Odeme
            {
                Tutar = dto.Tutar,
                RezervasyonId = dto.RezervasyonId
            };
            var yen = await _service.YeniOdemeKaydiOlusturAsync(odeme);
            var result = new OdemeDto
            {
                Id = yen.Id,
                Tutar = yen.Tutar,
                RezervasyonId = yen.RezervasyonId,
                Durum = yen.Durum.ToString(),
                OdemeTarihi = yen.OdemeTarihi,
                Yontem = yen.Yontem.ToString()
            };
            return CreatedAtAction(nameof(GetById), new { id = yen.Id }, result);
        }

        /// <summary>
        /// Var olan odemeyi gunceller.
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] OdemeUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != dto.Id) return BadRequest();
            var odeme = await _service.IdIleOdemeGetirAsync(id);
            if (odeme == null) return NotFound();
            odeme.Tutar = dto.Tutar;
            odeme.RezervasyonId = dto.RezervasyonId;
            await _service.OdemeGuncelleAsync(odeme);
            return NoContent();
        }

        /// <summary>
        /// Id ile odeme kaydini siler.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.OdemeSilAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Odeme islemini yurutur (durum guncelleme, rezervasyonu onaylama vs.).
        /// </summary>
        [HttpPost("{id:int}/process")]
        public async Task<IActionResult> Process(int id)
        {
            await _service.OdemeIsleminiYurutAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Bir rezervasyona ait odeme kayitlarini getirir.
        /// </summary>
        [HttpGet("rezervasyon/{rezId:int}")]
        public async Task<ActionResult<IEnumerable<OdemeDto>>> GetByRezervasyon(int rezId)
        {
            var odemeler = await _service.RezervasyonaAitOdemeleriGetirAsync(rezId);
            var result = odemeler.Select(o => new OdemeDto
            {
                Id = o.Id,
                Tutar = o.Tutar,
                RezervasyonId = o.RezervasyonId,
                Durum = o.Durum.ToString(),
                OdemeTarihi = o.OdemeTarihi,
                Yontem = o.Yontem.ToString()
            }).ToList();
            return Ok(result);
        }
    }
}
