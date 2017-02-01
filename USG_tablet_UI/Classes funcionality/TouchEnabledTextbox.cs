using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace USG_tablet_UI
{
    
    public class TouchEnabledTextBox : TextBox
    {
        public TouchEnabledTextBox()
        {
            this.GotTouchCapture += TouchEnabledTextBox_GotTouchCapture;
        }
 
        private void TouchEnabledTextBox_GotTouchCapture(object sender, System.Windows.Input.TouchEventArgs e)
        {
            string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";        
            Process.Start( touchKeyboardPath );
        }
    }
}
