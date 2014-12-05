using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using fmb.HtmlForms;

namespace fmb
{  
    class HtmlFormShowPresentation : HtmlForm  
    {   
    	private TxtFile presentationStorage = new TxtFile(new FileInfo(Program.commonDataFile("presentation.txt")));
    	
        public HtmlFormShowPresentation()
        { 
            this.Title = "Setup presentation";
            
            presentationStorage.EnsureExists();   
            presentationStorage.Read();
             
            ElementTextarea elMessage = new ElementTextarea("presentation", "Presentation markup", presentationStorage.Get(), true);
            this.AddElement(elMessage).hasLabel = false;
              
            this.AddElement(new ElementHtml("dynamicSlideArea")).SetValue("<div id = \"dynamicSlideArea\" /><script type = \"text/javascript\" src = \"?servlet=ServletResource&amp;filename=presentationSlideEditor\"></script><script type = \"text/javascript\">loadInitialPresentation();</script>");
            this.AddElement(new ElementHtml("footerControls")).SetValue("<span class = \"fakeLink\" onclick = \"javascript:newSlide('')\">New Slide</span> <span class = \"fakeLink\" onclick = \"javascript:$('#presentation').toggle()\">Toggle advanced editor</span>");
             
            ElementNumber elDelay = new ElementNumber("defaultDelay", "Default slide delay (seconds)", 30); 
            this.AddElement(elDelay);

            this.AddElementSubmit().SetCaption("Save presentation"); 

            ElementHtml elHtml = new ElementHtml("description");
            TplContent tplElHelp = new TplContent(Resources.TplPresentationHelp);
            tplElHelp.Assign("SLIDESEP", MessageRendererPresentation.SLIDE_SEPARATOR);
            elHtml.SetValue(tplElHelp.Content);
            this.AddElement(elHtml); 
        }

        internal override void Process()
        {
            DisplayableMessageArguments dma = new DisplayableMessageArguments(Program.frmMain.messageRendererPresentation1);
             
            string message = this.getElementValue("presentation"); 
            
            presentationStorage.Set(message); 
            presentationStorage.Write(); 

            if (string.IsNullOrEmpty(message)) {
                dma.setArgument("message", MessageRendererPresentation.DEFAULT_PRESENTATION); 
            } else {  
                dma.setArgument("message", message); 
            }
              
            try {  
                dma.setArgument("defaultDelay", this.getElementValue("defaultDelay"));  
            } catch (Exception) 
            {  
            }

            Program.canShoutout = true; 
            Program.scheduler.add(dma);
            Program.scheduler.Run();
        }
    }
}
