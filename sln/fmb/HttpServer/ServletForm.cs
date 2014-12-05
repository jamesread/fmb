using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletForm : Servlet
    {
        public static TypeSafeRawList<HtmlForm> forms = new TypeSafeRawList<HtmlForm>();

        internal override void WriteResponse(HttpRequest req)
        {
            if (!req.urlArguments.ContainsKey("form"))
            {   
                throw new HttpException(HttpException.OBJECT_NOT_FOUND, "Form not specified"); 
            }   

            HtmlForm f = forms.Find(req.urlArguments["form"]);
            this.CheckFormAccess(f); 

            f.Inject(this);
            f.action = string.Empty;
            f.AddElement(new ElementHidden("servlet", "Servlet", this.GetType().Name));
            f.AddElement(new ElementHidden("form", "Form", f.GetType().Name));  
            
            if (f.Validate(req.urlArguments))
            {
                f.Process();

                if (f.postProcessContent != null)
                { 
                    this.contentType = "text/html";
                    this.WriteResponseHeader(); 
                    this.WriteTemplateHeader("Login successful"); 
                    this.output.Write(f.postProcessContent); 
                    this.WriteTemplateFooter();
                     
                    return;
                }
            } 

            this.contentType = "text/html";
            this.WriteResponseHeader();
            this.WriteTemplateHeader("Form: " + f.Title, true);
            f.Render(this.output);

            this.WriteTemplateFooter();
        }

        internal void CheckFormAccess(HtmlForm f)
        {  
            if (this.connectionHandler.GetAuthenticatedAccessLevel() < f.GetAccessLevel())
            {
                throw new HttpException(HttpException.ACCESS_FORBIDDEN, "No access to this form. Are you <a href = \"?servlet=ServletForm&form=HtmlFormLogin\">logged in</a>? "); 
            }
        }

        internal override AccessLevel GetAccessLevel()
        {
            return AccessLevel.GUEST;
        }
    }
}
