using Cosmic.Model;
using Cosmic.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cosmic.ViewModel
{
    public class LearnMorePageViewModel : ObservableBase
    {
        private List<Dosha> _doshas;
        public List<Dosha> Doshas
        {
            get { return _doshas; }
            set { SetProperty(ref _doshas, value); }
        }

        public LearnMorePageViewModel()
        {
            Doshas = DoshaQuestionHelper.GetDoshas();
        }
    }
}
