using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Todo.Site.Models
{

    public class Email
    {
        [Required(ErrorMessage = "Merci de remplir le formulaire")]
        [Display(Name = "Email")]
        public string Mail { get; set; }
    }

}