namespace projectY.Models
{
    public class Year
    {
        //private Year(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        //public static (Year year, string error) Create(int id, string name)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        error = "The field can't be empty";
        //    }

        //    var year = new Year(id, name);

        //    return (year, error);
        //}
    }
}
