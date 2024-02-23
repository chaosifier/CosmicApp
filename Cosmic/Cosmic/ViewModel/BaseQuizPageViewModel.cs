using Cosmic.Model;
using Cosmic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cosmic.ViewModel
{
    public class BaseQuizPageViewModel : ObservableBase
    {
        public bool IsBusy { get; set; }
        public ICommand OpenNextQuestion { get; set; }
        public List<DoshaQuestion> AllQuestions { get; set; }

        private int _questionCounter = 0;
        public int QuestionCounter
        {
            get { return _questionCounter; }
            set { SetProperty(ref _questionCounter, value); }
        }

        private DoshaQuestion _currentQuestion;
        public DoshaQuestion CurrentQuestion
        {
            get { return _currentQuestion; }
            set { SetProperty(ref _currentQuestion, value); }
        }

        private string _buttonText = "Next";
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private int _currentQuestionNo = 1;
        public int CurrentQuestionNo
        {
            get { return _currentQuestionNo; }
            set { SetProperty(ref _currentQuestionNo, value); }
        }

        private DoshaResult _result;
        public DoshaResult Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        private bool _showResult;
        public bool ShowResult
        {
            get { return _showResult; }
            set { SetProperty(ref _showResult, value); }
        }

        private DoshaResult getResult(decimal vataPercent, decimal pittaPercent, decimal kaphaPercent)
        {
            var sum = vataPercent + pittaPercent + kaphaPercent;
            var vataResult = sum <= 0 ? 0 : (vataPercent / sum * 100);
            var pittaResult = sum <= 0 ? 0 : (pittaPercent / sum * 100);
            var kaphaResult = sum <= 0 ? 0 : (kaphaPercent / sum * 100);

            return new DoshaResult(vataResult, pittaResult, kaphaResult);
        }

        public BaseQuizPageViewModel()
        {
            AllQuestions = DoshaQuestionHelper.GetQuestions();
            CurrentQuestion = AllQuestions[QuestionCounter];

            OpenNextQuestion = new Command(async () =>
            {
                if (IsBusy)
                    return;

                if (CurrentQuestionNo == AllQuestions.Count)
                {
                    // submit and show result
                    var doshaGroups = AllQuestions
                    .GroupBy(q => q.Dosha.Key)
                    .Select(q => new
                    {
                        q.Key,
                        Percent = q.Sum(da => da.Answer) / q.Count()
                    });

                    var vataPercent = doshaGroups.Single(d => d.Key == "vata").Percent;
                    var pittaPercent = doshaGroups.Single(d => d.Key == "pitta").Percent;
                    var kaphaPercent = doshaGroups.Single(d => d.Key == "kapha").Percent;

                    Result = getResult(vataPercent, pittaPercent, kaphaPercent);
                    ShowResult = true;
                }
                else
                {
                    QuestionCounter++;
                    CurrentQuestionNo++;
                    CurrentQuestion = AllQuestions[QuestionCounter];
                }

                try
                {
                    ButtonText = CurrentQuestionNo == AllQuestions.Count ? "Submit" : "Next";
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
