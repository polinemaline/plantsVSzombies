using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Entities;
using projectY.Models;

namespace projectY.Manager
{
    public class ManagerGenre: IManagerGenre
    {
        private readonly ApplicationDbContext _context;

        public ManagerGenre(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetGenresAsync()
        {
            return await _context.Genre.ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _context.Genre.FindAsync(id);
        }

        public async Task<bool> UpdateGenreAsync(int id, Genre Genre)
        {
            if (id != Genre.Id)
            {
                return false;
            }

            _context.Entry(Genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Genre> CreateGenreAsync(Genre Genre)
        {
            _context.Genre.Add(Genre);
            await _context.SaveChangesAsync();
            return Genre;
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var Genre = await _context.Genre.FindAsync(id);
            if (Genre == null)
            {
                return false;
            }

            _context.Genre.Remove(Genre);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.Id == id);
        }
        //public async Task<List<Genre>> Get()
        //{
        //    var genreentity = await _context.Genre
        //        .AsNoTracking()
        //        .ToListAsync();

        //    var genre = genreentity
        //        .Select(k => Genre.Create(k.Id, k.Name).genre)
        //        .ToList();

        //    return genre;
        //}

        //public async Task<Genre?> GetById(int id)
        //{
        //    var genreentity = await _context.Genre
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(k => k.Id == id);

        //    if (genreentity == null)
        //    {
        //        return null;
        //    }

        //    var genre = Genre.Create(genreentity.Id, genreentity.Name).genre;

        //    return genre;
        //}

        //public async Task<Genre> Create(Genre genre)
        //{
        //    int newId = await _context.Genre.MaxAsync(s => (int?)s.Id) ?? 0;
        //    newId++;

        //    var genreentity = new GenreEntity
        //    {
        //        Id = newId,
        //        Name = genre.Name
        //    };

        //    genre.Id = newId;

        //    await _context.Genre.AddAsync(genreentity);
        //    await _context.SaveChangesAsync();

        //    return genre;
        //}

        //public async Task<Genre> Update(int id, string name)
        //{
        //    await _context.Genre
        //        .Where(k => k.Id == id)
        //        .ExecuteUpdateAsync(s => s
        //            .SetProperty(k => k.Name, name));

        //    var genre = Genre.Create(id, name).genre;

        //    return genre;
        //}

        //public async Task<int> Delete(int id)
        //{
        //    await _context.Genre
        //        .Where(k => k.Id == id)
        //        .ExecuteDeleteAsync();

        //    return id;
        //}
    }
}
