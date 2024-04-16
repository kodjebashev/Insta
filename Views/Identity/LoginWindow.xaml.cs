using Insta.Data;
using Insta.Data.Identity;
using Insta.Services;
using Insta.Views.Identity.Register;
using System.Windows;

namespace Insta.Views.Identity
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : System.Windows.Window
    {
        private readonly UserServices services;
        private readonly globalData resources;
        public LoginWindow(UserServices services,globalData resources)
        {
            InitializeComponent();
            this.services = services;
            this.resources = resources;
        }
        public LoginWindow(UserServices services, userProxy proxy, globalData resources)
        {
            InitializeComponent();
            this.services = services;
            this.resources = resources;
            Login(proxy.Email, proxy.Password);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mail = inputEmail.Text;
            var pass = inputPassword.Text;
            if (ValidateLoginInput()== true) 
            {
                if (ValidateUserExistanve()==true) {
                    Login(mail, pass);
                }
            }
        }
        public void Login(string mail, string pass)
        {
                var proxy = new userProxy()
                {
                    Email = mail,
                    Password = pass,
                };

                proxy.Serialize();

                var mainW = new HomeWindow(new UserServices(new Data.AppDbContext()),resources);
                this.Hide();
                mainW.Show();

            
        }
        private void redirectToRegister(object sender, RoutedEventArgs e)
        {

            var regW = new RegisterWindowOne();
            regW.Show();
            this.Hide();
        }
        private bool ValidateLoginInput()
        {
            if (inputPassword.Text.Length >= 6 && inputEmail.Text.Length >= 2 &&
                inputEmail.Text != "Username" && inputPassword.Text != "Password")
            {
                return true;
            }
            return false;
        }
        private bool ValidateUserExistanve()
        {
            var users = services.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Email == inputEmail.Text)
                {
                    return true;
                }
            }
            return false;
        }
   
    }
}
