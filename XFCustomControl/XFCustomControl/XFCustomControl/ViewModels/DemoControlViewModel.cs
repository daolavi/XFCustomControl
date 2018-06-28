using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XFCustomControl.Controls;
using XFCustomControl.Models;
using static XFCustomControl.Controls.SortSelector;

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

        private SortType _sortType;
        public SortType SortType
        {
            get => _sortType;
            set => SetProperty(ref _sortType, value);
        }

        public ICommand RefreshCommand => new Command(() =>
                                                        {
                                                            IsListViewRefreshing = true;

                                                            Console.WriteLine("Refreshing data");

                                                            IsListViewRefreshing = false;
                                                        });

        private bool _isListViewRefreshing;
        public bool IsListViewRefreshing
        {
            get => _isListViewRefreshing;
            set => SetProperty(ref _isListViewRefreshing, value);
        }

        private List<string> _listViewItems;
        public List<string> ListViewItems
        {
            get => _listViewItems;
            set => SetProperty(ref _listViewItems, value);
        }

        private Dictionary<int, string> _radioGroup;
        public Dictionary<int, string> RadioGroup
        {
            get => _radioGroup;
            set => SetProperty(ref _radioGroup, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                SetProperty(ref _selectedIndex, value);
                SelectedRadioButton = _radioGroup[_selectedIndex];
            }
        }

        private string _selectedRadioButton;
        public string SelectedRadioButton
        {
            get => _selectedRadioButton;
            set => SetProperty(ref _selectedRadioButton, value);
        }

        public DelegateCommand NextScreenCommand { get; set; }

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
            _sortType = SortType.Descending;
            _listViewItems = new List<string>
            {
                "Item1","Item2","Item3","Item4","Item5","Item6","Item7","Item8",
            };

            _radioGroup = new Dictionary<int, string>();
            for (int i = 0; i < 3; i++)
            {
                _radioGroup.Add(i, "Option " + i);
            }
            _selectedIndex = 1;

            NextScreenCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("DemoControl2View");
            });
        }
    }
}
