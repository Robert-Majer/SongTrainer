using Microsoft.Win32;
using SongTrainer.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace SongTrainer.Views
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        private const double minimumLoopTime = 10;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void PlayerMediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            player.ScrubbingEnabled = true;
            player.Play();
        }

        private void PlayerMediaOpened(object sender, RoutedEventArgs e)
        {
            progresBar.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
            startLoopSlider.Maximum = progresBar.Maximum;
            endLoopSlider.Maximum = progresBar.Maximum;
            endLoopSlider.Value = endLoopSlider.Maximum;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;

            player.Play();
            player.Pause();
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            progresBar.Value = player.Position.TotalSeconds;

            if (progresBar.Value >= endLoopSlider.Value && loopCheckBox.IsChecked == true)
            {
                player.Pause();
                player.Position = TimeSpan.FromSeconds(startLoopSlider.Value);
                progresBar.Value = startLoopSlider.Value;
                player.Play();
            }
            else if (progresBar.Value >= endLoopSlider.Value)
            {
                player.Pause();
                player.Position = TimeSpan.FromSeconds(startLoopSlider.Value);
                progresBar.Value = startLoopSlider.Value;
            }
        }

        private void StartLoopSliderDragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            double loopTimeCheck = endLoopSlider.Value - startLoopSlider.Value;

            if (loopTimeCheck < minimumLoopTime)
            {
                startLoopSlider.Value = endLoopSlider.Value - minimumLoopTime;
            }

            if (progresBar.Value <= startLoopSlider.Value && player.IsBuffering == true)
            {
                player.Pause();
                player.Position = TimeSpan.FromSeconds(startLoopSlider.Value);
                progresBar.Value = startLoopSlider.Value;
                player.Play();
            }
            else if (progresBar.Value <= startLoopSlider.Value)
            {
                player.Position = TimeSpan.FromSeconds(startLoopSlider.Value);
                progresBar.Value = startLoopSlider.Value;
            }
        }

        private void EndLoopSliderDragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            double loopTimeCheck = endLoopSlider.Value - startLoopSlider.Value;

            if (loopTimeCheck < minimumLoopTime)
            {
                endLoopSlider.Value = startLoopSlider.Value + minimumLoopTime;
            }

            if (progresBar.Value >= endLoopSlider.Value && loopCheckBox.IsChecked == true)
            {
                player.Pause();
                player.Position = TimeSpan.FromSeconds(startLoopSlider.Value);
                progresBar.Value = startLoopSlider.Value;
                player.Play();
            }
            else if (progresBar.Value >= endLoopSlider.Value)
            {
                player.Pause();
                player.Position = TimeSpan.FromSeconds(startLoopSlider.Value);
                progresBar.Value = startLoopSlider.Value;
            }
        }

        private void SpeedSliderDragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            player.SpeedRatio = speedSlider.Value;

            var content = speedSlider.Value / 1.0;

            speedRatioInPercentage.Content = content;
        }
    }
}