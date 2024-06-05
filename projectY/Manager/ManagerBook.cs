using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Entities;
using projectY.Models;

namespace projectY.Manager
{
    public class ManagerBook: IManagerBook
    {
        private readonly ApplicationDbContext _context;

        public ManagerBook(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Book.Include(m => m.Year).Include(m => m.Genre).Include(m => m.Author).Include(m => m.Type).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Book.FindAsync(id);
        }

        public async Task<bool> UpdateBookAsync(int id, Book Book)
        {
            if (id != Book.Id)
            {
                return false;
            }

            _context.Entry(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Book> CreateBookAsync(Book Book)
        {
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return Book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var Book = await _context.Book.FindAsync(id);
            if (Book == null)
            {
                return false;
            }

            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }


    

        //public async Task<List<Book>> Get()
        //{
        //    var bookentity = await _context.Book
        //        .Include(s => s.Year)
        //        .Include(s => s.Genre)
        //        .Include(s => s.Author)
        //        .Include(s => s.Type)
        //        .ToListAsync();

        //    var book = bookentity
        //        .Select(s => Book.Create(s.Id, s.Title, s.YearId, s.GenreId, s.AuthorId, s.TypeId).book)
        //        .ToList();

        //    return book;
        //}

        //public async Task<(Book? book, string error)> GetById(int id)
        //{
        //    var error = string.Empty;

        //    var bookentity = await _context.Book
        //        .FindAsync(id);

        //    if (bookentity is null)
        //    {
        //        error = "Book with this Id is not exists";
        //        return (null, error);
        //    }

        //    var book = Book.Create(bookentity.Id, bookentity.Title, bookentity.YearId, bookentity.GenreId, bookentity.AuthorId, bookentity.TypeId).book;

        //    return (book, error);
        //}

        //public async Task<(Book? book, string error)> Create(Book book)
        //{
        //    var error = string.Empty;

        //    var bookexists = await _context.Book.AnyAsync(t => t.Id == book.AuthorId);

        //    if (!bookexists)
        //    {
        //        error = "Book with this id does not exists";
        //        return (null, error);
        //    }

        //    int newId = await _context.Book.MaxAsync(s => (int?)s.Id) ?? 0;
        //    book.Id = ++newId;

        //    var bookentity = new BookEntity
        //    {
        //        Id = book.Id,
        //        Title = book.Title,
        //        YearId = book.YearId,
        //        GenreId = book.GenreId,
        //        AuthorId = book.AuthorId,
        //        TypeId = book.TypeId,
        //    };

        //    await _context.Book.AddAsync(bookentity);
        //    await _context.SaveChangesAsync();

        //    return (book, error);
        //}

        //public async Task<(Book?, string)> Update(int id, string title, int yearid, int genreid, int authorid, int typeid)
        //{
        //    var error = string.Empty;

        //    var authorexists = await _context.Author.AnyAsync(t => t.Id == authorid);

        //    if (!authorexists)
        //    {
        //        error = "Author with this id is not exists.";
        //        return (null, error);
        //    }

        //    await _context.Book
        //        .Where(s => s.Id == id)
        //        .ExecuteUpdateAsync(e => e
        //            .SetProperty(s => s.Title, s => title)
        //            .SetProperty(s => s.YearId, s => yearid)
        //            .SetProperty(s => s.GenreId, s => genreid)
        //            .SetProperty(s => s.AuthorId, s => authorid)
        //            .SetProperty(s => s.TypeId, s =>typeid));

        //    var book = Book.Create(id, title, yearid, genreid, authorid, typeid).book;

        //    return (book, error);
        //}

        //public async Task<int> Delete(int id)
        //{
        //    await _context.Book
        //        .Where(s => s.Id == id)
        //        .ExecuteDeleteAsync();

        //    return id;
        //}
    }

