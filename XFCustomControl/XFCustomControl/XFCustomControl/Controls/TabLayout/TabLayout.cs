using CarouselView.FormsPlugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XFCustomControl.Controls
{
    public class TabLayout : StackLayout
    {
        protected TabView _tabView;

        protected CarouselViewControl _carouselView;

        public event TabSelectionChangedEventHandler TabSelectionChanged;

        public static BindableProperty SelectedTabIndexProperty = BindableProperty.Create(nameof(SelectedTabIndex),
                                                                typeof(int),
                                                                typeof(TabLayout),
                                                                defaultValue: 0,
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var tabLayout = (TabLayout)bindable;
                                                                    var intOldVal = (int)oldVal;
                                                                    var intNewVal = (int)newval;
                                                                    if (intOldVal != intNewVal)
                                                                    {
                                                                        tabLayout._tabView.SelectedIndex = intNewVal;
                                                                        tabLayout.TabSelectionChanged?.Invoke(tabLayout, new TabSelectionChangedEventArgs() { Position = intNewVal });
                                                                    }
                                                                });
        public int SelectedTabIndex
        {
            get => (int)GetValue(SelectedTabIndexProperty);
            set => SetValue(SelectedTabIndexProperty, value);
        }


        public TabLayout()
        {
            Spacing = 0;
            Children.Add(_tabView = new TabView(this));
            Children.Add(_carouselView = new CarouselViewControl()
            {
                Orientation = CarouselViewOrientation.Horizontal,
                InterPageSpacing = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            });

            ItemsSource = new ObservableCollection<View>();
            ItemsSource.CollectionChanged += ItemsSource_CollectionChanged;

            _carouselView.PositionSelected += CarouselView_PositionSelected;
        }

        public ObservableCollection<View> ItemsSource { get; set; }

        public IEnumerable<Tab> Tabs
        {
            set
            {
                _tabView.Tabs = value;
                var index = 0;
                foreach (var tab in _tabView.Tabs)
                {
                    tab.Parent = _tabView;
                    tab.Index = index++;
                }
            }
        }

        private void CarouselView_PositionSelected(object sender, PositionSelectedEventArgs e)
        {
            _tabView.SelectedIndex = e.NewValue;
            SelectedTabIndex = _tabView.SelectedIndex;
            TabSelectionChanged?.Invoke(this, new TabSelectionChangedEventArgs() { Position = e.NewValue });
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var views = _carouselView.ItemsSource != null ? new List<View>(_carouselView.ItemsSource as List<View>) : new List<View>();
            views.Add(e.NewItems[0] as View);
            _carouselView.ItemsSource = views;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            foreach (var tab in _tabView.Tabs)
            {
                tab.BindingContext = BindingContext;
            }
        }

        public void OnTabSelectionChanged(int position)
        {
            _carouselView.Position = position;
        }
    }

    public class TabView : View
    {
        private TabLayout _parent;
        public TabView(TabLayout parent)
        {
            _parent = parent;
        }

        public IEnumerable<Tab> Tabs { get; set; }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public event EventHandler<Tab> TabChanged;

        public void OnTabSelectionChanged(int position)
        {
            _parent.OnTabSelectionChanged(position);
        }

        public void OnTabChanged(Tab tab)
        {
            TabChanged?.Invoke(this, tab);
        }
    }

    public class Tab : BindableObject
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Tab),
            string.Empty, propertyChanged: OnTextPropertyChanged);

        public Tab()
        {
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public TabView Parent { get; set; }
        public int Index { get; set; }

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tab = bindable as Tab;
            tab.Parent?.OnTabChanged(tab);
        }
    }

    public delegate void TabSelectionChangedEventHandler(object sender, TabSelectionChangedEventArgs e);

    public class TabSelectionChangedEventArgs : EventArgs
    {
        public int Position { get; set; }
    }
}
