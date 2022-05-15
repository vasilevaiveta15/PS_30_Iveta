using System.Collections.ObjectModel;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class ToLowerPresenter : Presenter
    {
        public ToLowerPresenter(ObservableCollection<string> history) : base("Lower", history,
            new TextConverter(s => s.Trim().ToLower()))
        {
        }
    }
}