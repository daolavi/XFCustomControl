using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace XFCustomControl.ViewModels
{
    public class DemoControl3ViewModel : ViewModelBase
    {
        private bool _isTailTruncate;
        public bool IsTailTruncate
        {
            get => _isTailTruncate;
            set
            {
                SetProperty(ref _isTailTruncate, value);
                LineBreakMode = _isTailTruncate ? LineBreakMode.TailTruncation : LineBreakMode.WordWrap;
            }
        }

        private LineBreakMode _lineBreakMode;
        public LineBreakMode LineBreakMode
        {
            get => _lineBreakMode;
            set => SetProperty(ref _lineBreakMode, value);
        }

        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        private string _displayNote;
        public string DisplayNote
        {
            get => _displayNote;
            set => SetProperty(ref _displayNote, value);
        }

        public DelegateCommand SaveNoteCommand { get; set; }

        public DemoControl3ViewModel(INavigationService navigationService)
        {
            LineBreakMode = LineBreakMode.WordWrap;

            SaveNoteCommand = new DelegateCommand(() =>
            {
                DisplayNote = Note;
            });
        }
    }
}
