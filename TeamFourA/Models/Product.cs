using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class Product
        //Shermaine
    {
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(10)]
        public double Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImageURL { get; set; }

        [MaxLength(100)]
        public int Value { get; set; }

        public virtual IList<TransactionDetail> TransactionDetails { get; set; }

  
    }

    
    
}
