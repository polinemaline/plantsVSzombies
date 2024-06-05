namespace projectY.Models
{
    public class Genre
    {
        //private Genre(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        //public static (Genre genre, string error) Create(int id, string name)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        error = "The field can't be empty";
        //    }

        //    var genre = new Genre(id, name);

        //    return (genre, error);
        //}
    }
}
