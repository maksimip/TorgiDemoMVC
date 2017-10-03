using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitis
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Cars { get; set; }
        public bool Realty { get; set; }
        public bool Jewelry { get; set; }
        public bool Telephones { get; set; }
    }
}
