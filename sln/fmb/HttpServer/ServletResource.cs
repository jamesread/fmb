using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletResource : Servlet
    {
        internal override void WriteResponse(HttpRequest req)
        {
            if (!req.urlArguments.ContainsKey("filename"))
            {
                throw new HttpException(404);
            }

            string filename = req.urlArguments["filename"];
            string resourceContent = Resources.ResourceManager.GetString(filename);

            this.output.Write(resourceContent);  
        }

        internal override AccessLevel GetAccessLevel()
        {
            return AccessLevel.GUEST;
        }
    }
}
