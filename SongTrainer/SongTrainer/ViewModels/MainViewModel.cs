using SongTrainer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SongTrainer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ButtonPlayCommand = new RelayCommand(ButtonPlay);
            ButtonPauseCommand = new RelayCommand(ButtonPause);
            ButtonStopCommand = new RelayCommand(ButtonStop);
            ButtonSourceCommand = new RelayCommand(ButtonSource);
        }

        public ICommand ButtonPlayCommand { get; set; }
        public ICommand ButtonPauseCommand { get; set; }
        public ICommand ButtonStopCommand { get; set; }
        public ICommand ButtonSourceCommand { get; set; }

        private void ButtonPlay(object obj)
        {
            MessageBox.Show(obj as string);
        }

        private void ButtonPause(object obj)
        {
            MessageBox.Show(obj as string);
        }

        private void ButtonStop(object obj)
        {
            MessageBox.Show(obj as string);
        }

        private void ButtonSource(object obj)
        {
            MessageBox.Show(obj as string);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}