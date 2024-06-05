using Type = projectY.Models.Type;
using System.ComponentModel.DataAnnotations.Schema;


namespace projectY.Models
{
    public class Book
    {
        //private Book(int id, string title, int yearid, int genreid, int authorid, int typeid)
        //{
        //    Id = id;
        //    Title = title;
        //    YearId = yearid;
        //    GenreId = genreid;
        //    AuthorId = authorid;
        //    TypeId = typeid;
        //}
        public int Id { get; set; }
        public string Title { get; set; }

        public int YearId { get; set; }
        [ForeignKey(nameof(YearId))]
        public Year? Year { get; set; }

        public int GenreId { get; set; }
        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; }

        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public Type? Type { get; set; }
        //public static (Book book, string Error) Create(int id, string title, int yearid, int genreid, int authorid, int typeid)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title))
        //    {
        //        error = "The field can't be empty";
        //    }

        //    var book = new Book(id, title, yearid, genreid, authorid, typeid);

        //    return (book, error);
        //}
    }
}
