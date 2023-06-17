
using System;

namespace Nop.Web.Repo
{
    public interface IRepoClass
    {
        public bool CheckMail(string email);
        public Guid CreateContact(string fName , string lName , string Email);
    }
}
