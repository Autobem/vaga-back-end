using Cars.Domain.Model.PersonAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Domain.Model.CarAggregate
{
    [Table("car")]
    public class Car
    {
        [Key]
        public int id { get; private set; }

        [Required]
        public string name { get; private set; }

        public Person owner_id { get; set; }

        public DateTime created_on { get; private set; }
    }
}
