using System;

namespace Nop.Web.Factories
{
    public interface IRepoClass
    {
        public bool CheckMail(string email);
        public Guid CreateContact(string fName , string lName , string Email);
    }
}
