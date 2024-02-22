using Cosmic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cosmic.Model
{
    public class DoshaQuestion : ObservableBase
    {
        public DoshaQuestion(int questionNo, Dosha dosha, string question)
        {
            QuestionNo = questionNo;
            Question = question;
            Dosha = dosha;
        }

        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public Dosha Dosha { get; set; }

        private decimal _answer;
        public decimal Answer
        {
            get { return _answer; }
            set { SetProperty(ref _answer, value); }
        }
    }

    public class Dosha
    {
        public string DoshaName { get; set; }
        public string Key { get; set; }
        public List<string> InBalanceTraits { get; set; }
        public List<string> OutOfBalanceTraits { get; set; }
        public Color Color { get; set; }
    }

    public class DoshaResult : ObservableBase
    {
        public DoshaResult(decimal vata, decimal pita, decimal kafa)
        {
            VataResult = vata;
            PitaResult = pita;
            KafaResult = kafa;
        }

        private decimal _vataResult;
        public decimal VataResult
        {
            get { return _vataResult; }
            set { SetProperty(ref _vataResult, value); }
        }

        private decimal _pitaResult;
        public decimal PitaResult
        {
            get { return _pitaResult; }
            set { SetProperty(ref _pitaResult, value); }
        }

        private decimal _kafaResult;
        public decimal KafaResult
        {
            get { return _kafaResult; }
            set { SetProperty(ref _kafaResult, value); }
        }
    }
}
