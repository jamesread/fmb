using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletError : Servlet
    {
        private Exception e;
         
        public ServletError(Exception e)
        {
            this.e = e;

            this.contentType = "text/html"; 
        }

        public void WriteResponseExceptionBasic()
        {
            HttpException httpee = (HttpException)e;
            this.WriteResponseHeader();
            this.WriteTemplateHeader("HTTP Status " + httpee.httpStatusCode);
            this.output.WriteLine(e.Message); 
            this.WriteTemplateFooter();
        }

        internal override void WriteResponse(HttpRequest req)
        {
            this.contentType = "text/html";

            try
            {
                if (e is HttpException)
                {
                    this.WriteResponseExceptionBasic();
                }
                else
                {
                    this.WriteResponseExceptionTemplated();
                }
            }
            catch (Exception e)
            { 
                Program.errors.Add(e.ToString()); 
            }
        }

        private void WriteResponseExceptionTemplated()
        {
            TplContent tpl = new TplContent(Resources.TplError);
            tpl.Assign("EXCEPTION", e.ToString());
            tpl.Assign("PROGRAM_VERSION", Program.getVersion());

            this.WriteResponseHeader();
            this.WriteTemplateHeader("fmb Error", false);
            this.WriteTemplate(tpl);
            this.WriteTemplateFooter();
        }
    }
}
