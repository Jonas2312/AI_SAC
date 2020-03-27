using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_SAC.AutoCompletion.Model.HookFeed
{
    public class KeyData
    {
        public Keys key;
        public bool shiftPressed;
        public bool ctrlPressed;

        public KeyData(Keys key, bool shiftPressed, bool ctrlPressed)
        {
            this.key = key;
            this.shiftPressed = shiftPressed;
            this.ctrlPressed = ctrlPressed;
        }
    }
}
