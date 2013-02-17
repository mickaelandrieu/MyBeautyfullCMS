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
    [Table("Comment")]
    public class Comment
    {

        public Comment()
        { 
            this.createdAt = DateTime.Now;
            this.status = false;
        }

        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Key]
        public int CommentId { get; set; }
        [Display(Name = "Date de création")]
        public DateTime createdAt { get; set; }

        [Required]
        [Display(Name = "Valider le commentaire ?")]
        public Boolean status { get; set; }
        [Required]
        public string author;

        [Required]
        [Display(Name = "Votre commentaire")]
        public String content { get; set; }

        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

    }
}