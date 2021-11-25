using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    interface IMainView
    {
        event Action InfoClicked;
        event Action AdminClicked;
        Control Scene { get; }
    }
}
