using Insta.Data;
using Insta.Services;
using System.Windows;

namespace Insta.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private readonly UserServices services;
        public HomeWindow(UserServices services, globalData resources)
        {
            InitializeComponent();
            this.services = services;
            var users = services.GetAllUsers();

            for (int i = 0; i <= 20; i++)
            {
                var post = new Insta.Attributes.Post();

                postsStackPanel.Children.Add(post);
            }
            
            for (int i = 0; i <= users.Count-1; i++)
            {

                var badge = new Insta.Attributes.followBadge(users[i].Id);

                followStackPanel.Children.Add(badge);
            }
            navigation.resources = resources;
        }

    }
}
