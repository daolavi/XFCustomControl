using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageEntry : ContentView
    {

        #region TextColor
        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
                                                             typeof(Color),
                                                             typeof(ImageEntry),
                                                             defaultValue: Color.Black);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        #endregion

        #region PlaceHolderColor
        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor),
                                                             typeof(Color),
                                                             typeof(ImageEntry),
                                                             defaultValue: Color.FromHex("#A8A8A8"));

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }
        #endregion

        #region Text
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                        typeof(string),
                                                        typeof(ImageEntry),
                                                        defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        #endregion

        #region PlaceHolder
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
                                                            typeof(string), typeof(ImageEntry),
                                                            defaultBindingMode: BindingMode.TwoWay,
                                                            propertyChanged: (bindable, oldVal, newval) =>
                                                            {
                                                                var imageEntry = (ImageEntry)bindable;
                                                                imageEntry.Entry.Placeholder = (string)newval;
                                                            });
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        #endregion

        #region IsPassword
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword),
                                                            typeof(bool),
                                                            typeof(ImageEntry),
                                                            defaultValue: false,
                                                            propertyChanged: (bindable, oldVal, newVal) =>
                                                            {
                                                                var imageEntry = (ImageEntry)bindable;
                                                                imageEntry.Entry.IsPassword = (bool)newVal;

                                                            });
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        #endregion

        #region Keyboard
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard),
                                                            typeof(Keyboard),
                                                            typeof(ImageEntry),
                                                            defaultValue: Keyboard.Default,
                                                            propertyChanged: (bindable, oldVal, newVal) =>
                                                            {
                                                                var imageEntry = (ImageEntry)bindable;
                                                                imageEntry.Entry.Keyboard = (Keyboard)newVal;
                                                            });

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
        #endregion

        #region AccenColor
        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor),
                                                             typeof(Color),
                                                             typeof(ImageEntry),
                                                             defaultValue: Color.Accent);

        public Color AccentColor
        {
            get => (Color)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }
        #endregion

        #region LeftImage
        public static readonly BindableProperty LeftImageSourceProperty = BindableProperty.Create(nameof(LeftImageSource),
                                                                       typeof(ImageSource),
                                                                       typeof(ImageEntry),
                                                                       defaultBindingMode: BindingMode.TwoWay,
                                                                       propertyChanged: (bindable, oldVal, newVal) =>
                                                                       {
                                                                           var imageEntry = (ImageEntry)bindable;
                                                                           imageEntry.LeftImage.Source = (ImageSource)newVal;
                                                                       });

        public ImageSource LeftImageSource
        {
            get => (ImageSource)GetValue(LeftImageSourceProperty);
            set => SetValue(LeftImageSourceProperty, value);
        }

        public event EventHandler LeftImageClicked;

        public virtual void LeftImageOn_Clicked(object sender, EventArgs e)
        {
            LeftImageClicked?.Invoke(sender, e);
        }
        #endregion

        #region RightImage
        public static readonly BindableProperty RightImageSourceProperty = BindableProperty.Create(nameof(RightImageSource),
                                                                       typeof(ImageSource),
                                                                       typeof(ImageEntry),
                                                                       defaultBindingMode: BindingMode.TwoWay,
                                                                       propertyChanged: (bindable, oldVal, newVal) =>
                                                                       {
                                                                           var imageEntry = (ImageEntry)bindable;
                                                                           imageEntry.RightImage.Source = (ImageSource)newVal;
                                                                       });

        public ImageSource RightImageSource
        {
            get => (ImageSource)GetValue(RightImageSourceProperty);
            set => SetValue(RightImageSourceProperty, value);
        }

        public event EventHandler RightImageClicked;

        public virtual void RightImageOn_Clicked(object sender, EventArgs e)
        {
            RightImageClicked?.Invoke(sender, e);
        }
        #endregion

        #region ImageAlignment
        public static readonly BindableProperty ImageAlignmentProperty = BindableProperty.Create(nameof(ImageAlignment),
                                                                         typeof(ImageEntryAlignment),
                                                                         typeof(ImageEntry),
                                                                         defaultValue: ImageEntryAlignment.None,
                                                                         propertyChanged: OnImageAlignmentChanged);

        public ImageEntryAlignment ImageAlignment
        {
            get => (ImageEntryAlignment)GetValue(ImageAlignmentProperty);
            set => SetValue(ImageAlignmentProperty, value);
        }

        private static void OnImageAlignmentChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = bindable as ImageEntry;
            switch (control.ImageAlignment)
            {
                case ImageEntryAlignment.None:
                    control.LeftImage.IsVisible = false;
                    control.RightImage.IsVisible = false;
                    break;
                case ImageEntryAlignment.Left:
                    control.LeftImage.IsVisible = true;
                    control.RightImage.IsVisible = false;
                    break;
                case ImageEntryAlignment.Right:
                    control.LeftImage.IsVisible = false;
                    control.RightImage.IsVisible = true;
                    break;
                case ImageEntryAlignment.Both:
                    control.LeftImage.IsVisible = true;
                    control.RightImage.IsVisible = true;
                    break;
            }
        }
        #endregion


        public ImageEntry()
        {
            InitializeComponent();

            Entry.BindingContext = this;

            RightImage.ImageClicked += RightImageOn_Clicked;
            LeftImage.ImageClicked += LeftImageOn_Clicked;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry.Text))
            {
                Entry.Placeholder = Placeholder;
            }
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            BottomBorder.HeightRequest = 1.5;
            BottomBorder.BackgroundColor = AccentColor;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            BottomBorder.HeightRequest = 1;
            BottomBorder.BackgroundColor = Color.Gray;
        }

        public enum ImageEntryAlignment
        {
            None,
            Left,
            Right,
            Both
        }
    }
}