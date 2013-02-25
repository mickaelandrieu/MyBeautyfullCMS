using System;
using Mvc.Mailer;
using Todo.Site.Models;

namespace Todo.Site.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		
		public virtual MvcMailMessage Welcome()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "Message en provenance de sucresale.fr";
				x.ViewName = "Welcome";
                x.To.Add("aspmvc4@gmail.com");
			});
		}
 
		public virtual MvcMailMessage GoodBye()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "GoodBye";
				x.ViewName = "GoodBye";
				x.To.Add("some-email@example.com");
			});
		}

        public virtual MvcMailMessage ContactForm(ContactForm ContactForm)
        {
            ViewBag.Name = ContactForm.name;
            ViewBag.Body = ContactForm.comment;

            return Populate(x =>
            {
                x.Subject = "Un message de sucre-sale.fr";
                x.ViewName = "Welcome";
                x.To.Add("aspmvc4@gmail.com");
            });
        }
 	}
}