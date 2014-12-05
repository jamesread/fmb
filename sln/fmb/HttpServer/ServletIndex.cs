using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletIndex : Servlet
    {
        internal override void WriteResponse(HttpRequest req)
        {
            req.GetCookies(); 

            this.contentType = "text/html";
            this.WriteResponseHeader();
            this.WriteTemplateHeader("Index", true); 
            this.output.WriteLine("<p>Welcome to the Flexible Message Board (fmb!)</p>");
            
            this.output.WriteLine("<h2>Queue</h2>");
             
            if (Program.scheduler.GetQueue().Count == 0) {
            	this.output.WriteLine("The queue is empty."); 
            } else {
	            foreach (DisplayableMessageArguments r in Program.scheduler.GetQueue()) {
            		this.output.WriteLine(r.getControl().ToString()); 
	            }
            }
 
            this.WriteTemplateFooter();
        } 

        internal override AccessLevel GetAccessLevel()
        {
            return AccessLevel.GUEST;
        }
    }
}
