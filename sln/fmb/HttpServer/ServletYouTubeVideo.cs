/*
 * Created by SharpDevelop.
 * User: xconspirisist
 * Date: 19/10/2013
 * Time: 16:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace fmb
{
	/// <summary>
	/// Description of ServletYouTubeVideo.
	/// </summary> 
	internal class ServletYouTubeVideo : Servlet
	{   
		internal override void WriteResponse(HttpRequest req)
		{
			this.contentType = "text/html"; 	
						
			try { 
				this.WriteResponseHeader();
				this.WriteTemplate(new TplContent(Resources.TplYouTube)); 
				this.output.Flush();
			} catch(Exception e ) { 
				Program.errors.Add(e.ToString()); 
			}  
		}
		
		internal override AccessLevel GetAccessLevel()
		{
			return AccessLevel.GUEST; 
		}
	}
}
 