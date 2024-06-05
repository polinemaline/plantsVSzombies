using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Models;

namespace projectY.Manager
{
    public class ManagerPublisher : IManagerPublisher
    {
        private readonly ApplicationDbContext _context;

        public ManagerPublisher(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> GetPublishersAsync()
        {
            return await _context.Publisher.ToListAsync();
        }

        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            return await _context.Publisher.FindAsync(id);
        }

        public async Task<bool> UpdatePublisherAsync(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return false;
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Publisher> CreatePublisherAsync(Publisher publisher)
        {
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<bool> DeletePublisherAsync(int id)
        {
            var publisher = await _context.Publisher.FindAsync(id);
            if (publisher == null)
            {
                return false;
            }

            _context.Publisher.Remove(publisher);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool PublisherExists(int id)
        {
            return _context.Publisher.Any(e => e.Id == id);
        }

    }
}
