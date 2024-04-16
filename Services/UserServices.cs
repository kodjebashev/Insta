using Insta.Data;
using Insta.Data.Identity;
using Insta.Services.Interfaces;
using System.Xml;

namespace Insta.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext context;
        public UserServices(AppDbContext context)
        {
            this.context = context;
        }
        public List<AppUser> GetAllUsers()
        {
           return context.AppUsers.ToList();
        }
        public AppUser GetUserByEmail(string mail)
        {
            return context.AppUsers.FirstOrDefault(x => x.Email == mail);
        }
        public void CreateUser(AppUser user)
        {
                context.AppUsers.Add(user);
               context.SaveChanges();        
        }
        public AppUser GetByUsername(string username)
        {
            return context.AppUsers.FirstOrDefault(x => x.Name == username);
        }
        public userProxy findLogedUserProxy()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\UserData.xml");
            XmlNode node = doc.DocumentElement;

            userProxy proxy = new userProxy();

            if (node.Name == "root")
            {
                proxy = null;
            }
            else
            {
                proxy.Email = node.ChildNodes[0].InnerText;
                proxy.Password = node.LastChild.InnerText;
            }


            return proxy;
        }
        public AppUser GetCurrentUser()
        {
            var proxy = findLogedUserProxy();
            return GetUserByEmail(proxy.Email);
        }
    }
}