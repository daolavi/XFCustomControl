using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;

namespace XFCustomControl.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDisposable
    {
        public ViewModelBase()
        {
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
