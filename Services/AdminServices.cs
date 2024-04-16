using Insta.Data;
using Insta.Data.Identity;
using Insta.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Insta.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly AppDbContext context;
        public AdminServices(AppDbContext context)
        {
           this.context = context;
        }
        public Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {           
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        public byte[] ToByteArray(Bitmap instance)
        {

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(instance, typeof(byte[]));
        }
        public void StartupDataLoad(globalData res)
        {
            var user = GetCurrentUser();
          //  res.userFollowing = user.Connections.FollowingId;
          //  res.userFollowers = user.Connections.FollowersId;
            res.allUsers = GetAllUsersNames();
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
            return context.AppUsers.FirstOrDefault(x=>x.Email == proxy.Email);
        }
        public List<string> GetAllUsersNames()
        {
            var list = context.AppUsers.ToList();
            List<string> names = new List<string>();
            foreach (var x in list) 
            {
             names.Add(x.Name);
            }
            return names;
        }
    }
}
