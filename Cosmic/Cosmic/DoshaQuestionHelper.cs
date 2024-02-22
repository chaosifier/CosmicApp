using Cosmic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cosmic
{
    public static class DoshaQuestionHelper
    {
        private static Random _rand = new Random();
        public static List<DoshaQuestion> GetQuestions()
        {
            var allDoshas = GetDoshas();
            var vataDosha = allDoshas.Single(d => d.Key == "vata");
            var pitaDosha = allDoshas.Single(d => d.Key == "pita");
            var kafaDosha = allDoshas.Single(d => d.Key == "kafa");

            var questions = new List<DoshaQuestion>()
            {
                new DoshaQuestion(1, vataDosha, "My personality is lively and enthusiastic."),
                new DoshaQuestion(2, vataDosha, "I learn new things quickly but also forget them easily."),
                new DoshaQuestion(3, vataDosha, "I naturally walk at a brisk pace."),
                new DoshaQuestion(4, vataDosha, "I tend to speak quickly and fluently."),
                new DoshaQuestion(5, vataDosha, "I experience waves of abundant energy throughout the day."),

                new DoshaQuestion(6, pitaDosha, "I have a sharp intellect and a driven, passionate personality."),
                new DoshaQuestion(7, pitaDosha, "I feel compelled to tackle challenging tasks."),
                new DoshaQuestion(8, pitaDosha, "I prefer to follow my own ideas and can be stubborn at times."),
                new DoshaQuestion(9, pitaDosha, "I hold myself and others to high standards."),
                new DoshaQuestion(10, pitaDosha, "Very spicy or hot foods tend to upset my stomach, which tends to be acidic."),

                new DoshaQuestion(11, kafaDosha, "Others often describe me as easy - going, loyal, loving, and compassionate."),
                new DoshaQuestion(12, kafaDosha, "I tend to move at a slow, steady pace."),
                new DoshaQuestion(13, kafaDosha, "I prefer to follow my own ideas and can be stubborn at times."),
                new DoshaQuestion(14, kafaDosha, "I find it easy to gain weight and difficult to lose it."),
                new DoshaQuestion(15, kafaDosha, "I may take longer to grasp new concepts, but I have excellent long-term memory retention.")
            };

            questions = questions.OrderBy(q => _rand.Next()).ToList();

            return questions;
        }

        public static List<Dosha> GetDoshas(bool includeTraits = true)
        {
            var doshas = new List<Dosha>()
            {
                new Dosha()
                {
                    DoshaName = "Vata",
                    Key = "vata",
                    Color = Color.Purple,
                    InBalanceTraits = new List<string>
                    {
                        "Balanced digestion and regular elimination.",
                        "Clear and alert mind.",
                        "Energetic and lively personality.",
                        "Good circulation and even body temperature.",
                        "Quick and easy learning ability.",
                        "Easily falls asleep at bedtime."
                    },
                    OutOfBalanceTraits = new List<string>
                    {
                        "Difficulty falling asleep.",
                        "Fatigue and tiredness.",
                        "Feeling physically cold.",
                        "Feeling spaced out or scattered.",
                        "Lack of focus or forgetfulness.",
                        "Occasional constipation, gas, or bloating.",
                        "Poor circulation, often manifesting as cold hands and feet.",
                        "Feelings of anxiousness or worry."
                    }
                },
                new Dosha()
                {
                    DoshaName = "Pita",
                    Key = "pita",
                    Color = Color.Orange,
                    InBalanceTraits = new List<string>
                    {
                        "Attention to detail and a tendency towards perfectionism.",
                        "Consistent, restful sleep throughout the night.",
                        "Inner peace and happiness.",
                        "Radiant and glowing skin.",
                        "Sharp intellect and mental acuity.",
                        "Strong digestion."
                    },
                    OutOfBalanceTraits = new List<string>
                    {
                        "Controlling and fiery personality traits.",
                        "Feeling overheated and excess stomach acid.",
                        "Interrupted or disturbed sleep patterns.",
                        "Loose bowel movements and digestive issues.",
                        "Skin rashes and acne breakouts.",
                        "Tendencies towards being a workaholic."
                    }
                },
                 new Dosha()
                {
                    DoshaName = "Kafa",
                    Key = "kafa",
                    Color = Color.Green,
                    InBalanceTraits = new List<string>
                    {
                        "Compassionate and affectionate nature.",
                        "Good long-term memory retention.",
                        "Healthy and robust physical constitution.",
                        "Enjoy sound and restful sleep.",
                        "Stable temperament and emotional balance.",
                        "Strength and stamina."
                    },
                    OutOfBalanceTraits = new List<string>
                    {
                        "Difficulty waking up and feelings of sadness.",
                        "Lethargy and lack of energy.",
                        "Prone to sinus and respiratory issues.",
                        "Sluggish digestion.",
                        "Tendency to gain weight easily."
                    }
                },
            };

            return doshas;
        }
    }
}
