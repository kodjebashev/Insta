using Insta.Data;
using Insta.Data.Identity;
using Insta.Services;
using Insta.Views;
using Insta.Views.Identity;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace Insta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly globalData resources;
        private readonly UserServices userServices;
        private readonly AdminServices adminServices;
       public App()
        {
            InitializeComponent();
              this.userServices= new UserServices(new AppDbContext());
                this.adminServices= new AdminServices(new AppDbContext());
                 this.resources = new globalData();
        }
       
        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {
          //  adminServices.StartupDataLoad(resources);

            userProxy proxy = userServices.findLogedUserProxy();

            if (proxy == null)
            {
                var log = new LoginWindow(new UserServices(new Data.AppDbContext()), resources);
                log.Show();

            }
            else
            {
                var log = new LoginWindow(new UserServices(new Data.AppDbContext()), proxy, resources);
            }                       
        }
    }
}
