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
    [Table("Article")]
    public class Article
    {

        public Article()
        { 
            this.createdAt = DateTime.Now;
           // this.User = Page.CurrentUser;
        }
        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Key]
        public int ArticleId { get; set; }
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

        [Display(Name = "Associer un Tag")]
        public int TagId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        [ForeignKey("UserId")]
        public UserProfile User { get; set; }
    }

}