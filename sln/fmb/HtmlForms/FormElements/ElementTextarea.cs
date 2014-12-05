using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb 
{
    class ElementTextarea : HtmlFormElement
    {
        internal bool readOnly;

        internal ElementTextarea(string name, string caption, string defaultValue) : this(name, caption, defaultValue, false) { }

        internal ElementTextarea(string name, string caption, string defaultValue, bool ro) : base(name, caption, defaultValue) {
            this.readOnly = ro;
        }
         
        internal override void Validate()
        {
             
        }

        internal override void render(System.IO.TextWriter output)
        {    

            if (this.readOnly)
            {
                output.WriteLine("<br /><textarea rows = '10' cols = '80' style = \"display: none\" id = \"" + this.name + "\" name = \"" + this.name + "\">" + this.value + "</textarea><br />");
            }
            else 
            {
                output.WriteLine("<br /><textarea " + readOnly + " rows = '20' cols = '80' id = \"" + this.name + "\" name = \"" + this.name + "\">" + this.value + "</textarea><br />");
            }
        }
    }
}
