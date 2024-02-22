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
    public partial class BaseQuizPage : ContentPage
    {
        public BaseQuizPageViewModel PageViewModel { get; set; }
        public BaseQuizPage()
        {
            InitializeComponent();

            PageViewModel = new BaseQuizPageViewModel();

            base.BindingContext = PageViewModel;
        }
    }
}