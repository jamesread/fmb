using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class HtmlFormShowTextMessage : HtmlForm
    { 
        public HtmlFormShowTextMessage()
        {
            this.Title = "Show text message";
            this.AddElement(new ElementTextarea("message", "Message", string.Empty)); 
            this.AddElement(new ElementTextbox("forecolor", "Forecolor", "white"));
            this.AddElement(new ElementTextbox("backcolor", "Backcolor", "black"));
            this.AddElement(new ElementTextbox("fontsize", "Font size", "32"));
            this.AddElement(new ElementTextbox("nextMessageTime", "Time in seconds till next message (0 for no timeout)", "10"));
            this.AddElementSubmit();
        }   
           
        internal override void Process()
        {
            DisplayableMessageArguments dma = new DisplayableMessageArguments(Program.frmMain.messageRendererError1);
            dma.setArgument("message", this.getElementValue("message"));
            dma.setArgument("forecolor", this.getElementValue("forecolor")); 
            dma.setArgument("backcolor", this.getElementValue("backcolor"));
            dma.setArgument("fontsize", this.getElementValue("fontsize"));
            
            int result = 0; 
            if (int.TryParse(this.getElementValue("nextMessageTime"), out result)) {
				if (result > 0) {
              		dma.setTimespan(new TimeSpan(0, 0, result)); 
            	}
            }
             
            Program.scheduler.add(dma);
            Program.scheduler.Run(); 
        }

    }
}
