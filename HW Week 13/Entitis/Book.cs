using HW_Week_13.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Entitis
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Writer { get; set; }
        public double Price { get; set; }
        public DateTime? Borrowdate { get; set; }
        public bool IsBorrowed { get;  set; }
        public GenreEnum Genre { get; set; }
        public User User { get; set; }


       
    }
}
