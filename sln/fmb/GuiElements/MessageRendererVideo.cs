using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fmb
{
    internal partial class MessageRendererVideo : UserControl, MessageRenderer
    {
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Label label1;

        public MessageRendererVideo() {
            this.InitializeComponent(); 
        }

        public void reset()
        {
            this.axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        public void render(DisplayableMessageArguments msg)
        {
            this.axWindowsMediaPlayer1.URL = msg.getArgument("url");
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
            this.axWindowsMediaPlayer1.uiMode = "none";
        }

        public void OnTimerExpired() { }
    }
}
