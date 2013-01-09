using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Todo.Site.Models
{
    public class Article
    {

        public Article()
        { 
            this.createdAt = DateTime.Now;
        }
        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date de création")]
        public DateTime createdAt { get; set; }
        [Required]
        [Display(Name = "Titre de l'article")]
        public string title { get; set; }

        [Display(Name = "Introduction (extrait)")]
        public string introduction { get; set;}

        [Required]
        [Display(Name = "Contenu principal")]
        public string content { get; set; }

        [Required]
        [Display(Name = "Activer l'article ?")]
        public Boolean status { get; set; }
    }

}