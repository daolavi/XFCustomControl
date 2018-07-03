using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using static XFCustomControl.Controls.ToggleButton;

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

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public DelegateCommand<string> ItemTappedCommand { get; set; }

        private ToggleButtonState _toggleButtonState;
        public ToggleButtonState ToggleButtonState
        {
            get => _toggleButtonState;
            set
            {
                SetProperty(ref _toggleButtonState, value);
                IsExpanded = ToggleButtonState == ToggleButtonState.On ? true : false;
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        private bool _checkboxState;
        public bool CheckboxState
        {
            get => _checkboxState;
            set
            {
                SetProperty(ref _checkboxState, value);
            }
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
            SelectedTabIndex = 1;

            ItemTappedCommand = new DelegateCommand<string>(str =>
            {
                SelectedItem = str.ToUpper();
            });
        }
    }
}
