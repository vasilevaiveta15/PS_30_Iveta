using System.Collections.ObjectModel;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class ToUpperPresenter : Presenter
    {
        public ToUpperPresenter(ObservableCollection<string> history) : base("Upper", history,
            new TextConverter(s => s.Trim().ToUpper()))
        {
        }
    }
}
