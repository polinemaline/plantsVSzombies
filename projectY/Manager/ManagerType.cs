
using System;
using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Models;
using Type = projectY.Models.Type;

namespace projectY.Manager
{
    public class ManagerType : IManagerType
    {
        private readonly ApplicationDbContext _context;
        public ManagerType(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Type>> GetTypesAsync()
        {
            return await _context.Type.ToListAsync();
        }

        public async Task<Type> GetTypeByIdAsync(int id)
        {
            return await _context.Type.FindAsync(id);
        }

        public async Task<bool> UpdateTypeAsync(int id, Type Type)
        {
            if (id != Type.Id)
            {
                return false;
            }

            _context.Entry(Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Type> CreateTypeAsync(Type Type)
        {
            _context.Type.Add(Type);
            await _context.SaveChangesAsync();
            return Type;
        }

        public async Task<bool> DeleteTypeAsync(int id)
        {
            var Type = await _context.Type.FindAsync(id);
            if (Type == null)
            {
                return false;
            }

            _context.Type.Remove(Type);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool TypeExists(int id)
        {
            return _context.Type.Any(e => e.Id == id);
        }
        //public void Add(Models.Type type)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Type>> GetAll()
        //{
        ////    var result = await _context.Type.ToListAsync();
        ////    return result;
        //}

        //public Models.Type GetbyId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Models.Type Update(int id, Models.Type newtype)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
