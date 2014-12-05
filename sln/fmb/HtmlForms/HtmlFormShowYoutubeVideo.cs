/*
 * Created by SharpDevelop.
 * User: root
 * Date: 09/05/2012
 * Time: 22:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using fmb.HtmlForms.FormElements;

namespace fmb.HtmlForms
{
	/// <summary>
	/// Description of HtmlFormShowYoutubeVideo.
	/// </summary>
	internal class HtmlFormShowYoutubeVideo : HtmlForm
	{
        private readonly HtmlFormElement ElUri; 
				        
		public HtmlFormShowYoutubeVideo()
		{
            this.Title = "Show Youtube video";
            this.ElUri = this.AddElement(new ElementTextbox("videoId", "YouTube Video ID")); 
            this.GetElement("videoId").setHelpText("The v=... that is in the YouTube video URL. eg: https://www.youtube.com/watch?v=<strong>r7d5XheWiBk</strong>");
            this.AddElement(new ElementCheckbox("autoplay", "Autoplay", "autoplay"));
            this.AddElement(new ElementNumber("start", "Seek to", 1));
            this.GetElement("start").setHelpText("The number of seconds from the start to begin playing the video");
            this.AddElementSubmit();
        }   

        internal override AccessLevel GetAccessLevel()
        { 
            return AccessLevel.ADMIN;   
        }
		
        internal override void Inject(ServletForm servletForm)
        {
            this.frmMain = Program.frmMain; 
        }

        internal override void Process() 
        {
        	string uri = "http://youtube.com/v/" + this.getElementValue("videoId") + "?version=3";
        	
        	ElementCheckbox chk = (ElementCheckbox) this.GetElement("autoplay");
        	if (chk.isChecked()) {
        		uri += "&autoplay=1"; 
        	} 
        	
        	if (!string.IsNullOrEmpty(this.getElementValue("start"))) {
        		uri += "&start=" + this.getElementValue("start");
        	}
        	
        	DisplayableMessageArguments dma = new DisplayableMessageArguments(this.frmMain.messageRendererWebBrowser); 
        	dma.setArgument("url", "http://localhost:" + Program.settings.PORT+ "/?servlet=ServletYouTubeVideo&videoId=" + this.getElementValue("videoId"));
        	  
        	Program.scheduler.add(dma);
        	
			if (Program.scheduler != null) {
                Program.canShoutout = false; 
        		Program.scheduler.Run();
			}
        }
	}
}
