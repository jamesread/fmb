using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace fmb
{
    class TplContent
    {
        string content; 

        public TplContent(string content)
        {
            this.content = content;
        }

        public void Assign(string variableName, Object value)
        {
            if (value == null)
            {
                value = "NULL";
            }

            string variableSearch = "{$" + variableName + "}";
            this.content = this.content.Replace(variableSearch, value.ToString());
        }

        public string Content
        {
            get
            {
                string processed;

                Regex r = new Regex(@"{if:([$\w]+)}(.+){/if}");
                MatchCollection mc = r.Matches(content);

                if (mc.Count > 2)
                { 
                    processed = r.Replace(content, mc[2].Value);
                }
                else 
                {
                    processed = r.Replace(content, "");
                }
                
                return processed;
            }
        } 


    }
}
