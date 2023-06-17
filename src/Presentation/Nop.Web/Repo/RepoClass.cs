using System;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Nop.Web.Repo
{
    public class RepoClass : IRepoClass
    {
        readonly private ServiceClient _serviceClient;
        public RepoClass()
        {
            // Create an instance of ServiceClient
            _serviceClient = new ServiceClient(@"AuthType=ClientSecret;Url=https://tllinterviews.crm4.dynamics.com/apps/CS;ClientId=23047e6f-c359-4cb3-8dcd-4f08373fead5;ClientSecret=pyH8Q~fLdAZzp5S9LI46W-Ab9eSZxWl7pZHbnaay;");
        }
        public bool CheckMail(string email)
        {
            if (_serviceClient.IsReady)
            {
                // Check if the email address already exists
                QueryExpression query = new QueryExpression("contact");
                query.ColumnSet = new ColumnSet("emailaddress1");
                query.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, email);

                EntityCollection results = _serviceClient.RetrieveMultiple(query);
                if (results.Entities.Count > 0)
                {
                    Console.WriteLine("Email address already exists.");
                    return false;
                }
                else
                {
                    // Create a new contact record
                    //Entity contact = new Entity("contact");
                    //contact["firstname"] = "hagar";
                    //contact["lastname"] = "mustafa";
                    //contact["emailaddress1"] = "hagarmustafa@gmail.com";
                    //Guid createdContactId = _serviceClient.Create(contact);
                    //Console.WriteLine($"Contact created. ID: {createdContactId}");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("A web service connection was not established.");
                return false;
            }
        }
        public Guid CreateContact(string fName, string lName, string Email)
        {
            //if (_serviceClient.IsReady)
            //{
                Entity TechLabs = new Entity("contact");
                TechLabs["firstname"] = fName;
                TechLabs["lastname"] = lName;
                TechLabs["emailaddress1"] = Email;
                Console.WriteLine($"User Id = {_serviceClient.Create(TechLabs)}");
                return _serviceClient.Create(TechLabs);
           //}
            //return null;
        }
      
    }
}
