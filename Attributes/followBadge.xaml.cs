using Insta.Services;
using System.Windows.Controls;

namespace Insta.Attributes
{
    /// <summary>
    /// Interaction logic for followBadge.xaml
    /// </summary>
    public partial class followBadge : UserControl
    {
        private readonly UserServices userServices;
        public followBadge(int id, UserServices services)
        {
            InitializeComponent();
            this.userServices = services;


        }
    }
}
