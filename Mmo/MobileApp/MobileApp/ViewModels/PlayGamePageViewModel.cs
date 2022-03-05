using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileApp.Heplers;
using MobileApp.Models;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class PlayGamePageViewModel : ViewModelBase
    {
        private int _points;
        private int _maxLength;
        private string _answer;
        private string _note;
        private int _id;
        private string _image;
        private bool _isLoading;
        private GameModel _game;
        private int _successful;
        private Random _random;

        public int Successful
        {
            get => _successful;
            set => SetProperty(ref _successful, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public int Id
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(Id), 000001);
            set => Xamarin.Essentials.Preferences.Set(nameof(Id), value);
        }

        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public string Answer
        {
            get => _answer;
            set => SetProperty(ref _answer, value);
        }

        public int MaxLength
        {
            get => _maxLength;
            set => SetProperty(ref _maxLength, value);
        }

        public ICommand GoBackCommand { get; private set; }

        public int Points
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(Points), 0);
            set => Xamarin.Essentials.Preferences.Set(nameof(Points), value);
        }

        public ICommand SubmitCommand { get; private set; }
        public PlayGamePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoBackCommand = new AsyncCommand(ExcuteGoBackCommand);
            _random = new Random();
            SubmitCommand = new AsyncCommand(ExcuteSubmitCommand);
        }

        private Task ExcuteSubmitCommand()
        {
            return CheckAnswer(Answer);
        }

        private async Task CheckAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer) || _game == null) return;
            if (answer.ToUpper() == _game.Answer.ToUpper())
            {
                Successful = 2;
                Id = Id + 1;
                Points += _random.Next(10);
                RaisePropertyChanged(nameof(Points));
                await GetData();
            }
            else
            {
                Successful = 1;
            }
            Answer = "";
            await Task.Delay(TimeSpan.FromSeconds(3));
            Successful = 0;
        }
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsLoading = true;
            await GetData();
            IsLoading = false;
        }

        private async Task GetData()
        {
            _game = await GetQuestionHelper.Get(Id);
            Image = _game?.Image;
            MaxLength = _game.Answer.Length;
            Note = "Ghi chú\n" + "Độ dài của câu trả lời " + MaxLength + " kí tự";
        }

        private Task ExcuteGoBackCommand()
        {
            return NavigationService.GoBackAsync();
        }
    }
}
