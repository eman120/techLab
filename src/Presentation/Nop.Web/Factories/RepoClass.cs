using System;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Nop.Web.Factories
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
                QueryExpression query = new QueryExpression("contact");
                query.ColumnSet = new ColumnSet("emailaddress1");
                query.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, email);

                EntityCollection results = _serviceClient.RetrieveMultiple(query);
                if (results.Entities.Count > 0)
                {
                    Console.WriteLine("Email address already exists.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("A web service connection was not established.");
                return true;
            }
        }
        public Guid CreateContact(string fName, string lName, string Email)
        {
                Entity TechLabs = new Entity("contact");
                TechLabs["firstname"] = fName;
                TechLabs["lastname"] = lName;
                TechLabs["emailaddress1"] = Email;
                return _serviceClient.Create(TechLabs);
        }
      
    }
}
