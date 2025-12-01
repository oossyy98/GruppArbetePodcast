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
            if (kategori == null)
                return "Ogiltig kategori.";

            if (string.IsNullOrWhiteSpace(kategori.Namn))
                return "Kategori måste ha ett namn.";

            var alla = await repository.GetAllAsync();

            if (alla.Any(k => k.Namn.ToLower() == kategori.Namn.ToLower()))
                return "En kategori med detta namn finns redan.";

            await repository.AddAsync(kategori);
            return null;
        }

        // READ ALL
        public async Task<List<Kategori>> HamtaAllaKategorierAsync()
        {
            return await repository.GetAllAsync() ?? new List<Kategori>();
        }

        // READ ONE
        public async Task<Kategori?> HamtaKategoriAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await repository.GetByIdAsync(id);
        }

        // UPDATE
        public async Task<string?> UppdateraKategoriAsync(Kategori kategori)
        {
            if (kategori == null)
                return "Ogiltig kategori.";

            if (string.IsNullOrWhiteSpace(kategori.Namn))
                return "Kategori måste ha ett namn.";

            var befintlig = await repository.GetByIdAsync(kategori.Id);
            if (befintlig == null)
                return "Kategorin finns inte.";

            var lyckades = await repository.UpdateAsync(kategori);
            if (!lyckades)
                return "Kategorin kunde inte uppdateras.";

            return null;
        }

        // DELETE
        public async Task<string?> RaderaKategoriAsync(string id)
        {
            var befintlig = await repository.GetByIdAsync(id);
            if (befintlig == null)
                return "Kategorin finns inte.";

            var lyckades = await repository.DeleteAsync(id);
            if (!lyckades)
                return "Kategorin kunde inte raderas.";

            return null;
        }
    }
}
