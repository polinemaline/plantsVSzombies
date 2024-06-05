using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Models;

namespace projectY.Manager
{
    public class ManagerUser : IManagerUser
    {
        private readonly ApplicationDbContext _context;
        public ManagerUser(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<bool> UpdateUserAsync(int id, User User)
        {
            if (id != User.Id)
            {
                return false;
            }

            _context.Entry(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<User> CreateUserAsync(User User)
        {
            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var User = await _context.User.FindAsync(id);
            if (User == null)
            {
                return false;
            }

            _context.User.Remove(User);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
        //public void Add(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    var result = await _context.User.ToListAsync();
        //    return result;
        //}

        //public User GetbyId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public User Update(int id, User newuser)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
