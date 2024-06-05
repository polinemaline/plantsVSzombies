using projectY.Data;
using projectY.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectY.Entities
{
    public class TypeEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }
        //public int Audio { get; set; }
        //public int Text {  get; set; }
        public BookType BookType { get; set; }
    }
}
