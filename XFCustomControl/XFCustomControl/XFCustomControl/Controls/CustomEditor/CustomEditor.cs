using Xamarin.Forms;

namespace XFCustomControl.Controls
{
    public class CustomEditor : Editor
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
                                                                                                typeof(string),
                                                                                                typeof(CustomEditor),
                                                                                                defaultValue: string.Empty);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public CustomEditor()
        {
        }
    }
}
