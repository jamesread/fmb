using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace fmb
{ 
    class ServletStartup : Servlet
    {
        internal override void WriteResponse(HttpRequest req)
        {
            this.contentType = "text/html";
            this.WriteResponseHeader();

            this.WriteTemplateHeader("Startup");

            TplContent tpl = new TplContent(Resources.TplStartup);  
            tpl.Assign("DATADIR", Application.CommonAppDataPath.Replace("\\", "/"));
            tpl.Assign("PORT", HttpServer.port);  
             
            this.WriteTemplate(tpl); 
              
            this.WriteTemplateFooter();
        }

        internal override AccessLevel GetAccessLevel() {
            return AccessLevel.GUEST; 
        }
    }
}
