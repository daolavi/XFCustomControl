using System;
using Xamarin.Forms.Platform.Android;
using XFCustomControl.Droid.Service;
using XFCustomControl.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomAlert))]
namespace XFCustomControl.Droid.Service
{
    public class CustomAlert : ICustomAlert
    {
        private const string FRAGMENT_TAG = "CustomAlert_Fragment";

        private CustomAlertDialogFragment _fragment;

        private static FormsAppCompatActivity _currentActivity;
        public static FormsAppCompatActivity CurrentActivity
        {
            set => _currentActivity = value;
        }

        public void Show(string title, string message, string cancelButton)
        {
            if (_currentActivity == null)
                throw new Exception("CustomAlert.CurrentActivity needs assigned");
            var fragMgr = _currentActivity.FragmentManager;
            var fragTransaction = fragMgr.BeginTransaction();
            var previous = fragMgr.FindFragmentByTag(FRAGMENT_TAG);
            if (previous != null)
            {
                fragTransaction.Remove(previous);
            }
            fragTransaction.DisallowAddToBackStack();
            _fragment = CustomAlertDialogFragment.Instance(_currentActivity, title, message, cancelButton);
            _fragment.Show(fragMgr, FRAGMENT_TAG);
        }

        public void Dismiss()
        {
            if (_fragment == null)
                throw new Exception("CustomAlert is not showing, call Show first");
            _fragment.Dismiss();
            _fragment.Dispose();
            _fragment = null;
        }
    }
}