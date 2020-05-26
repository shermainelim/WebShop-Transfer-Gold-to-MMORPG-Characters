using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class Order
    {
        //(shermaine)

        [Key]
        [Column("Id")] //this attribute maps TeamId to the column Id in the database
        public int OldId { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserID { get; set; }

        [Required]
        [MaxLength(500)]
        public string GameUsername { get; set; }

        [Required]
        [MaxLength(10)]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductActivationCode { get; set; }

        [Required]
        [MaxLength(100)]
        public double AmountPaid { get; set; }

        [Required]
        [MaxLength(100)]
        public int Quantity { get; set; }
    }
}
