using System.ComponentModel.DataAnnotations;
using projectY.Models;

namespace projectY.Manager
{
    public interface IManagerYear
    {
        Task<List<Year>> GetYearsAsync();
        Task<Year> GetYearByIdAsync(int id);
        Task<bool> UpdateYearAsync(int id, Year Year);
        Task<Year> CreateYearAsync(Year Year);
        Task<bool> DeleteYearAsync(int id);
        //private ManagerYear _manager;

        //public IManagerYear(ManagerYear manager)
        //{
        //    _manager = manager;
        //}

        //public async Task<List<Year>> GetAllYears()
        //{
        //    return await _manager.Get();
        //}

        //public async Task<Year?> GetYearById(int id)
        //{
        //    var data = await _manager.GetById(id);

        //    return data;
        //}

        //public async Task<Year> CreateYear(Year year)
        //{
        //    return await _manager.Create(year);
        //}

        //public async Task<Year> UpdateYear(int id, string name)
        //{
        //    return await _manager.Update(id, name);
        //}

        //public async Task<int> DeleteYear(int id)
        //{
        //    return await _manager.Delete(id);
        //}
    }
}
