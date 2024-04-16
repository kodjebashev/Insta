using Insta.Data;
using Insta.Data.Identity;
using System.Windows;

namespace Insta.Views.Identity.Register
{
    public partial class RegisterWindowOne : Window
    {
        private static AppUser user = new AppUser();
        public RegisterWindowOne()
        {
            InitializeComponent();
        }

        private void redirectToRegTwo(object sender, RoutedEventArgs e)
        {
            if(true)
            {
                user.Name = inputName.Text;
                user.Password = inputPassword.Text;

                var regTwo = new RegisterWindowTwo(user, new AppDbContext(),new Services.AdminServices(new Data.AppDbContext()));
                this.Hide();
                regTwo.Show();
            }
        }

        private bool dataIsValid()
        {
            if (inputName.Text.Length >= 3 && inputPassword.Text.Length >= 8 && inputPassword.Text == inputConfirmPassword.Text)
            {
                return true;
            }
            return false;
        }
    }
}
