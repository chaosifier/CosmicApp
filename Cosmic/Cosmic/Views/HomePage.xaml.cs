using Cosmic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cosmic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePageViewModel PageViewModel { get; set; }
        public HomePage()
        {
            InitializeComponent();

            PageViewModel = new HomePageViewModel();
            base.BindingContext = PageViewModel;
        }
    }
}