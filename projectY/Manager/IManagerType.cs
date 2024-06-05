using System;
using projectY.Models;
using Type = projectY.Models.Type;

namespace projectY.Manager
{
    public interface IManagerType
    {
        Task<List<Type>> GetTypesAsync();
        Task<Type> GetTypeByIdAsync(int id);
        Task<bool> UpdateTypeAsync(int id, Type Type);
        Task<Type> CreateTypeAsync(Type Type);
        Task<bool> DeleteTypeAsync(int id);
    }
}
