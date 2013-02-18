using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyBeautyfullCMS.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Key]
        public int TagId { get; set; }
        [Required]
        [Display(Name = "Titre du tag")]
        public string title { get; set; }
    }

}