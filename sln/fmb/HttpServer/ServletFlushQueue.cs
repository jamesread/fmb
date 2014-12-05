/*
 * Created by SharpDevelop.
 * User: xconspirisist
 * Date: 18/10/2013
 * Time: 20:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace fmb
{ 
	class ServletFlushQueue : Servlet {
		internal override void WriteResponse(HttpRequest req)
		{ 
			Program.scheduler.Clear();
			this.output.WriteLine("<p>The queue has been flushed.</p>");
		}
		
		internal override AccessLevel GetAccessLevel()
		{
		    return AccessLevel.ADMIN;
		}
	}
}
