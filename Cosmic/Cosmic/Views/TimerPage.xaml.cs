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
    public partial class TimerPage : ContentPage
    {
        public TimerPageViewModel PageViewModel { get; set; }
        public TimerPage()
        {
            InitializeComponent();

            PageViewModel = new TimerPageViewModel();
            base.BindingContext = PageViewModel;
        }
    }
}