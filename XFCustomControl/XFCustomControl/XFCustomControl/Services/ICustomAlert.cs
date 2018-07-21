using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControl.Services
{
    public interface ICustomAlert
    {
        void Show(string title, string message, string cancelButton);

        void Dismiss();
    }
}
