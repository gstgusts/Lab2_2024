using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DataAccess
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        public int Value { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public Student Student { get; set; }

    }
}
    