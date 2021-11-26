using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    interface IWelcomeView
    {
        event Action WestClicked;
        event Action CentralClicked;
        event Action AdminClicked;
        Control GetScene { get; }
    }
}
