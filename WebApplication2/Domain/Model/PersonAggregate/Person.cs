using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Domain.Model.PersonAggregate
{
    [Table("person")]
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

        public DateTime created_on { get; private set; }

        public Person(string name, string email, string password, DateTime created_on) 
        {
            this.name = name; 
            this.email = email;
            this.password = password;
            this.created_on = created_on;
        }
    }
}
