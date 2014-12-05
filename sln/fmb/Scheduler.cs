using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace fmb
{
    class Scheduler   
    {
        private Queue<DisplayableMessageArguments> queue = new Queue<DisplayableMessageArguments>();
        private List<MessageRenderer> renderers = new List<MessageRenderer>();
        
        internal Queue<DisplayableMessageArguments> GetQueue() 
        { 
        	return queue; 
        }
        
        internal void Clear() {
        	queue.Clear(); 
        }
         
        internal void AddRenderer(MessageRenderer messageRenderer)
        {
            this.renderers.Add(messageRenderer);   
        }

        internal void add(DisplayableMessageArguments displayableMessage)
        {
            this.queue.Enqueue(displayableMessage);
        }

        internal MessageRenderer getRenderer(DisplayableMessageArguments msg)
        {
            foreach (MessageRenderer renderer in this.renderers)
            {  
                if (renderer == msg.getControl())
                { 
                    return renderer;
                }
            }
             
            Program.frmMain.messageRendererError1.renderError("Could not find renderer, it is not registered with the scheduler.");
            return Program.frmMain.messageRendererError1;
        }

        internal void Run()
        {
            if (queue.Count == 0)  
            {   
            	HtmlFormShowPresentation form = new HtmlFormShowPresentation();
            	form.Process(); 
            	
            	return;
            }
              
            DisplayableMessageArguments msg = queue.Dequeue();
            MessageRenderer renderer = this.getRenderer(msg);

            Program.frmMain.ShowSingleControl(renderer);
            renderer.render(msg);
            
            new System.Threading.Timer(timerExpired, renderer, msg.getTimespan(), TimeSpan.FromMilliseconds(-1));
        }
        
        internal void timerExpired(Object state) 
        { 
            if (Program.frmMain.getRenderer() == state) {
                Program.frmMain.getRenderer().OnTimerExpired(); 
                Run();
            } 
        }
    	
		public void Next()
		{
			Run(); 
		}
    }
}
 