using Prism.Navigation;
using System;
using System.Collections.Generic;
using XFCustomControl.Controls;
using XFCustomControl.Models;

namespace XFCustomControl.ViewModels
{
    public class DemoControlViewModel : ViewModelBase
    {
        private string _searchEntryDefaultText;
        public string SearchEntryDefaultText
        {
            get => _searchEntryDefaultText;
            set => SetProperty(ref _searchEntryDefaultText, value);
        }

        private List<PickerItem> _pickerItems;
        public List<PickerItem> PickerItems
        {
            get => _pickerItems;
            set => SetProperty(ref _pickerItems,value);
        }

        private PickerItem _selectedItem;

        public PickerItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        public DemoControlViewModel(INavigationService navigationService)
        {
            _searchEntryDefaultText = "Default value";

            _pickerItems = new List<PickerItem>
            {
                new PickerItem
                {
                    Name = "Option 1",
                    DisplayName = "Displayname of opt1",
                },
                new PickerItem
                {
                    Name = "Option 2",
                    DisplayName = "Displayname of opt2",
                }
            };
            _selectedItem = _pickerItems[0];
        }
    }
}
