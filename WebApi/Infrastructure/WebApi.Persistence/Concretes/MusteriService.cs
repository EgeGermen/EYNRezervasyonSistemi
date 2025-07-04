using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Abstractions;
using WebApi.Domain.Entities;
using WebApi.Persistence.Contexts;

namespace WebApi.Persistence.Concretes
{
    public class MusteriService : IMusteriService
    {
        private readonly ApplicationDbContext _context;

        public MusteriService(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<Musteri>> TumMusterileriGetirAsync()
            => await _context.Musteriler
                .Include(m => m.Rezervasyonlar)
                .Include(m => m.Odemeler)
                .ToListAsync();

        public async Task<Musteri> IdIleMusteriGetirAsync(int id)
            => await _context.Musteriler
                .Include(m => m.Rezervasyonlar)
                .Include(m => m.Odemeler)
                .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<Musteri> YeniMusteriOlusturAsync(Musteri musteri)
        {
            await _context.Musteriler.AddAsync(musteri);
            await _context.SaveChangesAsync();
            return musteri;
        }

        public async Task MusteriGuncelleAsync(Musteri musteri)
        {
            _context.Musteriler.Update(musteri);
            await _context.SaveChangesAsync();
        }

        public async Task MusteriSilAsync(int id)
        {
            var m = await _context.Musteriler.FindAsync(id);
            if (m != null)
            {
                _context.Musteriler.Remove(m);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rezervasyon>> MusterininRezervasyonlariniGetirAsync(int musteriId)
            => await _context.Rezervasyonlar
                .Where(r => r.MusteriId == musteriId)
                .ToListAsync();

        public async Task<IEnumerable<Odeme>> MusterininOdemeleriniGetirAsync(int musteriId)
            => await _context.Odemeler
                .Where(p => p.Rezervasyon.MusteriId == musteriId)
                .ToListAsync();
    }
}
