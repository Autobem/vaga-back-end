using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain.Entities
{
    public class Owner: BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
