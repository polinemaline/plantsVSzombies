using projectY.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectY.Entities
{
    public class BookingBookEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DueTime { get; set; }
    }
}
