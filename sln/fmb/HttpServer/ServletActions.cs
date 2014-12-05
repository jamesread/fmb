using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletActions : Servlet
    {
        internal override void WriteResponse(HttpRequest req)
        {
            this.contentType = "text/html";
            this.WriteResponseHeader();
            this.WriteTemplateHeader("Actions", true);
            this.WriteTemplate(new TplContent(Resources.TplActions));
            this.WriteTemplateFooter(); 
        }

        internal override AccessLevel GetAccessLevel()
        {
            return AccessLevel.GUEST;
        }
    }
}
