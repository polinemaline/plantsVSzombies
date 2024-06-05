namespace projectY.Models
{
    public class Author
    {
        //private Author(int id, string firstname, string lastname)
        //{
        //    Id = id;
        //    FirstName = firstname;
        //    LastName = lastname;
        //}
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public static (Author author, string error) Create(int id, string firstname, string lastname)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(firstname))
        //    {
        //        error = "The field can't be empty";
        //    }

        //    if (string.IsNullOrEmpty(lastname))
        //    {
        //        error = "Thefield can't be empty";
        //    }

        //    var author = new Author(id, firstname, lastname);

        //    return (author, error);
        //}
    }
}
