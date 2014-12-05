using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    public class DisplayableMessageArguments 
    { 
        private Dictionary<string, string> arguments = new Dictionary<string, string>();
        private MessageRenderer mr;

        public DisplayableMessageArguments(MessageRenderer mr)
        {
            this.mr = mr;
        }

        public void setArgument(string key, string value)
        {
            this.arguments[key] = value;
        } 
        
        public void setTimespan(TimeSpan ts) 
        {
        	this.arguments["timespan"] = ts.ToString();
        }
        
        internal TimeSpan getTimespan() 
        { 
        	if (this.arguments.ContainsKey("timespan")) {
        		return TimeSpan.Parse(this.arguments["timespan"]); 
        	} else {
        		return TimeSpan.FromMilliseconds(-1); 
        	}
        }

        public string getArgument(string key)
        {
            if (arguments.ContainsKey(key)) {
                return this.arguments[key];
            } else { 
                return string.Empty;
            }
        }

        internal MessageRenderer getControl()
        {
            return this.mr;
        }
    }
}
