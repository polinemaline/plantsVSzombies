
using System;
using projectY.Models;

namespace projectY.Manager
{
    public interface IManagerBook
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> UpdateBookAsync(int id, Book Book);
        Task<Book> CreateBookAsync(Book Book);
        Task<bool> DeleteBookAsync(int id);

        //public async Task<List<Book>> GetAllBooks()
        //{
        //    return await _manager.Get();
        //}

        //public async Task<(Book?, string)> GetBookById(int id)
        //{
        //    return await _manager.GetById(id);
        //}

        //public async Task<(Book?, string)> CreateBook(Book book)
        //{
        //    return await _manager.Create(book);
        //}

        //public async Task<(Book?, string)> UpdateBook(int id, string title, int yearId, int genreId, int authorId, int typeId)
        //{
        //    return await _manager.Update(id, title, yearId, genreId, authorId, typeId);
        //}

        //public async Task<int> DeleteBook(int id)
        //{
        //    return await _manager.Delete(id);
        //}
    }
}
