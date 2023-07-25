namespace InnovaAspNetMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; //name null olamaz
        //public string? Name { get; set; } //? ile name hem bir değer alabilir hem de null olabilir demek
        public decimal Price { get; set; }
    }
}
