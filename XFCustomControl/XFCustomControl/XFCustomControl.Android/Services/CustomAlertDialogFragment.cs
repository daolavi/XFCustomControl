using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;

namespace XFCustomControl.Droid.Service
{
    public class CustomAlertDialogFragment : DialogFragment
    {
        AlertDialog alertDialog;
        readonly Context context;

        public static CustomAlertDialogFragment Instance(Context context, string title, string message, string cancelButton)
        {
            var fragment = new CustomAlertDialogFragment(context);
            var bundle = new Bundle();
            bundle.PutString("title", title);
            bundle.PutString("message", message);
            bundle.PutString("cancelButton", cancelButton);
            fragment.Arguments = bundle;
            return fragment;
        }

        public CustomAlertDialogFragment(Context context)
        {
            this.context = context;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var title = Arguments.GetString("title");
            var message = Arguments.GetString("message");
            var htmlMessage = Html.FromHtml(message);
            var cancelButton = Arguments.GetString("cancelButton");
            alertDialog = new AlertDialog.Builder(context)
                        .SetTitle(title)
                        .SetMessage(htmlMessage)
                        .SetNegativeButton(cancelButton, (senderAlert, args) => {})
                        .Create();
            return alertDialog;
        }
    }
}