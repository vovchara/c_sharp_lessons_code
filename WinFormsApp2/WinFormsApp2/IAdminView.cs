using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    interface IAdminView
    {
        event Action<string, string> OkClicked;
        event Action BackClicked;
        void ShowPassIncorrect(string errorText);
        Control GetScene { get; }
    }
}
