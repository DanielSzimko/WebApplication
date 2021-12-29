using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication_Server.Models
{
    public class Patient
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(35)]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MaxLength(35)]
        [MinLength(4)]
        public string Address { get; set; }

        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public string TAJNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string Complaint { get; set; }

        public string Diagnosis { get; set; }

        public DateTime AddedDate { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Address} - {TAJNumber} - {Complaint} - {Diagnosis}";
        }

    }
}
