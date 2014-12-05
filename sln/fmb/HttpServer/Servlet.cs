using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace fmb
{
    abstract class Servlet
    {
        protected string contentType = "text/plain";
        public TextWriter output;
        internal HttpConnectionHandler connectionHandler;
        protected Dictionary<string, string> cookiesToSet = new Dictionary<string, string>();
        private bool headersSent = false;

        public Servlet(TextWriter output) 
        { 
            this.output = output;
        } 

        protected Servlet() { }

        internal void SetCookie(string cookieName, string cookieValue)
        {
            cookiesToSet[cookieName] = cookieValue;  
        }

        internal void WriteSetCookies()
        {
            StringBuilder cookieJar = new StringBuilder();

            foreach (string cookieName in this.cookiesToSet.Keys)
            {
                cookieJar.Append(cookieName + "=" + this.cookiesToSet[cookieName]);
            }

            if (cookieJar.ToString() != string.Empty)
            { 
                this.output.WriteLine("Set-Cookie: " + cookieJar.ToString() + "\n");
            } 
        }

        internal abstract void WriteResponse(HttpRequest req);

        internal void WriteResponseHeader() 
        {
            if (headersSent)
            {
                return;
            }
            else
            {
                headersSent = true;
            } 

            this.output.Write("HTTP/1.0 200\n");
            this.output.Write("Server: fmb\n");
            this.output.Write("Content-Type: " + this.contentType + "\n");
            this.output.Write("Connection: Close\n");
            
            // Internet Explorer agressively caches stuff, lets stop it.
            this.output.Write("Cache-Control: no-cache\n");
            this.output.Write("Pragma: no-cache\n");
            this.output.Write("Expires: -1\n");
				  
            this.WriteSetCookies();
            this.output.Write("\n");
            this.output.Flush();  
        }

        internal void WriteTemplateFooter()
        {
            TplContent tplContent = new TplContent(Resources.TplFooter);
            
            if (this.connectionHandler != null)
            {
                tplContent.Assign("ACCESS_LEVEL_REQUIRED", (int)this.GetAccessLevel());
                tplContent.Assign("ACCESS_LEVEL_OBTAINED", (int)this.connectionHandler.GetAuthenticatedAccessLevel());
            } 
            else    
            {
                tplContent.Assign("ACCESS_LEVEL_REQUIRED", "?");   
                tplContent.Assign("ACCESS_LEVEL_OBTAINED", "?");    
            }
                        
            tplContent.Assign("PROGRAM_VERSION", Program.getVersion());
            WriteTemplate(tplContent);  
        }  
         
        internal void WriteTemplateHeader(string pageTitle) 
        {
            this.WriteTemplateHeader(pageTitle, false); 
        }

        internal void WriteTemplateHeader(string pageTitle, bool includeNavigation)
        {
            TplContent header = new TplContent(Resources.TplHeader);

            if (includeNavigation)
            {    
                header.Assign("QUICK_NAV", new TplContent(Resources.TplNavigation).Content);
            }
            else
            {
                header.Assign("QUICK_NAV", string.Empty);
            }
   
            header.Assign("PAGE_TITLE", pageTitle);

            WriteTemplate(header);  
        }
        
        internal void WriteTemplate(TplContent tpl)
        {
            try {
                this.output.Write(tpl.Content);
            } catch (Exception e) {  
                Program.errors.Add(e.Message);
            } 
        }
         
        internal void FlushAndclose()
        {
            this.output.Flush();
            this.output.Close();
        }

        internal virtual AccessLevel GetAccessLevel()
        {
            return AccessLevel.MODERATOR; 
        }
    }
}
