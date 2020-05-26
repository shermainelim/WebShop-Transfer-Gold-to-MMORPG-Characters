using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class User
    {

        [Key]
        [Column("Id")] //this attribute maps TeamId to the column Id in the database
        public int OldId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public virtual IList<Transaction> Transactions { get; set; }
    }
}
