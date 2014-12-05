using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletShowSessions : Servlet
    { 
        internal override void WriteResponse(HttpRequest req)
        {
            this.WriteResponseHeader(); 
            this.WriteTemplateHeader("Sessions");
            this.WriteTemplateFooter(); 
        }
    }
}
