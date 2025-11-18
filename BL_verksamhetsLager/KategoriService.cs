using DAL_dataAtkomstlager;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL_verksamhetsLager
{
    public class KategoriService
    {
        private readonly IRepository<Kategori> repository;

        public KategoriService(IRepository<Kategori> repository)
        {
            this.repository = repository;
        }

        // CREATE
        public async Task<string?> SkapaKategoriAsync(Kategori kategori)
        {
            if (string.IsNullOrWhiteSpace(kategori.Namn))
                return "Kategori måste ha ett namn.";

            var alla = await repository.GetAllAsync();
            if (alla.Any(k => k.Namn.Equals(kategori.Namn, System.StringComparison.OrdinalIgnoreCase)))
                return "En kategori med detta namn finns redan.";

            await repository.AddAsync(kategori);
            return null;
        }

        // READ ALL
        public async Task<List<Kategori>> HamtaAllaKategorierAsync()
        {
            var lista = await repository.GetAllAsync();
            return lista ?? new List<Kategori>();
        }

        // READ ONE
        public async Task<Kategori?> HamtaKategoriAsync(string kategoriId)
        {
            if (string.IsNullOrWhiteSpace(kategoriId))
                return null;

            return await repository.GetByIdAsync(kategoriId);
        }

        // UPDATE
        public async Task<string?> UppdateraKategoriAsync(Kategori uppdateradKategori)
        {
            if (string.IsNullOrWhiteSpace(uppdateradKategori.Namn))
                return "Kategori måste ha ett namn.";

            var original = await repository.GetByIdAsync(uppdateradKategori.Id);
            if (original == null)
                return "Kategorin finns inte.";

            await repository.UpdateAsync(uppdateradKategori);
            return null;
        }

        // DELETE
        public async Task<string?> RaderaKategoriAsync(string kategoriId)
        {
            var kategori = await repository.GetByIdAsync(kategoriId);
            if (kategori == null)
                return "Kategorin finns inte.";

            await repository.DeleteAsync(kategoriId);
            return null;
        }
    }
}
