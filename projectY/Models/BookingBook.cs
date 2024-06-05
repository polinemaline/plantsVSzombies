using System.ComponentModel.DataAnnotations.Schema;

namespace projectY.Models
{
    public class BookingBook
    {
        //private BookingBook(int id,string description, int userid, int bookid, DateTime bookingdate, DateTime duetime)
        //{
        //    Id = id;
        //    Description = description;
        //    UserId = userid;
        //    BookId = bookid;
        //    BookingDate = bookingdate;
        //    DueTime = duetime;
        //}
        public int Id { get; set; }
        //public string Description { get; set; } 
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }
        public DateTime BookingDate {  get; set; }
        public DateTime DueTime {  get; set; }
        //public static (BookingBook bookingbook, string error) Create(int id, string description, int userid, int bookid, DateTime bookingdate, DateTime duetime)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(description))
        //    {
        //        error = "The field can't be empty";
        //    }

        //    var bookingbook = new BookingBook(id, description, userid, bookid, bookingdate, duetime);

        //    return (bookingbook, error);
        //}
    }
}
