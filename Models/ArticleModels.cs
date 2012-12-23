using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Todo.Site.Models
{

    public class ArticlesContext : DbContext
    {
        public ArticlesContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Article> Articles { get; set; }
    }


 
    public class Article
    {

        public Article()
        { 
            this.createdAt = DateTime.Now;
        }
        /*[Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Display(Name = "Email")]*/
        [Key]
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        [Required]
        public string title { get; set; }
        public string introduction { get; set;}
        [Required]
        public string content { get; set; }
        [Required]
        public Boolean status { get; set; }
    }

}