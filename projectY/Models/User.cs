namespace projectY.Models
{
    public class User
    {
        //private User(int id, string firstname, string lastname, string email, string password, DateTime registration)
        //{
        //    Id = id;
        //    FirstName = firstname;
        //    LastName = lastname;
        //    Email = email;
        //    Password = password;
        //    RegistrationDate = registration;
        //}
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        //public static (User user, string error) Create(int id, string firstname, string lastname, string email, string password, DateTime registration)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(firstname))
        //    {
        //        error = "The field can't be empty";
        //    }
        //    if (string.IsNullOrEmpty(lastname))
        //    {
        //        error = "The field can't be empty";
        //    }
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        error = "The field can't be empty";
        //    }
        //    if (string.IsNullOrEmpty(password))
        //    {
        //        error = "The field can't be empty";
        //    }
        //    var user = new User(id, firstname, lastname, email, password, registration);

        //    return (user, error);
        //}
    }
}
