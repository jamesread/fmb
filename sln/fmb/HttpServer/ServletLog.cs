using System;

namespace fmb
{
	class ServletLog : Servlet
	{
		
		internal override void WriteResponse(HttpRequest req)
		{
			this.contentType = "text/html";
            this.WriteResponseHeader();
            this.WriteTemplateHeader("Log", true);
            
		    this.output.WriteLine("<h2>Log (mostly errors)</h2>");  
		    
            // the following nasty bit of code is a temporary measure. 
            // The Program.errors structure obviously needs to die, but at the moment it is simple and effective.
            this.output.WriteLine("<p>The following most recent errors have been caught (" + Program.errors.Count + " out of a maximum of 5): <br /></p>");
		    
            if (Program.errors.Count == 0) {  
            	output.WriteLine("There have been 0 errors (wow)!");
            } else {
	            this.output.WriteLine("<textarea readonly='true'>");
	            for (int i = 0; i < Math.Min(Program.errors.Count, 5); i++)
	            {
	                output.WriteLine(Program.errors[i] + "<br />");  
	            }  
	            this.output.WriteLine("</textarea>");
            }
		    
		    this.WriteTemplateFooter(); 
		}
		
		internal override AccessLevel GetAccessLevel()
		{
			return AccessLevel.ADMIN; 
		}
	}
}
