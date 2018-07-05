/**
 * Refer to: https://github.com/daolavi/Xamarin.Forms.Popup
 * */

using MWX.XamForms.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomControl.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopup : Popup
    {
        public static readonly BindableProperty NoteHeaderProperty = BindableProperty.Create(nameof(NoteHeader),
                                                                                               typeof(string),
                                                                                               typeof(CustomPopup),
                                                                                               defaultValue: string.Empty);

        public string NoteHeader
        {
            get => (string)GetValue(NoteHeaderProperty);
            set => SetValue(NoteHeaderProperty, value);
        }

        public static readonly BindableProperty NoteProperty = BindableProperty.Create(nameof(Note),
                                                                                        typeof(string),
                                                                                        typeof(CustomPopup),
                                                                                        defaultValue: string.Empty,
                                                                                        defaultBindingMode: BindingMode.TwoWay,
                                                                                        propertyChanged: (bindable, oldVal, newval) =>
                                                                                        {
                                                                                            var notePopup = (CustomPopup)bindable;
                                                                                            var note = newval == null ? string.Empty : (string)newval;
                                                                                            notePopup.LblCounter.Text = $"{note.Length}/{notePopup.MaxLength}";
                                                                                            notePopup.BtbSave.IsEnabled = (notePopup.MaxLength == 0 || note.Length <= notePopup.MaxLength);
                                                                                            notePopup.BtbSave.BackgroundColor = notePopup.BtbSave.IsEnabled ? Color.FromHex("#00153A") : Color.FromHex("#9E9E9E");
                                                                                        });

        public string Note
        {
            get => (string)GetValue(NoteProperty);
            set => SetValue(NoteProperty, value);
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
                                                                                                typeof(string),
                                                                                                typeof(CustomPopup),
                                                                                                defaultValue: string.Empty);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength),
                                                                                                typeof(int),
                                                                                                typeof(CustomPopup),
                                                                                                defaultValue: 0,
                                                                                                propertyChanged: (bindable, oldVal, newval) =>
                                                                                                {
                                                                                                    var notePopup = (CustomPopup)bindable;
                                                                                                    var maxlength = (int)newval;
                                                                                                    notePopup.LblCounter.IsVisible = maxlength > 0;
                                                                                                    var length = notePopup.Note == null ? 0 : notePopup.Note.Length;
                                                                                                    notePopup.LblCounter.Text = $"{length}/{maxlength}";
                                                                                                });

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand),
                                                                                                typeof(ICommand),
                                                                                                typeof(CustomPopup),
                                                                                                defaultValue: default(ICommand));

        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public static readonly BindableProperty SaveCommandProperty = BindableProperty.Create(nameof(SaveCommand),
                                                                                                typeof(ICommand),
                                                                                                typeof(CustomPopup),
                                                                                                defaultValue: default(ICommand));

        public ICommand SaveCommand
        {
            get => (ICommand)GetValue(SaveCommandProperty);
            set => SetValue(SaveCommandProperty, value);
        }

        public CustomPopup()
        {
            InitializeComponent();

            LblNoteHeader.BindingContext = this;

            EdtNote.BindingContext = this;

            LblCounter.BindingContext = this;
            LblCounter.IsVisible = false;

            BtbSave.BindingContext = this;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EdtNote.Unfocus();
            Hide();
            CloseCommand?.Execute(null);
        }

        private void BtbSave_Clicked(object sender, EventArgs e)
        {
            EdtNote.Unfocus();
            Hide();
            SaveCommand?.Execute(null);
        }
    }
}