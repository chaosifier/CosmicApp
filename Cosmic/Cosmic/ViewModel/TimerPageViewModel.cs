using Cosmic.Model;
using Cosmic.Views;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cosmic.ViewModel
{
    public class TimerPageViewModel : ObservableBase
    {
        private double _durationInMinutes = 20;
        public double DurationInMinutes
        {
            get { return _durationInMinutes; }
            set { SetProperty(ref _durationInMinutes, value); }
        }

        public ICommand StartStopCommand { get; set; }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { SetProperty(ref _isRunning, value); }
        }

        private int _elapsedTimeInSecs;
        public int ElapsedTimeInSecs
        {
            get { return _elapsedTimeInSecs; }
            set { SetProperty(ref _elapsedTimeInSecs, value); }
        }

        private ISimpleAudioPlayer _player;

        private string _buttonText = "Start";
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        public TimerPageViewModel()
        {
            _player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

            StartStopCommand = new Command(() =>
            {
                if (IsRunning)
                {
                    IsRunning = false;
                    ElapsedTimeInSecs = 0;
                }
                else
                {
                    _player.Load("start.mp3");
                    _player.Play();

                    IsRunning = true;
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {   
                        if (!IsRunning)
                        {
                            _player.Stop();
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                ElapsedTimeInSecs++;
                            });
                        }

                        if (ElapsedTimeInSecs >= TimeSpan.FromMinutes(DurationInMinutes).TotalSeconds)
                        {
                            IsRunning = false;
                            _player.Stop();
                            _player.Load("end.mp3");
                            _player.Play();
                        }

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            ButtonText = IsRunning ? "Stop" : "Start";
                        });

                        return IsRunning;
                    });
                }

                ButtonText = IsRunning ? "Stop" : "Start";
            });
        }
    }
}
