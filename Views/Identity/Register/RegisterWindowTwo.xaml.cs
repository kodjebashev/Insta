using Insta.Data;
using Insta.Data.Identity;
using Insta.Services;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Insta.Views.Identity.Register
{
    /// <summary>
    /// Interaction logic for RegisterWindowTwo.xaml
    /// </summary>
    public partial class RegisterWindowTwo : Window
    {
        private protected AppUser user;
        private protected AppDbContext dbContext;
        private readonly AdminServices adminServices;
        public RegisterWindowTwo(AppUser user, AppDbContext dbContext, AdminServices adminServices)
        {
            InitializeComponent();
            this.user = user;
            this.dbContext = dbContext;
            this.adminServices = adminServices;
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            user.Bio = inputBio.Text;
            user.Email = inputEmail.Text;
            user.Profesional = false;
            user.EmailComfirmed = true;
            dbContext.AppUsers.Add(user);
            dbContext.SaveChanges();

            var proxy = new userProxy() 
               {
                Email = inputEmail.Text,
                Password = user.Password,
               };
            proxy.Serialize();

            var mainW = new HomeWindow(new UserServices(new Data.AppDbContext()), new globalData());
            this.Hide();
            mainW.Show();
        }
        private void redirectToRegOne(object sender, RoutedEventArgs e)
        {
            var regOne = new RegisterWindowOne();
            this.Hide();
            regOne.Show();
        }
        private void addProfilePic(object sender, RoutedEventArgs e)
        { 
            OpenFileDialog dlg = new OpenFileDialog();
           
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                user.Photo =  adminServices.ToByteArray(adminServices.BitmapImage2Bitmap(bitmap));
                image.Source = bitmap;
               
            }
        }
       
       
    }
       
}
