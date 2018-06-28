using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControl.ViewModels
{
    public class DemoControl2ViewModel : ViewModelBase
    {
        private List<string> _itemSource1;
        public List<string> ItemSource1
        {
            get => _itemSource1;
            set => SetProperty(ref _itemSource1, value);
        }

        private List<string> _itemSource2;
        public List<string> ItemSource2
        {
            get => _itemSource2;
            set => SetProperty(ref _itemSource2, value);
        }

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set => SetProperty(ref _selectedTabIndex, value);
        }

        public DemoControl2ViewModel(INavigationService navigationService)
        {
            ItemSource1 = new List<string>
            {
                "Item1","Item2","Item3","Item4",
            };
            ItemSource2 = new List<string>
            {
                "Item5","Item6","Item7","Item8",
            };
        }
    }
}
