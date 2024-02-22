using Cosmic.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cosmic.ViewModel
{
    public class HomePageViewModel : ObservableBase
    {
        public bool IsBusy { get; set; }
        public ICommand OpenBaseQuizCommand { get; set; }
        public ICommand OpenLearnMorePageCommand { get; set; }
        public ICommand OpenTimerPageCommand { get; set; }
        public string QuoteOfTheDay { get; set; }

        public HomePageViewModel()
        {
            QuoteOfTheDay = DoshaQuestionHelper.GetQuoteOfTheDay();

            OpenBaseQuizCommand = new Command(async () =>
            {
                if (IsBusy)
                    return;

                try
                {
                    IsBusy = true;
                    await Cosmic.App.MainNavigation.PushAsync(new BaseQuizPage());
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("An error occurred.", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            });

            OpenLearnMorePageCommand = new Command(async () =>
            {
                if (IsBusy)
                    return;

                try
                {
                    IsBusy = true;
                    await Cosmic.App.MainNavigation.PushAsync(new LearnMorePage());
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("An error occurred.", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            });

            OpenTimerPageCommand = new Command(async () =>
            {
                if (IsBusy)
                    return;

                try
                {
                    IsBusy = true;
                    await Cosmic.App.MainNavigation.PushAsync(new TimerPage());
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("An error occurred.", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
