using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    class Session  
    {
        private string sessionId;
        private AccessLevel accessLevel;
         
        public Session(string sessionId, AccessLevel userLevel)
        {
            this.sessionId = sessionId;
            this.accessLevel = userLevel; 
        }

        public Session() : this(string.Empty, (int) AccessLevel.GUEST) { }

        internal AccessLevel GetAccessLevel()
        {
            return this.accessLevel;
        }
    }
}
