using System;
using Xamarin.Forms;
using XFCustomControl.Controls;

namespace XFCustomControl
{
    public class ContentPageBase : ContentPage
    {
        public static readonly BindableProperty FormattedTitleProperty = BindableProperty.Create(nameof(FormattedTitle), typeof(FormattedString), typeof(ContentPageBase), null);

        public FormattedString FormattedTitle
        {
            get { return (FormattedString)GetValue(FormattedTitleProperty); }
            set
            {
                SetValue(FormattedTitleProperty, value);
            }
        }

        public static readonly BindableProperty FormattedSubtitleProperty = BindableProperty.Create(nameof(FormattedSubtitle), typeof(FormattedString), typeof(ContentPageBase), null);

        public FormattedString FormattedSubtitle
        {
            get { return (FormattedString)GetValue(FormattedSubtitleProperty); }
            set
            {
                SetValue(FormattedSubtitleProperty, value);
            }
        }

        public static readonly BindableProperty SubtitleProperty = BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(ContentPageBase), null);

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set
            {
                SetValue(SubtitleProperty, value);
            }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null)
            {
                if (BindingContext is IDisposable)
                {
                    (BindingContext as IDisposable).Dispose();
                }
            }
        }

        protected void RemovePages(int fromPage, int numOfPages = 0)
        {
            numOfPages = numOfPages > 0 ? numOfPages : Navigation.NavigationStack.Count - fromPage;
            for (var count = 0; count < numOfPages; count++)
            {
                if (fromPage < Navigation.NavigationStack.Count)
                {
                    Navigation.RemovePage(Navigation.NavigationStack[fromPage]);
                }
            }
        }

        protected void RemovePagesBetween(Type fromPage, Type toPage)
        {
            int fromPageIndex = -1;
            int toPageIndex = -1;
            for (int i = 0; i < Navigation.NavigationStack.Count; i++)
            {
                if (Navigation.NavigationStack[i].GetType() == fromPage)
                {
                    fromPageIndex = i;
                }

                if (Navigation.NavigationStack[i].GetType() == toPage)
                {
                    toPageIndex = i;
                }
            }

            if (fromPageIndex > -1 && toPageIndex > -1)
            {
                RemovePages(fromPageIndex + 1, toPageIndex - fromPageIndex - 1);
            }
        }

        protected void GoBackToPage(Type type)
        {
            for (int i = Navigation.NavigationStack.Count - 1; i >= 0; i--)
            {
                if (Navigation.NavigationStack[i].GetType() == type)
                {
                    RemovePages(i + 1);
                    return;
                }
            }
        }
    }
}
