using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Todo.Site.Models
{
    [Table("Page")]
    public class Page
    {

        public Page()
        {
            this.createdAt = DateTime.Now;
        }
        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date de création")]
        public DateTime createdAt { get; set; }
        [Required]
        [Display(Name = "Titre de la page")]
        public string title { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "Contenu principal")]
        public string content { get; set; }

        [Required]
        [Display(Name = "Activer la page ?")]
        public Boolean status { get; set; }
    }

}