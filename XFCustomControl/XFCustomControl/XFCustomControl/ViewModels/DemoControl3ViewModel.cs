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

        public DemoControl3ViewModel(INavigationService navigationService)
        {
            LineBreakMode = LineBreakMode.WordWrap;
        }
    }
}
