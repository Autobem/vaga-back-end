namespace Cars.Domain.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string NamePerson { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime? created_on { get; set; }
    }
}
