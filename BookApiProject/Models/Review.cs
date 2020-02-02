﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiApplication.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Review text cannot be greater than 200")]
        public string Headline { get; set; }

        [Required]
        [StringLength(2000,MinimumLength =50,ErrorMessage ="Review text cannot be greater than 200")]
        public string ReviewText { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual Book Book{ get; set; }
    }
}
