
using projectY.Models;

namespace projectY.Manager
{
    public interface IManagerBookingBook
    {
        Task<List<BookingBook>> GetBookingsAsync();
        Task<BookingBook> GetBookingByIdAsync(int id);
        Task<bool> UpdateBookingAsync(int id, BookingBook Booking);
        Task<BookingBook> CreateBookingAsync(BookingBook Booking);
        Task<bool> DeleteBookingAsync(int id);

        //private ManagerBookingBook _manager;

        //public IManagerBookingBook(ManagerBookingBook manager)
        //{
        //    _manager = manager;
        //}

        //public async Task<List<BookingBook>> GetAllBookings()
        //{
        //    return await _manager.Get();
        //}

        //public async Task<(BookingBook?, string)> GetBookingById(int id)
        //{
        //    return await _manager.GetById(id);
        //}

        //public async Task<(BookingBook?, string)> CreateBooking(BookingBook booking)
        //{
        //    return await _manager.Create(booking);
        //}

        //public async Task<(BookingBook?, string)> UpdateBooking(int id, string description, int userid, int bookid, DateTime bookingdate, DateTime duetime)
        //{
        //    return await _manager.Update(id, description, userid, bookid, bookingdate, duetime);
        //}

        //public async Task<int> DeleteBooking(int id)
        //{
        //    return await _manager.Delete(id);
        //}
    }
}
