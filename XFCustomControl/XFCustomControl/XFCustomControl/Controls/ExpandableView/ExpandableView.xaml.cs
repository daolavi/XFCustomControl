using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpandableView : ContentView
	{
        public static BindableProperty IsExpandedProperty = BindableProperty.Create(nameof(IsExpanded),
                                                                typeof(bool),
                                                                typeof(ExpandableView),
                                                                defaultValue: false,
                                                                defaultBindingMode: BindingMode.TwoWay,
                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                {
                                                                    var expandableView = (ExpandableView)bindable;
                                                                    var isExpanded = (bool)newval;
                                                                    if (isExpanded)
                                                                    {
                                                                        expandableView.ExpandableSource.IsVisible = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        expandableView.ExpandableSource.IsVisible = false;
                                                                    }
                                                                });

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public ObservableCollection<View> FixedViewSource { get; set; }

        public ObservableCollection<View> ExpandableViewSource { get; set; }

        public ExpandableView ()
		{
			InitializeComponent ();
            FixedViewSource = new ObservableCollection<View>();
            FixedViewSource.CollectionChanged += FixedViewSource_CollectionChanged;
            ExpandableViewSource = new ObservableCollection<View>();
            ExpandableViewSource.CollectionChanged += ExpandableViewSource_CollectionChanged;
        }

        private void ExpandableViewSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var view = e.NewItems[0] as View;
            ExpandableSource.Children.Add(view);
        }

        private void FixedViewSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var view = e.NewItems[0] as View;
            FixedSource.Children.Add(view);
        }
    }
}