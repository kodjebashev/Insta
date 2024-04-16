using Insta.Data;
using Insta.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Insta.Views
{
    /// <summary>
    /// Interaction logic for PostWindow.xaml
    /// </summary>
    public partial class PostWindow : Window
    {
        private protected Post post;
        private readonly AdminServices adminServices;
        private readonly AppDbContext context;
        private readonly globalData resources;
        public PostWindow(AdminServices adminServices,Post post, AppDbContext context, globalData resources)
        {
            InitializeComponent();
            this.adminServices = adminServices;
            this.post = post;
            this.context = context;
            this.resources = resources;
        }
        private void choisePostPic(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                post.Photo = adminServices.ToByteArray(adminServices.BitmapImage2Bitmap(bitmap));
                image.Source = bitmap;

            }
        }

        private void inputUsers(object sender, EventArgs e)
        {
            comboboxFrs.Items.Clear();
           
            foreach (var user in resources.userFollowers)
            {
                comboboxFrs.Items.Add($"@{user}");
            }
        }

        private void selectedIdx(object sender, RoutedEventArgs e)
        {
            tagedFrsListBox.Items.Add(comboboxFrs);
        }
    }
}
