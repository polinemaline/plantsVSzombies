using projectY.Models;

namespace projectY.Manager
{
    public interface IManagerUser
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, User User);
        Task<User> CreateUserAsync(User User);
        Task<bool> DeleteUserAsync(int id);
        //Task<IEnumerable<User>> GetAll();
        //User GetbyId(int id);
        //void Add(User user);
        //User Update(int id, User newuser);
        //void Delete(int id);
    }
}
