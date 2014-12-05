using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using fmb.HtmlForms;

namespace fmb       
{
    class HtmlFormShowMedia : HtmlForm
    { 
        public HtmlFormShowMedia() 
        { 
            this.Title = "Play (local) media";  
            this.AddElement(new ElementHtml("Help Text"));   
            this.GetElement("Help Text").setHelpText("This form allows you to play a media file that is saved on the same machine that is running FMB. Media files can be video, music or a picture.");
            this.AddElement(new ElementTextbox("file", "Full path to media file")); 
            this.GetElement("file").setHelpText("eg: c:/My Videos/MyVideo.avi");
            this.AddElementSubmit();
        }

        internal override void Process()
        {
            string file = this.GetElement("file").getValue();
            FileInfo fi = new FileInfo(file);

            DisplayableMessageArguments dm = new DisplayableMessageArguments(Program.frmMain.messageRendererVideo1);
            dm.setArgument("url", fi.FullName);
            Program.scheduler.add(dm);
            Program.scheduler.Run(); 

            //SqlCeCommand query = new SqlCeCommand("SELECT * FROM library", Program.conn);
        }
    }
}
