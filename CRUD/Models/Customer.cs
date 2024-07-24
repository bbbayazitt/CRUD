namespace CRUD.Models
{
    public class Customer
    {
        public int Id { get; set; } // entity framework know automatically its primary key
        public string? FirstName { get; set; } // ? means that nullable
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
