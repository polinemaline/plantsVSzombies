using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Entities;
using projectY.Models;

namespace projectY.Manager
{
    public class ManagerAuthor: IManagerAuthor 
    {
        private readonly ApplicationDbContext _context;

        public ManagerAuthor(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _context.Author.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Author.FindAsync(id);
        }

        public async Task<bool> UpdateAuthorAsync(int id, Author author)
        {
            if (id != author.Id)
            {
                return false;
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool AuthorExists(int id)
        {
            return _context.Author.Any(e => e.Id == id);
        }

        //public async Task<List<Author>> Get()
        //{
        //    var authorentity = await _context.Author
        //        .AsNoTracking()
        //        .ToListAsync();

        //    var author = authorentity
        //        .Select(c => Author.Create(c.Id, c.FirstName, c.LastName).author)
        //        .ToList();

        //    return author;
        //}

        //public async Task<Author?> GetById(int id)
        //{
        //    var authorentity = await _context.Author
        //        .FindAsync(id);

        //    if (authorentity is null) { return null; }

        //    var author = Author.Create(authorentity.Id, authorentity.FirstName, authorentity.LastName).author;

        //    return author;
        //}

        //public async Task<List<Book>> GetBooks(int id)
        //{
        //    var bookentity = await _context.Book
        //        .Include(t => t.Author)
        //        .Include(t => t.Year)
        //        .Include(t => t.Genre)
        //        .Include(t => t.Type)
        //        .Where(t => t.AuthorId == id)
        //        .ToListAsync();

        //    var book = bookentity
        //        .Select(t => Book.Create(t.Id, t.Title, t.YearId, t.GenreId, t.AuthorId, t.TypeId).book)
        //        .ToList();

        //    return book;
        //}

        //public async Task<Author> Create(Author author)
        //{
        //    int newId = await _context.Author.MaxAsync(s => (int?)s.Id) ?? 0;
        //    author.Id = ++newId;

        //    var authorentity = new AuthorEntity
        //    {
        //        Id = author.Id,
        //        FirstName = author.FirstName,
        //        LastName = author.LastName,
        //    };

        //    await _context.Author.AddAsync(authorentity);
        //    await _context.SaveChangesAsync();

        //    return author;
        //}

        //public async Task<Author> Update(int id, string firstname, string lastname)
        //{
        //    await _context.Author
        //        .Where(c => c.Id == id)
        //        .ExecuteUpdateAsync(s => s
        //            .SetProperty(c => c.FirstName, c => firstname)
        //            .SetProperty(c => c.LastName, c => lastname));

        //    var author = Author.Create(id, firstname, lastname).author;

        //    return author;
        //}

        //public async Task<int> Delete(int id)
        //{
        //    await _context.Author
        //        .Where(c => c.Id == id)
        //        .ExecuteDeleteAsync();

        //    return id;
        //}
    }
}
