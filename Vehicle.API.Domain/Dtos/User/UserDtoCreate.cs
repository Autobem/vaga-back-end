using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.API.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
