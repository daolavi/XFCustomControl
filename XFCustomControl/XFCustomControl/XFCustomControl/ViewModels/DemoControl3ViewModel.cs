﻿using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using XFCustomControl.Services;

namespace XFCustomControl.ViewModels
{
    public class DemoControl3ViewModel : ViewModelBase
    {
        private bool _isTailTruncate;
        public bool IsTailTruncate
        {
            get => _isTailTruncate;
            set
            {
                SetProperty(ref _isTailTruncate, value);
                LineBreakMode = _isTailTruncate ? LineBreakMode.TailTruncation : LineBreakMode.WordWrap;
            }
        }

        private LineBreakMode _lineBreakMode;
        public LineBreakMode LineBreakMode
        {
            get => _lineBreakMode;
            set => SetProperty(ref _lineBreakMode, value);
        }

        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        private string _displayNote;
        public string DisplayNote
        {
            get => _displayNote;
            set => SetProperty(ref _displayNote, value);
        }

        public DelegateCommand SaveNoteCommand { get; set; }

        public DelegateCommand DisplayAlertCommand { get; set; }

        public DelegateCommand DisplayCustomAlertCommand { get; set; }

        private ICustomAlert _customAlert;

        public DemoControl3ViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _customAlert = Xamarin.Forms.DependencyService.Get<ICustomAlert>();

            LineBreakMode = LineBreakMode.WordWrap;

            SaveNoteCommand = new DelegateCommand(() =>
            {
                DisplayNote = Note;
            });

            DisplayAlertCommand = new DelegateCommand(async () =>
            {
                await pageDialogService.DisplayAlertAsync("Info", "Made <b>by me</b>", "DISMISS");
            });

            DisplayCustomAlertCommand = new DelegateCommand(() =>
            {
                _customAlert.Show("Info", "Made <b>by me</b>", "DISMISS");
            });
        }
    }
}
