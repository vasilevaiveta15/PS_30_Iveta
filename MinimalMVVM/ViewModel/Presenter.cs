using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public abstract class Presenter : ObservableObject
    {
        private readonly TextConverter _textConverter;
        private string _someText;
        private readonly string _name;
        private readonly ObservableCollection<string> _history;

        protected Presenter(string name, ObservableCollection<string> history, TextConverter converter)
        {
            _name = name;
            _history = history;
            _textConverter = converter;
        }

        public string SomeText
        {
            get => _someText;
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }
        
        public ICommand ConvertTextCommand => new DelegateCommand(ConvertText);
        public string Name => _name;
        public ObservableCollection<string> History => _history;

        private void ConvertText()
        {
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}