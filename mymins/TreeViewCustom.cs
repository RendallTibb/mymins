using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mymins
{
    public class TreeViewCustom : TreeView
    {
        // Remove double-click because it doesn't register all AfterCheck events.
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203)
                m.Result = IntPtr.Zero;
            else
                base.WndProc(ref m);
        }
    }
}
