using Mvc.Mailer;

namespace Todo.Site.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage GoodBye();
	}
}