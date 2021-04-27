using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string FabricationYear { get; set; }
        
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
    }
}
