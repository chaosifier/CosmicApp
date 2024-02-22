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
    public partial class LearnMorePage : ContentPage
    {
        public LearnMorePageViewModel PageViewModel { get; set; }
        public LearnMorePage()
        {
            InitializeComponent();

            PageViewModel = new LearnMorePageViewModel();
            base.BindingContext = PageViewModel;
        }
    }
}