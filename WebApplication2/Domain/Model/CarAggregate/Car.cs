using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Car.Domain.Model.PersonAggregate;

namespace Car.Domain.Model.CarAggregate
{
    [Table("car")]
    public class Vehicle
    {
        [Key]
        public int id { get; private set; }

        [Required]
        public string name { get; private set; }

        [Required]
        public int owner_id { get; set; }

        [ForeignKey("owner_id")]
        public Person owner { get; set; }

        public DateTime created_on { get; set; }

        public Vehicle(int id, string name, int owner_id, DateTime created_on)
        {
            this.id = id;
            this.name = name;
            this.owner_id = owner_id;
            this.created_on = created_on;
        }

        public Vehicle()
        {
        }
    }
}
