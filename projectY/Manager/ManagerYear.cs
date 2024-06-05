using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Entities;
using projectY.Models;

namespace projectY.Manager
{
    public class ManagerYear: IManagerYear
    {
        private readonly ApplicationDbContext _context;

        public ManagerYear(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Year>> GetYearsAsync()
        {
            return await _context.Year.ToListAsync();
        }

        public async Task<Year> GetYearByIdAsync(int id)
        {
            return await _context.Year.FindAsync(id);
        }

        public async Task<bool> UpdateYearAsync(int id, Year Year)
        {
            if (id != Year.Id)
            {
                return false;
            }

            _context.Entry(Year).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Year> CreateYearAsync(Year Year)
        {
            _context.Year.Add(Year);
            await _context.SaveChangesAsync();
            return Year;
        }

        public async Task<bool> DeleteYearAsync(int id)
        {
            var Year = await _context.Year.FindAsync(id);
            if (Year == null)
            {
                return false;
            }

            _context.Year.Remove(Year);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool YearExists(int id)
        {
            return _context.Year.Any(e => e.Id == id);
        }
        //public async Task<List<Year>> Get()
        //{
        //    var yearentity = await _context.Year
        //        .AsNoTracking()
        //        .ToListAsync();

        //    var year = yearentity
        //        .Select(k => Year.Create(k.Id, k.Name).year)
        //        .ToList();

        //    return year;
        //}

        //public async Task<Year?> GetById(int id)
        //{
        //    var yearentity = await _context.Year
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(k => k.Id == id);

        //    if (yearentity == null)
        //    {
        //        return null;
        //    }

        //    var year = Year.Create(yearentity.Id, yearentity.Name).year;

        //    return year;
        //}

        //public async Task<Year> Create(Year year)
        //{
        //    int newId = await _context.Year.MaxAsync(s => (int?)s.Id) ?? 0;
        //    newId++;

        //    var yearentity = new YearEntity
        //    {
        //        Id = newId,
        //        Name = year.Name
        //    };

        //    year.Id = newId;

        //    await _context.Year.AddAsync(yearentity);
        //    await _context.SaveChangesAsync();

        //    return year;
        //}

        //public async Task<Year> Update(int id, string name)
        //{
        //    await _context.Year
        //        .Where(k => k.Id == id)
        //        .ExecuteUpdateAsync(s => s
        //            .SetProperty(k => k.Name, name));

        //    var year = Year.Create(id, name).year;

        //    return year;
        //}

        //public async Task<int> Delete(int id)
        //{
        //    await _context.Year
        //        .Where(k => k.Id == id)
        //        .ExecuteDeleteAsync();

        //    return id;
        //}
    }
}
