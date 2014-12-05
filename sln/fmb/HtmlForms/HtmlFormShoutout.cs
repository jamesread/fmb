using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class HtmlFormShoutout : HtmlForm
    {   
        public HtmlFormShoutout()
        {
            this.Title = "Shoutout";
            this.AddElement(new ElementTextarea("message", "Message", string.Empty)); 
            this.AddElementSubmit("Shoutout!");

            if (DateTime.Now < Program.canNextShoutout)
            {
                this.GetElement("message").validationError = "Shoutouts disabled because of spamming for " + Math.Round((Program.canNextShoutout - DateTime.Now).TotalSeconds) + " more seconds";
            }
        }       
        
        protected override void ValidateInternals() 
		{
        	string shoutout = this.getElementValue("message").Trim();
        	
        	if (String.IsNullOrEmpty(shoutout)) {
        		this.GetElement("message").validationError = "Shoutout is empty.";
        	}
        	
        	if (shoutout.Length > 120) {
        		this.GetElement("message").validationError = "Message too long."; 
        	}

            if (!Program.canShoutout)
            {
                this.GetElement("message").validationError = "Can't shoutout right now, something else is on the projector.";
            }

		}  
              
        internal override void Process()
        {
            DisplayableMessageArguments dma = new DisplayableMessageArguments(Program.frmMain.messageRendererError1);
            dma.setArgument("message", "Shoutout: " + this.getElementValue("message"));
            dma.setArgument("forecolor", "black"); 
            dma.setArgument("backcolor", "yellow");  
            dma.setArgument("fontsize", "40"); 
            dma.setTimespan(TimeSpan.FromSeconds(40));

            Program.canShoutout = false; 
              
            Program.scheduler.add(dma);  
            Program.scheduler.Run(); 
        }
        
		internal override AccessLevel GetAccessLevel()
		{
			return AccessLevel.GUEST;
		}
    }  
}
