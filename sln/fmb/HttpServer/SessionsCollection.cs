using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fmb
{
	class SessionsCollection : IniFile
    {
        public SessionsCollection() : base (new FileInfo(Path.Combine(Application.CommonAppDataPath, "httpSessions.ini")))
        { 
        	this.EnsureExists();
            this.ReadFromDisk();
        }
        
        public void Write() {
        	this.WriteToDisk();
        }
         
        internal void InsertNewSessionImpl(string newSessionId, AccessLevel al)
        { 
        	this.cache[newSessionId] = al.ToString();
        } 

        internal void InsertNewSession(string newSessionId)
        {
            this.InsertNewSessionImpl(newSessionId, AccessLevel.GUEST);
        } 
  
        internal Session SelectSession(string sessionId)
        { 
            if (this.cache.ContainsKey(sessionId))
            { 
            	AccessLevel al = (AccessLevel) AccessLevel.Parse(typeof(AccessLevel), this.cache[sessionId]);
                return new Session(sessionId, al); 
            }
            else  
            {
                return new Session();
            } 
        }

        internal void UpdateAccessLevel(string p, AccessLevel accessLevel)
        { 
        	this.cache[p] = accessLevel.ToString();
        }
		
		public void Load()
		{
			this.ReadFromDisk();
		}
    }  
}
