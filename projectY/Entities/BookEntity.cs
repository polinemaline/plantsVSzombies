using projectY.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Type = projectY.Models.Type;


namespace projectY.Entities
{
    public class BookEntity
    {
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
    }
}
