using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    interface IInfoView
    {
        Control Scene { get; }
        event Action BackClicked;
        event Action ShowAllClicked;
        event Action<int> FindByIdClicked;
        event Action<string> FindByDestinationClicked;
    }
}
