using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SortSelector : ContentView
    {
        public static BindableProperty SelectedSortTypeProperty = BindableProperty.Create(nameof(SelectedSortType),
                                                                        typeof(SortType),
                                                                        typeof(SortSelector),
                                                                        defaultValue: SortType.Ascending,
                                                                        defaultBindingMode: BindingMode.TwoWay,
                                                                        propertyChanged: (bindable, oldVal, newval) =>
                                                                        {
                                                                            var sortSelector = (SortSelector)bindable;
                                                                            var sortType = (SortType)newval;
                                                                            if (sortType == SortType.Ascending)
                                                                            {
                                                                                sortSelector.UpArrow.IsVisible = false;
                                                                                sortSelector.UpArrowSolid.IsVisible = true;
                                                                                sortSelector.DownArrow.IsVisible = true;
                                                                                sortSelector.DownArrowSolid.IsVisible = false;
                                                                            }
                                                                            else
                                                                            {
                                                                                sortSelector.UpArrow.IsVisible = true;
                                                                                sortSelector.UpArrowSolid.IsVisible = false;
                                                                                sortSelector.DownArrow.IsVisible = false;
                                                                                sortSelector.DownArrowSolid.IsVisible = true;
                                                                            }

                                                                            sortSelector.OnChanged?.Invoke(sortSelector, sortType);
                                                                        });
        public SortType SelectedSortType
        {
            get => (SortType)GetValue(SelectedSortTypeProperty);
            set => SetValue(SelectedSortTypeProperty, value);
        }

        public event EventHandler<SortType> OnChanged;

        public SortSelector()
		{
            InitializeComponent();

            UpArrow.IsVisible = false;
            UpArrowSolid.IsVisible = true;
            DownArrow.IsVisible = true;
            DownArrowSolid.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            SelectedSortType = SelectedSortType == SortType.Ascending ? SortType.Descending : SortType.Ascending;
        }

        public enum SortType
        {
            Ascending,
            Descending,
        }
    }
}