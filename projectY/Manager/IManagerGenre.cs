using System.ComponentModel.DataAnnotations;
using projectY.Models;

namespace projectY.Manager
{
    public interface IManagerGenre
    {
        Task<List<Genre>> GetGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task<bool> UpdateGenreAsync(int id, Genre Genre);
        Task<Genre> CreateGenreAsync(Genre Genre);
        Task<bool> DeleteGenreAsync(int id);
        //private ManagerGenre _manager;

        //public IManagerGenre(ManagerGenre manager)
        //{
        //    _manager = manager;
        //}

        //public async Task<List<Genre>> GetAllGenres()
        //{
        //    return await _manager.Get();
        //}

        //public async Task<Genre?> GetGenreById(int id)
        //{
        //    var data = await _manager.GetById(id);

        //    return data;
        //}

        //public async Task<Genre> CreateKindOfSport(Genre genre)
        //{
        //    return await _manager.Create(genre);
        //}

        //public async Task<Genre> UpdateGenre(int id, string name)
        //{
        //    return await _manager.Update(id, name);
        //}

        //public async Task<int> DeleteGenre(int id)
        //{
        //    return await _manager.Delete(id);
        //}
    }
}
