using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace fmb
{
    class ServletLibrary : Servlet
    {
        internal override void WriteResponse(HttpRequest req)
        {
            this.contentType = "text/html";
            this.WriteResponseHeader();
            this.WriteTemplateHeader("Library", true);

            TplContent tpl = new TplContent(Resources.TplLibrary);
            tpl.Assign("LIBSIZE", this.connectionHandler.server.library.Size());
            this.WriteTemplate(tpl);   

            // template doesnt support loops, yet.
            output.WriteLine("<ul>");
            foreach (FileInfo fi in connectionHandler.server.library.All()) {
                output.WriteLine("<li>" + fi.FullName + "</li>");
            }
            output.WriteLine("<ul>");

            this.WriteTemplateFooter();
        }
    }
}
