using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Todo.Site.Models
{
    
    public class ContactForm
    {
        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Key]
        public int ContactId { get; set; }
        [Required]
        [Display(Name = "Votre nom")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Votre email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Votre site web")]
        public string website { get; set; }
        [Required]
        [Display(Name = "Votre commentaire")]
        public string comment { get; set; }

    }
}