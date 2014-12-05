using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class ServletPostponeShoutouts : Servlet
    {
        internal override void WriteResponse(HttpRequest req)
        {
            Program.canNextShoutout = Program.canNextShoutout.AddMinutes(10);
            this.output.WriteLine("Can next shoutout at: " + Program.canNextShoutout.ToString()); 
        }

        internal override AccessLevel GetAccessLevel()  
        {  
            return AccessLevel.ADMIN;    
        }
    }
}
