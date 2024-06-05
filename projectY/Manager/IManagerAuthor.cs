using projectY.Models;
namespace projectY.Manager
{
    public interface IManagerAuthor
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<bool> UpdateAuthorAsync(int id, Author author);
        Task<Author> CreateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);
        //private ManagerAuthor _manager;

        //public IManagerAuthor(ManagerAuthor manager)
        //{
        //    _manager = manager;
        //}

        //public async Task<List<Author>> GetAllAuthors()
        //{
        //    return await _manager.Get();
        //}

        //public async Task<Author?> GetAuthorById(int id)
        //{
        //    return await _manager.GetById(id);
        //}

        //public async Task<List<Book>> GetAllBooksAuthor(int id)
        //{
        //    return await _manager.GetBooks(id);
        //}

        //public async Task<Author> CreateAuthor(Author author)
        //{
        //    return await _manager.Create(author);
        //}

        //public async Task<Author> UpdateAuthor(int id, string firstname, string lastname)
        //{
        //    return await _manager.Update(id, firstname, lastname);
        //}

        //public async Task<int> DeleteAuthor(int id)
        //{
        //    return await _manager.Delete(id);
        //}
    }

}

