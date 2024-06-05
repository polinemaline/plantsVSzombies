using Microsoft.EntityFrameworkCore;
using projectY.Data;
using projectY.Models;
using projectY.Entities;
using System;

namespace projectY.Manager
{
    public class ManagerBookingBook: IManagerBookingBook
    {
        private readonly ApplicationDbContext _context;

        public ManagerBookingBook(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<BookingBook>> GetBookingsAsync()
        {
            return await _context.BookingBook.Include(m => m.User).Include(m => m.Book).ToListAsync();
        }

        public async Task<BookingBook> GetBookingByIdAsync(int id)
        {
            return await _context.BookingBook.FindAsync(id);
        }

        public async Task<bool> UpdateBookingAsync(int id, BookingBook Booking)
        {
            if (id != Booking.Id)
            {
                return false;
            }

            _context.Entry(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<BookingBook> CreateBookingAsync(BookingBook Booking)
        {
            _context.BookingBook.Add(Booking);
            await _context.SaveChangesAsync();
            return Booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var Booking = await _context.BookingBook.FindAsync(id);
            if (Booking == null)
            {
                return false;
            }

            _context.BookingBook.Remove(Booking);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BookingExists(int id)
        {
            return _context.BookingBook.Any(e => e.Id == id);
        }
        //public async Task<List<BookingBook>> Get()
        //{
        //    var bookingentity = await _context.BookingBook
        //        .Include(s => s.User)
        //        .Include(s => s.Book)
        //        .ToListAsync();

        //    var booking = bookingentity
        //        .Select(s => BookingBook.Create(s.Id, s.Description, s.UserId, s.BookId, s.BookingDate, s.DueTime).bookingbook)
        //        .ToList();

        //    return booking;
        //}

        //public async Task<(BookingBook? booking, string error)> GetById(int id)
        //{
        //    var error = string.Empty;

        //    var bookingentity = await _context.BookingBook
        //        .FindAsync(id);

        //    if (bookingentity is null)
        //    {
        //        error = "Bookig does not exists";
        //        return (null, error);
        //    }

        //    var booking = BookingBook.Create(bookingentity.Id, bookingentity.Description, bookingentity.UserId, bookingentity.BookId, bookingentity.BookingDate, bookingentity.DueTime).bookingbook;

        //    return (booking, error);
        //}

        //public async Task<(BookingBook? booking, string error)> Create(BookingBook booking)
        //{
        //    var error = string.Empty;

        //    var bookingexists = await _context.BookingBook.AnyAsync(t => t.Id == booking.UserId);

        //    if (!bookingexists)
        //    {
        //        error = "Booking does not exists";
        //        return (null, error);
        //    }

        //    int newId = await _context.BookingBook.MaxAsync(s => (int?)s.Id) ?? 0;
        //    booking.Id = ++newId;

        //    var bookingentity = new BookingBookEntity
        //    {
        //        Id = booking.Id,
        //        Description = booking.Description,
        //        UserId = booking.UserId,
        //        BookId = booking.BookId,
        //        BookingDate = booking.BookingDate,
        //        DueTime = booking.DueTime,
        //    };

        //    await _context.BookingBook.AddAsync(bookingentity);
        //    await _context.SaveChangesAsync();

        //    return (booking, error);
        //}

        //public async Task<(BookingBook?, string)> Update(int id, string description, int userid, int bookid, DateTime bookingdate, DateTime duetime)
        //{
        //    var error = string.Empty;

        //    var userexists = await _context.User.AnyAsync(t => t.Id == userid);

        //    if (!userexists)
        //    {
        //        error = "Booking with this id is not exists.";
        //        return (null, error);
        //    }

        //    await _context.BookingBook
        //        .Where(s => s.Id == id)
        //        .ExecuteUpdateAsync(e => e
        //            .SetProperty(s => s.Description, s => description)
        //            .SetProperty(s => s.UserId, s => userid)
        //            .SetProperty(s => s.BookId, s => bookid)
        //            .SetProperty(s => s.BookingDate, s => DateTime.SpecifyKind(bookingdate, DateTimeKind.Utc))
        //            .SetProperty(s => s.DueTime, s => DateTime.SpecifyKind(duetime, DateTimeKind.Utc)));

        //    var booking = BookingBook.Create(id, description, userid, bookid, bookingdate, duetime).bookingbook;

        //    return (booking, error);
        //}

        //public async Task<int> Delete(int id)
        //{
        //    await _context.BookingBook
        //        .Where(s => s.Id == id)
        //        .ExecuteDeleteAsync();

        //    return id;
        //}
    }
}
