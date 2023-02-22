using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Domain.Model.PersonAggregate
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int id { get; private set; }

        [Required]
        public string name { get; private set; }

        [Required]
        public string password { get; private set; }

        [Required]
        public string email { get; private set; }

        public string created_on { get; private set; }
    }
}
