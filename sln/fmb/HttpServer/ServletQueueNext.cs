using System;

namespace fmb
{
	class ServletQueueNext : Servlet
	{
		public ServletQueueNext()
		{
			Program.scheduler.Next(); 
		}
		
		internal override void WriteResponse(HttpRequest req)
		{
			this.output.WriteLine("Next...");
		}
		
		internal override AccessLevel GetAccessLevel()
		{
			return AccessLevel.GUEST; 
		}
	}
}
