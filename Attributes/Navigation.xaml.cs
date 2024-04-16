using Insta.Data;
using Insta.Services;
using Insta.Views;
using System.Windows;
using System.Windows.Controls;

namespace Insta.Attributes
{
    public partial class Navigation : UserControl
    {
        public globalData resources;
        public Navigation()
        {
            InitializeComponent();
        }
    
        private void Home_Click(object sender, RoutedEventArgs e)
        {
           
            var homwW = new HomeWindow(new UserServices(new Data.AppDbContext()), resources);
            Window.GetWindow(this).Hide();
            homwW.Show();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchW = new SearchWindow();
             Window.GetWindow(this).Hide();
             searchW.Show();
        }
        private void Explore_Click(object sender, RoutedEventArgs e)
        {
            var exploreW = new ExploreWondow();
             Window.GetWindow(this).Hide();
             exploreW.Show();
        }
        private void Post_Click(object sender, RoutedEventArgs e)
        {
            var postW = new PostWindow(new AdminServices(new Data.AppDbContext()),new Data.Post(), new Data.AppDbContext(),resources);
             Window.GetWindow(this).Hide();
            postW.Show();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            var profW = new ProfileWindow();
            Window.GetWindow(this).Hide();
            profW.Show();
        }
    }
}
