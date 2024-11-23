using HW_Week_13.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Entitis
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Family { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public List<Book> Books { get; set; } = new();
        
    }
}
