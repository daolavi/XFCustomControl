using Prism.Navigation;
using System;
using System.Collections.Generic;
using XFCustomControl.Controls;

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

        private List<CustomPickerItem> _pickerItems;
        public List<CustomPickerItem> PickerItems
        {
            get => _pickerItems;
            set => SetProperty(ref _pickerItems,value);
        }

        private CustomPickerItem _selectedItem;

        public CustomPickerItem SelectedItem
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

            _pickerItems = new List<CustomPickerItem>
            {
                new CustomPickerItem
                {
                    Name = "Option 1",
                    DisplayName = "Displayname of opt1",
                },
                new CustomPickerItem
                {
                    Name = "Option 2",
                    DisplayName = "Displayname of opt2",
                }
            };
            _selectedItem = _pickerItems[0];
        }
    }
}
