using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Tokens;
using projectY.Data;

namespace projectY.Models
{
    public class Type
    {
        //private Type(int id, int bookid, BookType booktype)
        //{
        //    Id = id;
        //    BookId = bookid;
        //    BookType = booktype;
        //}
        public int Id { get; set; }
        //public int BookId { get; set; }
        //[ForeignKey(nameof(BookId))]
        //public Book? Book { get; set; }
       
        public BookType BookType { get; set; }
        //public static (Type type, string error) Create(int id, int bookid, BookType booktype)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(Convert.ToString(booktype)))
        //    {
        //        error = "The field can't be empty";
        //    }

        //    var type = new Type(id, bookid, booktype);

        //    return (type, error);
        //}
    }
}
