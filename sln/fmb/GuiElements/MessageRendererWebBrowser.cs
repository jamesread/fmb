using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CefSharp.WinForms;

namespace fmb
{ 
    class MessageRendererWebBrowser : Control, MessageRenderer
    {
        public void render(DisplayableMessageArguments msg)
        {
            string url = msg.getArgument("url");
            //this.Url = new Uri(url); 
        }  

        public void reset()  
        {
            //this.Url = new Uri("about:blank"); 
        }

        public void OnTimerExpired() { }
    }
}
